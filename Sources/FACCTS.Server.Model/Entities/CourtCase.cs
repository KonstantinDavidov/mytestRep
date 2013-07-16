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
    public partial class CourtCase : BaseEntity
    {

        public CourtCase()
            : base()
        {
            ParentCase = null;
        }


        [StringLength(20)]
        public string CaseNumber { get; set; }

        public virtual User CourtClerk { get; set; }
        
        [EnumDataType(typeof(CCPORStatus))]
        public CCPORStatus? CCPORStatus { get; set; }

        [StringLength(20)]
        public string CCPORId { get; set; }

        public virtual CourtCase ParentCase { get; set; }

        #region CaseRecord members

        public virtual CourtParty Party1 { get; set; }

        public virtual CourtParty Party2 { get; set; }

        [InverseProperty("CourtCase")]
        public virtual ICollection<Child> Children { get; set; }

        [InverseProperty("CourtCase")]
        public virtual ICollection<OtherProtected> OtherProtected { get; set; }

        [InverseProperty("CourtCase")]
        public virtual ICollection<CaseHistory> CaseHistory { get; set; }

        [InverseProperty("CourtCase")]
        public virtual ICollection<CaseNote> CaseNotes { get; set; }

        public virtual CourtCounty CourtCounty { get; set; }

        public virtual ICollection<CourtCase> RelatedCases { get; set; }

        public RestrainingPartyIdentificationInformation RestrainingPartyIdentificationInformation { get; set; }

        #endregion

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
