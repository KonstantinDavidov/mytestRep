using FACCTS.Server.Model.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class CourtCases : WebApiClientBase
    {
        public IEnumerable<Faccts.Model.Entities.CourtCase> GetAll()
        {
            List<Faccts.Model.Entities.CourtCase> output = this.CallServiceGet<List<CourtCase>>(Routes.GetCourtCases.CourtCaseController)
                .Select(x => new Faccts.Model.Entities.CourtCase(x))
                .ToList();
            return output;
        }

        protected CourtCase CreateNewCase(CourtCase courtCase)
        {
            return this.CallServicePost<CourtCase, ExpandoObject>("CourtCase", CreateCourtCaseRequest(courtCase));
        }

        protected dynamic CreateCourtCaseRequest(CourtCase courtCase)
        {
            dynamic values = new ExpandoObject();
            values.CaseNumber = courtCase.CaseNumber;

            return values;
        }

        public static CourtCase CreateNew(CourtCase cc)
        {
            return new CourtCases().CreateNewCase(cc);
        }
    }
}
