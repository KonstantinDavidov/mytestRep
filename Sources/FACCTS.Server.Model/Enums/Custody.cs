using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum Custody
    {
        [Description("Joint Custody")]
        JT = 0,
        [Description("Other Party")]
        OP = 1,
        [Description("Protected Person")]
        PP = 2,
        [Description("Restrained Person")]
        RP = 3
    }
}
