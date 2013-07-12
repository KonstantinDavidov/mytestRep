using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CourtMember")]
    public class CourtMember : User
    {
        public long? SubstituteId { get; set; }

        [ForeignKey("SubstituteId")]
        public virtual CourtMember Substitute { get; set; }

        public bool IsCertified { get; set; }
        public bool IsAvilable { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public string Phone { get; set; }

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
