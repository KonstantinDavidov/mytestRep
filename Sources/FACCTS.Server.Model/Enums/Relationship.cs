using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum Relationship
    {
        [Description("Friend")]
        F = 0,
        [Description("Child")]
        C = 1,
        [Description("Parent")]
        P = 2,
        [Description("Sibling")]
        S = 3,
        [Description("Other Relative")]
        O = 4
    }
}
