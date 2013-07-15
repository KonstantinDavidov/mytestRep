using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtPartyAttorneyData
    {
        partial void Initialize()
        {
            this.HasAttorney = true;
            this.Attorney = new Attorneys();
        }
    }
}
