using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum Designation
    {
        [Description("None")]
        None = 0,
        [Description("Plaintiff")]
        Plaintiff = 1,
        [Description("Respondent")]
        Respondent = 2
    }
}
