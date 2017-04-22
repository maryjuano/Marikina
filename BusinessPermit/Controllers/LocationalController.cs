using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessPermit.Models;

namespace BusinessPermit.Controllers
{
    public class LocationalController : BaseController
    {       
        // GET: /Locational/
        public ActionResult Index()
        {
            return View(db.LocationalClearance.ToList());
        }
        public ActionResult ApplicationSuccess()
        {
            return View();
        }

        // GET: /Locational/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationalClearance locationalclearance = db.LocationalClearance.Find(id);
            if (locationalclearance == null)
            {
                return HttpNotFound();
            }
            return View(locationalclearance);
        }

        // GET: /Locational/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Locational/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "LocationalClearanceId,ApplicationNumber,DateApplied,LCPermitNumber,DateIssued,Project,Location,Address,Firm,FloorArea,LandArea,UsableOpenSpace,TCTNumber,EmailAddress")] LocationalClearance locationalclearance, HttpPostedFileBase attachments)
        {
            if (attachments != null)
            {
                locationalclearance.Attachments = base.GetFileBytes(attachments);
                locationalclearance.DateApplied = DateTime.Now;
                locationalclearance.DateIssued = DateTime.Now;
                locationalclearance.ApplicationNumber = GenerateApplicationNumber();
                db.LocationalClearance.Add(locationalclearance);
                db.SaveChanges();
                return RedirectToAction("ApplicationSuccess");
            }

            return View(locationalclearance);
        }

        [HttpPost]
        public ActionResult ApproveApplication(int? id)
        {
            LocationalClearance clearance = db.LocationalClearance.Find(id);
            if (clearance == null)
            {
                return HttpNotFound();
            }
            clearance.Status = "Approved";
            db.Entry(clearance).State = EntityState.Modified;
            db.SaveChanges();
            EmailSender.SendMail(clearance.EmailAddress, "Locational Clearance Application : Approved", "Thank you");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DisqualifyApplication(int? id)
        {
            LocationalClearance clearance = db.LocationalClearance.Find(id);
            if (clearance == null)
            {
                return HttpNotFound();
            }
            clearance.Status = "Denied";
            db.Entry(clearance).State = EntityState.Modified;
            db.SaveChanges();
            EmailSender.SendMail(clearance.EmailAddress, "Locational Clearance Application : Denied", "Thank you");
            return RedirectToAction("Index");
        }

        // GET: /Locational/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationalClearance locationalclearance = db.LocationalClearance.Find(id);
            if (locationalclearance == null)
            {
                return HttpNotFound();
            }
            return View(locationalclearance);
        }

        // POST: /Locational/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationalClearanceId,ApplicationNumber,DateApplied,LCPermitNumber,DateIssued,Project,Location,Address,Firm,FloorArea,LandArea,UsableOpenSpace,TCTNumber,Attachments,EmailAddress")] LocationalClearance locationalclearance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationalclearance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationalclearance);
        }

        // GET: /Locational/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationalClearance locationalclearance = db.LocationalClearance.Find(id);
            if (locationalclearance == null)
            {
                return HttpNotFound();
            }
            return View(locationalclearance);
        }

        // POST: /Locational/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationalClearance locationalclearance = db.LocationalClearance.Find(id);
            db.LocationalClearance.Remove(locationalclearance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileResult DownloadAttachment(int id)
        {
            var record = db.LocationalClearance.Find(id);

            if (record == null)
            {
                Byte[] array = new Byte[64];
                return File(array, System.Net.Mime.MediaTypeNames.Application.Octet, "record-not-found");
            }

            return File(record.Attachments, System.Net.Mime.MediaTypeNames.Application.Octet, record.ApplicationNumber + ".docx");
        }

        private string GenerateApplicationNumber()
        {
            var purchaseOrderNumber = db.LocationalClearance.OrderByDescending(p => p.DateApplied).FirstOrDefault();

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

            return string.Format("LC-{0}{1}", numberOnly, numberResult.ToString());
        }
    }
}
