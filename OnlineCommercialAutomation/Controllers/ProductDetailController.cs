using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context c = new Context();
        public ActionResult Index()
        {
            //r values = c.Products.Where(x => x.ProductID== 1).ToList();
            Class1 cs = new Class1();
            cs.Value1 = c.Products.Where(x => x.ProductID == 1).ToList();
            cs.Value2 = c.Details.Where(y => y.DetailID == 1).ToList();
            return View(cs);
        }
    }
}