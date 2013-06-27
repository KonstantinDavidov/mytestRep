using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    public class FirstMiddleLastNameToFullNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null)
                return Binding.DoNothing;

            if (values.Length > 3)
            {
                throw new Exception("Person's attribute should contain Firs Name, Middle name and Last name (not more than 3 parts).");
            }
            return string.Format("{0} {1} {2}", values[0].ToString(), values[1].ToString(), values[2].ToString());
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
