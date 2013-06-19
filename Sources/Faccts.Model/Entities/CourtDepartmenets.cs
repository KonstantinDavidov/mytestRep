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
    [KnownType(typeof(CourtCounty))]
    public partial class CourtDepartmenets: IObjectWithChangeTracker, INotifyPropertyChanged, INavigationPropertiesLoadable
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
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public string Room
        {
            get { return _room; }
            set
            {
                if (_room != value)
                {
                    _room = value;
                    OnPropertyChanged("Room");
                }
            }
        }
        private string _room;
    
        [DataMember]
        public string BranchOfficer
        {
            get { return _branchOfficer; }
            set
            {
                if (_branchOfficer != value)
                {
                    _branchOfficer = value;
                    OnPropertyChanged("BranchOfficer");
                }
            }
        }
        private string _branchOfficer;
    
        [DataMember]
        public string Reporter
        {
            get { return _reporter; }
            set
            {
                if (_reporter != value)
                {
                    _reporter = value;
                    OnPropertyChanged("Reporter");
                }
            }
        }
        private string _reporter;
    
        [DataMember]
        public int CourtCountyId
        {
            get { return _courtCountyId; }
            set
            {
                if (_courtCountyId != value)
                {
                    ChangeTracker.RecordOriginalValue("CourtCountyId", _courtCountyId);
                    if (!IsDeserializing)
                    {
                        if (CourtCounty != null && CourtCounty.Id != value)
                        {
                            CourtCounty = null;
                        }
                    }
                    _courtCountyId = value;
                    OnPropertyChanged("CourtCountyId");
                }
            }
        }
        private int _courtCountyId;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<CaseRecord> CaseRecord
        {
            get
            {
                if (_caseRecord == null)
                {
                    _caseRecord = new TrackableCollection<CaseRecord>();
                    _caseRecord.CollectionChanged += FixupCaseRecord;
                }
                return _caseRecord;
            }
            set
            {
                if (!ReferenceEquals(_caseRecord, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_caseRecord != null)
                    {
                        _caseRecord.CollectionChanged -= FixupCaseRecord;
                    }
                    _caseRecord = value;
                    if (_caseRecord != null)
                    {
                        _caseRecord.CollectionChanged += FixupCaseRecord;
                    }
                    OnNavigationPropertyChanged("CaseRecord");
                }
            }
        }
        private TrackableCollection<CaseRecord> _caseRecord;
    
        [DataMember]
        public CourtCounty CourtCounty
        {
            get { return _courtCounty; }
            set
            {
                if (!ReferenceEquals(_courtCounty, value))
                {
                    var previousValue = _courtCounty;
                    _courtCounty = value;
                    FixupCourtCounty(previousValue);
                    OnNavigationPropertyChanged("CourtCounty");
                }
            }
        }
        private CourtCounty _courtCounty;

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
            CourtDepartmenets p = obj as CourtDepartmenets;
            if ((System.Object)p == null)
            {
                return false;
            }
    
    			if (this.Id != p.Id)
    				return false;
    			if (this.Name != p.Name)
    				return false;
    			if (this.Room != p.Room)
    				return false;
    			if (this.BranchOfficer != p.BranchOfficer)
    				return false;
    			if (this.Reporter != p.Reporter)
    				return false;
    			if (this.CourtCountyId != p.CourtCountyId)
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
    			
    		hashCode ^= this.Name.GetHashCode();
    		if (this.Name != null)
    		{
    			hashCode ^= this.Name.GetHashCode();
    		}
    			
    		hashCode ^= this.Room.GetHashCode();
    		if (this.Room != null)
    		{
    			hashCode ^= this.Room.GetHashCode();
    		}
    			
    		hashCode ^= this.BranchOfficer.GetHashCode();
    		if (this.BranchOfficer != null)
    		{
    			hashCode ^= this.BranchOfficer.GetHashCode();
    		}
    			
    		hashCode ^= this.Reporter.GetHashCode();
    		if (this.Reporter != null)
    		{
    			hashCode ^= this.Reporter.GetHashCode();
    		}
    			
    		hashCode ^= this.CourtCountyId.GetHashCode();
    		if (this.CourtCountyId != null)
    		{
    			hashCode ^= this.CourtCountyId.GetHashCode();
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
            CaseRecord.Clear();
            CourtCounty = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCourtCounty(CourtCounty previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtDepartmenets.Contains(this))
            {
                previousValue.CourtDepartmenets.Remove(this);
            }
    
            if (CourtCounty != null)
            {
                CourtCounty.CourtDepartmenets.Add(this);
    
                CourtCountyId = CourtCounty.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CourtCounty")
                    && (ChangeTracker.OriginalValues["CourtCounty"] == CourtCounty))
                {
                    ChangeTracker.OriginalValues.Remove("CourtCounty");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CourtCounty", previousValue);
                }
                if (CourtCounty != null && !CourtCounty.ChangeTracker.ChangeTrackingEnabled)
                {
                    CourtCounty.StartTracking();
                }
            }
        }
    
        private void FixupCaseRecord(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CaseRecord item in e.NewItems)
                {
                    item.CourtDepartmenets = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CaseRecord", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CaseRecord item in e.OldItems)
                {
                    if (ReferenceEquals(item.CourtDepartmenets, this))
                    {
                        item.CourtDepartmenets = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CaseRecord", item);
                    }
                }
            }
        }

        #endregion

    }
}