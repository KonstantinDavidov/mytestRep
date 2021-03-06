﻿using System;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.PermanentRO)
            {
                sb.Append("Permanent RO;");
            }
            if (this.SpousalSupport)
            {
                sb.Append("SS;");
            }
            if (this.ChildCustodyOrChildVisitation)
            {
                sb.Append("CC / CV;");
            }
            if (this.ChildSupport)
            {
                sb.Append("CS;");
            }
            if (this.IsOtherIssue)
            {
                sb.Append("Other;");
            }
            return sb.ToString().TrimEnd(';');
        }

    }
}
