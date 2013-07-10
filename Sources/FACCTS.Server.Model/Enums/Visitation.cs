using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum Visitation
    {
        [Description("No")]
        N = 0,
        [Description("Yes")]
        Y = 1,
        [Description("Supervised")]
        S = 2
    }
}
