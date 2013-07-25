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
            this.ThirdPartyAttorneyData = new ThirdPartyData();
            this.AttorneyForChild = new Attorneys();
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

        public CourtCase(FACCTS.Server.Model.DataModel.CourtCase dto) : this()
        {
            if (dto != null)
            {
                this.CaseNumber = dto.CaseNumber;
                this.Id = dto.Id;

                this.CCPORId = dto.CCPORId;
                this.CCPORStatus = (int?)dto.CCPORStatus;
                this.Party1 = new CourtParty(dto.Party1);
                this.Party2 = new CourtParty(dto.Party2);
                this.CaseHistory = new TrackableCollection<Entities.CaseHistory>(dto.CaseHistory.Select(x => new CaseHistory(x)));
                this.CaseNotes = new TrackableCollection<Entities.CaseNotes>(dto.CaseNotes.Select(x => new CaseNotes(x)));
                this.RestrainingPartyIdentificationInformation = new RestrainingPartyIDInfo(dto.RestrainingPartyIdentificationInformation);
                RaiseNavigationPropertyLoading(() => User);
            }
            
            
            this.MarkAsUnchanged();
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
                ThirdPartyData = this.ThirdPartyAttorneyData.ToDTO(),
                AttorneyForChild = this.AttorneyForChild.ToDTO(),
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


        private ReactiveCollection<PersonBase> _witnesses;
        public ReactiveCollection<PersonBase> Witnesses
        {
            get
            {
                if (_witnesses == null)
                {
                    _witnesses = this.Persons.CreateDerivedCollection(x => x, x => x.PersonType == PersonType.Witness);
                    _witnesses.ChangeTrackingEnabled = true;
                    _witnesses.ItemChanged.Subscribe(x =>
                    {
                        if (x.PropertyName == "IsDirty" && (bool)x.GetValue())
                        {
                            this.IsDirty = true;
                        }
                    });

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
                    _interpreters = this.Persons.CreateDerivedCollection<PersonBase, Interpreter>(x => (Interpreter)x, x => x is Interpreter && x.PersonType == PersonType.Interpreter);
                    _interpreters.ChangeTrackingEnabled = true;
                    _interpreters.ItemChanged.Subscribe(x =>
                        {
                            if (x.PropertyName == "IsDirty" && (bool)x.GetValue())
                            {
                                this.IsDirty = true;
                            }
                        }
                        );
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
                    _children = this.Persons.CreateDerivedCollection<PersonBase, Child>(x => (Child)x, x => x is Child && x.PersonType == PersonType.Child);
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
                    _otherProtected = this.Persons.CreateDerivedCollection<PersonBase, OtherProtected>(x => (OtherProtected)x, x => x is OtherProtected && x.PersonType == PersonType.OtherProtected);
                }
                return _otherProtected;
            }
        }

        public void NewChild()
        {
            this.Persons.Add(
                new Child()
                {
                    PartyFor = PartyFor.Party1,
                    PersonType = PersonType.Child,
                    Sex = Gender.F,
                    EntityType = FACCTSEntity.PERSON,
                }
                );
        }

        public void RemoveChild(Child child)
        {
            this.Persons.Remove(child);
        }

        public void NewWitness()
        {
            this.Persons.Add(
                    new PersonBase()
                    {
                        PersonType = PersonType.Witness,
                        EntityType = FACCTSEntity.PERSON,
                        PartyFor = PartyFor.Party1,
                    }
                );
        }

        public void NewInterpreter()
        {
            this.Persons.Add(
                new Interpreter()
                {
                    PersonType = PersonType.Interpreter,
                    EntityType = FACCTSEntity.PERSON,
                    PartyFor = PartyFor.Party1,
                }
                );
        }

        public void RemoveInterpreter(Interpreter interpreter)
        {
            this.Persons.Remove(interpreter);
        }

        public void NewOtherProtected()
        {
            this.Persons.Add(new OtherProtected()
                {
                    PersonType = PersonType.OtherProtected,
                    EntityType = FACCTSEntity.PERSON,
                    Sex = Gender.F,
                    PartyFor = PartyFor.Party1,
                }
                );
        }

        public void RemoveOtherProtected(OtherProtected otherProtected)
        {
            this.Persons.Remove(otherProtected);
        }

        public void RemoveAdditionalParty(PersonBase additionalParty)
        {
            this.Persons.Remove(additionalParty);
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
