using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum ParticipantRole
    {
        [Display(Name = "Protected")]
        Protected = 0,
        [Display(Name = "Restrained")]
        Restrained = 1,
        [Display(Name = "Additional Protected")]
        AdditionalProtected = 2
    }
}
