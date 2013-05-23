using FACCTS.Server.Code;
using System.Web;
using System.Web.Mvc;

namespace FACCTS.Server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandlingAttribute());
        }
    }
}