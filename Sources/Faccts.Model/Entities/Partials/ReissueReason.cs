using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class ReissueReason
    {
        partial void Initialize()
        {
            
        }

        public ReissueReason(FACCTS.Server.Model.DataModel.ReissueReason dto)
            : this()
        {
            if (dto == null)
                return;

            this.NoPOS = dto.NoPOS;
            this.FCSReferral = dto.FCSReferral;
            this.GetAttyToPrepare = dto.GetAttyToPrepare;
            this.IsOtherReason = dto.IsOtherReason;
            this.OtherReasonDescription = dto.OtherReasonDescription;

        }
    }
}
