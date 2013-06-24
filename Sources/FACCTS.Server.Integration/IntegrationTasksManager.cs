using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using log4net;
using FACCTS.Server.Common;

namespace FACCTS.Server.Integration
{
    public class IntegrationTasksManager
    {
        private IntegrationTasksManager()
        {
            double timerInterval;
            _logger = ServiceLocator.Current.GetInstance<ILog>();

            _manualTasksTimer = new Timer();
            if (!double.TryParse(ConfigurationManager.AppSettings["manualTaskTimerInterval"], out timerInterval))
                timerInterval = 10000;
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

        private static object _lock = new object();

        private Timer _manualTasksTimer;

        private Timer _scheduledTasksTimer;

        public static IntegrationTasksManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new IntegrationTasksManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public static void Start()
        {
            Instance._manualTasksTimer.Start();
            Instance._scheduledTasksTimer.Start();
        }

        public static void Stop()
        {
            Instance._manualTasksTimer.Stop();
            Instance._scheduledTasksTimer.Stop();
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

        private void ScheduledTasksTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }

        private void ManualTasksTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }
    }
}