using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum CaseStatus
    {
        [Description("New")]
        New = 0,
        [Description("Active")]
        Active = 1,
        [Description("Dropped")]
        Dropped = 2,
        [Description("Dismissed")]
        Dismissed = 3,
        [Description("Reissued")]
        Reissued = 4,
    }
}
