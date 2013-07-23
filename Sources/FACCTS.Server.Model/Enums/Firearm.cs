using System;
using System.ComponentModel;
namespace FACCTS.Server.Model.Enums
{
    public enum Firearm
    {
        [Description("Both P and S")]
        B = 0,
        [Description("No Firearm Restrictions")]
        N = 1,
        [Description("Cannot Purchase or Receive")]
        P = 2,
        [Description("Must Surrender all")]
        S = 3
    }
}
