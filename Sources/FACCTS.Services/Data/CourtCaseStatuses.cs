using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
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

        private static List<EnumDescript<CaseStatus>> _all;
        public static List<EnumDescript<CaseStatus>> GetAll()
        {
            if (_all == null)
            {
                _all = new CourtCaseStatuses().GetCourtCaseStatuses();
            }
            return _all;
        }

        protected List<EnumDescript<CaseStatus>> GetCourtCaseStatuses()
        {
            return Enum.GetValues(typeof(CaseStatus))
                .Cast<CaseStatus>()
                .Select(x => new EnumDescript<CaseStatus>(x))
                .ToList();
        }
    }
}
