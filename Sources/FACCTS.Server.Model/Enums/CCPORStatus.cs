using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum CCPORStatus
    {
        [Description("None")]
        None = 0,
        [Description("Add")]
        Add,
        [Description("Pending")]
        Pending,
        [Description("Update")]
        Update,
        [Description("Modify")]
        Modify,
        [Description("Reject")]
        Reject,
    }
}
