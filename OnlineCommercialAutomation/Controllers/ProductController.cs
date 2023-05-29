using Newtonsoft.Json.Linq;
using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(string parameter)
        {
            var product = from x in c.Products select x;
            if (!string.IsNullOrEmpty(parameter))
            {
                product = product.Where(y => y.ProductName.Contains(parameter));
            }
            return View(product.ToList());
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            c.Products.Add(product);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

         public ActionResult ProductDelete(int id)
        {
            var product = c.Products.Find(id);
            product.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductBring(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var product = c.Products.Find(id);
            return View("ProductBring", product);
        }

        public ActionResult ProductUpdate(Product product)
        {
            var prdct = c.Products.Find(product.ProductID);
            prdct.PurchasePrice = product.PurchasePrice;
            prdct.Status = product.Status;
            prdct.CategoryId = product.CategoryId;
            prdct.Brand = product.Brand;
            prdct.SalePrice = product.SalePrice;
            prdct.Stock = product.Stock;
            prdct.ProductName = product.ProductName;
            prdct.ProductImage = product.ProductImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Productlist()
        {
            var values = c.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult DoSales(int id)
        {
            List<SelectListItem> value1 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.value1 = value1;
            var value2 = c.Products.Find(id);
            ViewBag.value2 = value2.ProductID;
            ViewBag.value3 = value2.SalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult DoSales(SalesMovement salesMovement)
        {
            salesMovement.Date= DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(salesMovement);
            c.SaveChanges();
            return RedirectToAction("Index","Sales");
        }
    }
}