using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Integration.Operations
{
    public interface IScheduledTaskOperaiton
    {
        void ProcessTask(ScheduledIntegrationTask task);
    }
}
