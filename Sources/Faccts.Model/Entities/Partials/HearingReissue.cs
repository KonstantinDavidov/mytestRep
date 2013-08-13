using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class HearingReissue : IDataTransferConvertible<FACCTS.Server.Model.DataModel.HearingReissue>
    {
        partial void Initialize()
        {
            
        }

        public HearingReissue(FACCTS.Server.Model.DataModel.HearingReissue dto)
            : this()
        {
            if (dto == null)
                return;
            this.Id = dto.Id;
            this.ReissueReason = new ReissueReason(dto.ReissueReason);
            this.ReissueServiceSpecification = dto.ReissueServiceSpecification;
            this.DaysCount = dto.DaysCount;

            this.MarkAsUnchanged();
        }

        public FACCTS.Server.Model.DataModel.HearingReissue ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.HearingReissue()
            {
                Id = this.Id,
                ReissueReason = this.ReissueReason.ConvertToDTO(),
                ReissueServiceSpecification = this.ReissueServiceSpecification,
                DaysCount = this.DaysCount,
            };
        }
    }
}
