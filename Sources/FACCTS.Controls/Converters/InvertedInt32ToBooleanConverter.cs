using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    [ValueConversion(typeof(Int32), typeof(Boolean))]
    public class InvertedInt32ToBooleanConverter : IValueConverter
    {
        private static Lazy<InvertedInt32ToBooleanConverter> _instance = new Lazy<InvertedInt32ToBooleanConverter>(true);
        public static InvertedInt32ToBooleanConverter Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)Int32ToBooleanConverter.Instance.Convert(value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)Int32ToBooleanConverter.Instance.ConvertBack(value, targetType, parameter, culture);
        }
    }
}
