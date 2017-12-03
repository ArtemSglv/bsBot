using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Net.Http.Formatting;

namespace bsBot
{
    class ExCryptopia : Exchange
    {
        public ExCryptopia()
        {
            Name = "cryptopia.co.nz";
            publicAPI = "https://www.cryptopia.co.nz/Api/";
            tradeAPI = "https://www.cryptopia.co.nz/Api/";
            min_rate = new Dictionary<string, double>();
            //key abae36b2f2954405aea5505b99b4c000 secret dgWT333d6TfRslCO4BlYow7xq9ytW7zV/Xd3xniAc1w=
        }
        public override string GetInfo(string pair,int nonce)
        {
            string parameters = $"Currency=" + pair + "&nonce=" + (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            //return Response("GetBalance",parameters);
            Foo("GetBalance", "ETH",nonce); //pair.Remove(pair.IndexOf("_"),pair.Length-pair.IndexOf("_")).ToUpper()
            return "";
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
        }

        public override void GetPrice(string market)
        {
            string command = string.Empty;
            string resp = string.Empty;

            command = "GetMarketOrders" + market + "/1";
            resp = new WebClient().DownloadString(publicAPI + command);
            if (resp.Contains("not found"))
            {
                return;
            }

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

        public override string Trade(TypeOrder type, string pair, double rate, double amount,int nonce)
        {
            throw new NotImplementedException();
        }

        protected string Response(string method, string parameters)
        {
            string jsonResponse = string.Empty;

            string address = $"{tradeAPI}/" + method + "/";

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
        async void Foo(string method, string cur,int nonce)
        {
            var postData = new
            {
                Currency = cur
            };

            // Create Request
            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(tradeAPI + method);
            request.Content = new ObjectContent(typeof(object), postData, new JsonMediaTypeFormatter());

            // Authentication
            string requestContentBase64String = string.Empty;
            if (request.Content != null)
            {
                // Hash content to ensure message integrity
                using (var md5 = MD5.Create())
                {
                    requestContentBase64String = Convert.ToBase64String(md5.ComputeHash(await request.Content.ReadAsByteArrayAsync()));
                }
            }

            //create random nonce for each request
           // var nonce = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds; //Guid.NewGuid().ToString("N");

            //Creating the raw signature string
            var signature = Encoding.UTF8.GetBytes(string.Concat(Key, HttpMethod.Post, WebUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower()), nonce, requestContentBase64String));
            using (var hmac = new HMACSHA256(Convert.FromBase64String(Secret)))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("amx", string.Format("{0}:{1}:{2}", Key, Convert.ToBase64String(hmac.ComputeHash(signature)), nonce));
            }


            // Send Request
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();

                }
            }
        }
    }
}
