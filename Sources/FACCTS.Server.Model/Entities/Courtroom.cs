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
    public partial class Courtroom : IEntityWithId, IEntityWithState
    {

        [StringLength(100)]
        public string RoomName { get; set; }

        [InverseProperty("Courtrooms")]
        public virtual CourtLocation CourtLocation { get; set; }

        public long Id { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
