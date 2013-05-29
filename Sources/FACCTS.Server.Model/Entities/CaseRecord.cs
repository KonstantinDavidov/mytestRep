using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CaseRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual CourtParty Party1 { get; set; }

        public virtual CourtParty Party2 { get; set; }

        [InverseProperty("CaseRecord")]
        public virtual ICollection<Child> Children { get; set; }

        [InverseProperty("CaseRecord")]
        public virtual ICollection<OtherProtected> OtherProtected { get; set; }
    }
}
