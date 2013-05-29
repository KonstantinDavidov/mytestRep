using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("Appearances")]
    public partial class Appearance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public virtual Designation Designation { get; set; }

        public bool? Appear { get; set; }

        public bool? Sworn { get; set; }

        public bool? AttorneyPresent { get; set; }

        [InverseProperty("Appearances")]
        public virtual CaseRecord CaseRecord { get; set; }

    }
}
