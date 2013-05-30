using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Common
{
    public class ServiceLocator
    {
        public static IServiceLocator Current { get; set; }
    }
}
