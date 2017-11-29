﻿using System;
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
            Name = "Yobit";
            publicAPI = "https://yobit.net/api/3/";
            tradeAPI = "https://yobit.net/tapi/";
            min_rate = new Dictionary<string, double>();
            // secret: dd0009fd19e2531c93b8b16a62859071 key: 045F12F9CFB472607EACF75AC4CADFA1
        }
        public override void GetMarkets()
        {
            string command = "info";
            YobitInfo yInfo = JsonConvert.DeserializeObject<YobitInfo>(new WebClient().DownloadString(publicAPI + command));
            AvailableMarkets = yInfo.pairs.Keys.ToList();
            yInfo.pairs.Keys.ToList().ForEach(k=> { min_rate[k] = yInfo.pairs[k].min_price; });
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

            //resp=resp.Replace("[[", "[");
            //resp=resp.Replace("]]", "]");
            resp=resp.Remove(0, resp.IndexOf(":") + 1);
            resp=resp.Remove(resp.Length-1,1);
                
            YobitPrice pr = JsonConvert.DeserializeObject<YobitPrice>(resp);

            if (!pr.Equals(null))
            {
                Price p=new Price();
                p.ask = pr.asks[0][0];
                p.bid = pr.bids[0][0];
                price = p;
            }

        }

        public override string Trade(TypeOrder type, string pair,double rate,double amount)
        {
            string parameters = $"method=Trade&pair=" + pair +
                "&type="+type.ToString()+"&rate="+rate.ToString(CultureInfo.InvariantCulture)+"&amount="+amount+
                "&nonce=" + (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            string resp = Response(parameters);
            if(resp.Contains("error"))
            {
                return DateTime.UtcNow.ToString("dd/MM/yy HH:mm:ss.ffff") + " "+resp +"\n\r";
            }
            YobitTradeInfo info = JsonConvert.DeserializeObject<YobitTradeInfo>(resp);

            return DateTime.UtcNow.ToString("dd/MM/yy HH:mm:ss.ffff") +" Order Type: "+type.ToString()+" Order ID: "+info.returnInfo.order_id
                +" Received: "+info.returnInfo.received+" Remains: "+info.returnInfo.remains+"\n\r";
        }

        public override string GetInfo(string pair)
        {
            string parameters = $"method=getInfo&pair=" + pair + "&nonce=" + (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            return Response(parameters);
        }

        protected  string Response(string parameters) // return JSON response
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
