using System;
using System.ComponentModel;


namespace FACCTS.Server.Model.OrderModels
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
