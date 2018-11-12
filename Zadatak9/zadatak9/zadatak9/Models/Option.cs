using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zadatak9.Models
{
    [Table("Option", Schema = "dbo")]
    public class Option
    {
        [Key]
        [Column("SID")]
        public string SID_ID { get; set; }

        [ForeignKey("SID_ID")]
        public Security SID { get; set; }

        public string Strike_Price { get; set; }

        public string Put_Call_Flag { get; set; }

        public string Option_Type { get; set; }
    }
}
