using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class CaseInfo
    {
        public int CaseId { get; set; }
        public string CaseNumber { get; set; }
        public bool IsSealed { get; set; }
        public int CasesOnDocket { get; set; }
        public int CasesCompleteHead { get; set; }
        public bool IsTempJudge { get; set; }
        public string TempJudgeName { get; set; }
    }
}
