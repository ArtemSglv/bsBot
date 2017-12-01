﻿using System;
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
        public abstract string Trade(TypeOrder type,string pair, double rate, double amount,int nonce); // buy or sell
        public abstract string GetInfo(string pair);
        //protected abstract string Response(string parameters);       

    }
}
