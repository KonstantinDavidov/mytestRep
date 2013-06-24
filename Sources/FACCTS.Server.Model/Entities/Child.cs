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
    public partial class Child
    {
        public Child()
        {
            this.EntityType = FACCTSEntity.Person;
            this.RelationshipToProtected = Relationship.Child;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public FACCTSEntity EntityType { get; set; } 

        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        public Relationship RelationshipToProtected { get; set; }

        [Required]
        public virtual Sex Sex { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [InverseProperty("Children")]
        public virtual CaseRecord CaseRecord { get; set; }
    }
}
