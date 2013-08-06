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
    public partial class CourtCase : IEntityWithId, IEntityWithState
    {

        public CourtCase()
            : base()
        {
            ParentCase = null;
            LastAction = CourtAction.PendingForService;
        }

        public long Id { get; set; }

        [StringLength(20)]
        public string CaseNumber { get; set; }

        public long? CourtClerkId { get; set; }

        public virtual User CourtClerk { get; set; }
        
        [EnumDataType(typeof(CCPORStatus))]
        public CCPORStatus? CCPORStatus { get; set; }

        [StringLength(20)]
        public string CCPORId { get; set; }

        public long? ParentCaseId { get; set; }

        public virtual CourtCase ParentCase { get; set; }

        public virtual ICollection<CourtCase> RelatedCases { get; set; }

        public long? Party1Id { get; set; }

        public virtual CourtParty Party1 { get; set; }

        public long? Party2Id { get; set; }

        public virtual CourtParty Party2 { get; set; }

        public virtual ICollection<Child> Children { get; set; }

        public virtual ICollection<OtherProtected> OtherProtected { get; set; }

        public virtual ICollection<CaseHistory> CaseHistory { get; set; }

        public virtual ICollection<Hearing> Hearings { get; set; }

        public virtual ICollection<CaseNote> CaseNotes { get; set; }

        public long? CourtCountyId { get; set; }

        public virtual CourtCounty CourtCounty { get; set; }

        public RestrainingPartyIdentificationInformation RestrainingPartyIdentificationInformation { get; set; }

        public virtual ICollection<Witness> Witnesses { get; set; }

        public virtual ICollection<Interpreter> Interpreters { get; set; }

        public long? AttorneyForChildId { get; set; }

        public virtual Attorney AttorneyForChild { get; set; }

        public long? ThirdPartyDataId { get; set; }

        public virtual ThirdPartyData ThirdPartyData { get; set; }

        public CourtAction LastAction { get; set; }

        public ObjectState State { get; set; }
    }
}
