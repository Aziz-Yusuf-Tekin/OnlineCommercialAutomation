using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}
