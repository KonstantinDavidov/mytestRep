using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition.Hosting;
using Microsoft.Mef.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;
using FACCTS.Server.Code;
using FACCTS.Server.Data;
using System.Reflection;
using log4net;
using System.Web;
using Rhino.Mocks;

namespace FACCTS.Server.Tests.Controllers
{
    [TestClass]
    public class ControllerTestBase
    {
        protected static CompositionContainer Contailer { get; private set; }

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            AggregateCatalog aggregate = new AggregateCatalog(
                new AssemblyCatalog(Assembly.LoadFrom("FACCTS.Server.dll")),
                new AssemblyCatalog(Assembly.LoadFrom("FACCTS.Server.Data.dll")),
                new AssemblyCatalog(Assembly.LoadFrom("FACCTS.Server.DataContracts.dll"))
                );
            Contailer = new CompositionContainer(aggregate);
            InitializeContainerData();
            
            MefServiceLocator locator = new MefServiceLocator(Contailer);
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        protected static void InitializeContainerData()
        {
            var batch = new CompositionBatch();
            log4net.Config.XmlConfigurator.Configure();
            var loggerForWebSite = LogManager.GetLogger("FacctsServiceTest");
            batch.AddExportedValue<ILog>(loggerForWebSite);
            Contailer.Compose(batch);
        }
        
    }
}
