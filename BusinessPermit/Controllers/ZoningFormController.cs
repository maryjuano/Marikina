using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessPermit.Models;

namespace FinessaAesthetica.Controllers
{
    public class ZoningFormController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ZoningForm/
        public ActionResult Index()
        {
            return View(db.ZoningClearance.ToList());
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
            return View();
        }

        // POST: /ZoningForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ZoningClearanceId,ApplicationNumber,DateApplied,BusinessName,OwnerName,BusinessAddress,BusinessNature,ContactNumber,MainOffice,TotalFloorArea,FloorAreaBusiness,Attachments")] ZoningClearance zoningclearance)
        {
            if (ModelState.IsValid)
            {
                zoningclearance.DateApplied = DateTime.Now;
                zoningclearance.ApplicationNumber = GenerateApplicationNumber();
                zoningclearance.Status = "Pending";
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
            if (zoningclearance == null)
            {
                return HttpNotFound();
            }
            zoningclearance.Status = "Passed Assessment";
            db.Entry(zoningclearance).State = EntityState.Modified;
            db.SaveChanges();
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
            zoningclearance.Status = "Disapproved";
            db.Entry(zoningclearance).State = EntityState.Modified;
            db.SaveChanges();
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
        public ActionResult Edit([Bind(Include = "ZoningClearanceId,ApplicationNumber,DateApplied,BusinessName,OwnerName,BusinessAddress,BusinessNature,ContactNumber,MainOffice,TotalFloorArea,FloorAreaBusiness,Attachments")] ZoningClearance zoningclearance)
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

        private string GenerateApplicationNumber()
        {
            var purchaseOrderNumber = db.ZoningClearance.OrderByDescending(p => p.DateApplied).First();
            string lastNumber = purchaseOrderNumber.ApplicationNumber;

            if (lastNumber == null)
            {
                return "ZO-00000001";
            }

            string numberOnly = lastNumber.Remove(0, lastNumber.IndexOf('-') + 1);
            int numberResult = Convert.ToInt32(numberOnly);
            int numberResultLength = numberResult.ToString().Length;
            int startIndex = (numberOnly.Length) - numberResultLength;

            numberOnly = numberOnly.Remove(startIndex, numberResultLength);

            numberResult++;

            return string.Format("ZC-{0}{1}", numberOnly, numberResult.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
