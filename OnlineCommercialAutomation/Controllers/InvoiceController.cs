using OnlineCommercialAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Invoices.ToList(); 
            return View(values);
        }

        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)
        {
            c.Invoices.Add(invoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceBring(int id)
        {
            var invoice = c.Invoices.Find(id);
            return View("InvoiceBring", invoice);
        }

        public ActionResult Invoiceupdate(Invoice invoice)
        {
            var invc = c.Invoices.Find(invoice.InvoiceID);
            invc.InvoiceNumber = invoice.InvoiceNumber;
            invc.InvoiceSerialNumber = invoice.InvoiceSerialNumber;
            invc.Time = invoice.Time;
            invc.Date = invoice.Date;
            invc.Receiver = invoice.Receiver;
            invc.Submitter = invoice.Submitter;
            invc.TaxAdministration = invoice.TaxAdministration;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceItemDetail(int id) 
        {
            var value = c.InvoiceItems.Where(x => x.InvoiceId == id).ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult ItemAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ItemAdd(InvoiceItem ınvoiceItem)
        {
            c.InvoiceItems.Add(ınvoiceItem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dynamic()
        {
            Class3 cs = new Class3();
            cs.value1 = c.Invoices.ToList();
            cs.value2 = c.InvoiceItems.ToList();
            return View(cs);
        }

        public ActionResult InvoiceSave(string InvoiceNumber, string InvoiceSerialNumber, DateTime Date, string TaxAdministration, string Time, string Submitter, string Receiver, string Total, InvoiceItem[] ınvoiceItems)
        {
            Invoice i = new Invoice();
            i.InvoiceNumber = InvoiceNumber;
            i.InvoiceSerialNumber = InvoiceSerialNumber;
            i.Date = Date;
            i.TaxAdministration = TaxAdministration;
            i.Time = Time;
            i.Submitter = Submitter;
            i.Receiver = Receiver;
            i.Total = decimal.Parse(Total);
            c.Invoices.Add(i);
            foreach (var x in ınvoiceItems)
            {
                InvoiceItem item = new InvoiceItem();
                item.Description = x.Description;
                item.UnitPrice = x.UnitPrice;
                item.InvoiceId = x.InvoiceId;
                item.Quantity = x.Quantity;
                item.TotalAmount = x.TotalAmount;
                c.InvoiceItems.Add(item);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);

        }
    }
}