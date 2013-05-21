using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FACCTS.Server.Areas.Admin
{
    public class CourtStaffController : Controller
    {
        /// <summary>
        /// Default action
        /// </summary>
        public ActionResult Index()
        {
            return RedirectToAction("Profile");
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult Availability()
        {
            return View();
        }

        public ActionResult UserRole()
        {
            return View();
        }
    }
}
