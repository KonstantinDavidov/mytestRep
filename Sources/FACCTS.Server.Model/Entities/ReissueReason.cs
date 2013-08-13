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
    public partial class ReissueReason
    {
        public bool NoPOS { get; set; }
        public bool FCSReferral { get; set; }
        public bool GetAttyToPrepare { get; set; }
        public bool IsOtherReason { get; set; }
        [StringLength(150)]
        public string OtherReasonDescription { get; set; }
    }
}
