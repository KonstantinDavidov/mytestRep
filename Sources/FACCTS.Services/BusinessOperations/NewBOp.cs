using Faccts.Model.Entities;
using FACCTS.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.BusinessOperations
{
    public class NewBOp : StrategyBase
    {
        private string _newCaseNumber;
        public NewBOp(string newCaseNumber)
            : base()
        {
            if (string.IsNullOrWhiteSpace(newCaseNumber))
            {
                throw new ArgumentNullException("newCaseNumber");
            }
            _newCaseNumber = newCaseNumber;
        }

        public override Faccts.Model.Entities.CourtCase Execute(CourtCase courtCase)
        {
            CourtCase newCourtCase = new CourtCase()
            {
                CaseNumber = _newCaseNumber,
                CaseHistory = Faccts.Model.Entities.CaseHistory.GetHistoryCollectionForNewCase(),
                LastAction = Server.Model.Enums.CourtAction.PendingForService,
            };
            HeadingForNew = new CourtCaseHeading()
                {
                    CaseNumber = _newCaseNumber,
                    CaseStatus = Server.Model.Enums.CaseStatus.New,
                };
            DataContainer.CourtCaseHeadings.Add(HeadingForNew);
            ((DataContainer)DataContainer).CurrentCourtCase = newCourtCase;

            return newCourtCase;
        }

        public CourtCaseHeading HeadingForNew { get; private set; }
    }
}
