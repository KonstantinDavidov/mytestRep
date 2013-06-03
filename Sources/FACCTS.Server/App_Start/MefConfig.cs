using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;
using MEF.MVC4;
using log4net;
using FACCTS.Server.Model.DataModel;
using System.ComponentModel.Composition.Primitives;
using System.Web.Hosting;
using Thinktecture.IdentityServer.Repositories;
using Thinktecture.IdentityServer.Protocols.OAuth2;
using System.IO;
using FACCTS.Server.Common;
using Microsoft.Mef.CommonServiceLocator;

namespace FACCTS.Server
{
    public static class MefConfig
    {
        public static void RegisterMef()
        {
            var container = ConfigureContainer();

            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(container));
            
            var dependencyResolver = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver;
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new MefDependencyResolver(container);
            
        }

        private static CompositionContainer ConfigureContainer()
        {
            var path = HostingEnvironment.MapPath("~/bin");
            if (path == null) throw new Exception("Unable to find the path");
            var aggregateCatalog = new AggregateCatalog(new DirectoryCatalog(path, "FACCTS.Server.*.dll"));
            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(aggregateCatalog);
            Container.Current = container;
            RegisterInstances(container);
            ServiceLocator.Current = new MefServiceLocator(container);
            return container;
        }

        private static void RegisterInstances(CompositionContainer container)
        {
            var batch = new CompositionBatch();
            log4net.Config.XmlConfigurator.Configure();
            var loggerForWebSite = LogManager.GetLogger("FacctsService");
            batch.AddExportedValue<ILog>(loggerForWebSite);
            //batch.AddExportedValue<OAuth2AuthorizeController>(new OAuth2AuthorizeController());
            //batch.AddExportedValue<OAuth2TokenController>(new OAuth2TokenController());
            container.Compose(batch);
        }
    }
}