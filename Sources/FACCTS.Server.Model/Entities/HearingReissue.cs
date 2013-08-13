using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class HearingReissue : IEntityWithId, IEntityWithState
    {
        public ObjectState State
        {
            get;
            set;
        }

        public long Id
        {
            get;
            set;
        }

        public ReissueReason ReissueReason { get; set; }

        public ReissueServiceSpecification ReissueServiceSpecification { get; set; }

        public int DaysCount { get; set; }

        public Hearing ParentHearing { get; set; }
    }
}
