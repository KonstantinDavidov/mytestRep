using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum CaseHistoryEvent
    {
        [Description("File")]
        File = 0,
        [Description("Hearing")]
        Hearing = 1,
        [Description("Dropped")]
        Dropped = 2,
        [Description("Dismissed")]
        Dismissed = 3,
        [Description("Merged")]
        Merged = 4,
    }
}
