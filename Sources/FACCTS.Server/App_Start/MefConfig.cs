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
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(assemblyCatalog);
            RegisterInstances(container);
            
            return container;
        }

        private static void RegisterInstances(CompositionContainer container)
        {
            var batch = new CompositionBatch();
            log4net.Config.XmlConfigurator.Configure();
            var loggerForWebSite = LogManager.GetLogger("FacctsService");
            batch.AddExportedValue<ILog>(loggerForWebSite);
            batch.AddExportedValue<FACCTS_DBEntities>(new FACCTS_DBEntities());
            container.Compose(batch);
        }
    }
}