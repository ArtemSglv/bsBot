using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;

namespace bsBot
{
    class ExYobit : Exchange
    {
        public ExYobit()
        {
            Name = "yobit.net";
            publicAPI = "https://yobit.net/api/3/";
            tradeAPI = "https://yobit.net/tapi/";
            min_rate = new Dictionary<string, double>();
        }
        public override void GetMarkets()
        {
            string command = "info";
            YobitInfo yInfo = JsonConvert.DeserializeObject<YobitInfo>(new WebClient().DownloadString(publicAPI + command));
            AvailableMarkets = yInfo.pairs.Keys.ToList();
            AvailableMarkets.Sort();
            yInfo.pairs.Keys.ToList().ForEach(k => { min_rate[k] = yInfo.pairs[k].min_price; });
        }

        public override void GetPrice(string market)
        {
            string command = string.Empty;
            string resp = string.Empty;

            command = "depth/" + market + "?limit=1";
            resp = new WebClient().DownloadString(publicAPI + command);
            if (resp.Contains("Invalid pair name"))
            {
                return;
            }
            
            resp = resp.Remove(0, resp.IndexOf(":") + 1);
            resp = resp.Remove(resp.Length - 1, 1);

            YobitPrice pr = JsonConvert.DeserializeObject<YobitPrice>(resp);

            if (pr.bids != null && pr.asks != null && pr.bids.Count > 0 && pr.asks.Count > 0 && pr.bids[0].Count > 0 && pr.asks[0].Count > 0)
            {
                Price p = new Price();
                p.ask = pr.asks[0][0];
                p.bid = pr.bids[0][0];
                price = p;
            }

        }

        public override string Trade(TypeOrder type, string pair, double rate, double amount, int nonce)
        {
            string parameters = $"method=Trade&pair=" + pair +
                "&type=" + type.ToString() + "&rate=" + rate.ToString("F8", CultureInfo.InvariantCulture) + "&amount=" +
                amount.ToString("F8", CultureInfo.InvariantCulture) +
                "&nonce=" + nonce;

            string resp = Response(parameters);
            if (resp.Contains("error"))
            {
                return DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " " + resp + "\n";
            }
            resp = resp.Replace("return", "returnInfo");
            YobitTradeInfo info = JsonConvert.DeserializeObject<YobitTradeInfo>(resp);
            //curBalance = info.returnInfo.funds_incl_orders;

            return DateTime.Now.ToString("dd/MM/yy HH:mm:ss.ffff") + " Order Type: " + type.ToString() + " Order ID: " + info.returnInfo.order_id
                + " Price: " + rate.ToString("F8", CultureInfo.InvariantCulture) + " Received: " + info.returnInfo.received + " Remains: " + info.returnInfo.remains + "\n";
        }  //private

        public override Dictionary<string, double> GetBalance(string pair, int nonce)
        {
            string parameters = $"method=getInfo&nonce=" + nonce;
            string resp = Response(parameters);

            resp = resp.Replace("return", "returnInfo");

            YobitAccountInfo yAccInfo= JsonConvert.DeserializeObject<YobitAccountInfo>(resp);
            var res = yAccInfo.returnInfo.funds_incl_orders;

            return res;
        } //private

        protected string Response(string parameters) // return JSON response
        {
            string jsonResponse = string.Empty;

            string address = $"{tradeAPI}/";

            var keyByte = Encoding.UTF8.GetBytes(Secret);

            string sign1 = string.Empty;
            byte[] inputBytes = Encoding.UTF8.GetBytes(parameters);
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

            WebRequest webRequest = (HttpWebRequest)WebRequest.Create(address);
            if (webRequest != null)
            {
                webRequest.Method = "POST";
                webRequest.Timeout = 50000; //20 000
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Headers.Add("Key", Key);
                webRequest.Headers.Add("Sign", sign1);

                webRequest.ContentLength = parameters.Length;
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(inputBytes, 0, parameters.Length);
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
