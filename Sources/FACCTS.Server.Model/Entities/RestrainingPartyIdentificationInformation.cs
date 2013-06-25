using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [ComplexType]
    public partial class RestrainingPartyIdentificationInformation
    {
        [Column("RP_IDType")]
        public IdentificationIDType IDType { get; set; }

        [Column("RP_IDNumber")]
        public string IDNumber { get; set; }

        [Column("RP_IssuedDate")]
        public DateTime? IssuedDate { get; set; }
    }
}
