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
    public partial class OtherProtected : BaseEntity
    {
        public OtherProtected()
        {
            this.EntityType = FACCTSEntity.PERSON;
            this.RelationshipToPlaintiff = Relationship.O;
        }

        public FACCTSEntity EntityType { get; set; } 

        public Relationship RelationshipToPlaintiff { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Sex { get; set; }

        public int Age { get; set; }

        public bool IsHouseHold { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        [InverseProperty("OtherProtected")]
        public virtual CaseRecord CaseRecord { get; set; }

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
