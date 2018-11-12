using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadatak9.Proxy
{
    public class SecurityProxy
    {
        public string Sid { get; set; }

        public string Ticker { get; set; }

        public string Description { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public CurrencyProxy Currency { get; set; }

        public string Underlyning_Sid { get; set; }

        public ExchangeProxy Exchange { get; set; }

        public Security_Primary_TypeProxy Security_Primary_Type { get; set; }
    }
}
