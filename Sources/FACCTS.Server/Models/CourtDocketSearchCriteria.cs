using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FACCTS.Server.Models
{
    public class CourtDocketSearchCriteria : ICourtDocketSearchCriteria
    {
        public DateTime Date
        {
            get;
            set;
        }

        public long? CourtRoomId
        {
            get;
            set;
        }

        public Model.Enums.DocketSession? Session
        {
            get;
            set;
        }

        public Expression<Func<CourtCase, bool>> GetLINQCriteria()
        {
            return
                cc =>
                    cc.CaseHistory.Where(y => y.CaseHistoryEvent == Model.Enums.CaseHistoryEvent.Hearing).OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefault(x => x == this.Date) != null
                    &&
                    (
                        !this.CourtRoomId.HasValue || cc.CaseHistory.Where(y => y.CaseHistoryEvent == Model.Enums.CaseHistoryEvent.Hearing).OrderByDescending(x => x.Date).Select(x => x.Hearing.Courtroom).FirstOrDefault(x => x.Id == this.CourtRoomId.Value) != null
                    )
                    &&
                    (
                        !Session.HasValue || this.CourtRoomId.HasValue || cc.CaseHistory.Where(y => y.CaseHistoryEvent == Model.Enums.CaseHistoryEvent.Hearing).OrderByDescending(x => x.Date).Select(x => x.Hearing.Session).FirstOrDefault(x => x == this.Session.Value) != null
                    );

        }
    }
}