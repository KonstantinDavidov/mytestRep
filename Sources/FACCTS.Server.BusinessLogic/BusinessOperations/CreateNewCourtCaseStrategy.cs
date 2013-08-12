using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.BusinessLogic.BusinessOperations
{
    public class CreateNewCourtCaseStrategy : BusinessOperationStrategyBase
    {
        private string _caseNumber;
        private long _courtClerkId;
        public CreateNewCourtCaseStrategy(string caseNumber, long courtClerkId)
            : base()
        {
            if (string.IsNullOrWhiteSpace(caseNumber))
            {
                throw new ArgumentNullException("caseNumber");
            }
            if (courtClerkId <= 0)
            {
                throw new InvalidOperationException("The Id of the Court Clerk should be a positive Int64 value.");
            }
            _caseNumber = caseNumber;
            _courtClerkId = courtClerkId;
        }

        public override void Execute()
        {
            this.Logger.Info("Trying to create a new court case...");
            var courtCase = new CourtCase()
            {
                CaseNumber = _caseNumber,
                CourtClerkId = _courtClerkId,
                RestrainingPartyIdentificationInformation = new RestrainingPartyIdentificationInformation(),
            };
            courtCase.CaseHistory = new List<CaseHistory>()
                {
                    new CaseHistory()
                    {
                        Date = DateTime.Now,
                        CaseHistoryEvent = Model.Enums.CaseHistoryEvent.File,
                        CourtClerk = DataManager.UserRepository.GetById(_courtClerkId),
                    }
                };
            DataManager.CourtCaseRepository.Insert(courtCase);

            DataManager.Commit();
            CourtCase = courtCase;
            this.Logger.Info("The new court case created.");
        }

        public CourtCase CourtCase { get; private set; }
    }
}
