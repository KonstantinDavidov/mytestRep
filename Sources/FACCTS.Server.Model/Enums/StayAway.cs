using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum StayAway
    {
        [Description("Child's school / day care")]
        C = 0,
        [Description("Protected person")]
        P = 1,
        [Description("Residence")]
        R = 2,
        [Description("Protected person's vehicle")]
        V = 3,
        [Description("Workplace")]
        W = 4,
        [Description("All")]
        A = 5

    }
}
