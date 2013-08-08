using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services
{
    internal static class ReflectionHelper
    {
        public static string UriStringByPublicProperties(Object source)
        {
            StringBuilder sb = new StringBuilder();
            var propInfos = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            sb = propInfos.Aggregate(sb, (builder, item) =>
            {
                if (item.CanRead)
                {
                    MethodInfo mget = item.GetGetMethod(false);
                    if (mget != null)
                    {
                        var value = item.GetValue(source);
                        if (value != null)
                        {
                            builder.AppendFormat("{0}={1}&", WebUtility.UrlEncode(item.Name), WebUtility.UrlEncode(value.ToString()));
                        }
                    }
                }
                return builder;
            }
                );
            return sb.ToString().TrimEnd('&');
        }
    }
}
