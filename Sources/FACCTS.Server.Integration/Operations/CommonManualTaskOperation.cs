using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Integration.Operations
{
    [Export(typeof(IManualTaskOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    internal class CommonManualTaskOperation : IManualTaskOperation
    {
        public void ProcessTask(ManualIntegrationTask task)
        {
            throw new NotImplementedException();
        }
    }
}