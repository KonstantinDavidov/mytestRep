using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Authorization.Mvc;
using Thinktecture.IdentityServer;

namespace FACCTS.Server.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        //[ClaimsAuthorize(Constants.Actions.Administration, Constants.Resources.Configuration)]
        public ActionResult Index()
        {
            return View();
        }
    }
}
