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
    }
}
