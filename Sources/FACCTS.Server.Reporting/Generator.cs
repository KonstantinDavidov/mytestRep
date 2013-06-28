using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Reporting
{
    public abstract class Generator<T> : IOrderGenerator where T : new() 
    {
        public abstract void Run(string pathToPdf, Dictionary<string, string> mapper, object data);
    }
}
