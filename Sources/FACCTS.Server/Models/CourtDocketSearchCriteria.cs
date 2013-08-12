using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Objects;
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
                    cc.CaseHistory.Where(x => x.CaseHistoryEvent == Model.Enums.CaseHistoryEvent.Hearing).OrderByDescending(x => x.Date).FirstOrDefault() != null
                    &&
                    cc.Hearings.OrderByDescending(x => x.Id).FirstOrDefault(x => EntityFunctions.DiffDays(x.HearingDate, this.Date) == 0) != null
                    &&
                    (
                        !this.CourtRoomId.HasValue || cc.CaseHistory.OrderByDescending(x => x.Date).Select(x => x.Hearing).FirstOrDefault(x => x.CourtroomId == this.CourtRoomId.Value) != null
                    )
                    &&
                    (
                        !this.Session.HasValue || cc.CaseHistory.OrderByDescending(x => x.Date).Select(x => x.Hearing).FirstOrDefault(x => x.Session == this.Session.Value) != null
                    );
        }
    }
}