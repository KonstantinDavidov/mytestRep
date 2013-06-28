using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace FACCTS.Server.Reporting
{
    public static class OrderGenerator
    {
        public static void GenerateOrder(object orderData)
        {
            Type orderType = orderData.GetType();
            string handlerTypeName = ConfigurationManager.AppSettings[orderType.Name];

            Type handlerType = Type.GetType(handlerTypeName);
            Type[] genericArgs = { orderType };

            //Type constructed = handlerType.MakeGenericType(genericArgs);

            if (handlerType != null)
            {
                IOrderGenerator generator = (IOrderGenerator)Activator.CreateInstance(handlerType);
                //generator.Run
            }
            else
            {
            }
        }
    }
}
