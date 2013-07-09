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
    [KnownType(typeof(CourtCounty))]
    [KnownType(typeof(Hearings))]
    [KnownType(typeof(CourtDocketRecord))]
    public partial class CourtDepartmenets: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CourtDepartmenets()
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
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
    				OnPropertyChanging("Name");
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
    				OnPropertyChanging("Room");
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
    				OnPropertyChanging("BranchOfficer");
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
    				OnPropertyChanging("Reporter");
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
    				OnPropertyChanging("CourtCountyId");
                    _courtCountyId = value;
                    OnPropertyChanged("CourtCountyId");
                }
            }
        }
        private int _courtCountyId;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public CourtCounty CourtCounty
        {
            get { return _courtCounty; }
            set
            {
                if (!ReferenceEquals(_courtCounty, value))
                {
                    var previousValue = _courtCounty;
    				OnNavigationPropertyChanging("CourtCounty");
                    _courtCounty = value;
                    FixupCourtCounty(previousValue);
                    OnNavigationPropertyChanged("CourtCounty");
                }
            }
        }
        private CourtCounty _courtCounty;
    
        [DataMember]
        public TrackableCollection<Hearings> Hearings
        {
            get
            {
                if (_hearings == null)
                {
                    _hearings = new TrackableCollection<Hearings>();
                    _hearings.CollectionChanged += FixupHearings;
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
    				OnNavigationPropertyChanging("Hearings");
                    if (_hearings != null)
                    {
                        _hearings.CollectionChanged -= FixupHearings;
                    }
                    _hearings = value;
                    if (_hearings != null)
                    {
                        _hearings.CollectionChanged += FixupHearings;
                    }
                    OnNavigationPropertyChanged("Hearings");
                }
            }
        }
        private TrackableCollection<Hearings> _hearings;
    
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
            CourtCounty = null;
            Hearings.Clear();
            CourtDocketRecords.Clear();
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
    
        private void FixupHearings(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Hearings item in e.NewItems)
                {
                    item.CourtDepartment = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Hearings", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Hearings item in e.OldItems)
                {
                    if (ReferenceEquals(item.CourtDepartment, this))
                    {
                        item.CourtDepartment = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Hearings", item);
                    }
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
                    item.CourtDepartmenets = this;
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
                    if (ReferenceEquals(item.CourtDepartmenets, this))
                    {
                        item.CourtDepartmenets = null;
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
