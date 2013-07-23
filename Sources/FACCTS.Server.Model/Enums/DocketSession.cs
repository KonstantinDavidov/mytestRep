using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum DocketSession
    {
        [Description("AM")]
        AM = 0,
        [Description("PM")]
        PM = 1,
    }
}
