using Faccts.Model.Entities;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using FACCTS.Services.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.BusinessOperations
{
    public abstract class StrategyBase
    {
        protected StrategyBase()
        {
            DataContainer = ServiceLocatorContainer.Locator.GetInstance<IDataContainer>();
            AuthenticationService = ServiceLocatorContainer.Locator.GetInstance<IAuthenticationService>();
            Logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();
        }


        protected virtual IDataContainer DataContainer { get; private set; }
        protected virtual IAuthenticationService AuthenticationService { get; private set; }
        protected virtual ILogger Logger { get; private set; }

        public abstract void Execute();
        
    }
}
