using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace bsBot
{
    static class Bot
    {
        public static Exchange currentExchange= new ExYobit(); // временно

        public static void Buy()
        {

        }

        public static void Sell()
        {

        }
        public static string GetInfo()
        {
            string str = string.Empty;
            string parameters = $"method=getInfo&nonce=" + (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            string address = $"{currentExchange.tradeAPI}/";

            var keyByte = Encoding.UTF8.GetBytes(currentExchange.Secret);

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
                webRequest.Headers.Add("Key", currentExchange.Key);
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
                        var jsonResponse = sr.ReadToEnd();
                        str=String.Format("Response: {0}", jsonResponse);
                    }
                }
            }
                return str;
        }
    }
}
