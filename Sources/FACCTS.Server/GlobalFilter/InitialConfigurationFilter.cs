using FACCTS.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Thinktecture.IdentityServer.Repositories;

namespace FACCTS.Server.GlobalFilter
{
    public class InitialConfigurationFilter : ActionFilterAttribute
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
        }
    }
}