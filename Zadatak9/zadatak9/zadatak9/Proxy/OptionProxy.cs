using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadatak9.Proxy
{
    public class OptionProxy
    {
        public string Sid { get; set; }

        public SecurityProxy SecurityProxy { get; set; }

        public string Strike_Price { get; set; }

        public string Put_Call_Flag { get; set; }

        public string Option_Type { get; set; }
    }
}
