using FACCTS.Server.Code;
using FACCTS.Server.Filters;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityServer.Repositories;

namespace FACCTS.Server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IConfigurationRepository configuration)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandlingAttribute());

            filters.Add(new GlobalViewModelFilter());
            filters.Add(new SslRedirectFilterAttribute(configuration.Global.HttpsPort));
            //filters.Add(new InitialConfigurationFilterAttribute());
        }
    }
}