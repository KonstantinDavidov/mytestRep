using FACCTS.Server.Model.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class CourtCases : WebApiClientBase
    {
        public IEnumerable<CourtCase> GetAll()
        {
            List<CourtCase> output = this.CallServiceGet<List<CourtCase>>(Routes.GetCourtCases.CourtCaseController);
            return output;
        }
    }
}
