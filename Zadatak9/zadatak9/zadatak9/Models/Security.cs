using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zadatak9.Models
{
    [Table("Security", Schema ="dbo")]
    public class Security
    {
        public Security()
        {
            this.Securities =  new HashSet<Security>();
        }

        [Key]
        public string SID { get; set; }

        public string Ticker { get; set; }

        public string Description { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        [Column("Currency")]
        public string Currency_ID { get; set; }

        [ForeignKey("Currency_ID")]
        public Currency Currency { get; set; }

        [Column("Underlining_SID")]
        public string Underlyning_SID { get; set; }

        [ForeignKey("Underlyning_SID")]
        public Security UnderlyningSecurity { get; set; }

        [Column("Exchange")]
        public string Exchange_ID { get; set; }

        [ForeignKey("Exchange_ID")]
        public Exchange Exchange { get; set; }

        [Column("Security_Primary_Tipe")]
        public string Security_Primary_Type_ID { get; set; }

        [ForeignKey("Security_Primary_Type_ID")]
        public Security_Primary_Type Security_Primary_Type { get; set; }

        public HashSet<Security> Securities { get; set; }
    }
}
