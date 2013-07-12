using FACCTS.Server.Model.Entities;
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
    [Table("CaseNotes")]
    public partial class CaseNote : BaseEntity
    {

        [Required]
        public virtual User Author { get; set; }

        [EnumDataType(typeof(CaseNoteStatus))]
        [Required]
        public CaseNoteStatus Status { get; set; }

        public string Text { get; set; }

        [InverseProperty("CaseNotes")]
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
