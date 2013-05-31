using FACCTS.Server.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Thinktecture.IdentityServer.Repositories;

namespace FACCTS.Server.Filters
{
    public class InitialConfigurationFilterAttribute : ActionFilterAttribute
    {
        
        public IConfigurationRepository ConfigurationRepository 
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IConfigurationRepository>();
            } 
        }

        private ILog _logger = ServiceLocator.Current.GetInstance<ILog>();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.MethodEntry("InitialConfigurationFilterAttribute.OnActionExecuting");

            if (!filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Equals("InitialConfiguration"))
            {
                if ((ConfigurationRepository.Keys.SigningCertificate == null))
                {
                    var route = new RouteValueDictionary(new Dictionary<string, object>
                        {
                            { "Controller", "InitialConfiguration" },
                        });

                    filterContext.Result = new RedirectToRouteResult(route);
                }
            }

            base.OnActionExecuting(filterContext);
            _logger.MethodExit("InitialConfigurationFilterAttribute.OnActionExecuting");
        }
    }
}