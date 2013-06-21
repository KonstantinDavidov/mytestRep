using FACCTS.Server.Common;
using log4net;
using Microsoft.Mef.CommonServiceLocator;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;

namespace FACCTS.WindowsService
{
    internal static class MefCongif
    {
        public static void RegisterMef()
        {
            CompositionContainer container = GetCompositionContainer();

            ServiceLocator.Current = new MefServiceLocator(container);
        }

        private static CompositionContainer GetCompositionContainer()
        {
            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Service)).Location);

            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(path, "FACCTS.Server.*.dll"));

            var container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            ILog logger = LogManager.GetLogger("FACCTS.WindowsService");
            batch.AddExportedValue<ILog>(logger);
            container.Compose(batch);

            return container;
        }
    }
}
