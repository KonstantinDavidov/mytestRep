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
        [Description("PERSON")]
        Person,
        [Description("GOVT. AGENCY")]
        GovtAgency,
        [Description("ENTITY")]
        Entity,
    }
}
