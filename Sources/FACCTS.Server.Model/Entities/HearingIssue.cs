using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [ComplexType]
    public partial class HearingIssue
    {
        public bool PermanentRO { get; set; }

        public bool ChildCustodyOrChildVisitation { get; set; }

        public bool ChildSupport { get; set; }

        public bool SpousalSupport { get; set; }

        public bool IsOtherIssue { get; set; }

        public string OtheIssueText { get; set; }
    }
}
