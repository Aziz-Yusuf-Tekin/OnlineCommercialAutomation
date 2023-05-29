using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineCommercialAutomation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Customer customer)
        {
            c.Customers.Add(customer);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CustomerLogin1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin1(Customer customer)
        {
            var values = c.Customers.FirstOrDefault(x => x.CustomerMail == customer.CustomerMail && x.CustomerPassword == customer.CustomerPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.CustomerMail, false);
                Session["CustomerMail"] = values.CustomerMail.ToString();
                return RedirectToAction("Index", "CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult AdminLogin(Admin admin)
        {
            var values = c.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["UserName"] = values.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}