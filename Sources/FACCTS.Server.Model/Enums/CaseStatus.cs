using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum CaseStatus
    {
        [Display(Name = "New")]
        New = 0,
        [Display(Name = "Active")]
        Active = 1,
        [Display(Name = "Reissued")]
        Reissued = 2,
        [Display(Name = "Dropped")]
        Dropped = 3,
        [Display(Name = "Dismissed")]
        Dismissed = 4,
    }
}
