using FACCTS.Server.Model;
using FACCTS.Server.Model.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.BusinessLogic.BusinessOperations
{
    public class SearchCourtCasesStrategy : BusinessOperationStrategyBase
    {
        private CourtCaseSearchCriteria _criteria;
        public SearchCourtCasesStrategy(CourtCaseSearchCriteria criteria)
            : base()
        {
            if (criteria == null)
            {
                throw new ArgumentNullException("criteria");
            }
            _criteria = criteria;
        }

        public override void Execute()
        {
            Logger.Info("SearchCourtCasesStrategy: searching courg cases...");
            var query = DataManager.CourtCaseRepository
                .GetAll(
                x => x.Party1,
                x => x.Party2,
                x => x.CaseHistory,
                x => x.CourtClerk
                )
                .Where(_criteria.GetLINQCriteria())
                .Select(x =>
                    new
                    {
                        CourtCaseId = x.Id,
                        CaseNumber = x.CaseNumber,
                        CasehistoryEvent = x.CaseHistory.OrderByDescending(y => y.Date).Select(y => y.CaseHistoryEvent).FirstOrDefault(),
                        Date = (DateTime?)null,
                        Order = (string)null,
                        Party1 = x.Party1,
                        Party2 = x.Party2,
                        CourtClerk = x.CourtClerk,
                        CCPOR_ID = x.CCPORId,
                    }
                    );
            Result = query
                .ToArray()
            .Select(
            x => new CourtCaseHeading()
            {
                CourtCaseId = x.CourtCaseId,
                CaseNumber = x.CaseNumber,
                CaseStatus = CaseHistoryEventToCaseStatusConverter.Convert(x.CasehistoryEvent),
                Date = null,
                Order = null,
                Party1Name = x.Party1 != null ? x.Party1.FirstName + " " + x.Party1.MiddleName + " " + x.Party1.LastName : null,
                Party2Name = x.Party2 != null ? x.Party2.FirstName + " " + x.Party2.MiddleName + " " + x.Party2.LastName : null,
                CourtClerkName = x.CourtClerk != null ? x.CourtClerk.FirstName + " " + x.CourtClerk.MiddleName + " " + x.CourtClerk.LastName : string.Empty,
                CCPOR_ID = x.CCPOR_ID,
            }
            )
            .ToList();
        }

        public List<CourtCaseHeading> Result { get; private set; }
    }
}
