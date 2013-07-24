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
        public static string Validate(this IDataErrorInfo source, IDictionary<string, string> requiredFields, IDictionary<string, string> errors,  string propertyName)
        {
            string result = string.Empty;
            if (errors.ContainsKey(propertyName))
            {
                errors.Remove(propertyName);
            }
            if (requiredFields.ContainsKey(propertyName))
            {
                
                object propertyValue = source.GetProperty(propertyName);
                if (propertyValue is String && string.IsNullOrEmpty(propertyValue.ToString()) || propertyValue == null)
                {
                    result = string.Format("{0} can not be blank!", requiredFields[propertyName]);
                }
                else if (propertyValue is IDataErrorInfo)
                {
                    result = (propertyValue as IDataErrorInfo)[string.Empty];                        
                }
            }
            if (!string.IsNullOrEmpty(result))
            {
                errors.Add(propertyName, result);
            }
            return result;
        }

        public static string ValidateByPropertyName(this IDataErrorInfo source, IDictionary<string, string> requiredFields, IDictionary<string, string> errors, string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                string result = null;
                foreach (var kv in requiredFields)
                {
                    result = Validate(source, requiredFields, errors, kv.Key);
                    if (!string.IsNullOrEmpty(result))
                    {
                        break;
                    }
                }
                return result;
            }
            else
            {
                return Validate(source, requiredFields, errors, propertyName);
            }
        }
    }
}
