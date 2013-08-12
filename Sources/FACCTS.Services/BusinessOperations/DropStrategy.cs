using Faccts.Model.Entities;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.BusinessOperations
{
    public class DropStrategy : StrategyBase
    {
        private DocketRecord _docketRecord;
        public DropStrategy(DocketRecord docketRecord) : base()
        {
            if (docketRecord == null)
            {
                throw new ArgumentNullException("docketRecord");
            }
            _docketRecord = docketRecord;
        }

        public override void Execute()
        {
            _docketRecord.Courtroom = null;
            _docketRecord.Department = null;
            _docketRecord.CourtClerkId = AuthenticationService.CurrentUser.Id;
            _docketRecord.Action = CourtAction.Dropped;
            _docketRecord.MarkAsDeleted();

            if (DataContainer.CourtCaseHeadings.Any(x => x.CourtCaseId == _docketRecord.CourtCaseId))
            {
                DataContainer.CourtCaseHeadings.Where(x => x.CourtCaseId == _docketRecord.CourtCaseId).First().CaseStatus = CaseStatus.Dropped;
            }
        }
    }
}
