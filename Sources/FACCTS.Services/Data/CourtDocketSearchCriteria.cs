using FACCTS.Server.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    [Export(typeof(ICourtDocketSearchCriteria))]
    public class CourtDocketSearchCriteria : ICourtDocketSearchCriteria
    {
        public DateTime Date
        {
            get;
            set;
        }

        public long? CourtRoomId
        {
            get;
            set;
        }

        public Server.Model.Enums.DocketSession? Session
        {
            get;
            set;
        }
    }
}
