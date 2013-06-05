using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum CaseNoteStatus
    {
        [Display(Name="Private")]
        Private = 0,
        [Display(Name = "Public")]
        Public = 1
    }
}
