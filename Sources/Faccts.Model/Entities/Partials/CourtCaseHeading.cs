using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtCaseHeading
    {
        partial void Initialize()
        {
            
        }

        public CourtCaseHeading(FACCTS.Server.Model.Calculations.CourtCaseHeading dto)
        {
            if (dto == null)
                return;
            this.CourtCaseId = dto.CourtCaseId;
            this.CaseNumber = dto.CaseNumber;
            this.CaseStatus = dto.CaseStatus;
            this.Date = dto.Date;
            this.Order = dto.Order;
            this.Party1Name = dto.Party1Name;
            this.Party2Name = dto.Party2Name;
            this.CourtClerkId = dto.CourtClerkId;
            this.CCPOR_ID = dto.CCPOR_ID;

            this.MarkAsUnchanged();
        }
    }
}
