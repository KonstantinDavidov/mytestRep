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
    public partial class CaseHistory : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [EnumDataType(typeof(CaseHistoryEvent))]
        public CaseHistoryEvent CaseHistoryEvent { get; set; }

        public virtual User CourtClerk { get; set; }

        [StringLength(30)]
        public string CCPOR_ID { get; set; }

        public long? CourtCaseOrderId { get; set; }

        [ForeignKey("CourtCaseOrderId")]
        public virtual CourtCaseOrder Order { get; set; }

        [InverseProperty("CaseHistory")]
        public virtual CaseRecord CaseRecord { get; set; }

        public virtual Appearance Appearances { get; set; }

        public CourtCase MergeCase { get; set; }

        public virtual Hearing Hearing { get; set; }

        public virtual CourtCaseOrder CourtOrder { get; set; }

        public virtual Attorney AttorneyForChild { get; set; }

        [InverseProperty("CaseHistoryRecord")]
        public virtual ICollection<Witness> Witnesses { get; set; }

        [InverseProperty("CaseHistoryRecord")]
        public virtual ICollection<Interpreter> Interpreters { get; set; }

        public virtual CourtPartyAttorneyData Party1Attorney { get; set; }

        public virtual CourtPartyAttorneyData Party2Attorney { get; set; }

        public virtual ThirdPartyData ThirdPartyData { get; set; }

        [NotMapped]
        public override ObjectState State
        {
            get
            {
                return base.State;
            }
            set
            {
                base.State = value;
            }
        }
        
    }
}
