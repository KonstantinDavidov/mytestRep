using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Logger
{
    [Export(typeof(ILogger))]
    public class Logger : ILogger
    {
        private ILog _logger;
        public Logger()
        {
            log4net.GlobalContext.Properties["LogFileName"] = "FACCTS.xml";
            log4net.Config.XmlConfigurator.Configure();
            _logger = log4net.LogManager.GetLogger(this.GetType());
        }

        public void Info(string message)
        {
            if (!_logger.IsInfoEnabled)
                return;
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            if (!_logger.IsWarnEnabled)
                return;
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            if (!_logger.IsErrorEnabled)
                return;
            _logger.Error(message);
        }

        public void Error(string message, Exception ex)
        {
            if (!_logger.IsErrorEnabled)
                return;
            _logger.Error(message, ex);
            RaiseErrorDialogShowing(ex);
        }

        public void Fatal(string message)
        {
            if (!_logger.IsFatalEnabled)
                return;
            _logger.Fatal(message);
        }

        public void Fatal(string message, Exception ex)
        {
            if (!_logger.IsFatalEnabled)
                return;
            _logger.Fatal(message, ex);
            RaiseErrorDialogShowing(ex);
        }

        private void RaiseErrorDialogShowing(Exception ex)
        {
            if (ErrorDialogShowing != null)
            {
                ErrorDialogShowing(this, new ShowDialogEventArgs(ex));
            }
        }

        public event EventHandler<ShowDialogEventArgs> ErrorDialogShowing;
    }
}
