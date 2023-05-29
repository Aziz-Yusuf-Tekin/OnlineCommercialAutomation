using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Detail
    {
        [Key] 
        public int DetailID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(3000)]
        public string ProductInformation { get; set; }
    }
}