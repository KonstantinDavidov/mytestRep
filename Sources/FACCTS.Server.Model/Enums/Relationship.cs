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
        F,
        [Description("Child")]
        C,
        [Description("Parent")]
        P,
        [Description("Sibling")]
        S,
        [Description("Other Relative")]
        O
    }
}
