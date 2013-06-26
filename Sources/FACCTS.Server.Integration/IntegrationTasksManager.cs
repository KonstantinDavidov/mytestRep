using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using log4net;
using FACCTS.Server.Common;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Integration.Operations;
using System.ComponentModel.Composition;

namespace FACCTS.Server.Integration
{
    [Export]
    public class IntegrationTasksManager
    {
        private IntegrationTasksManager()
        {
            double timerInterval;
            _logger = ServiceLocator.Current.GetInstance<ILog>();

            _manualTasksTimer = new Timer();
            if (!double.TryParse(ConfigurationManager.AppSettings["manualTaskTimerInterval"], out timerInterval))
                timerInterval = 60 * 1000;
            _manualTasksTimer.Interval = timerInterval;
            _manualTasksTimer.AutoReset = true;
            _manualTasksTimer.Elapsed += ManualTasksTimer_Elapsed;

            _scheduledTasksTimer = new Timer();
            if (!double.TryParse(ConfigurationManager.AppSettings["scheduledTaskTimerInterval"], out timerInterval))
                timerInterval = 5 * 60 * 1000;
            _scheduledTasksTimer.Interval = timerInterval;
            _scheduledTasksTimer.AutoReset = true;
            _scheduledTasksTimer.Elapsed += ScheduledTasksTimer_Elapsed;
        }

        private ILog _logger;

        private static volatile IntegrationTasksManager _instance;

        private static readonly object _instanceLock = new object();

        private static readonly object _mTasksLock = new object();

        private static readonly object _sTasksLock = new object();

        private Timer _manualTasksTimer;

        private Timer _scheduledTasksTimer;

        [ImportMany(typeof(IManualTaskOperation))]
        private IEnumerable<IManualTaskOperation> _mTasksOperations;

        [ImportMany(typeof(IScheduledTaskOperaiton))]
        private IEnumerable<IScheduledTaskOperaiton> _sTasksOperations;

        public static IntegrationTasksManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = ServiceLocator.Current.GetInstance<IntegrationTasksManager>();
                        }
                    }
                }
                return _instance;
            }
        }

        private IDataManager GetDataManager()
        {
            return ServiceLocator.Current.GetInstance<IDataManager>();
        }

        public static void Start()
        {
            Instance._manualTasksTimer.Start();
            Instance._scheduledTasksTimer.Start();
            Instance._logger.Info("Tasks processing started.");
        }

        public static void Stop()
        {
            Instance._manualTasksTimer.Stop();
            Instance._scheduledTasksTimer.Stop();
            Instance._logger.Info("Tasks processing stopped.");
        }

        public void ChangeManualTaskTimerInterval(double interval)
        {
            Instance._manualTasksTimer.Stop();
            Instance._manualTasksTimer.Interval = interval;
            Instance._manualTasksTimer.Start();
        }

        public void ChangeScheduledTaskTimerInterval(double interval)
        {
            Instance._scheduledTasksTimer.Stop();
            Instance._scheduledTasksTimer.Interval = interval;
            Instance._scheduledTasksTimer.Start();
        }

        public void ProcessNewManualTasksAsync()
        {
            _logger.Info("Manual tasks processing invoked");
            Task task = new Task(() => StartManualTasksExecution(PrepareManualTasks()));
            task.Start();
        }

        private void ManualTasksTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Info("ManualTasksTimer elapsed");
            List<ManualIntegrationTask> readyTasks = PrepareManualTasks();
            if (readyTasks.Count > 0)
            {
                _logger.Info(string.Format("Found group of {0} manual tasks ready to run", readyTasks.Count));
                StartManualTasksExecution(readyTasks);
            }
        }

        private void ScheduledTasksTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Info("ScheduledTasksTimer elapsed");
            List<ScheduledIntegrationTask> readyTasks = PrepareScheduledTasks();
            if (readyTasks.Count > 0)
            {
                _logger.Info(string.Format("Found group of {0} scheduled tasks ready to run", readyTasks.Count));
                StartScheduledTasksExecution(readyTasks);
            }
        }

        /// <summary>
        /// Prepares manual tasks before execution
        /// </summary>
        /// <returns>tasks, whitch are ready to be executed</returns>
        private List<ManualIntegrationTask> PrepareManualTasks()
        {
            List<ManualIntegrationTask> mTasks;
            lock (_mTasksLock)
            {
                using (var dataManager = GetDataManager())
                {
                    mTasks =
                        dataManager.ManualIntegrationTaskRepository.GetAll()
                        .Where(t => t.State == IntegrationTaskState.Placed).ToList();
                    foreach (var task in mTasks)
                    {
                        task.State = IntegrationTaskState.Ready;
                    }
                    dataManager.Commit();
                }
            }
            return mTasks;
        }

        /// <summary>
        /// Prepares scheduled tasks before execution
        /// </summary>
        /// <returns>tasks, whitch are ready to be executed</returns>
        private List<ScheduledIntegrationTask> PrepareScheduledTasks()
        {
            List<ScheduledIntegrationTask> sTasks;
            lock (_sTasksLock)
            {
                using (var dataManager = GetDataManager())
                {
                    sTasks = dataManager.ScheduledIntegrationTaskRepository.GetAll()
                        .Where(t =>
                            t.State != IntegrationTaskState.Running &&
                            t.State != IntegrationTaskState.Ready &&
                            t.StartTime < DateTime.Now &&
                            t.Enabled).ToList();
                    foreach (var task in sTasks)
                    {
                        task.State = IntegrationTaskState.Ready;
                    }
                    dataManager.Commit();
                }
            }
            return sTasks;
        }

        private void StartManualTasksExecution(List<ManualIntegrationTask> readyTasks)
        {
            Parallel.ForEach(readyTasks, t => ExecuteManualTask(t));
        }

        private void ExecuteManualTask(ManualIntegrationTask task)
        {
            task.State = IntegrationTaskState.Running;
            task.StartTime = DateTime.Now;

            using (var dataManager = GetDataManager())
            {
                dataManager.ManualIntegrationTaskRepository.Update(task);
                dataManager.Commit();
            }

            try
            {
                _logger.Info(string.Format("Executing manual task {0}", task.Id));
                _mTasksOperations.FirstOrDefault().ProcessTask(task);
                task.State = IntegrationTaskState.Finished;
            }
            catch (Exception exc)
            {
                string errorText = string.Format("Exception occured during manual task {0} execution", task.Id);
                _logger.Error(errorText, exc);
                task.State = IntegrationTaskState.Error;
                task.Info = errorText + "\n" + exc.ToString();
            }
            finally
            {
                task.EndTime = DateTime.Now;
                _logger.Info(string.Format("Manual task {0} execution finished", task.Id));
            }

            using (var dataManager = GetDataManager())
            {
                dataManager.ManualIntegrationTaskRepository.Update(task);
                dataManager.Commit();
            }
        }

        private void StartScheduledTasksExecution(List<ScheduledIntegrationTask> readyTasks)
        {
            Parallel.ForEach(readyTasks, t => ExecuteScheduledTask(t));
        }

        private void ExecuteScheduledTask(ScheduledIntegrationTask task)
        {
            task.State = IntegrationTaskState.Running;

            using (var dataManager = GetDataManager())
            {
                dataManager.ScheduledIntegrationTaskRepository.Update(task);
                dataManager.Commit();
            }

            try
            {
                _logger.Info(string.Format("Executing scheduled task {0}", task.Id));
                _sTasksOperations.FirstOrDefault().ProcessTask(task);
                task.State = IntegrationTaskState.Finished;
            }
            catch (Exception exc)
            {
                string errorText = string.Format("Exception occured during scheduled task {0} execution", task.Id);
                _logger.Error(errorText, exc);
                task.State = IntegrationTaskState.Error;
                task.Info = errorText + "\n" + exc.ToString();
            }
            finally
            {
                task.StartTime += task.GetRepeatTimeInterval();
                _logger.Info(string.Format("Manual task {0} execution finished", task.Id));
            }

            using (var dataManager = GetDataManager())
            {
                dataManager.ScheduledIntegrationTaskRepository.Update(task);
                dataManager.Commit();
            }
        }
    }
}