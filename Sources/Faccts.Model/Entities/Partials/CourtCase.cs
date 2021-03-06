﻿using System;
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
            UpdateCaseNotesChanged();
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
                    this.OnPropertyChanged("IsPersonalInformationDirty", false);
                }
                );
            PersonsChanged = Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(handler =>
                {
                    NotifyCollectionChangedEventHandler eh = (s, e) => handler(e);
                    return eh;
                },
                handler => this.Persons.CollectionChanged += handler,
                handler => this.Persons.CollectionChanged -= handler
                );
            PersonsChanged.Subscribe(_ =>
                {
                    UpdateDirtyState();
                }
            );
            
           
        }

        private void UpdateCaseNotesChanged()
        {
            CaseNotesChanged = Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(handler =>
            {
                NotifyCollectionChangedEventHandler eh = (s, e) => handler(e);
                return eh;
            },
                     handler => this.CaseNotes.CollectionChanged += handler,
                     handler => this.CaseNotes.CollectionChanged -= handler
                    );
            CaseNotesChanged.Subscribe(_ =>
            {
                UpdateDirtyState();
            }
            );
        }

        private void UpdateDirtyState()
        {
            this.IsDirty = true;
            if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
        }

        private IObservable<NotifyCollectionChangedEventArgs> PersonsChanged;
        private IObservable<NotifyCollectionChangedEventArgs> CaseNotesChanged;

        private void CaseHistoryChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.OnPropertyChanged("CaseStatus", false);
            this.OnPropertyChanged("Hearings", false);
            this.OnPropertyChanged("HasDocket", false);
        }

        private static FACCTS.Server.Model.Enums.CaseStatus CaseHistoryEventToStatus(FACCTS.Server.Model.Enums.CaseHistoryEvent chEvent)
        {
            FACCTS.Server.Model.Enums.CaseStatus result;
            switch(chEvent)
            {
                case FACCTS.Server.Model.Enums.CaseHistoryEvent.File:
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
                this.ChangeTracker.ChangeTrackingEnabled = false;
                this.CaseNumber = dto.CaseNumber;
                this.Id = dto.Id;

                this.CCPORId = dto.CCPORId;
                this.CCPORStatus = (int?)dto.CCPORStatus;
                this.LastAction = dto.LastAction;
                this.Party1 = new CourtParty(dto.Party1);
                this.Party2 = new CourtParty(dto.Party2);
                this.CaseHistory = new TrackableCollection<Entities.CaseHistory>(dto.CaseHistory.Select(x => new CaseHistory(x)));
                this.CaseHistory.CollectionChanged += CaseHistoryChanged;
                dto.CaseNotes.Aggregate(this.CaseNotes, (notes, item) =>
                    {
                        CaseNotes cn = new CaseNotes(item);
                        notes.Add(cn);
                        cn.MarkAsUnchanged();
                        return notes;
                    }
                    );

                this.RestrainingPartyIdentificationInformation = new RestrainingPartyIDInfo(dto.RestrainingPartyIdentificationInformation);
                this.AttorneyForChild = new Attorneys(dto.AttorneyForChild);
                this.ThirdPartyAttorneyData = new ThirdPartyData(dto.ThirdPartyData);
                dto.OtherProtected.Aggregate(this.Persons, (persons, item) => 
                {
                    OtherProtected op = new OtherProtected(item);
                    persons.Add(op);
                    op.MarkAsUnchanged();
                    return persons;
                });
                dto.Children.Aggregate(this.Persons, (persons, item) =>
                    {
                        Child c = new Child(item);
                        persons.Add(c);
                        c.MarkAsUnchanged();
                        return persons;
                    }
                    );
                dto.Witnesses.Aggregate(this.Persons, (persons, item) =>
                    {
                        PersonBase p = new PersonBase(item);
                        persons.Add(p);
                        p.MarkAsUnchanged();
                        return persons;
                    }
                    );
                dto.Interpreters.Aggregate(this.Persons, (persons, item) =>
                    {
                        Interpreter ip = new Interpreter(item);
                        persons.Add(ip);
                        ip.MarkAsUnchanged();
                        return persons;
                    }
                    );
                RaiseNavigationPropertyLoading(() => CourtClerk);

                this.MarkAsUnchanged();
                this.ChangeTracker.ChangeTrackingEnabled = true;
            }
            
            
            
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
                    this.OnPropertyChanged("HasDocket", false);
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
                var fileEvent = CaseHistory.FirstOrDefault(x => x.CaseHistoryEvent == (int)CaseHistoryEvent.File);
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
                Party1Id = this.Party1_Id > 0 ? this.Party1_Id: (long?)null,
                Party2Id = this.Party2_Id > 0 ? this.Party2_Id : (long?)null,
                RestrainingPartyIdentificationInformation = this.RestrainingPartyIdentificationInformation.ConvertToDTO(),
                CaseHistory = this.CaseHistory.Where(x => x.IsDirty).Select(x =>x.ConvertToDTO()).ToArray(),
                CaseNotes = this.CaseNotes.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                Children = this.Children.Where(x => x.IsDirty).Select(x => ((IDataTransferConvertible<FACCTS.Server.Model.DataModel.Child>)x).ConvertToDTO()).ToArray(),
                OtherProtected = this.OtherProtected.Where(x => x.IsDirty).Select(x => ((IDataTransferConvertible<FACCTS.Server.Model.DataModel.OtherProtected>)x).ConvertToDTO()).ToArray(),
                Witnesses = this.Witnesses.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                Interpreters = this.Interpreters.Where(x => x.IsDirty).Select(x => ((IDataTransferConvertible<FACCTS.Server.Model.DataModel.Interpreter>)x).ConvertToDTO()).ToArray(),
                ThirdPartyData = this.ThirdPartyAttorneyData.ConvertToDTO(),
                ThirdPartyDataId = this.ThirdPartyDataId.GetValueOrDefault(0) > 0 ? this.ThirdPartyDataId : null,
                AttorneyForChild = ((IDataTransferConvertible<FACCTS.Server.Model.DataModel.Attorney>)this.AttorneyForChild).ConvertToDTO(),
                AttorneyForChildId = this.AttorneyForChild_Id.GetValueOrDefault(0) > 0 ? this.AttorneyForChild_Id : null,
                LastAction = this.LastAction,
                //CourtClerk = this.User1.ToDTO(),
            };
        }

        private ReactiveCollection<PersonBase> _witnesses;
        public ReactiveCollection<PersonBase> Witnesses
        {
            get
            {
                if (_witnesses == null)
                {
                    _witnesses = this.Persons
                        .Where(x => x.PersonType == PersonType.Witness)
                        .CreateDerivedCollection(x => x, signalReset: PersonsChanged);
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
                    _interpreters = this.Persons
                        .Where(x => x.PersonType == PersonType.Interpreter)
                        .Select(x => (Interpreter)x)
                        .CreateDerivedCollection(x => x, signalReset: PersonsChanged);
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
                    _children = this.Persons
                        .Where(x => x.PersonType == PersonType.Child)
                        .Select(x => (Child)x)
                        .CreateDerivedCollection(x => x, signalReset: PersonsChanged);
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
                    _otherProtected = this.Persons
                        .Where(x => x.PersonType == PersonType.OtherProtected)
                        .Select(x => (OtherProtected)x)
                        .CreateDerivedCollection(x => x, signalReset: PersonsChanged);
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
                return this.CaseStatus == FACCTS.Server.Model.Enums.CaseStatus.Active;
            }
        }
    }
}
