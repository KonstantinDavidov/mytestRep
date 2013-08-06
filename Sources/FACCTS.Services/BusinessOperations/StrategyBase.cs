using Faccts.Model.Entities;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
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
        }


        protected virtual IDataContainer DataContainer { get; private set; }
        protected virtual IAuthenticationService AuthenticationService { get; private set; }

        public abstract CourtCase Execute(CourtCase courtCase);
        
    }
}
