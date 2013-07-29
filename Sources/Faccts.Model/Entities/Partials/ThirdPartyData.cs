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
                Attorney = this.Attorney.ConvertToDTO<FACCTS.Server.Model.DataModel.Attorney>(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

        public ThirdPartyData(FACCTS.Server.Model.DataModel.ThirdPartyData dto)
            : this()
        {
            if (dto == null)
                return;

            this.Id = dto.Id;
            this.IsThirdpartyProPer = dto.IsProPer;
            this.IsThirdPartyRequestorInEACase = dto.IsRequestorInEACase;
            this.Attorney = new Attorneys(dto.Attorney);

        }

    }
}
