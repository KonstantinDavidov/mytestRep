using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.Messaging;
using FACCTS.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.Composition;
using FACCTS.Server.Services;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Code;

namespace FACCTS.Server.Controllers
{
    [HandleError]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountController : Controller
    {
        [Import]
        public IDataManager DataManager {protected get; set;}

        // **************************************
		// URL: /Account/LogOn
		// **************************************
		public ActionResult LogOn() {
			return View();
		}

		[HttpPost]
		public ActionResult LogOn(LogOnModel model, string returnUrl) {
			if (ModelState.IsValid) {
				var rp = new OpenIdRelyingParty();
				var request = rp.CreateRequest(model.UserSuppliedIdentifier, Realm.AutoDetect, new Uri(Request.Url, Url.Action("Authenticate")));
				if (request != null) {
					if (returnUrl != null) {
						request.AddCallbackArguments("returnUrl", returnUrl);
					}

					return request.RedirectingResponse.AsActionResult();
				} else {
					ModelState.AddModelError(string.Empty, "The identifier you supplied is not recognized as a valid OpenID Identifier.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		public ActionResult Authenticate(string returnUrl) {
			var rp = new OpenIdRelyingParty();
			var response = rp.GetResponse();
			if (response != null) {
				switch (response.Status) {
					case AuthenticationStatus.Authenticated:
						// Make sure we have a user account for this guy.
						string identifier = response.ClaimedIdentifier; // convert to string so LinqToSQL expression parsing works.
						if (DataManager.UsersRepository.Get(u => u.OpenIDClaimedIdentifier == identifier).FirstOrDefault() == null) {
							DataManager.UsersRepository.Insert(new OAuth_Users {
								OpenIDFriendlyIdentifier = response.FriendlyIdentifierForDisplay,
								OpenIDClaimedIdentifier = response.ClaimedIdentifier,
							});
						}

						FormsAuthentication.SetAuthCookie(response.ClaimedIdentifier, false);
						return this.Redirect(returnUrl ?? Url.Action("Index", "Home"));
					default:
						ModelState.AddModelError(string.Empty, "An error occurred during login.");
						break;
				}
			}

			return this.View("LogOn");
		}

		// **************************************
		// URL: /Account/LogOff
		// **************************************
		public ActionResult LogOff() {
			FormsAuthentication.SignOut();

			return RedirectToAction("Index", "Home");
		}

	}

}
