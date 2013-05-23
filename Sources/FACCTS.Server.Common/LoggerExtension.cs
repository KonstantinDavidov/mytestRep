using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Common
{
    public static class LoggerExtension
    {
        public static void MethodEntry(this ILog logger, [CallerMemberName]string methodName = null)
        {
            logger.InfoFormat("{0} started.", methodName);
        }

        public static void MethodEntry(this ILog logger, [CallerMemberName]string methodName = null, params object[] parameters)
        {
            string formatString = "{0} started. Parameters: ";
            int startIndex = 1;
            formatString = parameters.Aggregate(formatString, (str, par) =>
            {
                formatString += "{" + startIndex.ToString() + "}, ";
                startIndex++;
                return formatString;
            });
            logger.InfoFormat(formatString, methodName, parameters);
        }

        public static void MethodExit(this ILog logger, [CallerMemberName]string methodName = null)
        {
            logger.InfoFormat("{0} finished.", methodName);
        }
    }
}
