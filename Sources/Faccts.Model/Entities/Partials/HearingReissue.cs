using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class HearingReissue
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
    }
}
