using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Employees.Where(x=>x.Status == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeAdd(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                employee.EmployeeImage = "Image/" + dosyaadi + uzanti;
            }
            employee.Status = true;
            c.Employees.Add(employee);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeDelete(int id)
        {
            var employee = c.Employees.Find(id);
            employee.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeBring(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.DepartmentID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var employee = c.Employees.Find(id);
            return View("EmployeeBring", employee);
        }

        public  ActionResult EmployeeUpdate(Employee employee)
        {
            var emply = c.Employees.Find(employee.EmployeeID);
            emply.EmployeeID= employee.EmployeeID;
            emply.EmployeeName= employee.EmployeeName;
            emply.EmployeeSurname= employee.EmployeeSurname;
            emply.EmployeeImage= employee.EmployeeImage;
            emply.DepartmentId = employee.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmployeeList()
        {
            var query = c.Employees.ToList();
            return View(query);
        }
    }
}