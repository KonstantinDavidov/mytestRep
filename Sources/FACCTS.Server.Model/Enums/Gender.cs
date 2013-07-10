using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum Gender
    {
        [Description( "Male")]
        M = 0,
        [Description("Female")]
        F = 1,
        [Description("Unknown")]
        X = 2
    }
}
