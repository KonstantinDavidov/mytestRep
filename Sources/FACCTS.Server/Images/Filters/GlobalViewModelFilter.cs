using FACCTS.Server.Common;
using log4net;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Authorization;
using Thinktecture.IdentityServer;
using Thinktecture.IdentityServer.Repositories;

namespace FACCTS.Server.Filters
{
    public class GlobalViewModelFilter : ActionFilterAttribute
    {
        private ILog _logger = ServiceLocator.Current.GetInstance<ILog>();

        public IConfigurationRepository ConfigurationRepository  
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IConfigurationRepository>();
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.MethodEntry("GlobalViewModelFilter.OnActionExecuting");
            filterContext.Controller.ViewBag.SiteName = ConfigurationRepository.Global.SiteName;
            filterContext.Controller.ViewBag.IsAdministrator = ClaimsAuthorization.CheckAccess(Thinktecture.IdentityServer.Constants.Actions.Administration, Thinktecture.IdentityServer.Constants.Resources.UI);
            filterContext.Controller.ViewBag.IsSignedIn = filterContext.HttpContext.User.Identity.IsAuthenticated;

            base.OnActionExecuting(filterContext);
            _logger.MethodExit("GlobalViewModelFilter.OnActionExecuting");
        }
    }
}