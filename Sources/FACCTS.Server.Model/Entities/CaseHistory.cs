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
    public class CaseHistory : IEntityWithId, IEntityWithState
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [EnumDataType(typeof(CaseHistoryEvent))]
        public CaseHistoryEvent CaseHistoryEvent { get; set; }

        public long? CourtClerkId { get; set; }

        public virtual User CourtClerk { get; set; }

        [StringLength(30)]
        public string CCPOR_ID { get; set; }

        public long CourtCaseId { get; set; }
        
        public virtual CourtCase CourtCase { get; set; }

        public long? MergeCaseId { get; set; }

        public CourtCase MergeCase { get; set; }

        public long? HearingId { get; set; }

        public virtual Hearing Hearing { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
