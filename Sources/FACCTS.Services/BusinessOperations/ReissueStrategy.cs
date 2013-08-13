using Faccts.Model.Entities;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.BusinessOperations
{
    public class ReissueStrategy : StrategyBase
    {
        private DocketRecord _docketRecord;
        private dynamic _additionalData;
        public ReissueStrategy(DocketRecord docketRecord, dynamic additionalData)
            : base()
        {
            if (docketRecord == null)
            {
                throw new ArgumentNullException("docketRecord");
            }
            if (additionalData == null)
            {
                throw new ArgumentNullException("additionalData");
            }
            _docketRecord = docketRecord;
            _additionalData = additionalData;
        }

        public override void Execute()
        {
            DataContainer.DocketRecords.Add(
                new DocketRecord()
                {
                    CourtCaseId = _docketRecord.CourtCaseId,
                    CaseNumber = _docketRecord.CaseNumber,
                    HearingDate = _additionalData.NewCourtDate,
                    Courtroom = _additionalData.Courtroom,
                    Department = _additionalData.Department,
                    Party1Name = _docketRecord.Party1Name,
                    Party2Name = _docketRecord.Party2Name,
                    HasChildren = _docketRecord.HasChildren,
                    HearingIssue = _docketRecord.HearingIssue,
                    CourtClerkId = AuthenticationService.CurrentUser.Id,
                    Action = FACCTS.Server.Model.Enums.CourtAction.Reissue,
                    Session = _docketRecord.Session,
                    HearingReissue = new HearingReissue()
                    {
                        ReissueReason = new ReissueReason()
                        {
                            NoPOS = _additionalData.NoPOS,
                            FCSReferral = _additionalData.FCSReferral,
                            GetAttyToPrepare = _additionalData.GetAttyToPrepare,
                            IsOtherReason = _additionalData.IsOtherReason,
                            OtherReasonDescription = _additionalData.IsOtherReason ? _additionalData.OtherReason : null,
                        },
                        ReissueServiceSpecification = GetServiceSpecification(),
                        DaysCount = _additionalData.DaysCount,
                    }
                }
                );
        }

        private ReissueServiceSpecification GetServiceSpecification()
        {
            if (_additionalData.NoServiceRequired)
                return ReissueServiceSpecification.NoService;
            if (_additionalData.ReissuanceOnSomeDaysBeforeHearing)
                return ReissueServiceSpecification.ReissuanceOnSomeDaysBeforeHearing;
            if (_additionalData.ReissuanceAfterDays)
                return ReissueServiceSpecification.AllPaperworkOnSomeDaysBeforeHearing;

            return ReissueServiceSpecification.NoService;
        }
    }
}
