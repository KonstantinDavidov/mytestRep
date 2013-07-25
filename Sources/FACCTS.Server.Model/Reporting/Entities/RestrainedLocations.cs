using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    [Flags]
    public enum RestrainedLocations
    {
        [Description("County")]
        County = 0,
        [Description("California")]
        California = 0x0001,
        [Description("United States")]
        US = 0x0002,
        [Description("Other")]
        Other = 0x0004
    }
}
