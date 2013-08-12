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
    public class DropCourtCaseStrategy : BusinessOperationStrategyBase
    {
        private DocketRecord _docket;
        private CourtCase _courtCase;
        private IDataManager _dataManagerInstance;
        public DropCourtCaseStrategy(IDataManager dataManagerInstance
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
            _courtCase.CaseHistory.Add(
                new CaseHistory()
                {
                    CaseHistoryEvent = Model.Enums.CaseHistoryEvent.Dropped,
                    Hearing = null,
                    Date = DateTime.Now,
                    CourtClerk = _docket.CourtClerkId.HasValue ? DataManager.UserRepository.GetById(_docket.CourtClerkId.Value) : null,
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
                throw new NotImplementedException(); 
            }
        }
    }
}
