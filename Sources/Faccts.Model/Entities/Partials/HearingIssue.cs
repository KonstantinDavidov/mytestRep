using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class HearingIssue : IDataTransferConvertible<FACCTS.Server.Model.DataModel.HearingIssue>
    {
        partial void Initialize()
        {
            
        }

        public HearingIssue(FACCTS.Server.Model.DataModel.HearingIssue dto)
            : this()
        {
            if (dto != null)
            {
                this.PermanentRO = dto.PermanentRO;
                this.SpousalSupport = dto.SpousalSupport;
                this.OtheIssueText = dto.OtheIssueText;
                this.IsOtherIssue = dto.IsOtherIssue;
                this.ChildCustodyOrChildVisitation = dto.ChildCustodyOrChildVisitation;
                this.ChildSupport = dto.ChildSupport;
            }
        }

        public FACCTS.Server.Model.DataModel.HearingIssue ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.HearingIssue()
            {
                PermanentRO = this.PermanentRO,
                ChildCustodyOrChildVisitation = this.ChildCustodyOrChildVisitation,
                ChildSupport = this.ChildSupport,
                SpousalSupport = this.SpousalSupport,
                IsOtherIssue = this.IsOtherIssue,
                OtheIssueText = this.OtheIssueText,
            };
        }

    }
}
