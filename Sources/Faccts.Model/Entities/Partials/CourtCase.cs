using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Server.Model.Enums;

namespace Faccts.Model.Entities
{
    public partial class CourtCase
    {
        partial void Initialize()
        {            
            this.WhenAny(x => x.ParentCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("HasParentCases");
                }
                );

            this.CaseHistory = new TrackableCollection<CaseHistory>();
            this.CaseHistory.CollectionChanged += CaseHistoryChanged;
            this.CaseNotes = new TrackableCollection<CaseNotes>();
            this.Witnesses = new TrackableCollection<Witnesses>();
            this.Interpreters = new TrackableCollection<Interpreters>();
            this.OtherProtected = new TrackableCollection<OtherProtected>();
            this.Party1 = new CourtParty();
            this.Party2 = new CourtParty();
            this.Attorneys = new Attorneys();
            this.Children = new TrackableCollection<Children>();
            this.RestrainingPartyIdentificationInformation = new RestrainingPartyIDInfo();
            this.ThirdPartyData = new ThirdPartyData();
            this.WhenAny(x => x.Party1.IsDirty, x => x.Party2.IsDirty, x => x.RestrainingPartyIdentificationInformation.IsDirty,
                (x1, x2, x3) => x1.Value || x2.Value || x3.Value
                )
                .Subscribe(x =>
                {
                    this.OnPropertyChanging("IsPersonalInformationDirty");
                    this.OnPropertyChanged("IsPersonalInformationDirty");
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
        }

        public FACCTS.Server.Model.Enums.CaseStatus CaseStatus
        {
            get
            {
                if (CaseHistory == null)
                {
                    return FACCTS.Server.Model.Enums.CaseStatus.New;
                }
                var latestHistoryRecord = this.CaseHistory.OrderByDescending(x => x.Date).FirstOrDefault(x => x.Date <= DateTime.Now);
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
                if (CaseHistory == null)
                    return null;
                var latestHistoryRecord = this.CaseHistory.OrderByDescending(x => x.Date).FirstOrDefault(x => x.Date <= DateTime.Now);
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

        public DateTime? FileDate
        {
            get
            {
                if (this.CaseHistory == null || !CaseHistory.Any())
                {
                    return null;
                }
                var fileEvent = CaseHistory.FirstOrDefault(x => x.CaseHistoryEvent == (int)CaseHistoryEvent.New);
                if (fileEvent == null)
                    return null;
                return fileEvent.Date;
            }
        }

        public bool IsPersonalInformationDirty
        {
            get
            {
                return this.Party1.IsDirty || this.Party2.IsDirty || this.RestrainingPartyIdentificationInformation.IsDirty;
            }
        }

        public FACCTS.Server.Model.DataModel.CourtCase ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.CourtCase()
            {
                Id = this.Id,
                CaseNumber = this.CaseNumber,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
                Party1 = this.Party1.ToDTO(),
                Party2 = this.Party2.ToDTO(),
                RestrainingPartyIdentificationInformation = this.RestrainingPartyIdentificationInformation.ToDTO(),
                //CourtClerk = this.User1.ToDTO(),
            };
        }
    }
}
