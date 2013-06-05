using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum CCPORStatus
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Add")]
        Add,
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Update")]
        Update,
        [Display(Name = "Modify")]
        Modify,
        [Display(Name = "Reject")]
        Reject,
    }
}
