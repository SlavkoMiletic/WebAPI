using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadatak9.Models
{
    public class SecurityQuery
    {
        
        public string SID { get; set; }
        public string SID_SearchType { get; set; }

        public string Ticker { get; set; }
        public string Ticker_SearchType { get; set; }

        public string Description { get; set; }
        public string Description_SearchType { get; set; }

        public string SecurityPrimaryType { get; set; }
        public string SecurityPrimaryType_SearchType { get; set; }

        public Func<Security, bool> Compile()
        {
            return (x) =>
            {
                bool result = true;

                if (this.SID != null)
                {
                    switch (this.SID_SearchType)
                    {
                        case "equals":
                            result &= x.SID.Trim() == this.SID;
                            break;
                        case "contains":
                            result &= x.SID.Contains(this.SID);
                            break;
                        case "starts with":
                            result &= x.SID.StartsWith(this.SID);
                            break;
                        default:
                            return false;
                    }
                }

                if (this.Ticker != null)
                {
                    switch (this.Ticker_SearchType)
                    {
                        case "equals":
                            result &= x.Ticker.Trim() == this.Ticker;
                            break;
                        case "contains":
                            result &= x.Ticker.Contains(this.Ticker);
                            break;
                        case "starts with":
                            result &= x.Ticker.StartsWith(this.Ticker);
                            break;
                        default:
                            return false;
                    }
                }

                if (this.Description != null)
                {
                    switch (this.Description_SearchType)
                    {
                        case "equals":
                            result &= x.Description.Trim() == this.Description;
                            break;
                        case "contains":
                            result &= x.Description.Contains(this.Description);
                            break;
                        case "starts with":
                            result &= x.Description.StartsWith(this.Description);
                            break;
                        default:
                            return false;
                    }
                }

                if (this.SecurityPrimaryType != null)
                {
                    switch (this.SecurityPrimaryType_SearchType)
                    {
                        case "equals":
                            result &= x.Security_Primary_Type_ID.Trim() == this.SecurityPrimaryType;
                            break;
                        case "contains":
                            result &= x.Security_Primary_Type_ID.Contains(this.SecurityPrimaryType);
                            break;
                        case "starts with":
                            result &= x.Security_Primary_Type_ID.StartsWith(this.SecurityPrimaryType);
                            break;
                        default:
                            return false;
                    }
                }

                return result;
            };
        }
    }
}
