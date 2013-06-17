using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    public class InvertedBooleanConverter : IValueConverter
    {
        private static Lazy<InvertedBooleanConverter> _lazy = new Lazy<InvertedBooleanConverter>(true);
        public static InvertedBooleanConverter Instance
        {
            get
            {
                return _lazy.Value;
            }
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        #endregion
    }
}
