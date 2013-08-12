using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.BusinessOperations
{
    public class DocketStrategy : StrategyBase
    {
        private Hearings _hearing;
        private CourtCaseHeading _caseHeading;
        public DocketStrategy(CourtCaseHeading caseHeading,  Hearings hearing)
            : base()
        {
            if (caseHeading == null)
            {
                throw new ArgumentNullException("caseHeading");
            }
            if (hearing == null)
            {
                throw new ArgumentNullException("hearing");
            }
            _hearing = hearing;
            _caseHeading = caseHeading;
        }

        public override void Execute()
        {

            DataContainer.DocketRecords.Add(new DocketRecord()
                {
                    CourtCaseId = _caseHeading.CourtCaseId,
                    CaseNumber = _caseHeading.CaseNumber,
                    HearingDate = _hearing.HearingDate,
                    Courtroom = _hearing.Courtrooms,
                    Department = _hearing.CourtDepartment,
                    Session = _hearing.Session,
                    Party1Name = _caseHeading.Party1Name,
                    Party2Name = _caseHeading.Party2Name,
                    HasChildren = false,
                    HearingIssue = _hearing.HearingIssue,
                    CourtClerkId = AuthenticationService.CurrentUser.Id,
                    Action = FACCTS.Server.Model.Enums.CourtAction.Docketed,
                });

            _caseHeading.CaseStatus = Server.Model.Enums.CaseStatus.Active;
        }

    }
}
