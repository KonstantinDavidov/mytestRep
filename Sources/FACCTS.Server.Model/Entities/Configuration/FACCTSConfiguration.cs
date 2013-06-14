using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel.Configuration
{
    public partial class FACCTSConfiguration
    {
        [Key]
        public int Id { get; set; }

        public bool CaseNumberAutoGeneration { get; set; }

        public virtual CourtCounty CurrentCourtCounty { get; set; }
    }
}
