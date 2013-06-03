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
using Microsoft.Mef.CommonServiceLocator;
using FACCTS.Controls.Interfaces;
using FACCTS.Controls.Views;

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
           // batch.AddExportedValue<ILogger>(new Logger());
            batch.AddExportedValue(container);
            ServiceLocatorContainer.Locator = new MefServiceLocator(container);
            container.Compose(batch);

            ILogger logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();
            logger.ErrorDialogShowing += ShowLoggerDialog;

        }

        private void ShowLoggerDialog(object sender, ShowDialogEventArgs e)
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<IShowExceptionDialogViewModel>();
            vm.Exception = e.Exception;
            ServiceLocatorContainer.Locator.GetInstance<IWindowManager>().ShowDialog(vm);
        }

        
        protected override IEnumerable<System.Reflection.Assembly> SelectAssemblies()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName[] anames = assembly.GetReferencedAssemblies();
            List<Assembly> result = new List<Assembly>() { assembly };
            result.AddRange(anames.Select(n => Assembly.Load(n)));
            return result.Where(a => a.GetAssemblyName().StartsWith("FACCTS")).ToArray();
        }

        protected override object GetInstance(Type serviceType, string key)
        {
            return ServiceLocatorContainer.Locator.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return ServiceLocatorContainer.Locator.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            container.SatisfyImportsOnce(instance);
        }

        protected override void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            base.OnUnhandledException(sender, e);
            ILogger logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();
            logger.Fatal("An unhandled Exception occured: ", e.Exception);
            e.Handled = true;
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            IWindowManager wm = ServiceLocatorContainer.Locator.GetInstance<IWindowManager>();
            UserLoginDialogView ul = ServiceLocatorContainer.Locator.GetInstance<IPasswordSupplier>() as UserLoginDialogView;
            ul.DataContext = ServiceLocatorContainer.Locator.GetInstance<UserLoginDialogViewModel>();
            ul.ShowDialog();
        }
    }
}
