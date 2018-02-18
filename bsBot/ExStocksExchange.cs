using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsBot
{
    class ExStocksExchange : Exchange
    {
        //key: FQ0qfb60HEAIx03RPxNGL4RTlVmEhOZtTFoTsiYo
        //secret: XDSU9ivFhT2knbosuAvMLjVssxB7hIjL486ampyHbI9X161yRFtqkbd0AR30qJ7y
        public override Dictionary<string, double> GetBalance(string pair, int nonce)
        {
            throw new NotImplementedException();
        }

        public override void GetMarkets()
        {
            throw new NotImplementedException();
        }

        public override void GetPrice(string coin)
        {
            throw new NotImplementedException();
        }

        public override string Trade(TypeOrder type, string pair, double rate, double amount, int nonce)
        {
            throw new NotImplementedException();
        }
    }
}
