using BusinessPermit.Models;
using System;
using System.Collections.Generic;
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsNew,BusinessAccountNumber,DateApplied,BusinessName,OwnerName,BusinessAddress,BusinessNature,DeliveryVehicles,TotalAreaBusiness,ContactNumber,TotalEmployee,RentedOwnerName,MonthlyRental,JanGrossReceipt,FebGrossReceipt,MarGrossReceipt,AprGrossReceipt,MayGrossReceipt,JunGrossReceipt,JulGrossReceipt,AugGrossReceipt,SepGrossReceipt,OctGrossReceipt,NovGrossReceipt,DecGrossReceipt,TotalGrossReceipt,CapitalInvestment,DateStartedRemarks,CapitalInvestmentRemarks,AreaRemarks,GrossSalesPerDay,GrossSalesPerYear,PreviousBasisLicenseTax,CurrentBasisLicenseTax,AssessedAmount,Status,ZoningClearanceReferenceNumber")] BusinessPermit.Models.BusinessPermit businesspermit, HttpPostedFileBase uploadFile)
        {
            if (uploadFile != null)
            {
                businesspermit.Attachments = base.GetFileBytes(uploadFile);
                businesspermit.DateApplied = DateTime.Now;
                businesspermit.Status = "Pending";
                ZoningClearance zoning = db.ZoningClearance.SingleOrDefault(z => z.ApplicationNumber == businesspermit.ZoningClearanceReferenceNumber);

                if (zoning == null)
                {
                    return View(businesspermit);
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

            return File(record.Attachments, System.Net.Mime.MediaTypeNames.Application.Octet, record.BusinessName + ".xlsx");
        }
        private void GenerateApplicationNumber()
        {
            //var purchaseOrderNumber = db.BusinessPermits.OrderByDescending(p => p.DateApplied).FirstOrDefault();

            //if (purchaseOrderNumber == null)
            //{
            //    return "ZC-00000001";
            //}

            //string lastNumber = purchaseOrderNumber.ref;

            //string numberOnly = lastNumber.Remove(0, lastNumber.IndexOf('-') + 1);
            //int numberResult = Convert.ToInt32(numberOnly);
            //int numberResultLength = numberResult.ToString().Length;
            //int startIndex = (numberOnly.Length) - numberResultLength;

            //numberOnly = numberOnly.Remove(startIndex, numberResultLength);

            //numberResult++;

            //return string.Format("ZC-{0}{1}", numberOnly, numberResult.ToString());
        }
    }
}