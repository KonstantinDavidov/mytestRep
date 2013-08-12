using FACCTS.Server.DataContracts;
using log4net;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.BusinessLogic
{
    public abstract class BusinessOperationStrategyBase : IDisposable
    {
        public BusinessOperationStrategyBase()
            : base()
        {
            DataManager = ServiceLocator.Current.GetInstance<IDataManager>();
            Logger = ServiceLocator.Current.GetInstance<ILog>();
        }

        public abstract void Execute();

        protected virtual IDataManager DataManager { get; set; }

        protected ILog Logger { get; set; }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BusinessOperationStrategyBase()
        {
            Dispose(false);
        }


        private bool _wasDisposed = false;
        protected virtual void Dispose(bool isDisposing)
        {
            if (_wasDisposed)
                return;

            if (isDisposing)
            {
                if (DataManager != null)
                {
                    DataManager.Dispose();
                    DataManager = null;
                }
            }
            Logger = null;

            _wasDisposed = true;
        }
    }
}
