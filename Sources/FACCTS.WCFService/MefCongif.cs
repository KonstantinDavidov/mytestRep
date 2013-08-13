using FACCTS.Server.Common;
using log4net;
using Microsoft.Mef.CommonServiceLocator;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;

namespace FACCTS.WCFService
{
    internal static class MefCongif
    {
        public static void RegisterMef(object obj)
        {
            CompositionContainer container = GetCompositionContainer(obj);

            ServiceLocator.SetLocatorProvider(() => new MefServiceLocator(container)); 
        }

        private static CompositionContainer GetCompositionContainer(object obj)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog(path, "FACCTS.Server.*.dll"));

            var container = new CompositionContainer(catalog);
            container.ComposeParts(obj);

            var batch = new CompositionBatch();

            ILog logger = LogManager.GetLogger("FACCTS.WCFService");
            batch.AddExportedValue<ILog>(logger);
            container.Compose(batch);

            return container;
        }
    }
}