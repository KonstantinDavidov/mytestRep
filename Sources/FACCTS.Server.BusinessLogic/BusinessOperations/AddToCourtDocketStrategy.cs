using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.Calculations;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.BusinessLogic.BusinessOperations
{
    public class AddToCourtDocketStrategy : BusinessOperationStrategyBase
    {
        private DocketRecord _docket;
        private CourtCase _courtCase;
        private IDataManager _dataManagerInstance;
        public AddToCourtDocketStrategy(
            IDataManager dataManagerInstance
            ,DocketRecord docket
            , CourtCase courtCase)
            : base()
        {
            if (docket == null)
            {
                throw new ArgumentNullException("docket");
            }
            if (courtCase == null)
            {
                throw new ArgumentNullException("courtCase");
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
            var hearing = new Hearing()
            {
                HearingDate = _docket.HearingDate,
                HearingIssues = _docket.HearingIssue,
                Courtroom = DataManager.CourtroomRepository.GetById(_docket.Courtroom.Id),
                Department = DataManager.CourtDepartmentRepository.GetById(_docket.Department.Id),
                Session = _docket.Session,
                State = ObjectState.Added,
            };
            _courtCase.Hearings.Add(hearing);
            _courtCase.CaseHistory.Add(
                new CaseHistory()
                {
                    CaseHistoryEvent = Model.Enums.CaseHistoryEvent.Hearing,
                    Hearing = hearing,
                    Date = DateTime.Now,
                    CourtClerk = _docket.CourtClerkId.HasValue ? DataManager.UserRepository.GetById(_docket.CourtClerkId.Value) : null,
                    State = ObjectState.Added,
                }
                );
            _courtCase.LastAction = _docket.Action.GetValueOrDefault(CourtAction.Docketed);
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
                throw new NotImplementedException();
            }
        }
    }
}
