using FACCTS.Server.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Authorization;
using Thinktecture.IdentityServer;
using Thinktecture.IdentityServer.Repositories;

namespace FACCTS.Server.GlobalFilter
{
    public class GlobalViewModelFilter : ActionFilterAttribute
    {
        
        public IConfigurationRepository ConfigurationRepository  
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IConfigurationRepository>();
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            filterContext.Controller.ViewBag.SiteName = ConfigurationRepository.Global.SiteName;
            filterContext.Controller.ViewBag.IsAdministrator = ClaimsAuthorization.CheckAccess(Constants.Actions.Administration, Constants.Resources.UI);
            filterContext.Controller.ViewBag.IsSignedIn = filterContext.HttpContext.User.Identity.IsAuthenticated;

            base.OnActionExecuting(filterContext);
        }
    }
}