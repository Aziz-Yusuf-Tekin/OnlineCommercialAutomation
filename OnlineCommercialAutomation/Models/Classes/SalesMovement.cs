using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class SalesMovement
    {
        [Key]
        public int SalesMovementID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
