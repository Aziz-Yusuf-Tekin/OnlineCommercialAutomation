using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanboş geçilemez!")]
        public string CustomerName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanboş geçilemez!")]
        public string CustomerSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "En fazla 15 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanboş geçilemez!")]
        public string CustomerCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanboş geçilemez!")]
        public string CustomerMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanboş geçilemez!")]
        public string CustomerPassword { get; set; }

        public  bool Status { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}