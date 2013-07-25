using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtPartyAttorneyData : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtPartyAttorneyData>
    {
        partial void Initialize()
        {
            this.HasAttorney = true;
            this.Attorney = new Attorneys();
        }

        public FACCTS.Server.Model.DataModel.CourtPartyAttorneyData ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.CourtPartyAttorneyData()
            {
                Id = this.Id,
                Attorney = this.Attorney.ConvertToDTO<FACCTS.Server.Model.DataModel.Attorney>(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }


    }
}
