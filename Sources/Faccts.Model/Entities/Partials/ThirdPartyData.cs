using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class ThirdPartyData : IDataTransferConvertible<FACCTS.Server.Model.DataModel.ThirdPartyData>
    {
        partial void Initialize()
        {
            this.Attorney = new Attorneys();
        }

        public FACCTS.Server.Model.DataModel.ThirdPartyData ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.ThirdPartyData()
            {
                Id = this.Id,
                IsProPer = this.IsThirdPartyProPer,
                IsRequestorInEACase = this.IsThirdPartyRequestorInEACase,
                Attorney = this.Attorney.ConvertToDTO(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

    }
}
