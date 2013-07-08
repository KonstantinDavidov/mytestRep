using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum MasterOrders
    {
        [Description("DV110 - Temporary restraining Order")]
        DV110 = 1,
        [Description("DV130 - Restraining Order")]
        DV130 = 2,
        [Description("CH110 - Civil Harrasment")]
        CH110 = 3,
        [Description("Ch130 - Civil Harrasment")]
        CH130= 4,
        [Description("EA110 - Eldery Abuse")]
        EA110 = 5,
        [Description("EA130 - Eldery Abuse")]
        EA130 = 6,
        [Description("Renew")]
        [Browsable(false)]
        DV730 = 7,
        [Description("Reissuance")]
        [Browsable(false)]
        DV115 = 8,
        [Description("Continuance")]
        [Browsable(false)]
        DV116 = 9,
    }
}
