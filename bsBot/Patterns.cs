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
        public Dictionary<string,pairInfo> pairs { get; set; }
    }
}
