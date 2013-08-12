using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Calculations
{
    public class DocketRecord : IEntityWithState
    {
        public long CourtCaseId { get; set; }
        public string CaseNumber { get; set; }
        public DateTime HearingDate { get; set; }
        public CourtRoom Courtroom { get; set; }
        public CourtDepartment Department { get; set; }
        public DocketSession Session { get; set; }
        public string Party1Name { get; set; }
        public string Party2Name { get; set; }
        public bool HasChildren { get; set; }
        public HearingIssue HearingIssue { get; set; }
        public long? CourtClerkId { get; set; }
        public CourtAction? Action { get; set; }

        public ObjectState State
        {
            get;
            set;
        }
    }
}
