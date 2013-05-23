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
            /*
             * save user info
             */
            MembershipUser mUser = Membership.GetUser(user.UserName);

            mUser.Email = "la la la";

            Membership.UpdateUser(mUser);

            return RedirectToAction("Profile", new { userName = user.UserName });
        }

        public ActionResult Availability(string userName)
        {
            ViewBag.userName = userName;

            return View();
        }

        public ActionResult UserRole(string userName)
        {
            ViewBag.userName = userName;

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

        public ActionResult LoadUserImage(string userName, HttpPostedFileBase userImageFile)
        {
            /*
             * save image
             */

            return RedirectToAction("Profile", new { userName = userName });
        }

        public FileContentResult GetImage(string userName)
        {
            /*
             * load image
             */

            return /*image != null ? File(image.Image, "image/png") :*/ null;
        }
    }
}
