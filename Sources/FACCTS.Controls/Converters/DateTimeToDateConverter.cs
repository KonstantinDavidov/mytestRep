using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    public class DateTimeToDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Binding.DoNothing;
            if (value.GetType() != typeof(DateTime) && value.GetType() != typeof(DateTime?))
            {
                return Binding.DoNothing;
            }
            return ((DateTime)value).Date;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Binding.DoNothing;
            if (value.GetType() != typeof(DateTime) && value.GetType() != typeof(DateTime?))
            {
                return Binding.DoNothing;
            }
            return ((DateTime)value).Date;
        }
    }
}
