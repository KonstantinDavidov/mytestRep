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
    public partial class CourtCase
    {

        public CourtCase()
            : base()
        {
            ParentCase = null;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string CaseNumber { get; set; }

        public virtual User CourtClerk { get; set; }
        
        [EnumDataType(typeof(CCPORStatus))]
        public CCPORStatus? CCPORStatus { get; set; }

        [StringLength(20)]
        public string CCPORId { get; set; }

        [Required]
        public virtual CaseRecord CaseRecord { get; set; }

        public virtual CourtCase ParentCase { get; set; }


    }
}
