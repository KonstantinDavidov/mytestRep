using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CourtDepartmenets")]
    public partial class CourtDepartment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Room { get; set; }

        [Required]
        [StringLength(100)]
        public string BranchOfficer {get; set;}

        [Required]
        [StringLength(100)]
        public string Reporter { get; set; }

        [InverseProperty("Departments")]
        public virtual CourtCounty CourtCounty { get; set; }
    }
}
