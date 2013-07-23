using FACCTS.Server.Common;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Integration;
using log4net;
using System;
using System.ComponentModel.Composition;

namespace FACCTS.WCFService
{
    public class IntegrationWCFService : IIntegrationWCFService
    {
        public IntegrationWCFService()
        {
            log4net.Config.XmlConfigurator.Configure();
            MefCongif.RegisterMef(this);
            _logger = ServiceLocator.Current.GetInstance<ILog>();
        }

        private ILog _logger;

        public void InsertManualIntegrationTask(ManualIntegrationTask task)
        {
            _logger.MethodEntry();
            try
            {
                using (var serviceManager = ServiceLocator.Current.GetInstance<IServiceManager>())
                {
                    serviceManager.InsertManualIntegrationTask(task);
                    serviceManager.Commit();
                }

                //run task processing asynchronously
                IntegrationTasksManager.Instance.ProcessNewManualTasksAsync();
            }
            catch (Exception exc)
            {
                _logger.FatalMethod(exc);
                throw;
            }
            _logger.MethodExit();
        }

        public void UpdateManualIntegrationTask(ManualIntegrationTask task)
        {
            _logger.MethodEntry();
            try
            {
                using (var serviceManager = ServiceLocator.Current.GetInstance<IServiceManager>())
                {
                    serviceManager.UpdateManualIntegrationTask(task);
                    serviceManager.Commit();
                }
            }
            catch (Exception exc)
            {
                _logger.FatalMethod(exc);
                throw;
            }
            _logger.MethodExit();
        }

        public void DeleteManualIntegrationTask(ManualIntegrationTask task)
        {
            _logger.MethodEntry();
            try
            {
                using (var serviceManager = ServiceLocator.Current.GetInstance<IServiceManager>())
                {
                    serviceManager.DeleteManualIntegrationTask(task);
                    serviceManager.Commit();
                }
            }
            catch (Exception exc)
            {
                _logger.FatalMethod(exc);
                throw;
            }
            _logger.MethodExit();
        }

        public void DeleteManualIntegrationTaskById(int taskId)
        {
            _logger.MethodEntry();
            try
            {
                using (var serviceManager = ServiceLocator.Current.GetInstance<IServiceManager>())
                {
                    serviceManager.DeleteManualIntegrationTask(taskId);
                    serviceManager.Commit();
                }
            }
            catch (Exception exc)
            {
                _logger.FatalMethod(exc);
                throw;
            }
            _logger.MethodExit();
        }


        public void InsertScheduledIntegrationTask(ScheduledIntegrationTask task)
        {
            _logger.MethodEntry();
            try
            {
                using (var serviceManager = ServiceLocator.Current.GetInstance<IServiceManager>())
                {
                    serviceManager.InsertScheduledIntegrationTask(task);
                    serviceManager.Commit();
                }
            }
            catch (Exception exc)
            {
                _logger.FatalMethod(exc);
                throw;
            }
            _logger.MethodExit();
        }

        public void UpdateScheduledIntegrationTask(ScheduledIntegrationTask task)
        {
            _logger.MethodEntry();
            try
            {
                using (var serviceManager = ServiceLocator.Current.GetInstance<IServiceManager>())
                {
                    serviceManager.UpdateScheduledIntegrationTask(task);
                    serviceManager.Commit();
                }

            }
            catch (Exception exc)
            {
                _logger.FatalMethod(exc);
                throw;
            }
            _logger.MethodExit();
        }

        public void DeleteScheduledIntegrationTask(ScheduledIntegrationTask task)
        {
            _logger.MethodEntry();
            try
            {
                using (var serviceManager = ServiceLocator.Current.GetInstance<IServiceManager>())
                {
                    serviceManager.DeleteScheduledIntegrationTask(task);
                    serviceManager.Commit();
                }
            }
            catch (Exception exc)
            {
                _logger.FatalMethod(exc);
                throw;
            }
            _logger.MethodExit();
        }

        public void DeleteScheduledIntegrationTaskById(int taskId)
        {
            _logger.MethodEntry();
            try
            {
                using (var serviceManager = ServiceLocator.Current.GetInstance<IServiceManager>())
                {
                    serviceManager.DeleteScheduledIntegrationTask(taskId);
                    serviceManager.Commit();
                }
            }
            catch (Exception exc)
            {
                _logger.FatalMethod(exc);
                throw;
            }
            _logger.MethodExit();
        }
    }
}