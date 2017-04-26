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
    public class BuildingPermitController : BaseController
    {        
        // GET: /BuildingPermit/
        public ActionResult Index()
        {
            return View(db.BuildingPermits.ToList());
        }

        // GET: /BuildingPermit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingPermit buildingpermit = db.BuildingPermits.Find(id);
            if (buildingpermit == null)
            {
                return HttpNotFound();
            }
            return View(buildingpermit);
        }

        // GET: /BuildingPermit/Create
        public ActionResult Create()
        {
            ViewBag.BuildingType = new BuildingTypePermit().ToSelectList();
            ViewBag.ScopeOfWork = new ScopeOfWork().ToSelectList();
            ViewBag.BuildingUse = new BuildingUse().ToSelectList();
            return View();
        }

        // POST: /BuildingPermit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuildingPermitId,BuildingTypePermit,ApplicationNumber,AreaNumber,LastName,FirstName,MiddleInitial,TIN,FormOfOwnerShip,OwnerStreetNumber,OwnerStreet,OwnerBarangay,OwnerCity,OwnerZipCode,TelephoneNumber,LocationLotNumber,LocationBlockNumber,LocationTCTNumber,LocationTaxDescriptionNumber,LocationStreet,LocationBarangay,LocationCity,ScopeOfWork,ScopeOfWorkOther,BuildingUse,BuildingUseOther,OccupancyClassified,NumberOfUnits,TotalFloorArea,TotalEstimatedCost,ProposedConstructionDate,ExpectedCompletionDate,CreatedOn,Status,PaymentReference,LocationaClearanceReference")] BuildingPermit buildingpermit, HttpPostedFileBase uploadFile)
        {
            if (uploadFile != null)
            {
                LocationalClearance locational = db.LocationalClearance.SingleOrDefault(z => z.ApplicationNumber == buildingpermit.LocationaClearanceReference);

                if (locational == null)
                {
                    ViewBag.BuildingType = new BuildingTypePermit().ToSelectList();
                    ViewBag.ScopeOfWork = new ScopeOfWork().ToSelectList();
                    ViewBag.BuildingUse = new BuildingUse().ToSelectList();
                    return View(buildingpermit);
                }

                buildingpermit.ApplicationNumber = GenerateApplicationNumber();
                buildingpermit.Attachment = base.GetFileBytes(uploadFile);
                buildingpermit.CreatedOn = DateTime.Now;
                buildingpermit.Status = "Pending";
                buildingpermit.LocationalId = locational.LocationalClearanceId;               
                db.BuildingPermits.Add(buildingpermit);              
                db.SaveChanges();
                return RedirectToAction("ApplicationSuccess");
            }
               
          
            ViewBag.BuildingType = new BuildingTypePermit().ToSelectList();
            ViewBag.ScopeOfWork = new ScopeOfWork().ToSelectList();
            ViewBag.BuildingUse = new BuildingUse().ToSelectList();
            return View(buildingpermit);
        }

        [HttpPost]
        public ActionResult ApproveApplication(int? id)
        {
            var permitQuery = db.BuildingPermits.Include(b => b.LocationalClearance);
            var permit = permitQuery.FirstOrDefault(p => p.BuildingPermitId == id);
            List<Fee> fees = db.Fees.Include(p => p.ApplicationType).Where(p => p.ApplicationType.Description.Contains("Building")).ToList();
            if (permit == null)
            {
                return HttpNotFound();
            }
            permit.Status = "Approved";
            permit.PaymentReference = base.RandomString();
            permit.TotalPayment = fees.Sum(f => f.Price);
            db.Entry(permit).State = EntityState.Modified;
            db.SaveChanges();
           
            EmailSender.SendMail(permit.LocationalClearance.EmailAddress, "Building Permit Application : Approved", EmailSender.BuildingPermitApprovedTemplate(permit, fees));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DisqualifyApplication(int? id)
        {
            var permitQuery = db.BuildingPermits.Include(b => b.LocationalClearance);
            var permit = permitQuery.FirstOrDefault(p => p.BuildingPermitId == id);

            if (permit == null)
            {
                return HttpNotFound();
            }
            permit.Status = "Denied";
            db.Entry(permit).State = EntityState.Modified;
            db.SaveChanges();
            EmailSender.SendMail(permit.LocationalClearance.EmailAddress, "Building Permit Application : Denied", EmailSender.BuildingPermitDeniedTemplate());
            return RedirectToAction("Index");
        }

        public ActionResult ApplicationSuccess()
        {
            return View();
        }

        // GET: /BuildingPermit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingPermit buildingpermit = db.BuildingPermits.Find(id);
            if (buildingpermit == null)
            {
                return HttpNotFound();
            }

            ViewBag.BuildingType = buildingpermit.BuildingTypePermit.GetEnumDescription();
            ViewBag.ScopeOfWork = buildingpermit.ScopeOfWork.GetEnumDescription();
            ViewBag.BuildingUse = buildingpermit.BuildingUse.GetEnumDescription();
            return View(buildingpermit);
        }

        // POST: /BuildingPermit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuildingPermitId,BuildingTypePermit,ApplicationNumber,AreaNumber,LastName,FirstName,MiddleInitial,TIN,FormOfOwnerShip,OwnerStreetNumber,OwnerStreet,OwnerBarangay,OwnerCity,OwnerZipCode,TelephoneNumber,LocationLotNumber,LocationBlockNumber,LocationTCTNumber,LocationTaxDescriptionNumber,LocationStreet,LocationBarangay,LocationCity,ScopeOfWork,ScopeOfWorkOther,BuildingUse,BuildingUseOther,OccupancyClassified,NumberOfUnits,TotalFloorArea,TotalEstimatedCost,ProposedConstructionDate,ExpectedCompletionDate,CreatedOn,Attachment,Status,PaymentReference,LocationaClearanceReference")] BuildingPermit buildingpermit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildingpermit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildingpermit);
        }

        // GET: /BuildingPermit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingPermit buildingpermit = db.BuildingPermits.Find(id);
            if (buildingpermit == null)
            {
                return HttpNotFound();
            }
            return View(buildingpermit);
        }

        // POST: /BuildingPermit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildingPermit buildingpermit = db.BuildingPermits.Find(id);
            db.BuildingPermits.Remove(buildingpermit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string GenerateApplicationNumber()
        {
            var purchaseOrderNumber = db.BuildingPermits.OrderByDescending(p => p.CreatedOn).FirstOrDefault();

            if (purchaseOrderNumber == null)
            {
                return "BP-00000001";
            }

            string lastNumber = purchaseOrderNumber.ApplicationNumber;

            string numberOnly = lastNumber.Remove(0, lastNumber.IndexOf('-') + 1);
            int numberResult = Convert.ToInt32(numberOnly);
            int numberResultLength = numberResult.ToString().Length;
            int startIndex = (numberOnly.Length) - numberResultLength;

            numberOnly = numberOnly.Remove(startIndex, numberResultLength);

            numberResult++;

            return string.Format("BP-{0}{1}", numberOnly, numberResult.ToString());
        }

        [HttpGet]
        public FileResult DownloadAttachment(int id)
        {
            var record = db.BuildingPermits.Find(id);

            if (record == null)
            {
                Byte[] array = new Byte[64];
                return File(array, System.Net.Mime.MediaTypeNames.Application.Octet, "record-not-found");
            }

            return File(record.Attachment, System.Net.Mime.MediaTypeNames.Application.Octet, record.ApplicationNumber + ".docx");
        }
    }
}
