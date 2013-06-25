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
    public partial class OtherProtected
    {
        public OtherProtected()
        {
            this.EntityType = FACCTSEntity.Person;
            this.RelationshipToPlaintiff = Relationship.OtherRelative;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public FACCTSEntity EntityType { get; set; } 

        public Relationship RelationshipToPlaintiff { get; set; }

        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual Sex Sex { get; set; }

        [InverseProperty("OtherProtected")]
        public virtual CaseRecord CaseRecord { get; set; }
    }
}
