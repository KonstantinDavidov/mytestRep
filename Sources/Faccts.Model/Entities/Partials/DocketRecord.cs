using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class DocketRecord
    {
        partial void Initialize()
        {
            
        }

        public DocketRecord(FACCTS.Server.Model.Calculations.DocketRecord dto)
            : this()
        {
            if (dto == null)
                return;

            CourtCaseId = dto.CourtCaseId;
            CaseNumber = dto.CaseNumber;
            HearingDate = dto.HearingDate;
            this.Courtroom = new Courtrooms(dto.Courtroom);
            this.Department = new CourtDepartment(dto.Department);
            this.Session = dto.Session;
            this.Party1Name = dto.Party1Name;
            this.Party2Name = dto.Party2Name;
            this.HasChildren = dto.HasChildren;
            this.HearingIssue = new HearingIssue(dto.HearingIssue);

            this.MarkAsUnchanged();
        }
    }
}
