using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class CourtCaseStatuses : WebApiClientBase
    {
        protected CourtCaseStatuses() : base()
        {

        }

        private static List<CourtCase> _all;
        public static List<CourtCase> GetAll()
        {
            if (_all == null)
            {
                _all = new CourtCaseStatuses().GetCourtCaseStatuses();
            }
            return _all;
        }

        protected List<CourtCase> GetCourtCaseStatuses()
        {
            return this.CallServiceGet<List<CourtCase>>("CourtCaseStatuses");
        }
    }
}
