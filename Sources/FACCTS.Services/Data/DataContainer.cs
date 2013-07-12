using Faccts.Model.Entities;
using FACCTS.Server.Model.Enums;
using FACCTS.Services.Logger;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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

        private TrackableCollection<CourtCase> _courtCases;
        public TrackableCollection<CourtCase> CourtCases
        {
            get
            {
                return _courtCases;
            }
            private set
            {
                if (_courtCases != null)
                {
                    _courtCases.CollectionChanged -= FixupCourtCases;
                }
                _courtCases = value;
                if (_courtCases != null)
                {
                    _courtCases.CollectionChanged += FixupCourtCases;
                }
                RaisePropertyChanged(() => CourtCases);
            }
        }

        private void FixupCourtCases(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsSearching)
            {
                return;
            }
            if (e.NewItems != null)
            {
                foreach (CourtCase item in e.NewItems)
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtCases", item);
                    }
                }
                RaisePropertyChanged(() => CourtCases);
            }

            if (e.OldItems != null)
            {
                foreach (CourtCase item in e.OldItems)
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtCases", item);
                    }
                }
            }
            RaisePropertyChanged(() => CourtCases);
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
            if (!reset && CourtCases != null)
                return;
            IsSearching = true;
            try
            {
                CourtCases = new TrackableCollection<CourtCase>(FACCTS.Services.Data.CourtCases.GetAll());
            }
            finally
            {
                IsSearching = false;   
            }
        }

        public void UpdateDictionaries()
        {
            RaisePropertyChanged(() => Sexes);
            RaisePropertyChanged(() => HairColors);
            RaisePropertyChanged(() => EyesColors);
            RaisePropertyChanged(() => Races);
            RaisePropertyChanged(() => Designations);
            //RaisePropertyChanged(() => ParticipantRoles);
        }

        public FACCTSConfiguration FacctsConfiguration
        {
            get
            {
                return FACCTSConfigurations.Configuration;
            }
        }

        private List<CourtDepartmenets> _availableDepartments;
        public List<CourtDepartmenets> AvailableDepartments
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
                    _stateList = EnumDescript<USAState>.GetList<USAState>();
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
                    _entityTypeList = EnumDescript<FACCTSEntity>.GetList<FACCTSEntity>();
                }
                return _entityTypeList;
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

        private List<Designation> _designations;
        public List<Designation> Designations
        {
            get
            {
                if (_designations == null)
                {
                    _designations = FACCTS.Services.Data.Designations.GetAll();
                }
                return _designations;
            }
        }

        public TrackableCollection<CourtDocketRecord> CourtDocketRecords
        {
            get
            {
                if (_courtDocketRecords == null)
                {
                    _courtDocketRecords = new TrackableCollection<CourtDocketRecord>();
                    _courtDocketRecords.CollectionChanged += FixupCourtDocketRecords;
                }
                return _courtDocketRecords;
            }
            set
            {
                if (!ReferenceEquals(_courtDocketRecords, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_courtDocketRecords != null)
                    {
                        _courtDocketRecords.CollectionChanged -= FixupCourtDocketRecords;
                    }
                    _courtDocketRecords = value;
                    if (_courtDocketRecords != null)
                    {
                        _courtDocketRecords.CollectionChanged += FixupCourtDocketRecords;
                    }
                    RaisePropertyChanged(() => CourtDocketRecords);
                }
            }
        }

        public CourtCase SaveData(CourtCase courtCaseToSave)
        {
            return FACCTS.Services.Data.CourtCases.SaveData(courtCaseToSave);
        }

        private void FixupCourtDocketRecords(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsSearching)
            {
                return;
            }

            if (e.NewItems != null)
            {
                foreach (CourtDocketRecord item in e.NewItems)
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
                foreach (CourtDocketRecord item in e.OldItems)
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtDocketRecords", item);
                    }
                }
            }
        }
        private TrackableCollection<CourtDocketRecord> _courtDocketRecords;

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

    public class SearchCriteria
    {
        public SearchCriteria()
        {

        }

        public string CaseNumber { get; set; }
        public string CCPOR_ID { get; set; }
        public DateTime? FirstActivityEndDate { get; set; }
        public DateTime? FirstActivityStartDate { get; set; }
        public DateTime? LastActivityEndDate { get; set; }
        public DateTime? LastActivityStartDate { get; set; }
        public string Party1FirstName { get; set; }
        public string Party1LastName { get; set; }
        public string Party1MiddleName { get; set; }
        public string Party2FirstName { get; set; }
        public string Party2LastName { get; set; }
        public string Party2MiddleName { get; set; }
        public FACCTS.Server.Model.Enums.CaseStatus CaseStatus { get; set; }
        public Faccts.Model.Entities.User CourtClerk { get; set; }

        public Server.Model.Enums.CCPORStatus CCPORStatus { get; set; }
    }

   
}
