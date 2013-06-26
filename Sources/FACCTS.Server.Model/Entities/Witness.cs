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
    [Table("Witnesses")]
    public partial class Witness
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public FACCTSEntity EntityType { get; set; } 

        [Required]
        public virtual CourtParty WitnessFor { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public virtual Designation Designation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Contact { get; set; }

        [InverseProperty("Witnesses")]
        public virtual CaseRecord CaseRecord { get; set; }
    }
}
