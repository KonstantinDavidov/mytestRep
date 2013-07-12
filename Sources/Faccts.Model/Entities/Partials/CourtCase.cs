using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class CourtCase
    {
        partial void Initialize()
        {
            this.CaseRecord = new CaseRecord();
            this.CaseRecord.CaseHistory.CollectionChanged += CaseHistoryChanged;
            this.WhenAny(x => x.ParentCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("HasParentCases");
                }
                );
        }

        private void CaseHistoryChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnPropertyChanged("CaseStatus");
        }

        private static FACCTS.Server.Model.Enums.CaseStatus CaseHistoryEventToStatus(FACCTS.Server.Model.Enums.CaseHistoryEvent chEvent)
        {
            FACCTS.Server.Model.Enums.CaseStatus result;
            switch(chEvent)
            {
                case FACCTS.Server.Model.Enums.CaseHistoryEvent.New:
                    result = FACCTS.Server.Model.Enums.CaseStatus.New;
                    break;
                case FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing:
                    result = FACCTS.Server.Model.Enums.CaseStatus.Active;
                    break;
                case FACCTS.Server.Model.Enums.CaseHistoryEvent.Dismissed:
                    result = FACCTS.Server.Model.Enums.CaseStatus.Dismissed;
                    break;
                case FACCTS.Server.Model.Enums.CaseHistoryEvent.Dropped:
                    result = FACCTS.Server.Model.Enums.CaseStatus.Dropped;
                    break;
                case FACCTS.Server.Model.Enums.CaseHistoryEvent.Reissued:
                    result = FACCTS.Server.Model.Enums.CaseStatus.Reissued;
                    break;
                default:
                    result = FACCTS.Server.Model.Enums.CaseStatus.New;
                    break;
            }
            return result;
        }

        public CourtCase(FACCTS.Server.Model.DataModel.CourtCase courtCaseDto) : this()
        {
            this.CaseNumber = courtCaseDto.CaseNumber;
            this.Id = courtCaseDto.Id;

            this.CCPORId = courtCaseDto.CCPORId;
            this.CCPORStatus = (int?)courtCaseDto.CCPORStatus;
            RaiseNavigationPropertyLoading(() => User);
            RaiseNavigationPropertyLoading(() => CaseRecord);
        }

        public FACCTS.Server.Model.Enums.CaseStatus CaseStatus
        {
            get
            {
                if (this.CaseRecord == null || this.CaseRecord.CaseHistory == null)
                {
                    return FACCTS.Server.Model.Enums.CaseStatus.New;
                }
                var latestHistoryRecord = this.CaseRecord.CaseHistory.OrderByDescending(x => x.Date).FirstOrDefault(x => x.Date <= DateTime.Now);
                if (latestHistoryRecord != null)
                {
                    return CaseHistoryEventToStatus((FACCTS.Server.Model.Enums.CaseHistoryEvent)latestHistoryRecord.CaseHistoryEvent);
                }
                return FACCTS.Server.Model.Enums.CaseStatus.New;
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

        public bool HasParentCase
        {
            get
            {
                return this.ParentCase != null;
            }
        }

        public bool HasChildCases
        {
            get
            {
                return this.ChildCases != null && this.ChildCases.Any();
            }
        }

        public FACCTS.Server.Model.DataModel.CourtCase ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.CourtCase()
            {
                Id = this.Id,
                CaseNumber = this.CaseNumber,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
                CaseRecord = this.CaseRecord.ToDTO(),
                //CourtClerk = this.User1.ToDTO(),
            };
        }
    }
}
