using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class CaseHistory : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CaseHistory>
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.CaseHistoryEvent, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("CaseEventName");
                });
            this.Hearing = new Hearings();
            this.Party1AttorneyData = new CourtPartyAttorneyData();
            this.Party2AttorneyData = new CourtPartyAttorneyData();
            this.ThirdPartyData = new ThirdPartyData();
            this.AttorneyForChild = new Attorneys();
        }

        public string CaseEventName
        {
            get
            {
                return ((FACCTS.Server.Model.Enums.CaseHistoryEvent)this.CaseHistoryEvent).ToDescription();
            }
        }

        public string CourtCaseNumber
        {
            get
            {
                return this.CourtCase.CaseNumber;
            }

        }

        public static TrackableCollection<CaseHistory> GetHistoryCollectionForNewCase()
        {
            return new TrackableCollection<CaseHistory>()
            {
                new CaseHistory()
                {
                    Date = DateTime.Now,
                    CaseHistoryEvent = FACCTS.Server.Model.Enums.CaseHistoryEvent.New,
                },
                new CaseHistory()
                {
                    Date = null,
                    CaseHistoryEvent = FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing,
                },
            };
        }

        public FACCTS.Server.Model.DataModel.CaseHistory ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.CaseHistory()
            {
                Id = this.Id,
                Date = this.Date,
                CaseHistoryEvent = this.CaseHistoryEvent,
                CourtClerk = this.User.IsDirty ? this.User.ToDTO() : null,
                CCPOR_ID = this.CCPOR_ID,
                MasterOrder = this.MasterOrder.IsDirty ? this.MasterOrder.ToDTO() : null,
                //CourtCase = this.CourtCase.ToDTO(),
                MergeCase = this.MergeCase.IsDirty ? this.MergeCase.ToDTO() : null,
                Hearing = this.Hearing.IsDirty ? this.Hearing.ToDTO() : null,
                AttorneyForChild = this.AttorneyForChild.IsDirty ? this.AttorneyForChild.ToDTO() : null,
                Party1Attorney = this.Party1AttorneyData.IsDirty ? this.Party1AttorneyData.ToDTO() : null,
                Party2Attorney = this.Party2AttorneyData.IsDirty ? this.Party2AttorneyData.ToDTO() : null,
                ThirdPartyData = this.ThirdPartyData.IsDirty ? this.ThirdPartyData.ToDTO() : null,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,

            };
        }
    }
}
