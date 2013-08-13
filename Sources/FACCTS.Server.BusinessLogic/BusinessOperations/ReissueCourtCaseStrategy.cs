using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.Calculations;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.BusinessLogic.BusinessOperations
{
    public class ReissueCourtCaseStrategy : BusinessOperationStrategyBase
    {
        private DocketRecord _docket;
        private CourtCase _courtCase;
        private IDataManager _dataManagerInstance;

        public ReissueCourtCaseStrategy(IDataManager dataManagerInstance
            , DocketRecord docket
            , CourtCase courtCase)
            : base()
        {
            if (docket == null)
            {
                throw new ArgumentNullException("docket");
            }
            if (dataManagerInstance == null)
            {
                throw new ArgumentNullException("dataManagerInstance");
            }
            _docket = docket;
            _courtCase = courtCase;
            _dataManagerInstance = dataManagerInstance;
        }

        public override void Execute()
        {
            if (_docket.HearingReissue == null)
            {
                throw new InvalidOperationException("There is no any reissue details in the docket record");
            }
            _docket.HearingReissue.State = ObjectState.Added;
            var hearing = new Hearing()
            {
                HearingDate = _docket.HearingDate,
                HearingIssues = _docket.HearingIssue,
                Courtroom = _dataManagerInstance.CourtroomRepository.GetById(_docket.Courtroom.Id),
                Department = _dataManagerInstance.CourtDepartmentRepository.GetById(_docket.Department.Id),
                Session = _docket.Session,
                State = ObjectState.Added,
                Reissue = _docket.HearingReissue,
            };
            _courtCase.Hearings.Add(hearing);
            _courtCase.CaseHistory.Add(
               new CaseHistory()
               {
                   CaseHistoryEvent = Model.Enums.CaseHistoryEvent.Hearing,
                   Hearing = hearing,
                   Date = DateTime.Now,
                   CourtClerk = _docket.CourtClerkId.HasValue ? _dataManagerInstance.UserRepository.GetById(_docket.CourtClerkId.Value) : null,
                   State = ObjectState.Added,
               }
               );
            _courtCase.State = ObjectState.Modified;
            _dataManagerInstance.CourtCaseRepository.ModifyByState(_courtCase);
        }

        protected override IDataManager DataManager
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                base.DataManager = value;
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
        }
    }
}
