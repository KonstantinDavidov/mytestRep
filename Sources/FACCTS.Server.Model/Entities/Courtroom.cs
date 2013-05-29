using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("Courtrooms")]
    public partial class Courtroom
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string RoomName { get; set; }

        [InverseProperty("Courtrooms")]
        public virtual CourtLocation CourtLocation { get; set; }
    }
}
