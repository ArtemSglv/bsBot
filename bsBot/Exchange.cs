using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace bsBot
{
    abstract class Exchange
    {
        public struct Price
        {
            public double ask;
            public double bid;
            public double diff()
            {
                return Math.Abs(ask - bid);
            }
        }

        public string Name { get; set; }
        public string publicAPI { get; set; }
        public string tradeAPI { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public Price price { get; set; }
        public Dictionary<string,double> min_rate { get; set; }

        public Exchange() { }

        public abstract void GetMarkets();
        public abstract void GetPrice(string coin);
        public abstract string Trade(TypeOrder type,string pair, double rate, double amount); // buy or sell
        public abstract string GetInfo(string pair);

        // надо перенести куда-то
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
                webRequest.Timeout = 20000;
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
                        //str = String.Format("Response: {0}", jsonResponse);
                    }
                }
            }
            return jsonResponse;
        }

    }
}
