using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Server.Model.Enums;
using System.Reactive.Linq;
using System.Collections.Specialized;

namespace Faccts.Model.Entities
{
    public partial class CourtCase : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtCase>
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
            this.Party1 = new CourtParty();
            this.Party2 = new CourtParty();
            this.RestrainingPartyIdentificationInformation = new RestrainingPartyIDInfo();
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
            this.OnPropertyChanged("Hearings");
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
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.CourtCase()
            {
                Id = this.Id,
                CaseNumber = this.CaseNumber,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
                Party1 = this.Party1.ConvertToDTO(),
                Party2 = this.Party2.ConvertToDTO(),
                RestrainingPartyIdentificationInformation = this.RestrainingPartyIdentificationInformation.ConvertToDTO(),
                CaseHistory = this.CaseHistory.Where(x => x.IsDirty).Select(x =>x.ConvertToDTO()).ToArray(),
                CaseNotes = this.CaseNotes.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                Children = this.Children.Where(x => x.IsDirty).Select(x => ((IDataTransferConvertible<FACCTS.Server.Model.DataModel.Child>)x).ConvertToDTO()).ToArray(),
                Witnesses = this.Witnesses.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                Interpreters = this.Interpreters.Where(x => x.IsDirty).Select(x => ((IDataTransferConvertible<FACCTS.Server.Model.DataModel.Interpreter>)x).ConvertToDTO()).ToArray(),
                //CourtClerk = this.User1.ToDTO(),
            };
        }


        public List<Hearings> Hearings
        {
            get
            {
                return this
                    .CaseHistory
                    .Where(x => x.CaseHistoryEvent == FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing && x.Date.HasValue)
                    .Select(x => x.Hearing)
                    .OrderBy(x => x.HearingDate)
                    .ToList();
            }
        }

        private void UpdateHistoryCollection()
        {
            if (this.CaseHistory.FirstOrDefault(x => x.CaseHistoryEvent == CaseHistoryEvent.Hearing) == null)
            {
                this.CaseHistory.Add(
                    new CaseHistory()
                        {
                            Date = null,
                            CaseHistoryEvent = FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing,
                        }
                    );
            }
        }

        public CourtPartyAttorneyData Party1AttorneyData
        {
            get
            {
                UpdateHistoryCollection();
                return this.CaseHistory.OrderByDescending(x => x.Date.GetValueOrDefault(DateTime.MaxValue)).First(x => x.CaseHistoryEvent == CaseHistoryEvent.Hearing).Party1AttorneyData;
            }
        }

        public CourtPartyAttorneyData Party2AttorneyData
        {
            get
            {
                UpdateHistoryCollection();
                return this.CaseHistory.OrderByDescending(x => x.Date.GetValueOrDefault(DateTime.MaxValue)).First(x => x.CaseHistoryEvent == CaseHistoryEvent.Hearing).Party2AttorneyData;
            }
        }

        public Attorneys AttorneyForChild
        {
            get
            {
                UpdateHistoryCollection();
                return this.CaseHistory.OrderByDescending(x => x.Date.GetValueOrDefault(DateTime.MaxValue)).First(x => x.CaseHistoryEvent == CaseHistoryEvent.Hearing).AttorneyForChild;
            }
        }

        public ThirdPartyData ThirdPartyAttorneyData
        {
            get
            {
                UpdateHistoryCollection();
                return this.CaseHistory.OrderByDescending(x => x.Date.GetValueOrDefault(DateTime.MaxValue)).First(x => x.CaseHistoryEvent == CaseHistoryEvent.Hearing).ThirdPartyData;
            }
        }

        private ReactiveCollection<AdditionalParty> _witnesses;
        public ReactiveCollection<AdditionalParty> Witnesses
        {
            get
            {
                if (_witnesses == null)
                {
                    _witnesses = this.AdditionalParties.CreateDerivedCollection(x => x, x => x.Designation == ExtendedDesignation.Witness);
                }
                return _witnesses;
            }
        }

        private ReactiveCollection<Interpreter> _interpreters;
        public ReactiveCollection<Interpreter> Interpreters
        {
            get
            {
                if (_interpreters == null)
                {
                    _interpreters = this.AdditionalParties.CreateDerivedCollection<AdditionalParty, Interpreter>(x => (Interpreter)x, x => x is Interpreter && x.Designation == ExtendedDesignation.Interpreter);
                }
                return _interpreters;
            }
        }

        private ReactiveCollection<Child> _children;
        public ReactiveCollection<Child> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = this.AdditionalParties.CreateDerivedCollection<AdditionalParty, Child>(x => (Child)x, x => x is Child && x.Designation == ExtendedDesignation.Son || x.Designation == ExtendedDesignation.Daughter);
                }
                return _children;
            }
        }

        private ReactiveCollection<OtherProtected> _otherProtected;
        public ReactiveCollection<OtherProtected> OtherProtected
        {
            get
            {
                if (_otherProtected == null)
                {
                    _otherProtected = this.AdditionalParties.CreateDerivedCollection<AdditionalParty, OtherProtected>(x => (OtherProtected)x, x => x is OtherProtected && x.Designation == ExtendedDesignation.OtherProtected);
                }
                return _otherProtected;
            }
        }

        public void NewChild()
        {
            this.AdditionalParties.Add(
                new Child()
                {
                    PartyFor = PartyFor.Party1,
                    Designation = ExtendedDesignation.Son,
                    Sex = Gender.F,
                    EntityType = FACCTSEntity.PERSON,
                }
                );
        }

        public void RemoveChild(Child child)
        {
            this.AdditionalParties.Remove(child);
        }

        public void NewWitness()
        {
            this.AdditionalParties.Add(
                    new AdditionalParty()
                    {
                        Designation = ExtendedDesignation.Witness,
                        EntityType = FACCTSEntity.PERSON,
                        PartyFor = PartyFor.Party1,
                    }
                );
        }

        public void NewInterpreter()
        {
            this.AdditionalParties.Add(
                new Interpreter()
                {
                    Designation = ExtendedDesignation.Interpreter,
                    EntityType = FACCTSEntity.PERSON,
                    PartyFor = PartyFor.Party1,
                }
                );
        }

        public void RemoveInterpreter(Interpreter interpreter)
        {
            this.AdditionalParties.Remove(interpreter);
        }

        public void NewOtherProtected()
        {
            this.AdditionalParties.Add(new OtherProtected()
                {
                    Designation = ExtendedDesignation.OtherProtected,
                    EntityType = FACCTSEntity.PERSON,
                    Sex = Gender.F,
                    PartyFor = PartyFor.Party1,
                }
                );
        }

        public void RemoveOtherProtected(OtherProtected otherProtected)
        {
            this.AdditionalParties.Remove(otherProtected);
        }

        public void RemoveAdditionalParty(AdditionalParty additionalParty)
        {
            this.AdditionalParties.Remove(additionalParty);
        }
        

        public void AssignNewHearing(Hearings hearing)
        {
            var emptyHearing = this.CaseHistory.FirstOrDefault(y => !y.Date.HasValue && y.CaseHistoryEvent == FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing);
            if (emptyHearing != null)
            {
                emptyHearing.Hearing = hearing;
                emptyHearing.Date = DateTime.Now;
                //this.CaseHistory.
            }
            else
            {
                CaseHistory.Add(
                   new CaseHistory()
                   {
                       Hearing = hearing,
                       CaseHistoryEvent = FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing,
                       Date = DateTime.Now,
                   }
                   );
            }
        }

        private ReactiveCollection<CaseHistory> _displayableCaseHistory;
        public ReactiveCollection<CaseHistory> DisplayableCaseHistory
        {
            get
            {
                if (_displayableCaseHistory == null)
                {
                    _displayableCaseHistory = this.CaseHistory.CreateDerivedCollection(x => x, filter: x => x.Date != null, signalReset: Observable.Merge(this.CaseHistory.Select(x => x.WhenAny(y => y.Date, y => y.Value))));
                }
                return _displayableCaseHistory;
            }
        }

        public bool HasDocket
        {
            get
            {
                if (this.CourtDocketRecord == null)
                    return false;
                return this.CourtDocketRecord.Hearing != null && this.CourtDocketRecord.Hearing.CaseHistory.CaseHistoryEvent == CaseHistoryEvent.Hearing;
            }
        }
    }
}
