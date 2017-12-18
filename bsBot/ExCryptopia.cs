using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Net.Http.Formatting;

namespace bsBot
{
    class ExCryptopia : Exchange
    {
        struct postObj
        {
           public string Market;
           public string Type;
           public string Rate;
           public string Amount;
        }
        public ExCryptopia()
        {
            Name = "cryptopia.co.nz";
            publicAPI = "https://www.cryptopia.co.nz/Api/";
            tradeAPI = "https://www.cryptopia.co.nz/Api/";
            min_rate = new Dictionary<string, double>();
            WebRequest.DefaultWebProxy = null;
            //key abae36b2f2954405aea5505b99b4c000 secret dgWT333d6TfRslCO4BlYow7xq9ytW7zV/Xd3xniAc1w=
        }
        public override Dictionary<string, double> GetBalance(string pair, int nonce) //private
        {
            string resp = Response("GetBalance", new { Currency = pair }, nonce);
            CryptopiaAccountInfo cAccInfo = JsonConvert.DeserializeObject<CryptopiaAccountInfo>(resp);
            var res = new Dictionary<string, double>();
            cAccInfo.Data.ForEach(d =>
            {
                res.Add(d.Symbol, d.Total);
            });
            return res;
        }

        public override void GetMarkets()
        {
            string command = "GetTradePairs";
            CryptopiaInfo cInfo = JsonConvert.DeserializeObject<CryptopiaInfo>(new WebClient().DownloadString(publicAPI + command));
            AvailableMarkets = new List<string>();
            cInfo.Data.ForEach(p =>
            {
                AvailableMarkets.Add(p.Label.Replace("/", "_"));
                min_rate[AvailableMarkets.Last()] = p.MinimumPrice;
            });
            AvailableMarkets.Sort();
        }

        public override void GetPrice(string market)
        {
            string command = string.Empty;
            string resp = string.Empty;

            command = "GetMarketOrders/" + market + "/1";
            resp = new WebClient().DownloadString(publicAPI + command);
            if (resp.Contains("not found"))
            {
                return;
            }
            resp = resp.Replace("[","");
            resp = resp.Replace("]", "");
            resp = resp.Trim('{', '}');
            resp = resp.Remove(0, resp.IndexOf("{"));
            resp = resp.Remove(resp.LastIndexOf("}") + 1, resp.Length - resp.LastIndexOf("}") - 1);

            CryptopiaPrice pr = JsonConvert.DeserializeObject<CryptopiaPrice>(resp);

            if (!pr.Equals(null))
            {
                Price p = new Price();
                p.ask = pr.Sell.Price;
                p.bid = pr.Buy.Price;
                price = p;
            }
        }

        public override string Trade(TypeOrder type, string pair, double rate, double amount, int nonce)
        {
            string resp = Response("SubmitTrade", new postObj() {
                Market = pair,
                Type = type.ToString(),
                Rate = rate.ToString("F8", CultureInfo.InvariantCulture),
                Amount = amount.ToString("F8", CultureInfo.InvariantCulture)
            }, nonce);

            if (resp.Contains("false"))
            {
                return DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " " + resp + "\n";
            }
            CryptopiaTradeInfo info = JsonConvert.DeserializeObject<CryptopiaTradeInfo>(resp);
            //curBalance = info.returnInfo.funds_incl_orders;

            return DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " Order Type: " + type.ToString() + " Order ID: " + info.Data.OrderId
                + " Price: " + rate.ToString("F8", CultureInfo.InvariantCulture)  + "\n";
        } //private

        protected string Response(string method, object postObj, int nonce)
        {
            string jsonResponse = string.Empty;

            string postData = JsonConvert.SerializeObject(postObj);

            // Authentication
            string requestContentBase64String = string.Empty;
            byte[] inputBytes = Encoding.UTF8.GetBytes(postData);
            // Hash content to ensure message integrity
            using (var md5 = MD5.Create())
            {
                requestContentBase64String = Convert.ToBase64String(md5.ComputeHash(inputBytes));
            }

            // Create Request
            var request = (HttpWebRequest)WebRequest.Create(tradeAPI + method);
            request.Method = "POST";
            request.Timeout = 20000;
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = inputBytes.Length;
            request.Proxy = null;

            //Creating the raw signature string
            var signature = Encoding.UTF8.GetBytes(string.Concat(Key, "POST", HttpUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower()), nonce, requestContentBase64String));
            using (var hmac = new HMACSHA256(Convert.FromBase64String(Secret)))
            {
                request.Headers.Add("Authorization", string.Format("amx {0}:{1}:{2}", Key, Convert.ToBase64String(hmac.ComputeHash(signature)), nonce));
            }

            // Send Request
            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(inputBytes, 0, postData.Length);
            }
            using (System.IO.Stream s = request.GetResponse().GetResponseStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                {
                    jsonResponse = sr.ReadToEnd();
                }
            }
            return jsonResponse;
        }
    }
}
