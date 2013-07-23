using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FACCTS.Server.Common
{
    public class LoggerTraceListener : TraceListener
    {
        private ILog _logger;
        public LoggerTraceListener() : base()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            _logger = ServiceLocator.Current.GetInstance<ILog>();
        }

        public LoggerTraceListener(string name) : base(name)
        {
            Initialize();
        }

        public override void Write(string message)
        {
            _logger.Info(message);
        }

        public override void WriteLine(string message)
        {
            _logger.Info(message + Environment.NewLine);
        }

    }
}