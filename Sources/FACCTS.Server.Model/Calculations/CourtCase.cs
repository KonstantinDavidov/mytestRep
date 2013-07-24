using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CourtCase
    {
        [NotMapped]
        public CaseStatus CaseStatus
        {
            get
            {
                if (CaseHistory == null || !CaseHistory.Any())
                {
                    return Enums.CaseStatus.New;
                }
                return CaseHistoryEventToStatus(CaseHistory.Where(x => x.Date.GetValueOrDefault(DateTime.Now) <= DateTime.Now).First().CaseHistoryEvent);
            }
        }

        [NotMapped]
        public DateTime? FirstActivity
        {
            get
            {
                if (CaseHistory == null)
                {
                    return null;
                }
                return CaseHistory.Select(X => X.Date).Min();
            }
        }

        public DateTime? LastActivity 
        {
            get
            {
                if (CaseHistory == null)
                {
                    return null;
                }
                return CaseHistory.Select(X => X.Date).Max();
            } 
        }

        private static CaseStatus CaseHistoryEventToStatus(CaseHistoryEvent chEvent)
        {
            return (CaseStatus)(int)chEvent;
        }
    }
}
