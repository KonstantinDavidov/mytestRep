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
    public partial class CaseHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public virtual Courtroom CourtRoom { get; set; }

        public string Orders { get; set; }//TODO: modify this when Order entity implemented

        [InverseProperty("CaseHistory")]
        public virtual CaseRecord CaseRecord { get; set; }

        
    }
}
