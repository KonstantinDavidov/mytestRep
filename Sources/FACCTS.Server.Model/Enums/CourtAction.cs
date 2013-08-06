using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum CourtAction
    {
        [Description("Pending for Service")]
        PendingForService = 0,
        [Description("Docketed")]
        Docketed = 1,
        [Description("Reissue")]
        Reissue = 2,
        [Description("Continuance")]
        Continuance = 3,
        [Description("Renew")]
        Renew = 4,
        [Description("Order")]
        Order = 5,
        [Description("Show Motion")]
        ShowMotion = 6,
        [Description("Dismissed")]
        Dismissed = 7,
        [Description("Dropped")]
        Dropped = 8,
    }
}
