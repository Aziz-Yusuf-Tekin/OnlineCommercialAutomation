using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OnlineCommercialAutomation.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index(string cargo)
        {
            var crg = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(cargo))
            {
                crg = crg.Where(y => y.CargoTrackingCode.Contains(cargo));
            }
            return View(crg.ToList());
        }

        [HttpGet]
        public ActionResult CargoAdd()
        {
            Random random = new Random();
            string[] values = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Z" };
            int v1, v2, v3;
            v1 = random.Next(0, values.Length);
            v2 = random.Next(0, values.Length);
            v3 = random.Next(0, values.Length);
            int n1, n2, n3;
            n1 = random.Next(100, 1000);
            n2 = random.Next(10, 99);
            n3 = random.Next(10, 99);
            string code = n1.ToString() + values[v1] + n2.ToString() + values[v2] + n3.ToString() + values[v3];
            ViewBag.trackingcode = code;
            return View();
        }

        [HttpPost]
        public ActionResult CargoAdd(CargoDetail cargoDetail)
        {
            c.CargoDetails.Add(cargoDetail);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CargoTracking(string id)
        {
            var values = c.CargoTrackings.Where(x => x.CargoTrackingCode == id).ToList();
            return View(values);
        }

    }
}