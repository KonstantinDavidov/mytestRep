﻿using System;
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
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.CaseHistory()
            {
                Id = this.Id,
                Date = this.Date,
                CaseHistoryEvent = this.CaseHistoryEvent,
                CourtClerk = this.User.ToDTO(),
                CCPOR_ID = this.CCPOR_ID,
                MasterOrder = this.MasterOrder.ToDTO(),
                //CourtCase = this.CourtCase.ToDTO(),
                MergeCase = this.MergeCase.ToDTO(),
                Hearing = this.Hearing.ToDTO(),
                AttorneyForChild = this.AttorneyForChild.ToDTO(),
                Party1Attorney = this.Party1AttorneyData.ToDTO(),
                Party2Attorney = this.Party2AttorneyData.ToDTO(),
                ThirdPartyData = this.ThirdPartyData.ToDTO(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,

            };
        }
    }
}
