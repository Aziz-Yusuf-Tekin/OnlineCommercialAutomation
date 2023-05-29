using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string CargoTrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string CargoTrackingComment { get; set; }
        public DateTime DateTime { get; set; }
    }
}