using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model
{
    public enum OrderItemState
    {
        [Display(Name = "NotRequested")]
        NotRequested = 0,
        [Display(Name = "Denied")]
        Denied = 1,
        [Display(Name = "Granted")]
        Granted = 2
    }
}
