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
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [EnumDataType(typeof(CaseHistoryEvent))]
        public CaseHistoryEvent CaseHistoryEvent { get; set; }

        public virtual User CourtClerk { get; set; }

        [StringLength(30)]
        public string CCPOR_ID { get; set; }

        public virtual MasterOrder MasterOrder { get; set; }

        [InverseProperty("CaseHistory")]
        public virtual CourtCase CourtCase { get; set; }

        public CourtCase MergeCase { get; set; }

        public virtual Hearing Hearing { get; set; }

        public virtual Attorney AttorneyForChild { get; set; }


        public virtual CourtPartyAttorneyData Party1Attorney { get; set; }

        public virtual CourtPartyAttorneyData Party2Attorney { get; set; }

        public virtual ThirdPartyData ThirdPartyData { get; set; }


        public long Id { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
