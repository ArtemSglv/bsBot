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
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace bsBot
{
    class ExStocksExchange : Exchange
    {
        //key: FQ0qfb60HEAIx03RPxNGL4RTlVmEhOZtTFoTsiYo
        //secret: XDSU9ivFhT2knbosuAvMLjVssxB7hIjL486ampyHbI9X161yRFtqkbd0AR30qJ7y
        
        public ExStocksExchange()
        {
            Name = "stocks.exchange";
            publicAPI = "https://stocks.exchange/api2/";
            tradeAPI = "https://stocks.exchange/api2/";
            min_rate = new Dictionary<string, double>();
            WebRequest.DefaultWebProxy = null;
        }
        public override Dictionary<string, double> GetBalance(string pair, int nonce) //Private API
        {
            //string parameters = $"method=getInfo&nonce=" + nonce;
            string resp = Response(new { nonce = nonce, method = "Getinfo" });

            //resp = resp.Replace("return", "returnInfo");

            StocksExchangeAccountInfo sAccInfo = JsonConvert.DeserializeObject<StocksExchangeAccountInfo>(resp);
            var res = sAccInfo.data.funds;

            return res;
        }

        public override void GetMarkets() //public api
        {
            string command = "markets";
            ServicePointManager.ServerCertificateValidationCallback +=
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
            StocksExchangeInfo yInfo = JsonConvert.DeserializeObject<StocksExchangeInfo>(new WebClient().DownloadString(publicAPI + command));
            yInfo.pairs.ForEach(x => { AvailableMarkets.Add(x.market_name); });
            AvailableMarkets.Sort();
            yInfo.pairs.ForEach(k => { min_rate[k.market_name] = k.min_buy_price; });
        }

        public override void GetPrice(string market) //Public API
        {
            string command = string.Empty;
            string resp = string.Empty;

            command = "prices";
            resp = new WebClient().DownloadString(publicAPI + command);
            if (resp.Contains("Invalid pair name"))
            {
                return;
            }

            //resp = resp.Remove(0, resp.IndexOf(":") + 1);
            //resp = resp.Remove(resp.Length - 1, 1);

            StocksExchangePrice prList = JsonConvert.DeserializeObject<StocksExchangePrice>(resp);
            var pr = prList.price.Find(x => x.market_name.Equals(market));

            // if (pr. != null && pr.asks != null && pr.bids.Count > 0 && pr.asks.Count > 0 && pr.bids[0].Count > 0 && pr.asks[0].Count > 0)
            //{
            Price p = new Price();
            p.ask = pr.buy;
            p.bid = pr.sell;
            price = p;
            //}
        }

        public override string Trade(TypeOrder type, string pair, double rate, double amount, int nonce) //private api
        {
            string resp = Response(new
            {
                pair = pair,
                type = type.ToString(),
                rate = rate.ToString("F8", CultureInfo.InvariantCulture),
                amount = amount.ToString("F8", CultureInfo.InvariantCulture),
                nonce = nonce,
                method = "Trade"
            });

            if (resp.Contains("false"))
            {
                return DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " " + resp + "\n";
            }
            StocksExchangeTradeInfo info = JsonConvert.DeserializeObject<StocksExchangeTradeInfo>(resp);

            return DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " Order Type: " + type.ToString() + " Order ID: " + info.data.order_id
                + " Price: " + rate.ToString("F8", CultureInfo.InvariantCulture) + "\n";
        }

        private string Sign(byte[] inputBytes)
        {
            var keyByte = Encoding.UTF8.GetBytes(Secret);

            string sign1 = string.Empty;

            using (var hmac = new System.Security.Cryptography.HMACSHA512(keyByte))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);

                StringBuilder hex1 = new StringBuilder(hashValue.Length * 2);
                foreach (byte b in hashValue)
                {
                    hex1.AppendFormat("{0:x2}", b);
                }
                sign1 = hex1.ToString();
            }
            return sign1;
        }

        private string Response(object postObj) // return JSON response
        {
            string jsonResponse = string.Empty;
            string address = $"{tradeAPI}";

            string postData = HttpUtility.UrlEncode(JsonConvert.SerializeObject(postObj));

            byte[] inputBytes = Encoding.UTF8.GetBytes(postData);

            string sign1 = Sign(inputBytes);

            WebRequest webRequest = (HttpWebRequest)WebRequest.Create(address);
            if (webRequest != null)
            {
                webRequest.Method = "POST";
                webRequest.Timeout = 20000; //20 000
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Headers.Add("Key", Key);
                webRequest.Headers.Add("Sign", sign1);
                webRequest.Proxy = null;
                //ServicePointManager.Expect100Continue = false;

                webRequest.ContentLength = inputBytes.Length;
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(inputBytes, 0, inputBytes.Length);
                }
                using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
                    {
                        jsonResponse = sr.ReadToEnd();
                    }
                }
            }
            return jsonResponse;
        }
    }
}
