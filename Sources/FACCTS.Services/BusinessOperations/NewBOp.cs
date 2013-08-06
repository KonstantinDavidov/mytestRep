using Faccts.Model.Entities;
using FACCTS.Services.Authentication;
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
                LastAction = Server.Model.Enums.CourtAction.PendingForService,
            };
            newCourtCase.CaseHistory.Add(new CaseHistory()
                {
                    Date = DateTime.Now,
                    CaseHistoryEvent = Server.Model.Enums.CaseHistoryEvent.File,
                    CourtClerk = AuthenticationService.CurrentUser,
                }
                );
            HeadingForNew = new CourtCaseHeading()
                {
                    CaseNumber = _newCaseNumber,
                    CaseStatus = Server.Model.Enums.CaseStatus.New,
                    CourtClerkName = AuthenticationService.CurrentUser.FullName,
                };
            DataContainer.CourtCaseHeadings.Add(HeadingForNew);
            ((DataContainer)DataContainer).CurrentCourtCase = newCourtCase;

            return newCourtCase;
        }

        public CourtCaseHeading HeadingForNew { get; private set; }
    }
}
