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
    [KnownType(typeof(CourtCaseOrders))]
    [KnownType(typeof(User))]
    [KnownType(typeof(Hearings))]
    [KnownType(typeof(CourtCase))]
    public partial class CaseHistory: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CaseHistory()
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
        public int Id
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
        private int _id;
    
        [DataMember]
        public System.DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
    				OnPropertyChanging("Date");
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        private System.DateTime _date;
    
        [DataMember]
        public int CaseHistoryEvent
        {
            get { return _caseHistoryEvent; }
            set
            {
                if (_caseHistoryEvent != value)
                {
    				OnPropertyChanging("CaseHistoryEvent");
                    _caseHistoryEvent = value;
                    OnPropertyChanged("CaseHistoryEvent");
                }
            }
        }
        private int _caseHistoryEvent;
    
        [DataMember]
        public string CCPOR_ID
        {
            get { return _cCPOR_ID; }
            set
            {
                if (_cCPOR_ID != value)
                {
    				OnPropertyChanging("CCPOR_ID");
                    _cCPOR_ID = value;
                    OnPropertyChanged("CCPOR_ID");
                }
            }
        }
        private string _cCPOR_ID;
    
        [DataMember]
        public Nullable<int> CourtCaseOrderId
        {
            get { return _courtCaseOrderId; }
            set
            {
                if (_courtCaseOrderId != value)
                {
                    ChangeTracker.RecordOriginalValue("CourtCaseOrderId", _courtCaseOrderId);
                    if (!IsDeserializing)
                    {
                        if (CourtCaseOrders != null && CourtCaseOrders.Id != value)
                        {
                            CourtCaseOrders = null;
                        }
                    }
    				OnPropertyChanging("CourtCaseOrderId");
                    _courtCaseOrderId = value;
                    OnPropertyChanged("CourtCaseOrderId");
                }
            }
        }
        private Nullable<int> _courtCaseOrderId;
    
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
        public Nullable<int> CaseRecord_Id
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
        private Nullable<int> _caseRecord_Id;
    
        [DataMember]
        public Nullable<int> Hearing_Id
        {
            get { return _hearing_Id; }
            set
            {
                if (_hearing_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Hearing_Id", _hearing_Id);
                    if (!IsDeserializing)
                    {
                        if (Hearing != null && Hearing.Id != value)
                        {
                            Hearing = null;
                        }
                    }
    				OnPropertyChanging("Hearing_Id");
                    _hearing_Id = value;
                    OnPropertyChanged("Hearing_Id");
                }
            }
        }
        private Nullable<int> _hearing_Id;
    
        [DataMember]
        public Nullable<int> MergeCase_Id
        {
            get { return _mergeCase_Id; }
            set
            {
                if (_mergeCase_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("MergeCase_Id", _mergeCase_Id);
                    if (!IsDeserializing)
                    {
                        if (MergeCase != null && MergeCase.Id != value)
                        {
                            MergeCase = null;
                        }
                    }
    				OnPropertyChanging("MergeCase_Id");
                    _mergeCase_Id = value;
                    OnPropertyChanged("MergeCase_Id");
                }
            }
        }
        private Nullable<int> _mergeCase_Id;

        #endregion

        #region Complex Properties
    
        [DataMember]
        public Appearance Appearance
        {
            get
            {
                if (!_appearanceInitialized && _appearance == null)
                {
                    _appearance = new Appearance();
                    ((INotifyComplexPropertyChanging)_appearance).ComplexPropertyChanging += HandleAppearanceChanging;
                }
                _appearanceInitialized = true;
                return _appearance;
            }
            set
            {
                _appearanceInitialized = true;
                if (!Equals(_appearance, value))
                {
                    if (_appearance != null)
                    {
                        ((INotifyComplexPropertyChanging)_appearance).ComplexPropertyChanging -= HandleAppearanceChanging;
                    }
    
                    HandleAppearanceChanging(this, null);
    				OnPropertyChanging("Appearance");
                    _appearance = value;
                    OnPropertyChanged("Appearance");
    
                    if (value != null)
                    {
                        ((INotifyComplexPropertyChanging)_appearance).ComplexPropertyChanging += HandleAppearanceChanging;
                    }
                }
            }
        }
        private Appearance _appearance;
        private bool _appearanceInitialized;

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
        public CourtCaseOrders CourtCaseOrders
        {
            get { return _courtCaseOrders; }
            set
            {
                if (!ReferenceEquals(_courtCaseOrders, value))
                {
                    var previousValue = _courtCaseOrders;
    				OnNavigationPropertyChanging("CourtCaseOrders");
                    _courtCaseOrders = value;
                    FixupCourtCaseOrders(previousValue);
                    OnNavigationPropertyChanged("CourtCaseOrders");
                }
            }
        }
        private CourtCaseOrders _courtCaseOrders;
    
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
        public Hearings Hearing
        {
            get { return _hearing; }
            set
            {
                if (!ReferenceEquals(_hearing, value))
                {
                    var previousValue = _hearing;
    				OnNavigationPropertyChanging("Hearing");
                    _hearing = value;
                    FixupHearing(previousValue);
                    OnNavigationPropertyChanged("Hearing");
                }
            }
        }
        private Hearings _hearing;
    
        [DataMember]
        public CourtCase MergeCase
        {
            get { return _mergeCase; }
            set
            {
                if (!ReferenceEquals(_mergeCase, value))
                {
                    var previousValue = _mergeCase;
    				OnNavigationPropertyChanging("MergeCase");
                    _mergeCase = value;
                    FixupMergeCase(previousValue);
                    OnNavigationPropertyChanged("MergeCase");
                }
            }
        }
        private CourtCase _mergeCase;

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
        // Records the original values for the complex property Appearance
        private void HandleAppearanceChanging(object sender, EventArgs args)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
        }
    
    
        protected virtual void ClearNavigationProperties()
        {
            CaseRecord = null;
            CourtCaseOrders = null;
            User = null;
            Hearing = null;
            MergeCase = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCaseRecord(CaseRecord previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CaseHistory.Contains(this))
            {
                previousValue.CaseHistory.Remove(this);
            }
    
            if (CaseRecord != null)
            {
                CaseRecord.CaseHistory.Add(this);
    
                CaseRecord_Id = CaseRecord.Id;
            }
            else if (!skipKeys)
            {
                CaseRecord_Id = null;
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
    
        private void FixupCourtCaseOrders(CourtCaseOrders previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CaseHistory.Contains(this))
            {
                previousValue.CaseHistory.Remove(this);
            }
    
            if (CourtCaseOrders != null)
            {
                CourtCaseOrders.CaseHistory.Add(this);
    
                CourtCaseOrderId = CourtCaseOrders.Id;
            }
            else if (!skipKeys)
            {
                CourtCaseOrderId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CourtCaseOrders")
                    && (ChangeTracker.OriginalValues["CourtCaseOrders"] == CourtCaseOrders))
                {
                    ChangeTracker.OriginalValues.Remove("CourtCaseOrders");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CourtCaseOrders", previousValue);
                }
                if (CourtCaseOrders != null && !CourtCaseOrders.ChangeTracker.ChangeTrackingEnabled)
                {
                    CourtCaseOrders.StartTracking();
                }
            }
        }
    
        private void FixupUser(User previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CaseHistory.Contains(this))
            {
                previousValue.CaseHistory.Remove(this);
            }
    
            if (User != null)
            {
                User.CaseHistory.Add(this);
    
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
    
        private void FixupHearing(Hearings previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CaseHistory.Contains(this))
            {
                previousValue.CaseHistory.Remove(this);
            }
    
            if (Hearing != null)
            {
                Hearing.CaseHistory.Add(this);
    
                Hearing_Id = Hearing.Id;
            }
            else if (!skipKeys)
            {
                Hearing_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Hearing")
                    && (ChangeTracker.OriginalValues["Hearing"] == Hearing))
                {
                    ChangeTracker.OriginalValues.Remove("Hearing");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Hearing", previousValue);
                }
                if (Hearing != null && !Hearing.ChangeTracker.ChangeTrackingEnabled)
                {
                    Hearing.StartTracking();
                }
            }
        }
    
        private void FixupMergeCase(CourtCase previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (MergeCase != null)
            {
                MergeCase_Id = MergeCase.Id;
            }
    
            else if (!skipKeys)
            {
                MergeCase_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("MergeCase")
                    && (ChangeTracker.OriginalValues["MergeCase"] == MergeCase))
                {
                    ChangeTracker.OriginalValues.Remove("MergeCase");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("MergeCase", previousValue);
                }
                if (MergeCase != null && !MergeCase.ChangeTracker.ChangeTrackingEnabled)
                {
                    MergeCase.StartTracking();
                }
            }
        }

        #endregion

    }
}
