using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Customers.Count().ToString();
            ViewBag.value1 = value1;

            var value2 = c.Products.Count().ToString();
            ViewBag.value2 = value2;

            var value3 = c.Employees.Count().ToString();
            ViewBag.value3 = value3;

            var value4 = c.Categories.Count().ToString();
            ViewBag.value4 = value4;

            var value5 = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.value5 = value5;

            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.value6 = value6;

            var value7 = c.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.value7 = value7;

            var value8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.value8 = value8;

            var value9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.value9 = value9;

            var value10 = c.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.value10 = value10;

            var value11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.value11 = value11;

            var value12 = c.Products.GroupBy(x=>x.Brand).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.value12 = value12;

            var value13 = c.Products.Where(p=>p.ProductID == (c.SalesMovements.GroupBy(x => x.ProductId).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.value13 = value13;

            var value14 = c.SalesMovements.Sum(x=>x.TotalAmount).ToString();
            ViewBag.value14 = value14;

            DateTime today = DateTime.Today;
            var value15 = c.SalesMovements.Count(x => x.Date == today).ToString();
            ViewBag.value15 = value15;

            var value16 = c.SalesMovements.Where(x => x.Date == today).ToList().Sum(y => y.TotalAmount).ToString();
            ViewBag.value16 = value16;

            return View();
        }

        public ActionResult SimplesTables()
        {
            var query = from x in c.Customers
                        group x by x.CustomerCity into g
                        select new GroupClass
                        {
                            City = g.Key,
                            Count = g.Count()
                        };
            return View(query.ToList());
        }

        public PartialViewResult Partial1()
        {
            var query2 = from x in c.Employees
                         group x by x.Department.Name into g
                         select new GroupClass2
                         {
                             Department = g.Key,
                             Count = g.Count()
                         };
            return PartialView(query2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var query = c.Customers.ToList();
            return PartialView(query);
        }

        public PartialViewResult Partial3()
        {
            var query = c.Products.ToList();
            return PartialView(query);
        }

        public PartialViewResult Partial4()
        {
            var query = from x in c.Products
                         group x by x.Brand into g
                         select new GroupClass3
                         {
                             Brand = g.Key,
                             Count = g.Count()
                         };
            return PartialView(query.ToList());
        }
    }
}