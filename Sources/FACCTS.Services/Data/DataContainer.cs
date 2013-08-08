using Faccts.Model.Entities;
using FACCTS.Server.Model.Calculations;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.Interfaces;
using FACCTS.Services.Dialog;
using FACCTS.Services.Logger;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Threading;

namespace FACCTS.Services.Data
{
    [Export(typeof(IDataContainer))]
    public class DataContainer : IDataContainer
    {
        private ILogger _logger;

        [ImportingConstructor]
        public DataContainer(ILogger logger)
        {
            //SearchCourtCases();
            _logger = logger;
        }

        private SearchCriteria _searchCriteria = new SearchCriteria();
        public SearchCriteria SearchCriteria
        {
            get
            {
                return _searchCriteria;
            }
        }

        [Import]
        public ICourtDocketSearchCriteria CourtDocketSearchCriteria
        {
            get;
            set;
        }

        private TrackableCollection<Faccts.Model.Entities.CourtCaseHeading> _courtCaseheadings;
        public TrackableCollection<Faccts.Model.Entities.CourtCaseHeading> CourtCaseHeadings
        {
            get
            {
                return _courtCaseheadings;
            }
            private set
            {
                _courtCaseheadings = value;
                RaisePropertyChanged(() => CourtCaseHeadings);
            }
        }



        private ObjectChangeTracker _changeTracker;
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }

        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            //TODO: implement this when needed
        }

        public bool IsSearching { get; private set; }

        public void SearchCourtCases(bool reset = false)
        {
            if (!reset && CourtCaseHeadings != null)
                return;
            IsSearching = true;
            ChangeTracker.ChangeTrackingEnabled = false;
            try
            {
                CourtCaseHeadings = new TrackableCollection<Faccts.Model.Entities.CourtCaseHeading>(FACCTS.Services.Data.CourtCases.GetAll(this.SearchCriteria));
            }
            finally
            {
                IsSearching = false;
                ChangeTracker.ChangeTrackingEnabled = true;
            }
        }

        public void UpdateDictionaries()
        {
            RaisePropertyChanged(() => Sexes);
            RaisePropertyChanged(() => HairColors);
            RaisePropertyChanged(() => EyesColors);
            RaisePropertyChanged(() => Races);
            RaisePropertyChanged(() => ParticipantRoles);
        }

        public FACCTSConfiguration FacctsConfiguration
        {
            get
            {
                return FACCTSConfigurations.Configuration;
            }
        }

        private List<EnumDescript<ParticipantRole>> _participantRoles;
        public List<EnumDescript<ParticipantRole>> ParticipantRoles
        {
            get
            {
                if (_participantRoles == null)
                {
                    _participantRoles = EnumDescript<ParticipantRole>.GetList();
                }
                return _participantRoles;
            }
        }

        private List<EnumDescript<FACCTS.Server.Model.Enums.Relationship>> _relationships;
        public List<EnumDescript<FACCTS.Server.Model.Enums.Relationship>> Relationships
        {
            get
            {
                if (_relationships == null)
                {
                    _relationships = EnumDescript<FACCTS.Server.Model.Enums.Relationship>.GetList();
                }
                return _relationships;
            }
        }

        private List<CourtDepartment> _availableDepartments;
        public List<CourtDepartment> AvailableDepartments
        {
            get
            {
                if (_availableDepartments == null)
                {
                    _availableDepartments = CourtDepartments.GetByCourtCountyId(this.FacctsConfiguration.CurrentCourtCountyId);
                }
                return _availableDepartments;
            }
        }

        private List<Courtrooms> _availableCourtrooms;
        public List<Courtrooms> AvailableCourtrooms
        {
            get
            {
                if (_availableCourtrooms == null)
                {
                    _availableCourtrooms = CourtRooms.GetAll(this.FacctsConfiguration.CurrentCourtCountyId);
                }
                return _availableCourtrooms;
            }
        }

        private List<EnumDescript<Gender>> _sexes;
        public List<EnumDescript<Gender>> Sexes
        {
            get
            {
                if (_sexes == null)
                {
                    _sexes = FACCTS.Services.Data.Sexes.GetAll();
                }
                return _sexes;
            }
        }

        private List<EnumDescript<USAState>> _stateList;
        public List<EnumDescript<USAState>> StateList
        {
            get
            {
                if (_stateList == null)
                {
                    _stateList = EnumDescript<USAState>.GetList();
                }
                return _stateList;
            }
        }

        private List<EnumDescript<FACCTSEntity>> _entityTypeList;
        public List<EnumDescript<FACCTSEntity>> EntityTypeList
        {
            get
            {
                if (_entityTypeList == null)
                {
                    _entityTypeList = EnumDescript<FACCTSEntity>.GetList();
                }
                return _entityTypeList;
            }
        }

        private CourtCase _currentCourtCase;
        public CourtCase CurrentCourtCase
        {
            get
            {
                return _currentCourtCase;
            }
            protected internal set
            {
                if (value == _currentCourtCase)
                    return;

                _currentCourtCase = value;
                RaisePropertyChanged(() => CurrentCourtCase);
            }
        }

        private List<HairColor> _hairColors;
        public List<HairColor> HairColors
        {
            get
            {
                if (_hairColors == null)
                {
                    _hairColors = FACCTS.Services.Data.HairColors.GetAll();
                }
                return _hairColors;
            }
        }

        private List<EyesColor> _eyesColors;
        public List<EyesColor> EyesColors
        {
            get
            {
                if (_eyesColors == null)
                {
                    _eyesColors = FACCTS.Services.Data.EyesColors.GetAll();
                }
                return _eyesColors;
            }
        }

        private List<Race> _races;
        public List<Race> Races
        {
            get
            {
                if (_races == null)
                {
                    _races = FACCTS.Services.Data.Races.GetAll();
                }
                return _races;
            }
        }

        private List<EnumDescript<AddressType>> _addressTypes;
        public List<EnumDescript<AddressType>> AddressTypes
        {
            get
            {
                if (_addressTypes == null)
                {
                    _addressTypes = EnumDescript<AddressType>.GetList();
                }
                return _addressTypes;
            }
        }

        private List<EnumDescript<CourtAction>> _courtActions;
        public List<EnumDescript<CourtAction>> CourtActions
        {
            get
            {
                if (_courtActions == null)
                {
                    _courtActions = EnumDescript<CourtAction>.GetList();
                }
                return _courtActions;
            }
        }

        private List<EnumDescript<FACCTS.Server.Model.Enums.Designation>> _designations;
        public List<EnumDescript<FACCTS.Server.Model.Enums.Designation>> Designations 
        {
            get
            {
                if (_designations == null)
                {
                    _designations = EnumDescript<FACCTS.Server.Model.Enums.Designation>.GetList();
                }
                return _designations;
            } 
        }

        public TrackableCollection<Faccts.Model.Entities.DocketRecord> DocketRecords
        {
            get
            {
                if (_hearings == null)
                {
                    _hearings = new TrackableCollection<Faccts.Model.Entities.DocketRecord>();
                    _hearings.CollectionChanged += FixupCourtDocketRecords;
                }
                return _hearings;
            }
            set
            {
                if (!ReferenceEquals(_hearings, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_hearings != null)
                    {
                        _hearings.CollectionChanged -= FixupCourtDocketRecords;
                    }
                    _hearings = value;
                    if (_hearings != null)
                    {
                        _hearings.CollectionChanged += FixupCourtDocketRecords;
                    }
                    RaisePropertyChanged(() => DocketRecords);
                }
            }
        }

        public void UpdateBySelection(Faccts.Model.Entities.CourtCaseHeading selectedItem)
        {
            if (selectedItem == null)
            {
                throw new ArgumentNullException("selectedItem");
            }
            if (this.CurrentCourtCase != null && this.CurrentCourtCase.ChangeTracker.State == ObjectState.Added)
            {
                return;
            }
            if (this.CurrentCourtCase != null && this.CurrentCourtCase.IsDirty)
            {
                IDialogService dialogService = ServiceLocatorContainer.Locator.GetInstance<IDialogService>();
                if (dialogService.MessageBox("Do you really want do discard all the changes?", "Please confirm", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question) == System.Windows.MessageBoxResult.No)
                {
                    return;
                }
            }
            this.CurrentCourtCase = CourtCases.GetById(selectedItem.CourtCaseId);
        }

        public CourtCase SaveData(CourtCase courtCaseToSave)
        {
            return FACCTS.Services.Data.CourtCases.SaveData(courtCaseToSave);
        }

        public void SearchDocket()
        {
            ChangeTracker.ChangeTrackingEnabled = false;
            IsSearching = true;
            try
            {
                this.DocketRecords = new TrackableCollection<Faccts.Model.Entities.DocketRecord>(CourtDockets.GetDocket());
            }
            finally
            {
                IsSearching = false;
                ChangeTracker.ChangeTrackingEnabled = true;
            }
        }

        private void FixupCourtDocketRecords(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsSearching)
            {
                return;
            }

            if (e.NewItems != null)
            {
                foreach (Hearings item in e.NewItems)
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtDocketRecords", item);
                    }
                }
            }

            if (e.OldItems != null)
            {
                foreach (Hearings item in e.OldItems)
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtDocketRecords", item);
                    }
                }
            }
        }
        private TrackableCollection<Faccts.Model.Entities.DocketRecord> _hearings;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("'propertyExpression' should be a member expression");

            var expression = body.Expression as ConstantExpression;
            if (expression == null)
                throw new ArgumentException("'propertyExpression' body should be a constant expression");

            object target = Expression.Lambda(expression).Compile().DynamicInvoke();

            RaisePropertyChanged(body.Member.Name);
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }

    public class SearchCriteria : ICourtCaseSearchCriteria
    {
        public SearchCriteria()
        {

        }

        public string CaseNumber { get; set; }
        public string CCPOR_ID { get; set; }
        public string Party1FirstName { get; set; }
        public string Party1LastName { get; set; }
        public string Party1MiddleName { get; set; }
        public string Party2FirstName { get; set; }
        public string Party2LastName { get; set; }
        public string Party2MiddleName { get; set; }
        public CourtAction? CourtAction { get; set; }
        public Server.Model.Enums.CCPORStatus CCPORStatus { get; set; }
        public CaseStatus? CaseStatus
        {
            get;
            set;
        }
        public long? CourtClerkId
        {
            get;
            set;
        }
        public DateTime? FirstHearingEnd
        {
            get;
            set;
        }
        public DateTime? FirstHearingStart
        {
            get;
            set;
        }
        public DateTime? LastHearingEnd
        {
            get;
            set;
        }
        public DateTime? LastHearingStart
        {
            get;
            set;
        }

        public override string ToString()
        {
            return ReflectionHelper.UriStringByPublicProperties(this);
        }
    }
   
}
