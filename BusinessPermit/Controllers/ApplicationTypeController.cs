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
    public class ApplicationTypeController : BaseController
    {
      
        // GET: /ApplicationType/
        public ActionResult Index()
        {
            var applicationType = db.ApplicationTypes;
            return View(db.ApplicationTypes.ToList());
        }

        // GET: /ApplicationType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationType applicationtype = db.ApplicationTypes.Find(id);
            if (applicationtype == null)
            {
                return HttpNotFound();
            }
            return View(applicationtype);
        }

        // GET: /ApplicationType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ApplicationType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ApplicationTypeId,Description")] ApplicationType applicationtype)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationTypes.Add(applicationtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationtype);
        }

        // GET: /ApplicationType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationType applicationtype = db.ApplicationTypes.Find(id);
            if (applicationtype == null)
            {
                return HttpNotFound();
            }
            return View(applicationtype);
        }

        // POST: /ApplicationType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ApplicationTypeId,Description")] ApplicationType applicationtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationtype);
        }

        // GET: /ApplicationType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationType applicationtype = db.ApplicationTypes.Find(id);
            if (applicationtype == null)
            {
                return HttpNotFound();
            }
            return View(applicationtype);
        }

        // POST: /ApplicationType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationType applicationtype = db.ApplicationTypes.Find(id);
            db.ApplicationTypes.Remove(applicationtype);
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
