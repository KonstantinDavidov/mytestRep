using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum CaseHistoryEvent
    {
        [Description("New")]
        New = 0,
        [Description("Hearing")]
        Hearing = 1,
        [Description("Dropped")]
        Dropped = 2,
        [Description("Dismissed")]
        Dismissed = 3,
        [Description("Merged")]
        Merged = 4,
        [Description("Reissued")]
        Reissued = 5,
    }
}
