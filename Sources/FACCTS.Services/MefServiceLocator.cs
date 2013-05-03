using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace FACCTS.Services
{
    public class MefServiceLocator : ServiceLocatorImplBase
    {

        private static Func<CompositionContainer> ContainerProvider;
        public static void Initialize(Func<CompositionContainer> containerProvider)
        {
            if (containerProvider == null)
            {
                throw new ArgumentNullException("containerProvider");
            }
            ContainerProvider = containerProvider;
        }


        public CompositionContainer CompositionContainer
        {
            get { return ContainerProvider.Invoke(); }
        }

        private static Lazy<MefServiceLocator> _instance = new Lazy<MefServiceLocator>(() => new MefServiceLocator(), true);
        public static MefServiceLocator Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        protected MefServiceLocator()
            : base()
        {

        }

        /// <summary>
        /// Resolves the instance of the requested service.
        /// </summary>
        /// <param name="serviceType">Type of instance requested.</param>
        /// <returns>The requested service instance.</returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            List<object> instances = new List<object>();

            IEnumerable<Lazy<object, object>> exports = CompositionContainer.GetExports(serviceType, null, null);
            if (exports != null)
            {
                instances.AddRange(exports.Select(export => export.Value));
            }

            return instances;
        }

        /// <summary>
        /// Resolves all the instances of the requested service.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <param name="key">Name of registered service you want. May be null.</param>
        /// <returns>Sequence of service instance objects.</returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            IEnumerable<Lazy<object, object>> exports = CompositionContainer.GetExports(serviceType, null, key);
            if ((exports != null) && (exports.Count() > 0))
            {
                // If there is more than one value, this will throw an InvalidOperationException, 
                // which will be wrapped by the base class as an ActivationException.
                return exports.Single().Value;
            }

            throw new ActivationException(
                this.FormatActivationExceptionMessage(new CompositionException("Export not found"), serviceType, key));
        }

    }
}
