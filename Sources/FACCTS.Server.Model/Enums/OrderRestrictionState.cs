using System;
using System.ComponentModel;

namespace FACCTS.Server.Model
{
    public enum OrderRestrictionState
    {
        [Description("NotRequested")]
        NotRequested = 0,
        [Description("Denied")]
        Denied = 1,
        [Description("Granted")]
        Granted = 2
    }
}
