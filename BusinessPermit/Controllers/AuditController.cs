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
    public class AuditController : BaseController
    {
      
        // GET: /Audit/
        public ActionResult Index()
        {
            return View(db.Audits.ToList());
        }

        // GET: /Audit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.Audits.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // GET: /Audit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Audit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Entity,Description,Status,CreatedOn")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                db.Audits.Add(audit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(audit);
        }

        // GET: /Audit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.Audits.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // POST: /Audit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Entity,Description,Status,CreatedOn")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audit);
        }

        // GET: /Audit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audit audit = db.Audits.Find(id);
            if (audit == null)
            {
                return HttpNotFound();
            }
            return View(audit);
        }

        // POST: /Audit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Audit audit = db.Audits.Find(id);
            db.Audits.Remove(audit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
