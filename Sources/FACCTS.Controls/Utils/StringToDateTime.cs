using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.Utils
{
    public static class StringToDateTime
    {
        public static DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public static DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }

        public static DateTime TwentyYearsAgo
        {
            get
            {
                return DateTime.Today.Subtract(TimeSpan.FromDays(20 * 365));
            }
        }
    }
}
