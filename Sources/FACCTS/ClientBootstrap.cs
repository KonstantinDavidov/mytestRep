using Caliburn.Micro;
using FACCTS.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Controls;
using FACCTS.Controls.ViewModels;
using FACCTS.Services.Logger;
using System.Dynamic;
using System.Windows;

namespace FACCTS
{
    public class ClientBootstrap : Bootstrapper<IShell>
    {
        public ClientBootstrap()
            : base(true)
        {

        }

        private CompositionContainer container;


        protected override void Configure()
        {
            AggregateCatalog catalog = new AggregateCatalog(
                    AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()
                    );
            container = new CompositionContainer(catalog);

            var batch = new CompositionBatch();

            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue<ILogger>(new Logger());
            batch.AddExportedValue(container);
            MefServiceLocator.Initialize(() => container);
            container.Compose(batch);

        }

        
        protected override IEnumerable<System.Reflection.Assembly> SelectAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => a.GetAssemblyName().StartsWith("FACCTS"))
                    .ToArray();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return MefServiceLocator.Instance.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return MefServiceLocator.Instance.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            container.SatisfyImportsOnce(instance);
        }

        protected override void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            base.OnUnhandledException(sender, e);
            ILogger logger = MefServiceLocator.Instance.GetInstance<ILogger>();
            logger.Fatal("An unhandled Exception occured: ", e.Exception);
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            var vm = MefServiceLocator.Instance.GetInstance<ShowExceptionDialogViewModel>();
            vm.Exception = e.Exception;
            MefServiceLocator.Instance.GetInstance<IWindowManager>().ShowDialog(vm, settings);
            e.Handled = true;
        }
    }
}
