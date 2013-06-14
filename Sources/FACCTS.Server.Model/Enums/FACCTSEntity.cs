using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Enums
{
    public enum FACCTSEntity
    {
        [Description("Person")]
        Person,
        [Description("Govt. Agency")]
        GovtAgency,
        [Description("Entity")]
        Entity,
    }
}
