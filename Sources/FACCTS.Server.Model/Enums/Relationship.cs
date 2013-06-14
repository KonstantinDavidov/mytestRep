using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum Relationship
    {
        [Description("Friend")]
        Friend,
        [Description("Child")]
        Child,
        [Description("Parent")]
        Parent,
        [Description("Sibling")]
        Sibling,
        [Description("Other Relative")]
        OtherRelative,
    }
}
