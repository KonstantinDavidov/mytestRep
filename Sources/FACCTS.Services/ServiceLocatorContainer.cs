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
    public static class ServiceLocatorContainer
    {
        public static IServiceLocator Locator { get; set; }    
    }
}
