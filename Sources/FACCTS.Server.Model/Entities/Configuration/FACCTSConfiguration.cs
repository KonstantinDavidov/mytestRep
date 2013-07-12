using FACCTS.Server.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel.Configuration
{
    public partial class FACCTSConfiguration : BaseEntity
    {

        public bool CaseNumberAutoGeneration { get; set; }

        [ForeignKey("CurrentCourtCountyId")]
        public virtual CourtCounty CurrentCourtCounty { get; set; }

        public long? CurrentCourtCountyId { get; set; }

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
