using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum IntegrationTaskRepeatPeriod: byte
    {
        OnceADay = 0,

        OnceAWeek = 1,

        OnceAMonth = 2
    }
}
