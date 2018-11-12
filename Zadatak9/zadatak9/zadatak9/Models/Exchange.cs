using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zadatak9.Models
{
    [Table("Exchange", Schema = "dbo")]
    public class Exchange
    {
        public Exchange()
        {
            this.Securities = new HashSet<Security>();
        }

        [Key]
        public string Exchange_ID { get; set; }

        public string Description { get; set; }

        public HashSet<Security> Securities { get; set; }
    }
}
