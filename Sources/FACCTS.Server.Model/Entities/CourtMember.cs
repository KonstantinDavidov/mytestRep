using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CourtMember")]
    public class CourtMember : User
    {
        public CourtMember Substitute { get; set; }
        public bool IsCertified { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public string Phone { get; set; }
    }
}
