using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class CaseHistory
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
            this.Witnesses = new TrackableCollection<Witnesses>();
            this.Interpreters = new TrackableCollection<Interpreters>();
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
    }
}
