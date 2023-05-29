using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(300)]
        public string CargoComment { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string CargoTrackingCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Sender { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Buyer { get; set; }
        public DateTime Date { get; set; }
    }
}