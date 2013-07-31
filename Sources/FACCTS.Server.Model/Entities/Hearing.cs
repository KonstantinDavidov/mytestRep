using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class Hearing : IEntityWithId, IEntityWithState
    {
        public long Id { get; set; }

        public DateTime HearingDate { get; set; }

        public long CourtCaseId { get; set; }

        public virtual CourtCase CourtCase { get; set; }

        public long? CourtroomId { get; set; }

        public virtual Courtroom Courtroom { get; set; }

        public long? CourtDepartmentId { get; set; }

        public virtual CourtDepartment Department { get; set; }

        public HearingIssue HearingIssues { get; set; }

        public DocketSession Session { get; set; }

        public virtual ICollection<CourtOrder> CourtOrders { get; set; }

        public virtual ICollection<Appearance> Appearances { get; set; }

        public ObjectState State { get; set; }
    }
}
