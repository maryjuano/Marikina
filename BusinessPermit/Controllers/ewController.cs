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
    public class ewController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ew/
        public ActionResult Index()
        {
            return View(db.BuildingPermits.ToList());
        }

        // GET: /ew/Details/5
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

        // GET: /ew/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BuildingPermitId,BuildingTypePermit,ApplicationNumber,AreaNumber,LastName,FirstName,MiddleInitial,TIN,FormOfOwnerShip,OwnerStreetNumber,OwnerStreet,OwnerBarangay,OwnerCity,OwnerZipCode,TelephoneNumber,LocationLotNumber,LocationBlockNumber,LocationTCTNumber,LocationTaxDescriptionNumber,LocationStreet,LocationBarangay,LocationCity,ScopeOfWork,ScopeOfWorkOther,BuildingUse,BuildingUseOther,OccupancyClassified,NumberOfUnits,TotalFloorArea,TotalEstimatedCost,ProposedConstructionDate,ExpectedCompletionDate,CreatedOn,Attachment,Status,PaymentReference,LocationaClearanceReference,LocationalId")] BuildingPermit buildingpermit)
        {
            if (ModelState.IsValid)
            {
                db.BuildingPermits.Add(buildingpermit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildingpermit);
        }

        // GET: /ew/Edit/5
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
            return View(buildingpermit);
        }

        // POST: /ew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BuildingPermitId,BuildingTypePermit,ApplicationNumber,AreaNumber,LastName,FirstName,MiddleInitial,TIN,FormOfOwnerShip,OwnerStreetNumber,OwnerStreet,OwnerBarangay,OwnerCity,OwnerZipCode,TelephoneNumber,LocationLotNumber,LocationBlockNumber,LocationTCTNumber,LocationTaxDescriptionNumber,LocationStreet,LocationBarangay,LocationCity,ScopeOfWork,ScopeOfWorkOther,BuildingUse,BuildingUseOther,OccupancyClassified,NumberOfUnits,TotalFloorArea,TotalEstimatedCost,ProposedConstructionDate,ExpectedCompletionDate,CreatedOn,Attachment,Status,PaymentReference,LocationaClearanceReference,LocationalId")] BuildingPermit buildingpermit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildingpermit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildingpermit);
        }

        // GET: /ew/Delete/5
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

        // POST: /ew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildingPermit buildingpermit = db.BuildingPermits.Find(id);
            db.BuildingPermits.Remove(buildingpermit);
            db.SaveChanges();
            return RedirectToAction("Index");
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
