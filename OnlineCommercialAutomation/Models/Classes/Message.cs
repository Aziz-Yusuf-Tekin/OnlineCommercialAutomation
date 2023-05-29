﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string Sender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Recipient { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Subject { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Contents { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}