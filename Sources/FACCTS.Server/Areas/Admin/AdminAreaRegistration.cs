using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace FACCTS.Server.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public static string ControllerOnly = "ApiControllerOnly";
        public static string ControllerAndId = "ApiControllerAndIntegerId";
        public static string ControllerAction = "ApiControllerAction";
        public static string ControllerActionId = "ApiControllerActionId";

        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }
        
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                name: ControllerOnly,
                routeTemplate: "Admin/api/{controller}"
            );

            context.Routes.MapHttpRoute(
                name: ControllerAndId,
                routeTemplate: "Admin/api/{controller}/{id}",
                defaults: null, //defaults: new { id = RouteParameter.Optional } //,
                constraints: new { id = @"^\d+$" } // id must be all digits
            );
            context.Routes.MapHttpRoute(
                name: ControllerAction,
                routeTemplate: "Admin/api/{controller}/{action}"
            );
            context.Routes.MapHttpRoute(
                name: ControllerActionId,
                routeTemplate: "Admin/api/{controller}/{action}/{id}",
                defaults: null//, //defaults: new { id = RouteParameter.Optional } //,
                //constraints: new { id = @"^\d+$" } // id must be all digits
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
