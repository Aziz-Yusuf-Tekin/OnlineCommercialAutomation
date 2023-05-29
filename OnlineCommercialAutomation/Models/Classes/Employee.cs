using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string EmployeeImage { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string EmployeePassword { get; set; }

        public bool Status { get; set; }


        public ICollection<SalesMovement> SalesMovements { get; set; }
        
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}