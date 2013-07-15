//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using ReactiveUI;
using System.Reactive.Linq;

namespace Faccts.Model.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CaseHistory))]
    [KnownType(typeof(Courtrooms))]
    [KnownType(typeof(CourtDepartmenets))]
    [KnownType(typeof(CourtDocketRecord))]
    public partial class Hearings: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public Hearings()
    		{
    			_reactiveHelper = new MakeObjectReactiveHelper(this);
    			Initialize();
    			Observable.FromEvent<EventHandler<ObjectStateChangingEventArgs>, ObjectStateChangingEventArgs>(
    			handler =>
    				{
    					EventHandler<ObjectStateChangingEventArgs> eh = (sender, e) => handler(e);
    					return eh;
    				},
    				handler =>  ChangeTracker.ObjectStateChanging += handler,
    				handler =>  ChangeTracker.ObjectStateChanging -= handler
    			)
    			.Subscribe(e =>
    				{
    					if(e.NewState == ObjectState.Unchanged)
    					{
    						IsDirty = false;
    					}
    				}
    			);
    			Observable.Merge<Object>(
    				this.ObservableForProperty(x => x.Id)
    				,this.ObservableForProperty(x => x.HearingDate)
    				,this.ObservableForProperty(x => x.Judge)
    				,this.ObservableForProperty(x => x.Courtroom_Id)
    				,this.ObservableForProperty(x => x.Department_Id)
    				,this.ObservableForProperty(x => x.Session)
    				,this.ObservableForProperty(x => x.CaseHistory.IsDirty)
    				,this.ObservableForProperty(x => x.Courtrooms.IsDirty)
    				,this.ObservableForProperty(x => x.CourtDepartment.IsDirty)
    			).
    			Subscribe(_ =>
    			{
    				if (ChangeTracker.State != ObjectState.Unchanged)
    				{
    					IsDirty = true;
    				}
    			}
    			);
    		}
    
    		partial void Initialize();
    		
    		private bool _isDirty;
    		public bool IsDirty
    		{
    			get
    			{
    				return _isDirty;
    			}
    			set
    			{
    				if (_isDirty == value)
    					return;
    				OnPropertyChanging("IsDirty");
    				_isDirty = value;
    				OnPropertyChanged("IsDirty");
    			}
    		}
    				
    
    		public IObservable<IObservedChange<object, object>> Changed 
    		{
    			get { return _reactiveHelper.Changed; }
    		}
    		public IObservable<IObservedChange<object, object>> Changing 
    		{
    			get { return _reactiveHelper.Changing; }
    		}
    		public IDisposable SuppressChangeNotifications() 
    		{
    			return _reactiveHelper.SuppressChangeNotifications();
    		}
    
    		private PropertyChangingEventHandler _propertyChanging;
    		public event PropertyChangingEventHandler PropertyChanging
    		{
    			add
    			{
    				_propertyChanging += value;
    			}
    			remove
    			{
    				_propertyChanging -= value;
    			}
    		}
    
    		public event EventHandler<LoadingNavigationPropertiesEventArgs> OnNavigationPropertyLoading;
    		protected virtual void RaiseNavigationPropertyLoading(string propertyName)
            {
                if (OnNavigationPropertyLoading != null)
                    OnNavigationPropertyLoading(this, new LoadingNavigationPropertiesEventArgs(propertyName));
            }
    
            protected virtual void RaiseNavigationPropertyLoading<T>(Expression<Func<T>> propertyExpression)
            {
                var body = propertyExpression.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("'propertyExpression' should be a member expression");
    
                var expression = body.Expression as ConstantExpression;
                if (expression == null)
                    throw new ArgumentException("'propertyExpression' body should be a constant expression");
    
                object target = Expression.Lambda(expression).Compile().DynamicInvoke();
    
                RaiseNavigationPropertyLoading(body.Member.Name);
            }
    	    #region Simple Properties
    
        [DataMember]
        public long Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Id' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
    				OnPropertyChanging("Id");
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private long _id;
    
        [DataMember]
        public System.DateTime HearingDate
        {
            get { return _hearingDate; }
            set
            {
                if (_hearingDate != value)
                {
    				OnPropertyChanging("HearingDate");
                    _hearingDate = value;
                    OnPropertyChanged("HearingDate");
                }
            }
        }
        private System.DateTime _hearingDate;
    
        [DataMember]
        public string Judge
        {
            get { return _judge; }
            set
            {
                if (_judge != value)
                {
    				OnPropertyChanging("Judge");
                    _judge = value;
                    OnPropertyChanged("Judge");
                }
            }
        }
        private string _judge;
    
        [DataMember]
        public Nullable<long> Courtroom_Id
        {
            get { return _courtroom_Id; }
            set
            {
                if (_courtroom_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Courtroom_Id", _courtroom_Id);
                    if (!IsDeserializing)
                    {
                        if (Courtrooms != null && Courtrooms.Id != value)
                        {
                            Courtrooms = null;
                        }
                    }
    				OnPropertyChanging("Courtroom_Id");
                    _courtroom_Id = value;
                    OnPropertyChanged("Courtroom_Id");
                }
            }
        }
        private Nullable<long> _courtroom_Id;
    
        [DataMember]
        public Nullable<long> Department_Id
        {
            get { return _department_Id; }
            set
            {
                if (_department_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Department_Id", _department_Id);
                    if (!IsDeserializing)
                    {
                        if (CourtDepartment != null && CourtDepartment.Id != value)
                        {
                            CourtDepartment = null;
                        }
                    }
    				OnPropertyChanging("Department_Id");
                    _department_Id = value;
                    OnPropertyChanged("Department_Id");
                }
            }
        }
        private Nullable<long> _department_Id;
    
        [DataMember]
        public FACCTS.Server.Model.Enums.DocketSession Session
        {
            get { return _session; }
            set
            {
                if (_session != value)
                {
    				OnPropertyChanging("Session");
                    _session = value;
                    OnPropertyChanged("Session");
                }
            }
        }
        private FACCTS.Server.Model.Enums.DocketSession _session;

        #endregion

        #region Complex Properties
    
        [DataMember]
        public HearingIssue HearingIssue
        {
            get
            {
                if (!_hearingIssueInitialized && _hearingIssue == null)
                {
                    _hearingIssue = new HearingIssue();
                    ((INotifyComplexPropertyChanging)_hearingIssue).ComplexPropertyChanging += HandleHearingIssueChanging;
                }
                _hearingIssueInitialized = true;
                return _hearingIssue;
            }
            set
            {
                _hearingIssueInitialized = true;
                if (!Equals(_hearingIssue, value))
                {
                    if (_hearingIssue != null)
                    {
                        ((INotifyComplexPropertyChanging)_hearingIssue).ComplexPropertyChanging -= HandleHearingIssueChanging;
                    }
    
                    HandleHearingIssueChanging(this, null);
    				OnPropertyChanging("HearingIssue");
                    _hearingIssue = value;
                    OnPropertyChanged("HearingIssue");
    
                    if (value != null)
                    {
                        ((INotifyComplexPropertyChanging)_hearingIssue).ComplexPropertyChanging += HandleHearingIssueChanging;
                    }
                }
            }
        }
        private HearingIssue _hearingIssue;
        private bool _hearingIssueInitialized;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public CaseHistory CaseHistory
        {
            get { return _caseHistory; }
            set
            {
                if (!ReferenceEquals(_caseHistory, value))
                {
                    var previousValue = _caseHistory;
    				OnNavigationPropertyChanging("CaseHistory");
                    _caseHistory = value;
                    FixupCaseHistory(previousValue);
                    OnNavigationPropertyChanged("CaseHistory");
                }
            }
        }
        private CaseHistory _caseHistory;
    
        [DataMember]
        public Courtrooms Courtrooms
        {
            get { return _courtrooms; }
            set
            {
                if (!ReferenceEquals(_courtrooms, value))
                {
                    var previousValue = _courtrooms;
    				OnNavigationPropertyChanging("Courtrooms");
                    _courtrooms = value;
                    FixupCourtrooms(previousValue);
                    OnNavigationPropertyChanged("Courtrooms");
                }
            }
        }
        private Courtrooms _courtrooms;
    
        [DataMember]
        public CourtDepartmenets CourtDepartment
        {
            get { return _courtDepartment; }
            set
            {
                if (!ReferenceEquals(_courtDepartment, value))
                {
                    var previousValue = _courtDepartment;
    				OnNavigationPropertyChanging("CourtDepartment");
                    _courtDepartment = value;
                    FixupCourtDepartment(previousValue);
                    OnNavigationPropertyChanged("CourtDepartment");
                }
            }
        }
        private CourtDepartmenets _courtDepartment;
    
        [DataMember]
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
    				OnNavigationPropertyChanging("CourtDocketRecords");
                    if (_courtDocketRecords != null)
                    {
                        _courtDocketRecords.CollectionChanged -= FixupCourtDocketRecords;
                    }
                    _courtDocketRecords = value;
                    if (_courtDocketRecords != null)
                    {
                        _courtDocketRecords.CollectionChanged += FixupCourtDocketRecords;
                    }
                    OnNavigationPropertyChanged("CourtDocketRecords");
                }
            }
        }
        private TrackableCollection<CourtDocketRecord> _courtDocketRecords;

        #endregion

        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    	protected virtual void OnPropertyChanging(String propertyName)
        {
            if (_propertyChanging != null)
            {
                _propertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    	protected virtual void OnNavigationPropertyChanging(String propertyName)
        {
            if (_propertyChanging != null)
            {
                _propertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
    
    	
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
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
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
        // Records the original values for the complex property HearingIssue
        private void HandleHearingIssueChanging(object sender, EventArgs args)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
        }
    
    
        protected virtual void ClearNavigationProperties()
        {
            CaseHistory = null;
            Courtrooms = null;
            CourtDepartment = null;
            CourtDocketRecords.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupCaseHistory(CaseHistory previousValue)
        {
            // This is the principal end in an association that performs cascade deletes.
            // Update the event listener to refer to the new dependent.
            if (previousValue != null)
            {
                ChangeTracker.ObjectStateChanging -= previousValue.HandleCascadeDelete;
            }
    
            if (CaseHistory != null)
            {
                ChangeTracker.ObjectStateChanging += CaseHistory.HandleCascadeDelete;
            }
    
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && ReferenceEquals(previousValue.Hearing, this))
            {
                previousValue.Hearing = null;
            }
    
            if (CaseHistory != null)
            {
                CaseHistory.Hearing = this;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CaseHistory")
                    && (ChangeTracker.OriginalValues["CaseHistory"] == CaseHistory))
                {
                    ChangeTracker.OriginalValues.Remove("CaseHistory");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CaseHistory", previousValue);
                    // This is the principal end of an identifying association, so the dependent must be deleted when the relationship is removed.
                    // If the current state of the dependent is Added, the relationship can be changed without causing the dependent to be deleted.
                    if (previousValue != null && previousValue.ChangeTracker.State != ObjectState.Added)
                    {
                        previousValue.MarkAsDeleted();
                    }
                }
                if (CaseHistory != null && !CaseHistory.ChangeTracker.ChangeTrackingEnabled)
                {
                    CaseHistory.StartTracking();
                }
            }
        }
    
        private void FixupCourtrooms(Courtrooms previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Hearings.Contains(this))
            {
                previousValue.Hearings.Remove(this);
            }
    
            if (Courtrooms != null)
            {
                Courtrooms.Hearings.Add(this);
    
                Courtroom_Id = Courtrooms.Id;
            }
            else if (!skipKeys)
            {
                Courtroom_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Courtrooms")
                    && (ChangeTracker.OriginalValues["Courtrooms"] == Courtrooms))
                {
                    ChangeTracker.OriginalValues.Remove("Courtrooms");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Courtrooms", previousValue);
                }
                if (Courtrooms != null && !Courtrooms.ChangeTracker.ChangeTrackingEnabled)
                {
                    Courtrooms.StartTracking();
                }
            }
        }
    
        private void FixupCourtDepartment(CourtDepartmenets previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Hearings.Contains(this))
            {
                previousValue.Hearings.Remove(this);
            }
    
            if (CourtDepartment != null)
            {
                CourtDepartment.Hearings.Add(this);
    
                Department_Id = CourtDepartment.Id;
            }
            else if (!skipKeys)
            {
                Department_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CourtDepartment")
                    && (ChangeTracker.OriginalValues["CourtDepartment"] == CourtDepartment))
                {
                    ChangeTracker.OriginalValues.Remove("CourtDepartment");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CourtDepartment", previousValue);
                }
                if (CourtDepartment != null && !CourtDepartment.ChangeTracker.ChangeTrackingEnabled)
                {
                    CourtDepartment.StartTracking();
                }
            }
        }
    
        private void FixupCourtDocketRecords(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtDocketRecord item in e.NewItems)
                {
                    item.Hearing = this;
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
                    if (ReferenceEquals(item.Hearing, this))
                    {
                        item.Hearing = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtDocketRecords", item);
                    }
                }
            }
        }

        #endregion

    }
}
