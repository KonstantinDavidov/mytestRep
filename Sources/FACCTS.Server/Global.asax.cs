//using FACCTS.Server.Code;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FACCTS.Server
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ConfigureMEF();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMEF()
        {
            MefConfig.RegisterMef();
            
        }

        //public static DatabaseKeyNonceStore KeyNonceStore { get; set; }

        public static FACCTS_DBEntities DataContext
        {
            get
            {
                FACCTS_DBEntities dataContext = DataContextSimple;
                if (dataContext == null)
                {
                    dataContext = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(FACCTS_DBEntities)) as FACCTS_DBEntities;
                    DataContextSimple = dataContext;
                }

                return dataContext;
            }
        }

        private static FACCTS_DBEntities DataContextSimple
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Items["DataContext"] as FACCTS_DBEntities;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items["DataContext"] = value;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}