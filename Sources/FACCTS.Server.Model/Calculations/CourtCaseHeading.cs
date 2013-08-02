using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Calculations
{
    public class CourtCaseHeading
    {
        public long CourtCaseId { get; set; }
        public string CaseNumber { get; set; }
        public CaseStatus CaseStatus { get; set; }
        public DateTime? Date { get; set; }
        public string Order { get; set; }
        public string Party1Name { get; set; }
        public string Party2Name { get; set; }
        public long? CourtClerkId { get; set; }
        public string CCPOR_ID { get; set; }
    }
}
