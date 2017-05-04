using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessPermit.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace BusinessPermit.Controllers
{
    public class ZoningFormController : BaseController
    {       
        // GET: /ZoningForm/
        public ActionResult Index()
        {
            return View(db.ZoningClearance.Where(z => z.Status == "Pending").ToList());
        }

        // GET: /ZoningForm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoningClearance zoningclearance = db.ZoningClearance.Find(id);
            if (zoningclearance == null)
            {
                return HttpNotFound();
            }
            return View(zoningclearance);
        }

        // GET: /ZoningForm/Create
        public ActionResult Create()
        {
            //   ViewBag.Fees = db.Fees.Include(p => p.ApplicationType).Where(p => p.ApplicationType.Description.Contains("Zoning"));
            //List<Fee> fees = db.Fees.Include(p => p.ApplicationType).Where(p => p.ApplicationType.Description.Contains("Zoning")).ToList();

            return View();
        }

        // POST: /ZoningForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]     
        public ActionResult Create([Bind(Include = "ZoningClearanceId,ApplicationNumber,DateApplied,BusinessName,OwnerName,BusinessAddress,BusinessNature,ContactNumber,MainOffice,TotalFloorArea,FloorAreaBusiness,EmailAddress,Fees")] ZoningClearance zoningclearance, HttpPostedFileBase attachments)
        {
            if (attachments != null)
            {
                zoningclearance.Attachments = base.GetFileBytes(attachments);
                zoningclearance.DateApplied = DateTime.Now;
                zoningclearance.ApplicationNumber = GenerateApplicationNumber();
                zoningclearance.Status = "Pending";
                zoningclearance.Fees = db.Fees.Include(p => p.ApplicationType).Where(p => p.ApplicationType.Description.Contains("Zoning")).ToList();
                db.ZoningClearance.Add(zoningclearance);
                db.SaveChanges();
                return RedirectToAction("ApplicationSuccess");
            }
            return View(zoningclearance);
        }

        [HttpPost]
        public ActionResult ApproveApplication(int? id)
        {
            ZoningClearance zoningclearance = db.ZoningClearance.Find(id);
            List<Fee> fees = db.Fees.Include(p => p.ApplicationType).Where(p => p.ApplicationType.Description.Contains("Locational")).ToList();

            if (zoningclearance == null)
            {
                return HttpNotFound();
            }

            zoningclearance.Status = "Approved";
            zoningclearance.TotalPayment = fees.Sum(f => f.Price);
            zoningclearance.PaymentReference = base.RandomString();
            db.Entry(zoningclearance).State = EntityState.Modified;
            db.SaveChanges();
            EmailSender.SendMail(zoningclearance.EmailAddress,
                "Zoning Clearance Application : Approved",
                EmailSender.ZoningClearanceApprovedTemplate(zoningclearance, fees));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DisqualifyApplication(int? id)
        {
            ZoningClearance zoningclearance = db.ZoningClearance.Find(id);
            if (zoningclearance == null)
            {
                return HttpNotFound();
            }
            zoningclearance.Status = "Denied";
            db.Entry(zoningclearance).State = EntityState.Modified;
            db.SaveChanges();
            EmailSender.SendMail(zoningclearance.EmailAddress, "Zoning Clearance Application : Denied", EmailSender.ZoningClearanceDeniedTemplate());
            return RedirectToAction("Index");
        }

        public ActionResult ApplicationSuccess()
        {
            return View();
        }

        // GET: /ZoningForm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoningClearance zoningclearance = db.ZoningClearance.Find(id);
            if (zoningclearance == null)
            {
                return HttpNotFound();
            }
            return View(zoningclearance);
        }

        // POST: /ZoningForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZoningClearanceId,ApplicationNumber,DateApplied,BusinessName,OwnerName,BusinessAddress,BusinessNature,ContactNumber,MainOffice,TotalFloorArea,FloorAreaBusiness,Attachments,EmailAddress")] ZoningClearance zoningclearance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zoningclearance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zoningclearance);
        }

        // GET: /ZoningForm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZoningClearance zoningclearance = db.ZoningClearance.Find(id);
            if (zoningclearance == null)
            {
                return HttpNotFound();
            }
            return View(zoningclearance);
        }

        // POST: /ZoningForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZoningClearance zoningclearance = db.ZoningClearance.Find(id);
            db.ZoningClearance.Remove(zoningclearance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileResult DownloadAttachment(int id)
        {
            var record = db.ZoningClearance.Find(id);

            if (record == null)
            {
                Byte[] array = new Byte[64];
                return File(array, System.Net.Mime.MediaTypeNames.Application.Octet, "record-not-found");
            }

            return File(record.Attachments, System.Net.Mime.MediaTypeNames.Application.Octet, record.ApplicationNumber + ".docx");
        }

        private string GenerateApplicationNumber()
        {
            var purchaseOrderNumber = db.ZoningClearance.OrderByDescending(p => p.DateApplied).FirstOrDefault();

            if (purchaseOrderNumber == null)
            {
                return "ZC-00000001";
            }

            string lastNumber = purchaseOrderNumber.ApplicationNumber;

            string numberOnly = lastNumber.Remove(0, lastNumber.IndexOf('-') + 1);
            int numberResult = Convert.ToInt32(numberOnly);
            int numberResultLength = numberResult.ToString().Length;
            int startIndex = (numberOnly.Length) - numberResultLength;

            numberOnly = numberOnly.Remove(startIndex, numberResultLength);

            numberResult++;

            return string.Format("ZC-{0}{1}", numberOnly, numberResult.ToString());
        }

    }
}
