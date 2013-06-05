using FACCTS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CourtCase
    {
        public CourtCaseDTO ToTDO()
        {
            return new CourtCaseDTO()
            {
                Id = this.Id,
                CaseNumber = this.CaseNumber,
                CaseStatusId = this.CaseStatus != null ? (int?)this.CaseStatus.Id : null,
                FirstActivity = this.FirstActivity,
                LastActivity = this.LastActivity,
                CourtClerkId = this.CourtClerk.UserId,
                CCPORStatus = this.CCPORStatus,
                CCPORId = this.CCPORId,
                CaseRecordId = this.CaseRecord != null ? (int?)this.CaseRecord.Id : null,
                RelatedCaseRecords = this.RelatedCaseRecords != null ? this.RelatedCaseRecords.Select(x => x.Id).ToList() : null,
                CourtOrders = this.CourtOrders != null ? this.CourtOrders.Select(x => x.Id).ToList() : null,
            };
        }
    }
}
