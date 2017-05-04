using BusinessPermit.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BusinessPermit.Controllers
{
    public class BusinessPermitController : BaseController
    {
        //
        // GET: /BusinessPermit/
        public ActionResult Index()
        {
            return View(db.BusinessPermits.Where(z => z.Status == "Pending").ToList());
        }

        // GET: /BusinessPermit/Create
        public ActionResult Create()
        {
            //  IEnumerable<Fee> fees = db.Fees.Include(p => p.ApplicationType).Where(p => p.ApplicationType.Description.Contains("Zoning")).ToList();
            return View();
        }

        [HttpPost]     
        public ActionResult Create([Bind(Include = "Id,IsNew,BusinessAccountNumber,DateApplied,BusinessName,OwnerName,BusinessAddress,BusinessNature,DeliveryVehicles,TotalAreaBusiness,ContactNumber,TotalEmployee,RentedOwnerName,MonthlyRental,JanGrossReceipt,FebGrossReceipt,MarGrossReceipt,AprGrossReceipt,MayGrossReceipt,JunGrossReceipt,JulGrossReceipt,AugGrossReceipt,SepGrossReceipt,OctGrossReceipt,NovGrossReceipt,DecGrossReceipt,TotalGrossReceipt,CapitalInvestment,DateStartedRemarks,CapitalInvestmentRemarks,AreaRemarks,GrossSalesPerDay,GrossSalesPerYear,PreviousBasisLicenseTax,CurrentBasisLicenseTax,AssessedAmount,Status,ZoningClearanceReferenceNumber")] BusinessPermit.Models.BusinessPermit businesspermit, HttpPostedFileBase uploadFile)
        {
            if (uploadFile != null)
            {
                businesspermit.Attachments = base.GetFileBytes(uploadFile);
                businesspermit.DateApplied = DateTime.Now;
                businesspermit.Status = "Pending";
                ZoningClearance zoning = db.ZoningClearance.Where(z => z.ApplicationNumber == businesspermit.ZoningClearanceReferenceNumber).FirstOrDefault();

                if (zoning == null)
                {
                    return View(businesspermit);
                }

                if (businesspermit.IsNew == false)
                {
                    BusinessPermit.Models.BusinessPermit previous = db.BusinessPermits.Where(z => z.BusinessAccountNumber == businesspermit.BusinessAccountNumber).OrderBy(p => p.DateApplied).FirstOrDefault();
                    if (previous != null)
                    {
                        if (previous.TotalGrossReceipt > businesspermit.TotalGrossReceipt)
                        {
                            businesspermit.TotalGrossReceipt = previous.TotalGrossReceipt;
                        }
                    }
                }

                businesspermit.BusinessAddress = zoning.BusinessAddress;
                businesspermit.BusinessName = zoning.BusinessName;
                businesspermit.BusinessNature = zoning.BusinessNature;
                businesspermit.OwnerName = zoning.OwnerName;

                businesspermit.ZoningClearanceId = zoning.ZoningClearanceId;

                db.BusinessPermits.Add(businesspermit);

                db.SaveChanges();
                return RedirectToAction("ApplicationSuccess");
            }
            return View(businesspermit);
        }

        public ActionResult ApproveApplication(int? id)
        {
            var permitQuery = db.BusinessPermits.Include(b => b.ZoningClearance);
            BusinessPermit.Models.BusinessPermit permit = permitQuery.FirstOrDefault(p => p.Id == id);
            List<Fee> fees = db.Fees.Include(p => p.ApplicationType).Where(p => p.ApplicationType.Description.Contains("Business")).ToList();
            if (permit == null)
            {
                return HttpNotFound();
            }

            permit.Status = "Approved";
            permit.PaymentReference = base.RandomString();
            db.Entry(permit).State = EntityState.Modified;
            permit.TotalPayment = fees.Sum(f => f.Price);
            db.SaveChanges();
          
            EmailSender.SendMail(permit.ZoningClearance.EmailAddress, "Business Permit Application : Approved", EmailSender.BusinessPermitApprovedTemplate(permit, fees));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DisqualifyApplication(int? id)
        {
            var permitQuery = db.BusinessPermits.Include(b => b.ZoningClearance);
            var permit = permitQuery.FirstOrDefault(p => p.Id == id);

            if (permit == null)
            {
                return HttpNotFound();
            }
            permit.Status = "Denied";
            db.Entry(permit).State = EntityState.Modified;
            db.SaveChanges();
            EmailSender.SendMail(permit.ZoningClearance.EmailAddress, "Business Permit Application : Denied", EmailSender.BusinessPermitDeniedTemplate());
            return RedirectToAction("Index");
        }

        //     GET: /aw/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessPermit.Models.BusinessPermit businesspermit = db.BusinessPermits.Find(id);
            if (businesspermit == null)
            {
                return HttpNotFound();
            }

            return View(businesspermit);
        }

        public ActionResult ApplicationSuccess()
        {
            return View();
        }
        [HttpGet]
        public FileResult DownloadAttachment(int id)
        {
            var record = db.BusinessPermits.Find(id);

            if (record == null)
            {
                Byte[] array = new Byte[64];
                return File(array, System.Net.Mime.MediaTypeNames.Application.Octet, "record-not-found");
            }

            return File(record.Attachments, System.Net.Mime.MediaTypeNames.Application.Octet, record.BusinessName + ".docx");
        }
    }
}