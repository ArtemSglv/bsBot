using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsBot
{
    abstract class Exchange
    {
        public struct CurrentPrice
        {
            public double ask;
            public double bid;
            public override string ToString()
            {
                string countDigitAfterComma = ConfigurationManager.AppSettings.Get("countDigitAfterComma");
                return (ask != 0.0d && bid != 0.0d) ? "asks: " + ask.ToString("F" + countDigitAfterComma) + "\r\nbids: " + bid.ToString("F" + countDigitAfterComma) : "";
            }
            public void Clear()
            {
                ask = 0.0d;
                bid = 0.0d;
            }
        }

        public string Name { get; set; }
        public string publicAPI { get; set; }
        public string tradeAPI { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public CurrentPrice Price { get; set; }

        public Exchange() { }

        public abstract void GetMarkets();
        public abstract void GetPrice(string coin);
        public abstract string Trade(string type); // buy or sell

    }
}
