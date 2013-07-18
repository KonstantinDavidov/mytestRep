using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    public class DataContextMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length != 2 )
            {
                throw new Exception("DataContextMultiValueConverter works only with two values");
            }
            values.Aggregate(0, (index, v) =>
                {
                    if (v == DependencyProperty.UnsetValue || v == Binding.DoNothing)
                        values[index] = null;
                    return ++index;
                }
                );
            
            int priorityValueToChoose = parameter != null ? System.Convert.ToInt32(parameter) : 0;//zero-based
            if ((priorityValueToChoose < 0) || (priorityValueToChoose > 1))
            {
                throw new Exception("Converter parameter must be 0 or 1");
            }
            return values[priorityValueToChoose] ?? values[1 - priorityValueToChoose];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
