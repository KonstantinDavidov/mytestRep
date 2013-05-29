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

        public virtual Attorney AttorneyForParty1 { get; set; }

        //public bool Party1ProPer { get; set; }

        public virtual Attorney AttorneyForParty2 { get; set; }

        public virtual Attorney AttorneyForChild { get; set; }

        [InverseProperty("CaseRecord")]
        public virtual ICollection<Witness> Witnesses { get; set; }

        [InverseProperty("CaseRecord")]
        public virtual ICollection<Interpreter> Interpreters { get; set; }

        [InverseProperty("CaseRecord")]
        public virtual ICollection<Appearance> Appearances { get; set; }

        [InverseProperty("CaseRecord")]
        public virtual ICollection<CaseHistory> CaseHistory { get; set; }

        [InverseProperty("CaseRecord")]
        public virtual ICollection<CaseNote> CaseNotes { get; set; }
    }
}
