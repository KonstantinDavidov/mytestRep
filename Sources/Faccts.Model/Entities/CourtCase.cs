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

namespace Faccts.Model.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CaseRecord))]
    [KnownType(typeof(User))]
    public partial class CourtCase: IObjectWithChangeTracker, INotifyPropertyChanged, INavigationPropertiesLoadable
    {
    
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
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public string CaseNumber
        {
            get { return _caseNumber; }
            set
            {
                if (_caseNumber != value)
                {
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
                    _caseRecord_Id = value;
                    OnPropertyChanged("CaseRecord_Id");
                }
            }
        }
        private int _caseRecord_Id;

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
                    _user = value;
                    FixupUser(previousValue);
                    OnNavigationPropertyChanged("User");
                }
            }
        }
        private User _user;
    
        [DataMember]
        public TrackableCollection<CaseRecord> CaseRecord1
        {
            get
            {
                if (_caseRecord1 == null)
                {
                    _caseRecord1 = new TrackableCollection<CaseRecord>();
                    _caseRecord1.CollectionChanged += FixupCaseRecord1;
                }
                return _caseRecord1;
            }
            set
            {
                if (!ReferenceEquals(_caseRecord1, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_caseRecord1 != null)
                    {
                        _caseRecord1.CollectionChanged -= FixupCaseRecord1;
                    }
                    _caseRecord1 = value;
                    if (_caseRecord1 != null)
                    {
                        _caseRecord1.CollectionChanged += FixupCaseRecord1;
                    }
                    OnNavigationPropertyChanged("CaseRecord1");
                }
            }
        }
        private TrackableCollection<CaseRecord> _caseRecord1;

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
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
    	public override bool Equals(System.Object obj)
    	{
    		// If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
    
            // If parameter cannot be cast to Point return false.
            CourtCase p = obj as CourtCase;
            if ((System.Object)p == null)
            {
                return false;
            }
    
    			if (this.Id != p.Id)
    				return false;
    			if (this.CaseNumber != p.CaseNumber)
    				return false;
    			if (this.CCPORStatus != p.CCPORStatus)
    				return false;
    			if (this.CCPORId != p.CCPORId)
    				return false;
    			if (this.CourtClerk_UserId != p.CourtClerk_UserId)
    				return false;
    			if (this.CaseRecord_Id != p.CaseRecord_Id)
    				return false;
    
    		return true;
    	}
    
    	public override int GetHashCode()
    	{
    		int hashCode = 1;
    			
    		hashCode ^= this.Id.GetHashCode();
    		if (this.Id != null)
    		{
    			hashCode ^= this.Id.GetHashCode();
    		}
    			
    		hashCode ^= this.CaseNumber.GetHashCode();
    		if (this.CaseNumber != null)
    		{
    			hashCode ^= this.CaseNumber.GetHashCode();
    		}
     
    		if (this.CCPORStatus != null)
    		{
    			hashCode ^= this.CCPORStatus.GetHashCode();
    		}
     
    		if (this.CCPORId != null)
    		{
    			hashCode ^= this.CCPORId.GetHashCode();
    		}
     
    		if (this.CourtClerk_UserId != null)
    		{
    			hashCode ^= this.CourtClerk_UserId.GetHashCode();
    		}
    			
    		hashCode ^= this.CaseRecord_Id.GetHashCode();
    		if (this.CaseRecord_Id != null)
    		{
    			hashCode ^= this.CaseRecord_Id.GetHashCode();
    		}
    		return hashCode;
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
            CaseRecord1.Clear();
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
    
        private void FixupCaseRecord1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CaseRecord item in e.NewItems)
                {
                    item.CourtCase1.Add(this);
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CaseRecord1", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CaseRecord item in e.OldItems)
                {
                    if (item.CourtCase1.Contains(this))
                    {
                        item.CourtCase1.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CaseRecord1", item);
                    }
                }
            }
        }

        #endregion

    }
}