using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    public class NullableBoolleanToBooleanConverter : IValueConverter
    {

        private static Lazy<NullableBoolleanToBooleanConverter> _lazy = new Lazy<NullableBoolleanToBooleanConverter>(true);
        public static NullableBoolleanToBooleanConverter Instance
        {
            get
            {
                return _lazy.Value;
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool defaultValue = false;
            if (parameter is Boolean)
            {
                defaultValue = (bool)parameter;
            }
            if (value != null && !(value is bool?))
            {
                return Binding.DoNothing;
            }

            bool? v = (bool?)value;
            return v.GetValueOrDefault(defaultValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
