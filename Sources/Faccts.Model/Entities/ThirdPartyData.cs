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
    [KnownType(typeof(Attorneys))]
    [KnownType(typeof(CaseRecord))]
    public partial class ThirdPartyData: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public ThirdPartyData()
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
        public bool IsThirdPartyProPer
        {
            get { return _isThirdPartyProPer; }
            set
            {
                if (_isThirdPartyProPer != value)
                {
    				OnPropertyChanging("IsThirdPartyProPer");
                    _isThirdPartyProPer = value;
                    OnPropertyChanged("IsThirdPartyProPer");
                }
            }
        }
        private bool _isThirdPartyProPer;
    
        [DataMember]
        public bool IsThirdPartyRequestorInEACase
        {
            get { return _isThirdPartyRequestorInEACase; }
            set
            {
                if (_isThirdPartyRequestorInEACase != value)
                {
    				OnPropertyChanging("IsThirdPartyRequestorInEACase");
                    _isThirdPartyRequestorInEACase = value;
                    OnPropertyChanged("IsThirdPartyRequestorInEACase");
                }
            }
        }
        private bool _isThirdPartyRequestorInEACase;
    
        [DataMember]
        public Nullable<int> Attorney_Id
        {
            get { return _attorney_Id; }
            set
            {
                if (_attorney_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Attorney_Id", _attorney_Id);
                    if (!IsDeserializing)
                    {
                        if (Attorney != null && Attorney.Id != value)
                        {
                            Attorney = null;
                        }
                    }
    				OnPropertyChanging("Attorney_Id");
                    _attorney_Id = value;
                    OnPropertyChanged("Attorney_Id");
                }
            }
        }
        private Nullable<int> _attorney_Id;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Attorneys Attorney
        {
            get { return _attorney; }
            set
            {
                if (!ReferenceEquals(_attorney, value))
                {
                    var previousValue = _attorney;
    				OnNavigationPropertyChanging("Attorney");
                    _attorney = value;
                    FixupAttorney(previousValue);
                    OnNavigationPropertyChanged("Attorney");
                }
            }
        }
        private Attorneys _attorney;
    
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
    				OnNavigationPropertyChanging("CaseRecord");
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
    
        protected virtual void ClearNavigationProperties()
        {
            Attorney = null;
            CaseRecord.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupAttorney(Attorneys previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.ThirdPartyData.Contains(this))
            {
                previousValue.ThirdPartyData.Remove(this);
            }
    
            if (Attorney != null)
            {
                Attorney.ThirdPartyData.Add(this);
    
                Attorney_Id = Attorney.Id;
            }
            else if (!skipKeys)
            {
                Attorney_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Attorney")
                    && (ChangeTracker.OriginalValues["Attorney"] == Attorney))
                {
                    ChangeTracker.OriginalValues.Remove("Attorney");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Attorney", previousValue);
                }
                if (Attorney != null && !Attorney.ChangeTracker.ChangeTrackingEnabled)
                {
                    Attorney.StartTracking();
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
                    item.ThirdPartyData = this;
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
                    if (ReferenceEquals(item.ThirdPartyData, this))
                    {
                        item.ThirdPartyData = null;
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