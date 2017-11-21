using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace bsBot
{
    class ExYobit : Exchange
    {
        public ExYobit()
        {
            Name = "Yobit";
            publicAPI = "https://yobit.net/api/3/";
            tradeAPI = "https://yobit.net/tapi/";
        }
        public override void GetMarkets()
        {
            string command = "info";
            AvailableMarkets = JsonConvert.DeserializeObject<YobitInfo>(new WebClient().DownloadString(publicAPI + command)).pairs.Keys.ToList();
        }

        public override void GetPrice(string market)
        {
            string command = string.Empty;
            string resp = string.Empty;
            
                command = "depth/"+market+"?limit=1";
                resp = Engine.Request(publicAPI + command);
                if (resp.Contains("INVALID_MARKET"))
                {
                    Price.Remove(pk);
                    return;
                }

                Dictionary<string, double> dict = Engine.DeserializeToPriceBittrex(resp);
                CurrentPrice pr;
                if (dict != null)
                {
                    pr.ask = dict["Ask"];
                    pr.bid = dict["Bid"];
                    Price[pk] = pr;
                }
            
        }

        public override string Trade(string type)
        {
            string message = string.Empty;



            return message;
        }
    }
}
