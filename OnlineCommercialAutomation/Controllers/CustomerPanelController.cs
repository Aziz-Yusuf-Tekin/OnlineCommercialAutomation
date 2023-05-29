using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineCommercialAutomation.Controllers
{
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var values = c.Messages.Where(x => x.Recipient == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerID).FirstOrDefault();
            ViewBag.mid = mailid;
            var totalsales = c.SalesMovements.Where(x => x.CustomerId == mailid).Count();
            ViewBag.totalsales = totalsales;
            var totalamount = c.SalesMovements.Where(x => x.CustomerId == mailid).Sum(y => y.TotalAmount);
            ViewBag.totalamount = totalamount;
            var totalproduct = c.SalesMovements.Where(x => x.CustomerId == mailid).Sum(y => y.Quantity);
            ViewBag.totalproduct = totalproduct;
            var namesurname = c.Customers.Where(x=>x.CustomerMail == mail).Select(y=>y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.namesurname = namesurname;
            return View(values);
        }
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CustomerMail"];
            var id = c.Customers.Where(x => x.CustomerMail == mail.ToString()).Select(y=>y.CustomerID).FirstOrDefault();
            var values = c.SalesMovements.Where(x => x.CustomerId == id).ToList();
            return View(values);
        }

        public ActionResult IncomingMessages ()
        {
            var mail = (string)Session["CustomerMail"];
            var messages = c.Messages.Where(x => x.Recipient == mail).OrderByDescending(x=>x.MessageID).ToList();
            var incmngnmbr = c.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.incomingnumber = incmngnmbr;
            var outgoingnmr = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.outgoingnumber = outgoingnmr; 
            return View(messages);
        }

        public ActionResult OutgoingMessages()
        {
            var mail = (string)Session["CustomerMail"];
            var messages = c.Messages.Where(x => x.Sender == mail).OrderByDescending(z => z.MessageID).ToList();
            var outgoingnmr = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.outgoingnumber = outgoingnmr;
            var incmngnmbr = c.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.incomingnumber = incmngnmbr;
            return View(messages);
        }

        public ActionResult MessageDetail(int id)
        {
            var values = c.Messages.Where(x => x.MessageID == id).ToList();;
            var mail = (string)Session["CustomerMail"];
            var incmngnmbr = c.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.incomingnumber = incmngnmbr;
            var outgoingnmr = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.outgoingnumber = outgoingnmr;
            return View(values);
        }
        [HttpGet]
        public ActionResult MessageAdd()
        {
            var mail = (string)Session["CustomerMail"];
            var incmngnmbr = c.Messages.Count(x => x.Recipient == mail).ToString();
            ViewBag.incomingnumber = incmngnmbr;
            var outgoingnmr = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.outgoingnumber = outgoingnmr;
            return View();
        }

        [HttpPost]
        public ActionResult MessageAdd(Message message)
        {
            var mail = (string)Session["CustomerMail"];
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            c.Messages.Add(message);
            c.SaveChanges();
            return View();
        }

        public ActionResult CargoTracking(string cargo)
        {
            var crg = from x in c.CargoDetails select x;
            crg = crg.Where(y => y.CargoTrackingCode.Contains(cargo));
            return View(crg.ToList());
        }

        public ActionResult CustomerCargoTracking(string id)
        {
            var values = c.CargoTrackings.Where(x => x.CargoTrackingCode == id).ToList();
            return View(values);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CustomerMail"];
            var id = c.Customers.Where(x=>x.CustomerMail == mail).Select(y=>y.CustomerID).FirstOrDefault();
            var customerfind = c.Customers.Find(id);
            return PartialView("Partial1", customerfind);
        }

        public PartialViewResult Partial2()
        {
            var values = c.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(values);
        }

        public ActionResult CustomerİnfoUpdate(Customer customer)
        {
            var cstmr = c.Customers.Find(customer.CustomerID);
            cstmr.CustomerName = customer.CustomerName;
            cstmr.CustomerSurname = customer.CustomerSurname;
            cstmr.CustomerPassword = customer.CustomerPassword;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}