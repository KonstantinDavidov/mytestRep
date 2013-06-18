using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtCase
    {
        public CourtCase(FACCTS.Server.Model.DataModel.CourtCase courtCaseDto)
        {
            this.CaseNumber = courtCaseDto.CaseNumber;
            this.Id = courtCaseDto.Id;

            this.CCPORId = courtCaseDto.CCPORId;
            this.CCPORStatus = (int?)courtCaseDto.CCPORStatus;
            this.CaseStatus = courtCaseDto.CaseStatus;
            RaiseNavigationPropertyLoading(() => User);
            RaiseNavigationPropertyLoading(() => CaseRecord);
        }

        private FACCTS.Server.Model.Enums.CaseStatus _caseStatus;
        public FACCTS.Server.Model.Enums.CaseStatus CaseStatus
        {
            get
            {
                return _caseStatus;
            }
            private set
            {
                if (_caseStatus == value)
                    return;

                OnPropertyChanged("CaseStatus");
            }

        }

        public DateTime? LastActivity
        {
            get
            {
                if (this.CaseRecord == null || this.CaseRecord.CaseHistory == null)
                    return null;
                var latestHistoryRecord = this.CaseRecord.CaseHistory.OrderByDescending(x => x.Date).FirstOrDefault(x => x.Date <= DateTime.Now);
                if (latestHistoryRecord != null)
                {
                    return latestHistoryRecord.Date;
                }
                return null;
            }
        }
    }
}
