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
    [Table("Hearings")]
    public partial class Hearing : BaseEntity
    {
        public DateTime HearingDate { get; set; }

        public virtual Courtroom Courtroom { get; set; }

        public virtual CourtDepartment Department { get; set; }

        [StringLength(250)]
        public string Judge { get; set; }

        public HearingIssue HearingIssues { get; set; }

        public virtual Appearance Appearance { get; set; }

        public DocketSession Session { get; set; }

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
