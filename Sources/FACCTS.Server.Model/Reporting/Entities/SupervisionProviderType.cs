using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public enum SupervisionProviderType
    {
        [Description("Professional")]
        Professional,
        [Description("Nonprofessional")]
        Nonprofessional,
        [Description("Therapeutic")]
        Therapeutic
    }
}
