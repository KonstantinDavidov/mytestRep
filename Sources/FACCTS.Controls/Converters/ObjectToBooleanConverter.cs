using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    public class ObjectToBooleanConverter : IValueConverter
    {
        private static Lazy<ObjectToBooleanConverter> _lazy = new Lazy<ObjectToBooleanConverter>(true);
        public static ObjectToBooleanConverter Instance
        {
            get
            {
                return _lazy.Value;
            }
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
