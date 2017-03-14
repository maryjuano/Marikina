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
    public class LocationalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="LocationalClearanceId,ApplicationNumber,DateApplied,LCPermitNumber,DateIssued,Project,Location,Address,Firm,FloorArea,LandArea,UsableOpenSpace,TCTNumber,Attachments")] LocationalClearance locationalclearance)
        {
            if (ModelState.IsValid)
            {
                locationalclearance.DateApplied = DateTime.Now;
                locationalclearance.DateIssued = DateTime.Now;
                locationalclearance.ApplicationNumber = GenerateApplicationNumber();
                db.LocationalClearance.Add(locationalclearance);
                db.SaveChanges();
                return RedirectToAction("ApplicationSuccess");
            }

            return View(locationalclearance);
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
        public ActionResult Edit([Bind(Include="LocationalClearanceId,ApplicationNumber,DateApplied,LCPermitNumber,DateIssued,Project,Location,Address,Firm,FloorArea,LandArea,UsableOpenSpace,TCTNumber,Attachments")] LocationalClearance locationalclearance)
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

        private string GenerateApplicationNumber()
        {
            var purchaseOrderNumber = db.LocationalClearance.OrderByDescending(p => p.DateApplied).First();
            string lastNumber = purchaseOrderNumber.ApplicationNumber;

            if (lastNumber == null)
            {
                return "LC-00000001";
            }

            string numberOnly = lastNumber.Remove(0, lastNumber.IndexOf('-') + 1);
            int numberResult = Convert.ToInt32(numberOnly);
            int numberResultLength = numberResult.ToString().Length;
            int startIndex = (numberOnly.Length) - numberResultLength;

            numberOnly = numberOnly.Remove(startIndex, numberResultLength);

            numberResult++;

            return string.Format("LC-{0}{1}", numberOnly, numberResult.ToString());
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
