using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class RelatedCase
    {
        public int CaseRecordId { get; set; }

        public virtual CaseRecord CaseRecord { get; set; }

        public int CourtCaseId { get; set; }

        public virtual CourtCase CourtCase { get; set; }
    }

}
