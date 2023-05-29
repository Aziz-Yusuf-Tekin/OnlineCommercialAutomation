using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
