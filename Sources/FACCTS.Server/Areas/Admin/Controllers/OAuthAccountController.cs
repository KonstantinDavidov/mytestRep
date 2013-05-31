using FACCTS.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityServer.Protocols;
using Thinktecture.IdentityServer.Repositories;
using FACCTS.Server;
using System.Security.Claims;

namespace FACCTS.Server.Areas.Admin.Controllers
{
    [Authorize]
    [FACCTS.Server.Filters.InitializeSimpleMembership]
    public class OAuthAccountController : AccountControllerBase
    {
        public OAuthAccountController() : base()
        { }

        [ImportingConstructor]
        public OAuthAccountController(IUserRepository userRepository, IConfigurationRepository configurationRepository)
            : base(userRepository, configurationRepository)
        { }
        
        // shows the signin screen
        [AllowAnonymous]
        public ActionResult SignIn(string returnUrl, bool mobile=false)
        {
            // you can call AuthenticationHelper.GetRelyingPartyDetailsFromReturnUrl to get more information about the requested relying party
            var vm = new SignInModel()
            {
                ReturnUrl = returnUrl,
                ShowClientCertificateLink = ConfigurationRepository.Global.EnableClientCertificateAuthentication
            };

            if (mobile) vm.IsSigninRequest = true;
            return View(vm);
        }

        // handles the signin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                if (UserRepository.ValidateUser(model.UserName, model.Password))
                {
                    // establishes a principal, set the session cookie and redirects
                    // you can also pass additional claims to signin, which will be embedded in the session token

                    return DoSignIn(
                        model.UserName, 
                        AuthenticationMethods.Password, 
                        model.ReturnUrl,
                        model.EnableSSO, 
                        ConfigurationRepository.Global.SsoCookieLifetime);
                }
            }

            ModelState.AddModelError("", Resources.AccountController.IncorrectCredentialsNoAuthorization);

            model.ShowClientCertificateLink = ConfigurationRepository.Global.EnableClientCertificateAuthentication;
            //return this.RedirectToLocal(model.ReturnUrl);
            return View(model);
        }

        private ActionResult DoSignIn(string userName, string authenticationMethod, string returnUrl, bool isPersistent, int ttl, IEnumerable<Claim> additionalClaims = null)
        {
            new AuthenticationHelper().SetSessionToken(
                userName,
                authenticationMethod,
                isPersistent,
                ttl,
                additionalClaims);

            return RedirectToLocal(returnUrl);
        }

        // handles client certificate based signin
        public ActionResult CertificateSignIn(string returnUrl)
        {
            if (!ConfigurationRepository.Global.EnableClientCertificateAuthentication)
            {
                return new HttpNotFoundResult();
            }

            var clientCert = HttpContext.Request.ClientCertificate;

            if (clientCert != null && clientCert.IsPresent && clientCert.IsValid)
            {
                string userName;
                if (UserRepository.ValidateUser(new X509Certificate2(clientCert.Certificate), out userName))
                {
                    // establishes a principal, set the session cookie and redirects
                    // you can also pass additional claims to signin, which will be embedded in the session token

                    return SignIn(
                        userName, 
                        AuthenticationMethods.X509, 
                        returnUrl, 
                        false, 
                        ConfigurationRepository.Global.SsoCookieLifetime);
                }
            }

            return View("Error");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
