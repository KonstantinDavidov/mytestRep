using FACCTS.Server.Common;
using log4net;
using Microsoft.Mef.CommonServiceLocator;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;

namespace FACCTS.WindowsService
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
            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Service)).Location);

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(path, "FACCTS.Server.*.dll"));
            catalog.Catalogs.Add(new DirectoryCatalog(path, "FACCTS.WCFService.dll"));

            var container = new CompositionContainer(catalog);
            container.ComposeParts(obj);

            var batch = new CompositionBatch();

            ILog logger = LogManager.GetLogger("FACCTS.WindowsService");
            batch.AddExportedValue<ILog>(logger);
            container.Compose(batch);

            return container;
        }
    }
}
