using FACCTS.Server.App_Start;
using FACCTS.Server.Common;
using FACCTS.Server.Model;
//using FACCTS.Server.Code;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Data;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FACCTS.Server.DataContracts;
using Thinktecture.IdentityServer.Repositories;

namespace FACCTS.Server
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private ILog _logger;
        protected void Application_Start()
        {
            // create empty config database if it not exists
            DatabasesConfigure.ConfigureDB();

            // set the anti CSRF for name (that's a unqiue claim in our system)
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
            AreaRegistration.RegisterAllAreas();

            ConfigureMEF();
            _logger = ServiceLocator.Current.GetInstance<ILog>();
            _logger.Info("Application_Start started");
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, ServiceLocator.Current.GetInstance<IConfigurationRepository>());
            ProtocolConfig.RegisterProtocols(GlobalConfiguration.Configuration, RouteTable.Routes,
                ServiceLocator.Current.GetInstance<IConfigurationRepository>(), 
                ServiceLocator.Current.GetInstance<IUserRepository>(),
                ServiceLocator.Current.GetInstance<IRelyingPartyRepository>());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiApplication.DataManager = ServiceLocator.Current.GetInstance<IDataManager>();
        }

        private void ConfigureMEF()
        {
            MefConfig.RegisterMef();
            
        }

        public static IDataManager DataManager { private get; set; }


        protected void Application_End(object sender, EventArgs e)
        {
            _logger.Info("FACCTS shutting down...");

            // this would be automatic, but in partial trust scenarios it is not.
            log4net.LogManager.Shutdown();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            _logger = ServiceLocator.Current.GetInstance<ILog>();
            _logger.Fatal("An unhandled exception occurred in ASP.NET processing: " + Server.GetLastError(), Server.GetLastError());
            DataManager.Dispose();
            
        }
        
    }
}