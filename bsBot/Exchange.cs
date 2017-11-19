using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsBot
{
    abstract class Exchange
    {
        public string Name { get; set; }
        public string publicAPI { get; set; }
        public string tradeAPI { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public Dictionary<string,string> AvailableMarkets { get; set; }    

        public Exchange() { }

        public abstract void GetMarkets();
        public abstract void GetPrice(string coin);
        public abstract void Trade(string type); // buy or sell

    }
}
