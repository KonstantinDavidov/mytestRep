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
            string output = this.CallServiceGet<String>(Routes.GetCourtCases.CourtCaseController);
            if (string.IsNullOrEmpty(output))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<List<CourtCase>>(output);
        }
    }
}
