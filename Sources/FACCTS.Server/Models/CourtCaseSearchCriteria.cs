using FACCTS.Server.Model;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.Interfaces;
using FACCTS.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FACCTS.Server.Models
{
    public class CourtCaseSearchCriteria : ICourtCaseSearchCriteria
    {
        public DateTime? FirstHearingStart { get; set; }
        public DateTime? FirstHearingEnd { get; set; }

        public DateTime? LastHearingStart { get; set; }
        public DateTime? LastHearingEnd { get; set; }

        public long? CourtClerkId { get; set; }

        public string CCPOR_ID { get; set; }

        public string CaseNumber { get; set; }

        public FACCTS.Server.Model.Enums.CaseStatus? CaseStatus { get; set; }

        public string Party1FirstName { get; set; }
        public string Party1MiddleName { get; set; }
        public string Party1LastName { get; set; }

        public string Party2FirstName { get; set; }
        public string Party2MiddleName { get; set; }
        public string Party2LastName { get; set; }

        public Expression<Func<CourtCase, bool>> GetLINQCriteria()
        {
            CaseHistoryEvent? eventForCaseStatus = CaseStatus.HasValue ? (CaseHistoryEvent?)CaseHistoryEventToCaseStatusConverter.ConvertBack(CaseStatus.Value) : null;
            return
                x => (string.IsNullOrEmpty(Party1FirstName) || x.Party1.FirstName.Contains(Party1FirstName)) &&
                    (string.IsNullOrEmpty(Party1MiddleName) || x.Party1.MiddleName.Contains(Party1MiddleName)) &&
                    (string.IsNullOrEmpty(Party1LastName) || x.Party1.LastName.Contains(Party1LastName)) &&
                    (string.IsNullOrEmpty(Party2FirstName) || x.Party2.FirstName.Contains(Party2FirstName)) &&
                    (string.IsNullOrEmpty(Party2MiddleName) || x.Party2.MiddleName.Contains(Party2MiddleName)) &&
                    (string.IsNullOrEmpty(Party2LastName) || x.Party2.LastName.Contains(Party2LastName)) &&
                    (string.IsNullOrEmpty(CaseNumber) || x.CaseNumber.Contains(CaseNumber)) &&
                    (!FirstHearingStart.HasValue ||
                        x.CaseHistory
                        .OrderBy(y => y.Date)
                        .FirstOrDefault(y => y.CaseHistoryEvent == Model.Enums.CaseHistoryEvent.Hearing && y.Date >= FirstHearingStart.Value) != null
                    ) &&
                    (
                        !FirstHearingEnd.HasValue ||
                        x.CaseHistory
                        .OrderBy(y => y.Date)
                        .FirstOrDefault(y => y.CaseHistoryEvent == Model.Enums.CaseHistoryEvent.Hearing && y.Date <= FirstHearingEnd.Value) != null

                    ) &&
                    (
                        !LastHearingStart.HasValue ||
                        x.CaseHistory
                        .OrderByDescending(y => y.Date)
                        .FirstOrDefault(y => y.CaseHistoryEvent == Model.Enums.CaseHistoryEvent.Hearing && y.Date >= LastHearingStart.Value) != null
                    ) &&
                    (
                        !LastHearingEnd.HasValue ||
                        x.CaseHistory
                        .OrderByDescending(y => y.Date)
                        .FirstOrDefault(y => y.CaseHistoryEvent == Model.Enums.CaseHistoryEvent.Hearing && y.Date <= LastHearingEnd.Value) != null
                    ) &&
                    (
                        !CourtClerkId.HasValue || x.CourtClerkId == CourtClerkId.Value
                    ) &&
                    (
                        !eventForCaseStatus.HasValue || x.CaseHistory.OrderByDescending(y => y.Date).Select(y => y.CaseHistoryEvent).FirstOrDefault() == eventForCaseStatus
                    ) &&
                    (
                        string.IsNullOrEmpty(CCPOR_ID) || x.CCPORId == CCPOR_ID
                    )
                    
                    ;
        }

    }
}