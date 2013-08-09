using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Interfaces
{
    public interface ICourtDocketSearchCriteria
    {
        DateTime Date { get; set; }
        long? CourtRoomId { get; set; }
        DocketSession? Session { get; set; }
    }
}
