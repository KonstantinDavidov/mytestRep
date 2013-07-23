using System;
using System.ComponentModel;


namespace FACCTS.Server.Model.Enums
{
    public enum CustodyParent
    {
        [Description("Mom")]
        Mom,
        [Description("Dad")]
        Dad,
        [Description("Other")]
        Other
    }
}
