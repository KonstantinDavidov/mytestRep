using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.WCFService
{
    [ServiceContract]
    public interface IIntegrationWCFService
    {
        [OperationContract]
        void InsertManualIntegrationTask(ManualIntegrationTask task);

        [OperationContract]
        void UpdateManualIntegrationTask(ManualIntegrationTask task);

        [OperationContract]
        void DeleteManualIntegrationTask(ManualIntegrationTask task);

        [OperationContract]
        void DeleteManualIntegrationTaskById(int taskId);

        [OperationContract]
        void InsertScheduledIntegrationTask(ScheduledIntegrationTask task);

        [OperationContract]
        void UpdateScheduledIntegrationTask(ScheduledIntegrationTask task);

        [OperationContract]
        void DeleteScheduledIntegrationTask(ScheduledIntegrationTask task);

        [OperationContract]
        void DeleteScheduledIntegrationTaskById(int taskId);
    }
}
