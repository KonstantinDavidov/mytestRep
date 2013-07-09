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

namespace Faccts.Model.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CaseRecord))]
    [KnownType(typeof(User))]
    [KnownType(typeof(CourtCase))]
    [KnownType(typeof(CourtDocketRecord))]
    public partial class CourtCase: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CourtCase()
    		{
    			_reactiveHelper = new MakeObjectReactiveHelper(this);
    			Initialize();
    		}
    
    		partial void Initialize();
    		
    
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
        public string CaseNumber
        {
            get { return _caseNumber; }
            set
            {
                if (_caseNumber != value)
                {
    				OnPropertyChanging("CaseNumber");
                    _caseNumber = value;
                    OnPropertyChanged("CaseNumber");
                }
            }
        }
        private string _caseNumber;
    
        [DataMember]
        public Nullable<int> CCPORStatus
        {
            get { return _cCPORStatus; }
            set
            {
                if (_cCPORStatus != value)
                {
    				OnPropertyChanging("CCPORStatus");
                    _cCPORStatus = value;
                    OnPropertyChanged("CCPORStatus");
                }
            }
        }
        private Nullable<int> _cCPORStatus;
    
        [DataMember]
        public string CCPORId
        {
            get { return _cCPORId; }
            set
            {
                if (_cCPORId != value)
                {
    				OnPropertyChanging("CCPORId");
                    _cCPORId = value;
                    OnPropertyChanged("CCPORId");
                }
            }
        }
        private string _cCPORId;
    
        [DataMember]
        public Nullable<int> CourtClerk_UserId
        {
            get { return _courtClerk_UserId; }
            set
            {
                if (_courtClerk_UserId != value)
                {
                    ChangeTracker.RecordOriginalValue("CourtClerk_UserId", _courtClerk_UserId);
                    if (!IsDeserializing)
                    {
                        if (User != null && User.Id != value)
                        {
                            User = null;
                        }
                    }
    				OnPropertyChanging("CourtClerk_UserId");
                    _courtClerk_UserId = value;
                    OnPropertyChanged("CourtClerk_UserId");
                }
            }
        }
        private Nullable<int> _courtClerk_UserId;
    
        [DataMember]
        public int CaseRecord_Id
        {
            get { return _caseRecord_Id; }
            set
            {
                if (_caseRecord_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("CaseRecord_Id", _caseRecord_Id);
                    if (!IsDeserializing)
                    {
                        if (CaseRecord != null && CaseRecord.Id != value)
                        {
                            CaseRecord = null;
                        }
                    }
    				OnPropertyChanging("CaseRecord_Id");
                    _caseRecord_Id = value;
                    OnPropertyChanged("CaseRecord_Id");
                }
            }
        }
        private int _caseRecord_Id;
    
        [DataMember]
        public Nullable<long> ParentCase_Id
        {
            get { return _parentCase_Id; }
            set
            {
                if (_parentCase_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("ParentCase_Id", _parentCase_Id);
                    if (!IsDeserializing)
                    {
                        if (ParentCase != null && ParentCase.Id != value)
                        {
                            ParentCase = null;
                        }
                    }
    				OnPropertyChanging("ParentCase_Id");
                    _parentCase_Id = value;
                    OnPropertyChanged("ParentCase_Id");
                }
            }
        }
        private Nullable<long> _parentCase_Id;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public CaseRecord CaseRecord
        {
            get { return _caseRecord; }
            set
            {
                if (!ReferenceEquals(_caseRecord, value))
                {
                    var previousValue = _caseRecord;
    				OnNavigationPropertyChanging("CaseRecord");
                    _caseRecord = value;
                    FixupCaseRecord(previousValue);
                    OnNavigationPropertyChanged("CaseRecord");
                }
            }
        }
        private CaseRecord _caseRecord;
    
        [DataMember]
        public User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
    				OnNavigationPropertyChanging("User");
                    _user = value;
                    FixupUser(previousValue);
                    OnNavigationPropertyChanged("User");
                }
            }
        }
        private User _user;
    
        [DataMember]
        public TrackableCollection<CourtCase> ChildCases
        {
            get
            {
                if (_childCases == null)
                {
                    _childCases = new TrackableCollection<CourtCase>();
                    _childCases.CollectionChanged += FixupChildCases;
                }
                return _childCases;
            }
            set
            {
                if (!ReferenceEquals(_childCases, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("ChildCases");
                    if (_childCases != null)
                    {
                        _childCases.CollectionChanged -= FixupChildCases;
                    }
                    _childCases = value;
                    if (_childCases != null)
                    {
                        _childCases.CollectionChanged += FixupChildCases;
                    }
                    OnNavigationPropertyChanged("ChildCases");
                }
            }
        }
        private TrackableCollection<CourtCase> _childCases;
    
        [DataMember]
        public CourtCase ParentCase
        {
            get { return _parentCase; }
            set
            {
                if (!ReferenceEquals(_parentCase, value))
                {
                    var previousValue = _parentCase;
    				OnNavigationPropertyChanging("ParentCase");
                    _parentCase = value;
                    FixupParentCase(previousValue);
                    OnNavigationPropertyChanged("ParentCase");
                }
            }
        }
        private CourtCase _parentCase;
    
        [DataMember]
        public TrackableCollection<CourtDocketRecord> CourtDocketRecord
        {
            get
            {
                if (_courtDocketRecord == null)
                {
                    _courtDocketRecord = new TrackableCollection<CourtDocketRecord>();
                    _courtDocketRecord.CollectionChanged += FixupCourtDocketRecord;
                }
                return _courtDocketRecord;
            }
            set
            {
                if (!ReferenceEquals(_courtDocketRecord, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("CourtDocketRecord");
                    if (_courtDocketRecord != null)
                    {
                        _courtDocketRecord.CollectionChanged -= FixupCourtDocketRecord;
                    }
                    _courtDocketRecord = value;
                    if (_courtDocketRecord != null)
                    {
                        _courtDocketRecord.CollectionChanged += FixupCourtDocketRecord;
                    }
                    OnNavigationPropertyChanged("CourtDocketRecord");
                }
            }
        }
        private TrackableCollection<CourtDocketRecord> _courtDocketRecord;

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
    
        // This entity type is the dependent end in at least one association that performs cascade deletes.
        // This event handler will process notifications that occur when the principal end is deleted.
        internal void HandleCascadeDelete(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                this.MarkAsDeleted();
            }
        }
    
        protected virtual void ClearNavigationProperties()
        {
            CaseRecord = null;
            User = null;
            ChildCases.Clear();
            ParentCase = null;
            CourtDocketRecord.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupCaseRecord(CaseRecord previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtCase.Contains(this))
            {
                previousValue.CourtCase.Remove(this);
            }
    
            if (CaseRecord != null)
            {
                CaseRecord.CourtCase.Add(this);
    
                CaseRecord_Id = CaseRecord.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CaseRecord")
                    && (ChangeTracker.OriginalValues["CaseRecord"] == CaseRecord))
                {
                    ChangeTracker.OriginalValues.Remove("CaseRecord");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CaseRecord", previousValue);
                }
                if (CaseRecord != null && !CaseRecord.ChangeTracker.ChangeTrackingEnabled)
                {
                    CaseRecord.StartTracking();
                }
            }
        }
    
        private void FixupUser(User previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtCase.Contains(this))
            {
                previousValue.CourtCase.Remove(this);
            }
    
            if (User != null)
            {
                User.CourtCase.Add(this);
    
                CourtClerk_UserId = User.Id;
            }
            else if (!skipKeys)
            {
                CourtClerk_UserId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("User")
                    && (ChangeTracker.OriginalValues["User"] == User))
                {
                    ChangeTracker.OriginalValues.Remove("User");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("User", previousValue);
                }
                if (User != null && !User.ChangeTracker.ChangeTrackingEnabled)
                {
                    User.StartTracking();
                }
            }
        }
    
        private void FixupParentCase(CourtCase previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.ChildCases.Contains(this))
            {
                previousValue.ChildCases.Remove(this);
            }
    
            if (ParentCase != null)
            {
                ParentCase.ChildCases.Add(this);
    
                ParentCase_Id = ParentCase.Id;
            }
            else if (!skipKeys)
            {
                ParentCase_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ParentCase")
                    && (ChangeTracker.OriginalValues["ParentCase"] == ParentCase))
                {
                    ChangeTracker.OriginalValues.Remove("ParentCase");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ParentCase", previousValue);
                }
                if (ParentCase != null && !ParentCase.ChangeTracker.ChangeTrackingEnabled)
                {
                    ParentCase.StartTracking();
                }
            }
        }
    
        private void FixupChildCases(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtCase item in e.NewItems)
                {
                    item.ParentCase = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ChildCases", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtCase item in e.OldItems)
                {
                    if (ReferenceEquals(item.ParentCase, this))
                    {
                        item.ParentCase = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ChildCases", item);
                    }
                }
            }
        }
    
        private void FixupCourtDocketRecord(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtDocketRecord item in e.NewItems)
                {
                    item.CourtCase = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtDocketRecord", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtDocketRecord item in e.OldItems)
                {
                    if (ReferenceEquals(item.CourtCase, this))
                    {
                        item.CourtCase = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtDocketRecord", item);
                    }
                }
            }
        }

        #endregion

    }
}
