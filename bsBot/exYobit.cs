using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public override void GetPrice(string coin)
        {
            throw new NotImplementedException();
        }

        public override void Trade(string type)
        {
            throw new NotImplementedException();
        }
    }
}
