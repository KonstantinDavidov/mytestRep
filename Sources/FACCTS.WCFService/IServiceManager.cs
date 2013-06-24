using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.WCFService
{
    interface IServiceManager : IDisposable
    {
        void InsertManualIntegrationTask(ManualIntegrationTask task);

        void UpdateManualIntegrationTask(ManualIntegrationTask task);

        void DeleteManualIntegrationTask(ManualIntegrationTask task);

        void DeleteManualIntegrationTask(int taskId);

        void InsertScheduledIntegrationTask(ScheduledIntegrationTask task);

        void UpdateScheduledIntegrationTask(ScheduledIntegrationTask task);

        void DeleteScheduledIntegrationTask(ScheduledIntegrationTask task);

        void DeleteScheduledIntegrationTask(int taskId);

        void Commit();
    }
}
