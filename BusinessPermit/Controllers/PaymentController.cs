using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessPermit.Models;
using System.Threading.Tasks;

namespace BusinessPermit.Controllers
{
    public class PaymentController : BaseController
    {        
        // GET: /Payment/
        public ActionResult Index()
        {
            return View(db.Payments.ToList());
        }

        // GET: /Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: /Payment/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationType = new PaymentApplicationType().ToSelectList();
            return View();
        }

        // POST: /Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationType,ReferenceNumber,OfficialReceiptNumber,Status")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                payment.Status = "Pending";
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("ApplicationSuccess");
            }
            ViewBag.ApplicationType = new PaymentApplicationType().ToSelectList();
            return View(payment);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ApproveApplication([Bind(Include = "Id,ApplicationType,ReferenceNumber,OfficialReceiptNumber,Status")] Payment payment)
        {
            if (payment.ApplicationType == PaymentApplicationType.Zoning)
            {
                await ApproveZoning(payment);
            }
            else if (payment.ApplicationType == PaymentApplicationType.Locational)
            {
                await ApproveLocational(payment);
            }
            else if (payment.ApplicationType == PaymentApplicationType.Building)
            {
               await ApproveBuilding(payment);
            }
            else if (payment.ApplicationType == PaymentApplicationType.Business)
            {
               await ApproveBusiness(payment);
            }
            //ZoningClearance zoning = new ZoningClearance();
            //LocationalClearance locational = new LocationalClearance();
            //BuildingPermit building = new BuildingPermit();
            //BusinessPermit.Models.BusinessPermit buiness = new Models.BusinessPermit();

            //ZoningClearance zoningclearance = db.ZoningClearance.Find(id);
            //if (zoningclearance == null)
            //{
            //    return HttpNotFound();
            //}
            //zoningclearance.Status = "Approved";
            //zoningclearance.PaymentReference = base.RandomString();
            //db.Entry(zoningclearance).State = EntityState.Modified;
            //db.SaveChanges();
            //List<Fee> fees = db.Fees.Include(p => p.ApplicationType).Where(p => p.ApplicationType.Description.Contains("Zoning")).ToList();
            //EmailSender.SendMail(zoningclearance.EmailAddress, "Zoning Clearance Application : Approved", EmailSender.ZoningClearanceApprovedTemplate(zoningclearance, fees));
            return RedirectToAction("Index");
        }

        public ActionResult ApplicationSuccess()
        {
            return View();
        }

        // GET: /Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: /Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ApplicationNumber,ReferenceNumber,OfficialReceiptNumber,Status")] Payment payment)
        {
            if (ModelState.IsValid)
            {              
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        // GET: /Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: /Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private async Task ApproveZoning(Payment payment)
        {
            ZoningClearance permit = await db.ZoningClearance.SingleOrDefaultAsync(z => z.PaymentReference == payment.ReferenceNumber);

            if (permit != null)
            {
                permit.Status = "Paid";
                payment.Status = "Confirmed";
                payment.TotalPayment = permit.TotalPayment;
                db.Entry(permit).State = EntityState.Modified;             
                db.Entry(payment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                // email ung attachment with congratulations
                EmailSender.SendMail(permit.EmailAddress, "Zoning Clearance Certification", EmailSender.ZoningClearanceCertifyTemplate());
            }           
        }


        private async Task ApproveLocational(Payment payment)
        {
            LocationalClearance permit = await db.LocationalClearance.SingleOrDefaultAsync(z => z.PaymentReference == payment.ReferenceNumber);

            if (permit != null)
            {
                permit.Status = "Paid";
                payment.Status = "Confirmed";
                payment.TotalPayment = permit.TotalPayment;
                db.Entry(permit).State = EntityState.Modified;
                db.Entry(payment).State = EntityState.Modified;
                await db.SaveChangesAsync();

                // email ung attachment with congratulations
                EmailSender.SendMail(permit.EmailAddress, "Locational Clearance Certification", EmailSender.LocationalClearanceCertifyTemplate());
            }   
        }
        private async Task ApproveBusiness(Payment payment)
        {
            BusinessPermit.Models.BusinessPermit permit = await db.BusinessPermits.Include(b => b.ZoningClearance).SingleOrDefaultAsync(z => z.PaymentReference == payment.ReferenceNumber);

            if (permit != null)
            {
                permit.Status = "Paid";
                payment.Status = "Confirmed";
                payment.TotalPayment = permit.TotalPayment;
                db.Entry(permit).State = EntityState.Modified;
                db.Entry(payment).State = EntityState.Modified;
                await db.SaveChangesAsync();

                // email ung attachment with congratulations
                EmailSender.SendMail(permit.ZoningClearance.EmailAddress, "Business Permit Certification", EmailSender.LocationalClearanceCertifyTemplate());
            }   
        }

        private async Task ApproveBuilding(Payment payment)
        {
            BuildingPermit permit = await db.BuildingPermits.Include(b => b.LocationalClearance).SingleOrDefaultAsync(z => z.PaymentReference == payment.ReferenceNumber);

            if (permit != null)
            {
                permit.Status = "Paid";
                payment.Status = "Confirmed";
                payment.TotalPayment = permit.TotalPayment;
                db.Entry(permit).State = EntityState.Modified;
                db.Entry(payment).State = EntityState.Modified;
                await db.SaveChangesAsync();

                // email ung attachment with congratulations
                EmailSender.SendMail(permit.LocationalClearance.EmailAddress, "Building Permit Certification", EmailSender.LocationalClearanceCertifyTemplate());
            }   
        }
    }
}
