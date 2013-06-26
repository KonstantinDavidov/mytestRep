using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Integration.Operations
{
    [Export(typeof(IScheduledTaskOperaiton))]
    public class CommonScheduledTaskOperation : IScheduledTaskOperaiton
    {
        public void ProcessTask(Model.DataModel.ScheduledIntegrationTask task)
        {
            throw new NotImplementedException();
        }
    }
}
