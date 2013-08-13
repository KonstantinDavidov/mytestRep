using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class ReissueReason : IDataTransferConvertible<FACCTS.Server.Model.DataModel.ReissueReason>
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

        public FACCTS.Server.Model.DataModel.ReissueReason ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.ReissueReason()
            {
                NoPOS = this.NoPOS,
                FCSReferral = this.FCSReferral,
                GetAttyToPrepare = this.GetAttyToPrepare,
                IsOtherReason = this.IsOtherReason,
                OtherReasonDescription = this.IsOtherReason ? this.OtherReasonDescription : null,
            };

        }
    }
}
