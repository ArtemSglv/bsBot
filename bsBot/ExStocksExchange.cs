using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Net.Http.Formatting;

namespace bsBot
{
    class ExStocksExchange : Exchange
    {
        //key: FQ0qfb60HEAIx03RPxNGL4RTlVmEhOZtTFoTsiYo
        //secret: XDSU9ivFhT2knbosuAvMLjVssxB7hIjL486ampyHbI9X161yRFtqkbd0AR30qJ7y
        public ExStocksExchange()
        {
            Name = "stocks.exchange";
            publicAPI = "https://stock.exchange/api2/";
            tradeAPI = "https://stock.exchange/api2/";
            min_rate = new Dictionary<string, double>();
            WebRequest.DefaultWebProxy = null;
        }
        public override Dictionary<string, double> GetBalance(string pair, int nonce)
        {
            throw new NotImplementedException();
        }

        public override void GetMarkets()
        {
            string command = "markets";
            StocksExchangeInfo yInfo = JsonConvert.DeserializeObject<StocksExchangeInfo>(new WebClient().DownloadString(publicAPI + command));
            yInfo.pairs.ForEach(x=> { AvailableMarkets.Add(x.market_name); });
            AvailableMarkets.Sort();
            yInfo.pairs.ForEach(k => { min_rate[k.market_name] = k.min_buy_price; });
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
