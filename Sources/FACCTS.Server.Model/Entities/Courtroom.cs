using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CourtRooms")]
    public partial class CourtRoom : IEntityWithId, IEntityWithState
    {

        [StringLength(100)]
        public string Name { get; set; }

        [InverseProperty("CourtRooms")]
        public virtual CourtLocation CourtLocation { get; set; }

        public long Id { get; set; }
        
        public long JudgeId { get; set; }

        public virtual CourtMember Judge { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
