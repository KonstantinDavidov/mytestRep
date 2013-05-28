using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model
{
    public class NullStringConverter : StringConverter
    {
        public override object ConvertFromString(System.Globalization.CultureInfo culture, string text)
        {
            if (text.Equals("NULL"))
            {
                return null;
            }
            return base.ConvertFromString(culture, text);
        }
    }
}
