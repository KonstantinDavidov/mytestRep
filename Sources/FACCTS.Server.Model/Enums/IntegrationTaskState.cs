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

        Running = 1,

        Finished = 2,

        Error = 3
    }
}
