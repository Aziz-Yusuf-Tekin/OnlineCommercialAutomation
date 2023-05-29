using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class ToDoListController : Controller
    {
        // GET: ToDoList
        Context c = new Context();
        public ActionResult Index()
        {
            var values1 = c.Customers.Count().ToString();
            ViewBag.v1 = values1;
            var values2 = c.Products.Count().ToString(); 
            ViewBag.v2 = values2;
            var values3 = c.Categories.Count().ToString();
            ViewBag.v3 = values3;
            var values4 = (from x in c.Customers select x.CustomerCity).Distinct().Count().ToString();
            ViewBag.v4 = values4;


            var todolist = c.ToDoLists.ToList();
            return View(todolist);
        }
    }
}