using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zadatak9.Models
{
    [Table("Security_Primary_Tipe", Schema = "dbo")]
    public class Security_Primary_Type
    {
        public Security_Primary_Type()
        {
            this.Securities = new HashSet<Security>();
        }
        [Key]
        public string Security_Primary_Type_ID { get; set; }

        public string Description { get; set; }

        public HashSet<Security> Securities { get; set; }
    }
}
