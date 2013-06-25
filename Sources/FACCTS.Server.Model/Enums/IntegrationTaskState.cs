using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum IntegrationTaskState: byte
    {
        Placed = 0,

        Ready = 1,

        Running = 2,

        Finished = 3,

        Error = 4
    }
}
