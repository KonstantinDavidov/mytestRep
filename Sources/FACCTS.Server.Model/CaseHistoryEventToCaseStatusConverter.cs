using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model
{
    public static class CaseHistoryEventToCaseStatusConverter
    {
        public static CaseStatus Convert(CaseHistoryEvent ch)
        {
            return (CaseStatus)(int)ch;
        }

        public static CaseHistoryEvent ConvertBack(CaseStatus cs)
        {
            return (CaseHistoryEvent)(int)cs;
        }
    }
}
