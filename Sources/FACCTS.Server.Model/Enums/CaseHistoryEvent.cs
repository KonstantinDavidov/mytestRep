using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum CaseHistoryEvent
    {
        [Description("New")]
        New = 0,
        [Description("Hearing")]
        Hearing = 1,
        [Description("Dropped")]
        Dropped = 2,
        [Description("Dismissed")]
        Dismissed = 3,
        [Description("Merged")]
        Merged = 4,
        [Description("Reissued")]
        Reissued = 5,
    }
}
