using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    internal static class Routes
    {
        public static class GetCourtCases
        {
            public const string CourtCaseController = "CourtCase";
        }

        public static class GetCaseHistory
        {
            public const string CaseHistoryController = "CaseHistory";
        }

        public static class CourtDocket
        {
            public const string CourtDocketController = "CourtDocket";
        }
    }
}
