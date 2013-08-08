using Faccts.Model.Entities;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
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


        public override void Execute()
        {
            dynamic courtCaseRequest = new ExpandoObject();
            courtCaseRequest.CaseNumber = _newCaseNumber;
            courtCaseRequest.CourtClerkId = AuthenticationService.CurrentUser.Id;
            bool sucsessfull = false;
            try
            {
                Logger.Info("NewBOp: Trying to create a new court case");
                CourtCases.CreateNew(courtCaseRequest);
                sucsessfull = true;
            }
            catch (Exception ex)
            {
                Logger.Fatal("Creation the new court case failed!", ex);
            }
            if (sucsessfull)
            {
                DataContainer.SearchCourtCases(true);
            }
            
            
        }

    }
}
