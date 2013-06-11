using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum CaseHistoryEvent
    {
        [Display(Name = "New")]
        New = 0,
        [Display(Name = "Hearing")]
        Hearing = 1,
        [Display(Name = "Dropped")]
        Dropped = 2,
        [Display(Name = "Dismissed")]
        Dismissed = 3,
        [Display(Name = "Merged")]
        Merged = 4,
    }
}
