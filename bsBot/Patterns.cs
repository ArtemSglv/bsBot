using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsBot
{
    struct YobitInfo
    {
        public struct pairInfo
        {
            public int decimal_places { get; set; }
            public double min_price { get; set; }
            public double max_price { get; set; }
            public double min_amount { get; set; }
            public double min_total { get; set; }
            public int hidden { get; set; }
            public double fee { get; set; }
            public double fee_buyer { get; set; }
            public double fee_seller { get; set; }
        }
        public long server_time { get; set; }
        public Dictionary<string, pairInfo> pairs { get; set; }
    }
    struct YobitPrice
    {
        public List<List<double>> asks { get; set; }
        public List<List<double>> bids { get; set; }
    }
    struct YobitTradeInfo
    {
        public struct ReturnInfo
        {
            public double received { get; set; }
            public double remains { get; set; }
            public long order_id { get; set; }
            public Dictionary<string, double> funds { get; set; }
            public Dictionary<string, double> funds_incl_orders { get; set; }
        }
        public int success { get; set; }
        public ReturnInfo returnInfo { get; set; }
    }
    struct YobitAccountInfo
    {
        public struct ReturnInfo
        {
            public int open_orders { get; set; }
            public Dictionary<string, double> funds { get; set; }
            public Dictionary<string, double> funds_incl_orders { get; set; }
        }
        public int success { get; set; }
        public ReturnInfo returnInfo { get; set; }
    }

    struct CryptopiaInfo
    {
        public struct pairInfo
        {
            public int Id { get; set; }
            public string Label { get; set; }
            public string Currency { get; set; }
            public string Symbol { get; set; }
            public string BaseCurrency { get; set; }
            public string BaseSymbol { get; set; }
            public string Status { get; set; }
            public object StatusMessage { get; set; }
            public double TradeFee { get; set; }
            public double MinimumTrade { get; set; }
            public double MaximumTrade { get; set; }
            public double MinimumBaseTrade { get; set; }
            public double MaximumBaseTrade { get; set; }
            public double MinimumPrice { get; set; }
            public double MaximumPrice { get; set; }
        }
        public bool Success { get; set; }
        public object Message { get; set; }
        public List<pairInfo> Data { get; set; }
    }
    struct CryptopiaPrice
    {
        public struct info
        {
            public int TradePairId { get; set; }
            public string Label { get; set; }
            public double Price { get; set; }
            public double Volume { get; set; }
            public double Total { get; set; }
        }

        public info Buy { get; set; }
        public info Sell { get; set; }
    }
    struct CryptopiaAccountInfo
    {
        public struct ReturnInfo
        {
            public string Symbol { get; set; }
            public double Total { get; set; }
            public double Available { get; set; }
            public double HeldForTrades { get; set; }
            public double PendingWithdraw { get; set; }
        }
        public bool Success { get; set; }
        public List<ReturnInfo> Data { get; set; }
    }
    struct CryptopiaTradeInfo
    {
        public struct ReturnInfo
        {
            public long OrderId { get; set; }
            public List<long> FilledOrders { get; set; }
        }
        public bool Success { get; set; }
        public object Error { get; set; }
        public ReturnInfo Data { get; set; }
    }

    struct StocksExchangeInfo
    {
        public struct pairInfo
        {
            public string currency { get; set; }
            public string partner { get; set; }
            public string currency_long { get; set; }
            public string partner_long { get; set; }
            public double min_order_amount { get; set; }
            public double min_buy_price { get; set; }
            public double min_sell_price { get; set; }
            public double buy_fee_percent { get; set; }
            public double sell_fee_percent { get; set; }
            public bool active { get; set; }
            public double currency_precission { get; set; }
            public double partner_precission { get; set; }
            public string market_name { get; set; }
        }        
        //public List<pairInfo> pairs { get; set; }
    }
    struct StocksExchangePrice
    {
        public struct Price
        {
            public double buy { get; set; }
            public double sell { get; set; }
            public string market_name { get; set; }
            public long updated_time { get; set; }
            public long server_time { get; set; }
        }

        //public List<Price> price { get; set; }
    }
    struct StocksExchangeAccountInfo
    {
        public struct ReturnInfo
        {
            public string email { get; set; }
            public string username { get; set; }
            public object userSessions { get; set; }
            public Dictionary<string, double> funds { get; set; }
            public Dictionary<string, double> hold_funds { get; set; }
            public object wallets_addresses {get; set;}
            public object publick_key { get; set; }
            public object Assets_portfolio { get; set; }
            public int open_orders { get; set; }
            public long server_time { get; set; }
        }
        public int success { get; set; }
        public ReturnInfo data { get; set; }
    }
    struct StocksExchangeTradeInfo
    {
        public struct ReturnInfo
        {
            public long order_id { get; set; }
            public Dictionary<string, double> funds { get; set; }
        }
        public int success { get; set; }
        public ReturnInfo data { get; set; }
    }
}
