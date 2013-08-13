using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum ReissueServiceSpecification
    {
        NoService = 0,
        ReissuanceOnSomeDaysBeforeHearing = 1,
        AllPaperworkOnSomeDaysBeforeHearing = 2,
    }
}
