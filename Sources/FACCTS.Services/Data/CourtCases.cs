using Faccts.Model.Entities;
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
        protected IEnumerable<CourtCaseHeading> GetAllCourtCases(SearchCriteria criteria)
        {
            List<CourtCaseHeading> output = 
                this.CallServiceGet<List<FACCTS.Server.Model.Calculations.CourtCaseHeading>>(string.Format("{0}?{1}", Routes.GetCourtCases.CourtCaseController, criteria.ToString()))
                .Select(x => new CourtCaseHeading(x))
                .ToList();
            return output;
        }

        public static IEnumerable<CourtCaseHeading> GetAll(SearchCriteria criteria)
        {
            return new CourtCases().GetAllCourtCases(criteria);
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

        private FACCTS.Server.Model.DataModel.CourtCase Save(FACCTS.Server.Model.DataModel.CourtCase dto)
        {
            return this.CallServicePut<FACCTS.Server.Model.DataModel.CourtCase, FACCTS.Server.Model.DataModel.CourtCase>("CourtCase", dto);
        }

        public static Faccts.Model.Entities.CourtCase SaveData(Faccts.Model.Entities.CourtCase courtCaseToSave)
        {
            FACCTS.Server.Model.DataModel.CourtCase dto = courtCaseToSave.ToDTO();
            var updated = new CourtCases().Save(dto);
            return new Faccts.Model.Entities.CourtCase(dto);
        }

        internal static CourtCase GetById(long courtCaseId)
        {
            return new CourtCase(new CourtCases().GetByCourtCaseId(courtCaseId));
        }

        private FACCTS.Server.Model.DataModel.CourtCase GetByCourtCaseId(long courtCaseId)
        {
            return this.CallServiceGet<FACCTS.Server.Model.DataModel.CourtCase>(string.Format("{0}?{1}", Routes.GetCourtCases.CourtCaseController, courtCaseId));
        }
    }
}
