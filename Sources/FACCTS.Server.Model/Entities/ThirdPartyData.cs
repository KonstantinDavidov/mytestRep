using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("ThirdPartyData")]
    public class ThirdPartyData : IEntityWithId, IEntityWithState
    {
        [Column("IsThirdpartyProPer")]
        public bool IsProPer { get; set; }

        [Column("IsThirdPartyRequestorInEACase")]
        public bool IsRequestorInEACase { get; set; }

        public virtual Attorney Attorney { get; set; }

        public long Id { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
