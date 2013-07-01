using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    [ValueConversion(typeof(Int32), typeof(Boolean))]
    public class Int32ToBooleanConverter : IValueConverter
    {
        private static Lazy<Int32ToBooleanConverter> _instance = new Lazy<Int32ToBooleanConverter>(true);
        public static Int32ToBooleanConverter Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            string checkValue = value.ToString();
            string targetValue = parameter.ToString();
            return checkValue.Equals(targetValue,
                     StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return null;

            bool useValue = (bool)value;
            string targetValue = parameter.ToString();
            if (useValue)
                return Int32.Parse(targetValue);

            return null;
        }
    }
}
