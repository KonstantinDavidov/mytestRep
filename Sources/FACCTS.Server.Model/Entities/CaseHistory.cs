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
    public partial class CaseHistory
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
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
        
    }
}
