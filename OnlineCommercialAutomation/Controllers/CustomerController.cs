using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Customers.Where(x => x.Status == true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CustomerAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerAdd(Customer customer)
        {
            customer.Status = true;
            c.Customers.Add(customer);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerDelete(int id)
        {
            var customer = c.Customers.Find(id);
            customer.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerBring(int id)
        {
            var customer = c.Customers.Find(id);
            return View("CustomerBring", customer);
        }
        public  ActionResult CustomerUpdate(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerBring");
            }
            var cstm = c.Customers.Find(customer.CustomerID);
            cstm.CustomerName = customer.CustomerName;
            cstm.CustomerSurname = customer.CustomerSurname;
            cstm.CustomerCity = customer.CustomerCity;
            cstm.CustomerMail = customer.CustomerMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSales(int id)
        {
            var values = c.SalesMovements.Where(x=>x.CustomerId == id).ToList();
            var cstmr = c.Customers.Where(x => x.CustomerID == id).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.customer = cstmr;
            return View(values);
        }
    }
}