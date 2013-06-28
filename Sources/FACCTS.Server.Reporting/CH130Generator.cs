using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Reporting;
using FACCTS.Server.Model.OrderModels;

namespace FACCTS.Server.Reporting
{
    public class CH130Generator : Generator<CH130>
    {
        public override void Run(string pathToPdf, Dictionary<string, string> mapper, CH130 data)
        {
            throw new NotImplementedException();
        }
    }
}
