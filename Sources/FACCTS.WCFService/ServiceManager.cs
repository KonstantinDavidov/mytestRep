using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.WCFService
{
    [Export(typeof(IServiceManager))]
    internal class ServiceManager : IServiceManager
    {
        private bool _disposed = false;

        [Import(typeof(IDataManager))]
        private IDataManager _dataManager;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataManager.Dispose();
                }

                _disposed = true;
            }
        }

        public void InsertManualIntegrationTask(ManualIntegrationTask task)
        {
            _dataManager.ManualIntegrationTaskRepository.Insert(task);
        }

        public void UpdateManualIntegrationTask(ManualIntegrationTask task)
        {
            _dataManager.ManualIntegrationTaskRepository.Update(task);
        }

        public void DeleteManualIntegrationTask(ManualIntegrationTask task)
        {
            _dataManager.ManualIntegrationTaskRepository.Delete(task);
        }

        public void DeleteManualIntegrationTask(int taskId)
        {
            _dataManager.ManualIntegrationTaskRepository.Delete(taskId);
        }
        
        public void InsertScheduledIntegrationTask(ScheduledIntegrationTask task)
        {
            _dataManager.ScheduledIntegrationTaskRepository.Insert(task);
        }

        public void UpdateScheduledIntegrationTask(ScheduledIntegrationTask task)
        {
            _dataManager.ScheduledIntegrationTaskRepository.Update(task);
        }

        public void DeleteScheduledIntegrationTask(ScheduledIntegrationTask task)
        {
            _dataManager.ScheduledIntegrationTaskRepository.Delete(task);
        }

        public void DeleteScheduledIntegrationTask(int taskId)
        {
            _dataManager.ScheduledIntegrationTaskRepository.Delete(taskId);
        }



        public void Commit()
        {
            _dataManager.Commit();
        }
    }
}
