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
            return View();
        }

        // POST: /BuildingPermit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BuildingPermitId,BuildingTypePermit,ApplicationNumber,AreaNumber,Owner,LastName,FirstName,MiddleInitial,TIN,FormOfOwnerShip,OwnerStreetNumber,OwnerStreet,OwnerBarangay,OwnerCity,OwnerZipCode,TelephoneNumber,LocationLotNumber,LocationBlockNumber,LocationTCTNumber,LocationTaxDescriptionNumber,LocationStreet,LocationBarangay,LocationCity,ScopeOfWork,ScopeOfWorkOther,BuildingUse,BuildingUseOther,OccupancyClassified,NumberOfUnits,TotalFloorArea,TotalEstimatedCost,ProposedConstructionDate,ExpectedCompletionDate,Attachment,Status,LocationalId")] BuildingPermit buildingpermit)
        {
            if (ModelState.IsValid)
            {
                db.BuildingPermits.Add(buildingpermit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildingpermit);
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
            return View(buildingpermit);
        }

        // POST: /BuildingPermit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BuildingPermitId,BuildingTypePermit,ApplicationNumber,AreaNumber,Owner,LastName,FirstName,MiddleInitial,TIN,FormOfOwnerShip,OwnerStreetNumber,OwnerStreet,OwnerBarangay,OwnerCity,OwnerZipCode,TelephoneNumber,LocationLotNumber,LocationBlockNumber,LocationTCTNumber,LocationTaxDescriptionNumber,LocationStreet,LocationBarangay,LocationCity,ScopeOfWork,ScopeOfWorkOther,BuildingUse,BuildingUseOther,OccupancyClassified,NumberOfUnits,TotalFloorArea,TotalEstimatedCost,ProposedConstructionDate,ExpectedCompletionDate,Attachment,Status,LocationalId,CreatedOn")] BuildingPermit buildingpermit)
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
    }
}
