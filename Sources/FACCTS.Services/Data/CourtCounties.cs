using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class CourtCounties : WebApiClientBase
    {
        protected CourtCounties() : base()
        {

        }

        public static List<CourtCounty> GetAll()
        {
            return new CourtCounties().GetCourtCounties();
        }

        private List<CourtCounty> GetCourtCounties()
        {
            return this.CallServiceGet<List<CourtCounty>>("CourtCounties");
        }
    }
}
