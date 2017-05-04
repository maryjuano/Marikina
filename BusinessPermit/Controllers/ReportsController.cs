using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPermit.Controllers
{
    public class ReportsController : BaseController
    {
        //
        // GET: /Reports/
        public ActionResult Index()
        {
            return View(db.Payments.ToList());
        }

        public ActionResult BusinessPermit()
        {
            return View(db.BusinessPermits.ToList());
        }

        public ActionResult BuildingPermit()
        {
            return View(db.BuildingPermits.ToList());
        }
	}
}