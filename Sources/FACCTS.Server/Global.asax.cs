//using FACCTS.Server.Code;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Services;
using log4net;
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
        private ILog _logger;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ConfigureMEF();
            _logger = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILog)) as ILog;
            _logger.Info("Application_Start started");
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiApplication.DataManager = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IDataManager)) as IDataManager;
        }

        private void ConfigureMEF()
        {
            MefConfig.RegisterMef();
            
        }

        public static IDataManager DataManager { private get; set; }

        public static OAuth_Users LoggedInUser
        {
            get { return DataManager.UsersRepository.Get(user => user.OpenIDClaimedIdentifier == HttpContext.Current.User.Identity.Name).SingleOrDefault(); }
        }


        protected void Application_End(object sender, EventArgs e)
        {
            _logger.Info("FACCTS shutting down...");

            // this would be automatic, but in partial trust scenarios it is not.
            log4net.LogManager.Shutdown();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            _logger.Fatal("An unhandled exception occurred in ASP.NET processing: " + Server.GetLastError(), Server.GetLastError());
            DataManager.Dispose();
            
        }
        
    }
}