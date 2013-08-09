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

        public static bool CreateNewCase(object rootModel, IWindowManager windowManager)
        {
            _logger.InfoFormat("Creating a new case");
            return windowManager.ShowDialog(rootModel).GetValueOrDefault(false);
        }

        private static string _chars = "0123456789";
        private static Random _random = new Random();
        public static string AutoGenerateCaseNumber()
        {
            var result = new string(
                Enumerable.Repeat(_chars, 6)
                .Select(s => s[_random.Next(s.Length)])
                .ToArray());
            result = result.Insert(2, "-");
            return result;
        }
    }
}
