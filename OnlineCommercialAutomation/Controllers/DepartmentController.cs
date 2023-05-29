using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departments.Where(x=>x.Status == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult DepartmentAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmentAdd(Department department)
        {
            c.Departments.Add(department);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDelete(int id)
        {
            var dprtmnt = c.Departments.Find(id);
            dprtmnt.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentBring(int id)
        {
            var dprtmnt = c.Departments.Find(id);
            return View("DepartmentBring", dprtmnt);
        }

        public ActionResult DepartmentUpdate(Department department)
        {
            var dprtmnt = c.Departments.Find(department.DepartmentID);
            dprtmnt.Name= department.Name;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail(int id)
        {
            var values = c.Employees.Where(x => x.DepartmentId == id).ToList();
            var dprtmnt = c.Departments.Where(x=>x.DepartmentID == id).Select(y=>y.Name).FirstOrDefault();
            ViewBag.d = dprtmnt;
            return View(values);
        }

        public ActionResult DepartmentEmployeeSale(int id)
        {
            var values = c.SalesMovements.Where(x=>x.EmployeeId == id).ToList();
            var per = c.Employees.Where(x=>x.EmployeeID == id).Select(y=>y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.demployee = per;
            return  View(values);
        }
    }
}