using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model
{
    public static class StringExtensions
    {
        public static string ThisOrEmpty(this string source)
        {
            return (source ?? string.Empty);
        }

    }
}
