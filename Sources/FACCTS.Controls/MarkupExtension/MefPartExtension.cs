using FACCTS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace FACCTS.Controls.MarkupExtension
{
    [MarkupExtensionReturnType(typeof(Object))]
    public class MefPartExtension : System.Windows.Markup.MarkupExtension
    {
        [ConstructorArgument("InstanceType")]
        public Type InstanceType { get; set; }

        public MefPartExtension()
        {
        }

        public MefPartExtension(string contract, Type instanceType)
        {
            this.InstanceType = instanceType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IEnumerable<Object> exports = ServiceLocatorContainer.Locator.GetAllInstances(this.InstanceType);

            if (!exports.Any()) return null;
            if (exports.Count() == 1) return exports.First();
            return exports;
        }
    }
}
