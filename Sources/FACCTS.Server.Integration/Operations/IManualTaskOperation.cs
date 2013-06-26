using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Integration.Operations
{
    public interface IManualTaskOperation
    {
        void ProcessTask(ManualIntegrationTask task);
    }
}
