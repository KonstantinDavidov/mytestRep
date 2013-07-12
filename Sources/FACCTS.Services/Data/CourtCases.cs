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
        protected IEnumerable<Faccts.Model.Entities.CourtCase> GetAllCourtCases()
        {
            List<Faccts.Model.Entities.CourtCase> output = this.CallServiceGet<List<CourtCase>>(Routes.GetCourtCases.CourtCaseController)
                .Select(x => new Faccts.Model.Entities.CourtCase(x))
                .ToList();
            return output;
        }

        public static IEnumerable<Faccts.Model.Entities.CourtCase> GetAll()
        {
            return new CourtCases().GetAllCourtCases();
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

        private CourtCase Save(CourtCase dto)
        {
            return this.CallServicePut<CourtCase, CourtCase>("CourtCase", dto);
        }

        public static Faccts.Model.Entities.CourtCase SaveData(Faccts.Model.Entities.CourtCase courtCaseToSave)
        {
            CourtCase dto = courtCaseToSave.ToDTO();
            var updated = new CourtCases().Save(dto);
            return new Faccts.Model.Entities.CourtCase(dto);
        }
    }
}
