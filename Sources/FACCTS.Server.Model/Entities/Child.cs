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
    [Table("Children")]
    public partial class Child : BaseEntity
    {
        public Child()
        {
            this.EntityType = FACCTSEntity.PERSON;
            this.RelationshipToProtected = Relationship.C;
        }


        public FACCTSEntity EntityType { get; set; } 

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        public Relationship RelationshipToProtected { get; set; }

        public Gender Sex { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [InverseProperty("Children")]
        public virtual CourtCase CourtCase { get; set; }

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
