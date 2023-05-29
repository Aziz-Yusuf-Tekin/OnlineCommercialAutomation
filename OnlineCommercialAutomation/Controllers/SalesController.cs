using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SalesMovements.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SalesAdd()
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName+" "+x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.value1 = value1;
            ViewBag.value2 = value2;
            ViewBag.value3 = value3;
            return View();
        }
        [HttpPost]
        public ActionResult SalesAdd(SalesMovement salesMovement)
        {
            salesMovement.Date = DateTime.Parse(DateTime.Now.ToShortDateString());  
            c.SalesMovements.Add(salesMovement);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesBring(int id)
        {
            List<SelectListItem> value1 = (from x in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductID.ToString()
                                           }).ToList();

            List<SelectListItem> value2 = (from x in c.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerID.ToString()
                                           }).ToList();

            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.value1 = value1;
            ViewBag.value2 = value2;
            ViewBag.value3 = value3;
            var sales = c.SalesMovements.Find(id);
            return View("SalesBring", sales);
        }

        public ActionResult SalesUpdate(SalesMovement salesMovement)
        {
            var value = c.SalesMovements.Find(salesMovement.SalesMovementID);
            value.CustomerId = salesMovement.CustomerId;
            value.Quantity = salesMovement.Quantity;
            value.Price = salesMovement.Price;
            value.EmployeeId = salesMovement.EmployeeId;
            value.Date= salesMovement.Date;
            value.TotalAmount = salesMovement.TotalAmount;
            value.ProductId = salesMovement.ProductId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int id)
        {
            var values = c.SalesMovements.Where(x=>x.SalesMovementID == id).ToList();
            return View(values);
        }
    }
}