using FACCTS.Server.Model.Entities;
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
    public partial class ThirdPartyData : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Column("IsThirdpartyProPer")]
        public bool IsProPer { get; set; }

        [Column("IsThirdPartyRequestorInEACase")]
        public bool IsRequestorInEACase { get; set; }

        public virtual Attorney Attorney { get; set; }

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
