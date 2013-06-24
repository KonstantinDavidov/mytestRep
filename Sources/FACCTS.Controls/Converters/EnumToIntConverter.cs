using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FACCTS.Controls.Converters
{
    public class EnumToIntConverter : IValueConverter
    {
        public Type EnumType { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null || value == null) return false;

            if (parameter.GetType().IsEnum && value is int)
            {
                return (int)parameter == (int)value;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is int))
                return false;

            object result;
            TryAsEnum(this.EnumType, (int)value, out result);
            return System.Convert.ChangeType(value, EnumType);
        }

        private static bool TryAsEnum(Type tEnum,int value, out object outEnum)
        {
            var enumType = tEnum;

            if (!enumType.IsEnum)
            {
                throw new InvalidOperationException(string.Format("{0} is not an enum type.", enumType.Name));
            }

            var valueAsUnderlyingType = System.Convert.ChangeType(value, Enum.GetUnderlyingType(enumType));

            if (Enum.IsDefined(enumType, valueAsUnderlyingType))
            {
                outEnum = Enum.ToObject(enumType, valueAsUnderlyingType);
                return true;
            }

            // IsDefined returns false if the value is multiple composed flags, so detect and handle that case

            if (enumType.GetCustomAttributes(typeof(FlagsAttribute), inherit: true).Any())
            {
                // Flags attribute set on the enum. Get the enum value.
                var enumValue = Enum.ToObject(enumType, valueAsUnderlyingType);

                // If a value outside the actual enum range is set, then ToString will result in a numeric representation (rather than a string one).
                // So if a number CANNOT be parsed from the ToString result, we know that only defined values have been set.
                decimal parseResult;
                if (!decimal.TryParse(enumValue.ToString(), out parseResult))
                {
                    outEnum = enumValue;
                    return true;
                }
            }

            outEnum = null;
            return false;
        }
    }
}
