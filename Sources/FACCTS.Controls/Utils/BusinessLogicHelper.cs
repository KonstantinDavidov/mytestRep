using Caliburn.Micro;
using FACCTS.Services;
using FACCTS.Services.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.Utils
{
    internal static class BusinessLogicHelper
    {
        private static readonly ILogger _logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();

        public static void CreateNewCase(object rootModel, IWindowManager windowManager)
        {
            _logger.InfoFormat("Creating a new case");
            bool? dialogResult;
            if ((dialogResult = windowManager.ShowDialog(rootModel)).GetValueOrDefault(false))
            {

            }
        }
    }
}
