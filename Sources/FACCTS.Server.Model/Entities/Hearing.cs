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
    public partial class Hearing
    {
        public int Id { get; set; }

        [Required]
        public DateTime HearingDate { get; set; }

        public virtual Courtroom Courtroom { get; set; }

        public virtual CourtDepartment Department { get; set; }

        [StringLength(250)]
        public string Judge { get; set; }

        public HearingIssue HearingIssues { get; set; }
    }
}
