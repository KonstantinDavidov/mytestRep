using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class DocketRecord : IDataTransferConvertible<FACCTS.Server.Model.Calculations.DocketRecord>
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.Courtroom, x => x.CourtroomsId, (x1, x2) =>
                new { CourtroomId = x1.Value}
                ).Subscribe(x =>
                    {
                        this.OnPropertyChanged("Judge", false);
                    }
                    )
                    ;
            this.WhenAny(x => x.HearingIssue, 
                x => x.HearingIssue.PermanentRO,
                x => x.HearingIssue.ChildCustodyOrChildVisitation,
                x => x.HearingIssue.SpousalSupport,
                x => x.HearingIssue.OtheIssueText,
                x => x.HearingIssue.IsOtherIssue,
                x => x.HearingIssue.ChildSupport,
                (x1, x2, x3, x4, x5, x6, x7) => x1.Value)
            .Subscribe(x =>
            {
                this.OnPropertyChanged("HearingIssuesTitle", false);
            });
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
            this.CourtClerkId = dto.CourtClerkId;
            this.Action = dto.Action;
            if (dto.HearingReissue != null)
            {
                this.HearingReissue = new HearingReissue(dto.HearingReissue);
            }

            this.MarkAsUnchanged();
        }

        public FACCTS.Server.Model.Calculations.DocketRecord ToDTO()
        {
            return new FACCTS.Server.Model.Calculations.DocketRecord()
            {
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
                CourtCaseId = this.CourtCaseId,
                CaseNumber = this.CaseNumber,
                HearingDate = this.HearingDate,
                Courtroom = this.Courtroom.ConvertToDTO(),
                Department = this.Department.ConvertToDTO(),
                Session = this.Session,
                HearingIssue = this.HearingIssue.ConvertToDTO(),
                CourtClerkId = this.CourtClerkId,
                Action = this.Action,
            };
        }

        public string Judge
        {
            get
            {
                return this.Courtroom != null ? this.Courtroom.JudgeName : null;
            }
        }

        public string HearingIssuesTitle
        {
            get
            {
                
                if (this.HearingIssue == null)
                {
                    return null;
                }
                return HearingIssue.ToString();
            }
        }
    }
}
