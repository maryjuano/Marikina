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
    public class UserRolesController : BaseController
    {       
        // GET: /UserRoles/
        public ActionResult Index()
        {
            var userroles = db.UserRoles.Include(r => r.CreatedBy);
            return View(userroles.ToList());
        }

        // GET: /UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userroles = db.UserRoles.Find(id);
            if (userroles == null)
            {
                return HttpNotFound();
            }
            return View(userroles);
        }

        // GET: /UserRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RoleId,RoleName,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn")] UserRoles userroles)
        {
            if (ModelState.IsValid)
            {
                userroles.SetOnCreate(CurrentUserId);
                db.UserRoles.Add(userroles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userroles);
        }

        // GET: /UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userroles = db.UserRoles.Find(id);
            if (userroles == null)
            {
                return HttpNotFound();
            }
            return View(userroles);
        }

        // POST: /UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RoleId,RoleName,CreatedById,LastModifiedById,CreatedOn,LastModifiedOn")] UserRoles userroles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userroles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userroles);
        }

        // GET: /UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoles userroles = db.UserRoles.Find(id);
            if (userroles == null)
            {
                return HttpNotFound();
            }
            return View(userroles);
        }

        // POST: /UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRoles userroles = db.UserRoles.Find(id);
            db.UserRoles.Remove(userroles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
