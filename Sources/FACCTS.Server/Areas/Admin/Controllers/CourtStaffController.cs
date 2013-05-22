using FACCTS.Server.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        public ActionResult Profile(string userName)
        {
            ViewBag.userName = userName;
            EditUser editUser = new EditUser();

            if (!string.IsNullOrEmpty(userName))
            {
                MembershipUser user = Membership.GetUser(userName);

                if (user != null)
                {
                    editUser.UserName = user.UserName;
                    editUser.Email = user.Email;
                }
            }

            return View(editUser);
        }

        [HttpPost]
        public ActionResult Profile(EditUser user)
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

        public PartialViewResult UsersList(string userName)
        {
            MembershipUserCollection users = Membership.GetAllUsers();

            ViewBag.userName = userName;

            return PartialView(users);
        }

        public ActionResult CreateUser(string userName)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RemoveUser(string userName)
        {
            /*
             * remove user
             */

            return RedirectToAction("Index");
        }
    }
}
