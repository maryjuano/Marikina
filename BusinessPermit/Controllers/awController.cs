//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using BusinessPermit.Models;

//namespace BusinessPermit.Controllers
//{
//    public class awController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: /aw/
//        public ActionResult Index()
//        {
//            var businesspermits = db.BusinessPermits.Include(b => b.ZoningClearance);
//            return View(businesspermits.ToList());
//        }

//        // GET: /aw/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            BusinessPermit businesspermit = db.BusinessPermits.Find(id);
//            if (businesspermit == null)
//            {
//                return HttpNotFound();
//            }
//            return View(businesspermit);
//        }

//        // GET: /aw/Create
//        public ActionResult Create()
//        {
//            ViewBag.ZoningClearanceId = new SelectList(db.ZoningClearance, "ZoningClearanceId", "ApplicationNumber");
//            return View();
//        }

//        // POST: /aw/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include="Id,IsNew,BusinessAccountNumber,DateApplied,BusinessName,OwnerName,BusinessAddress,BusinessNature,DeliveryVehicles,TotalAreaBusiness,ContactNumber,TotalEmployee,RentedOwnerName,MonthlyRental,JanGrossReceipt,FebGrossReceipt,MarGrossReceipt,AprGrossReceipt,MayGrossReceipt,JunGrossReceipt,JulGrossReceipt,AugGrossReceipt,SepGrossReceipt,OctGrossReceipt,NovGrossReceipt,DecGrossReceipt,TotalGrossReceipt,CapitalInvestment,DateStartedRemarks,CapitalInvestmentRemarks,AreaRemarks,GrossSalesPerDay,GrossSalesPerYear,PreviousBasisLicenseTax,CurrentBasisLicenseTax,AssessedAmount,Status,Attachments,ZoningClearanceReferenceNumber,ZoningClearanceId")] BusinessPermit businesspermit)
//        {
//            if (ModelState.IsValid)
//            {
//                db.BusinessPermits.Add(businesspermit);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.ZoningClearanceId = new SelectList(db.ZoningClearance, "ZoningClearanceId", "ApplicationNumber", businesspermit.ZoningClearanceId);
//            return View(businesspermit);
//        }

//        // GET: /aw/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            BusinessPermit businesspermit = db.BusinessPermits.Find(id);
//            if (businesspermit == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.ZoningClearanceId = new SelectList(db.ZoningClearance, "ZoningClearanceId", "ApplicationNumber", businesspermit.ZoningClearanceId);
//            return View(businesspermit);
//        }

//        // POST: /aw/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include="Id,IsNew,BusinessAccountNumber,DateApplied,BusinessName,OwnerName,BusinessAddress,BusinessNature,DeliveryVehicles,TotalAreaBusiness,ContactNumber,TotalEmployee,RentedOwnerName,MonthlyRental,JanGrossReceipt,FebGrossReceipt,MarGrossReceipt,AprGrossReceipt,MayGrossReceipt,JunGrossReceipt,JulGrossReceipt,AugGrossReceipt,SepGrossReceipt,OctGrossReceipt,NovGrossReceipt,DecGrossReceipt,TotalGrossReceipt,CapitalInvestment,DateStartedRemarks,CapitalInvestmentRemarks,AreaRemarks,GrossSalesPerDay,GrossSalesPerYear,PreviousBasisLicenseTax,CurrentBasisLicenseTax,AssessedAmount,Status,Attachments,ZoningClearanceReferenceNumber,ZoningClearanceId")] BusinessPermit businesspermit)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(businesspermit).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.ZoningClearanceId = new SelectList(db.ZoningClearance, "ZoningClearanceId", "ApplicationNumber", businesspermit.ZoningClearanceId);
//            return View(businesspermit);
//        }

//        // GET: /aw/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            BusinessPermit businesspermit = db.BusinessPermits.Find(id);
//            if (businesspermit == null)
//            {
//                return HttpNotFound();
//            }
//            return View(businesspermit);
//        }

//        // POST: /aw/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            BusinessPermit businesspermit = db.BusinessPermits.Find(id);
//            db.BusinessPermits.Remove(businesspermit);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
