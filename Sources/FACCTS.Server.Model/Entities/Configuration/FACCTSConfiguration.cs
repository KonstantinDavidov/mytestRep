using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel.Configuration
{
    public partial class FACCTSConfiguration : IEntityWithId, IEntityWithState
    {

        public bool CaseNumberAutoGeneration { get; set; }

        [ForeignKey("CurrentCourtCountyId")]
        public virtual CourtCounty CurrentCourtCounty { get; set; }

        public long? CurrentCourtCountyId { get; set; }

        public long Id { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
