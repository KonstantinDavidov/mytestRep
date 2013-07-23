using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    internal static class EntityExtensions
    {
        public static string Validate(this IDataErrorInfo source, IDictionary<string, string> requiredFields, string propertyName)
        {
            string result = string.Empty;
            if (requiredFields.ContainsKey(propertyName))
            {
                object propertyValue = source.GetProperty(propertyName);
                if (propertyValue is String && string.IsNullOrEmpty(propertyValue.ToString()) || propertyValue == null)
                {
                    result = string.Format("{0} can not be blank!", requiredFields[propertyName]);
                }
            }
            return result;
        }

        public static string ValidateByPropertyName(this IDataErrorInfo source, IDictionary<string, string> requiredFields, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                string result = null;
                foreach (var kv in requiredFields)
                {
                    result = Validate(source, requiredFields, kv.Key);
                    if (!string.IsNullOrEmpty(result))
                    {
                        break;
                    }
                }
                return result;
            }
            else
            {
                return Validate(source, requiredFields, propertyName);
            }
        }
    }
}
