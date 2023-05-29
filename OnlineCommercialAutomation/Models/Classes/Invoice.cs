using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceSerialNumber { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string TaxAdministration { get; set; }

        [Column(TypeName ="char")]
        [StringLength(5)]
        public string Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }

        public decimal Total { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
