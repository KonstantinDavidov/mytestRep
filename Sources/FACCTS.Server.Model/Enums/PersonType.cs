using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum PersonType
    {
        None = 0,

        Child=1,

        OtherProtected = 2,

        Attorney = 3,

        Witness = 4,

        Interpreter= 5,

        CourtParty = 6
    }
}
