using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPermit.Controllers
{   
    public class DashboardController : BaseController
    {
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            ViewBag.PendingZoning = db.BusinessPermits.Where(z => z.Status == "Pending").Count();
            ViewBag.ApprovedZoning = db.BusinessPermits.Where(z => z.Status == "Approved").Count();
            ViewBag.DeniedZoning = db.BusinessPermits.Where(z => z.Status == "Denied").Count();
            ViewBag.PaidZoning = db.BusinessPermits.Where(z => z.Status == "Paid").Count();

            ViewBag.PendingLocational = db.BuildingPermits.Where(z => z.Status == "Pending").Count();
            ViewBag.ApprovedLocational = db.BuildingPermits.Where(z => z.Status == "Approved").Count();
            ViewBag.DeniedLocational = db.BuildingPermits.Where(z => z.Status == "Denied").Count();
            ViewBag.PaidLocational = db.BuildingPermits.Where(z => z.Status == "Paid").Count();

            return View();
        }
	}
}