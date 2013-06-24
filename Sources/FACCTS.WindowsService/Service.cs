using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using FACCTS.WCFService;
using log4net;
using FACCTS.Server.Common;

namespace FACCTS.WindowsService
{
    public partial class Service : ServiceBase
    {
        private ServiceHost _serviceHost;

        private ILog _logger;

        public Service()
        {
            InitializeComponent();

            log4net.Config.XmlConfigurator.Configure();
            MefCongif.RegisterMef();

            _logger = ServiceLocator.Current.GetInstance<ILog>();
        }

        protected override void OnStart(string[] args)
        {
            _logger.Info("Starting FACCTS Windows service...");
            StartWCFService();
            _logger.Info("FACCTS Windows service started.");
        }

        protected override void OnStop()
        {
            _logger.Info("Stopping FACCTS WindowsService ...");
            StopWCFService();
            _logger.Info("FACCTS Windows service stopped.");
        }

        protected void StartWCFService()
        {
            _logger.Info("Hosting FACCTS WCF service ...");
            try
            {
                if (_serviceHost != null)
                    _serviceHost.Close();
                _serviceHost = new ServiceHost(typeof(IntegrationWCFService));
                _serviceHost.Open();
            }
            catch (Exception exc)
            {
                _logger.Fatal("Error occured while hosting FACCTS WCF service!", exc);
            }
            _logger.Info("FACCTS WCF service hosted.");
        }

        protected void StopWCFService()
        {
            _logger.Info("Stopping FACCTS WCF service ...");
            if (_serviceHost != null)
                _serviceHost.Close();
            _serviceHost = null;
            _logger.Info("FACCTS WCF service stopped.");
        }
    }
}
