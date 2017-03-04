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
    public class UserRoleController : BaseController
    {      

        // GET: /UserRole/
        public ActionResult Index()
        {
            return View(db.UserRoles.ToList());
        }

        // GET: /UserRole/Details/5
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

        // GET: /UserRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="RoleId,RoleName")] UserRoles userroles)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userroles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userroles);
        }

        // GET: /UserRole/Edit/5
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

        // POST: /UserRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="RoleId,RoleName")] UserRoles userroles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userroles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userroles);
        }

        // GET: /UserRole/Delete/5
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

        // POST: /UserRole/Delete/5
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
