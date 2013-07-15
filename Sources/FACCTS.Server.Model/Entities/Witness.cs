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
    [Table("Witnesses")]
    public partial class Witness : BaseEntity
    {

        public FACCTSEntity EntityType { get; set; } 

        public virtual CourtParty WitnessFor { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        public virtual Designation Designation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Contact { get; set; }

        [InverseProperty("Witnesses")]
        public virtual CaseHistory CaseHistoryRecord { get; set; }

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
