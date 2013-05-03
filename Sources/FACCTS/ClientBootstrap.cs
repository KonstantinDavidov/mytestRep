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
            batch.AddExportedValue(container);
            MefServiceLocator.Initialize(() => container);
            container.Compose(batch);

        }

        private Assembly[] _assemblies;
        protected override IEnumerable<System.Reflection.Assembly> SelectAssemblies()
        {
            if (_assemblies == null)
            {
                _assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => a.GetAssemblyName().StartsWith("FACCTS"))
                    .ToArray();
            }
            return _assemblies;
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
    }
}
