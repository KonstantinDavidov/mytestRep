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

        public FACCTS.Server.Model.DataModel.HearingIssue ToDTO()
        {
            if (!this.IsDirty)
                return null;
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
