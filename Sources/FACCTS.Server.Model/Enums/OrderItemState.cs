using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model
{
    public enum OrderItemState
    {
        [Description("NotRequested")]
        NotRequested = 0,
        [Description("Denied")]
        Denied = 1,
        [Description("Granted")]
        Granted = 2
    }
}
