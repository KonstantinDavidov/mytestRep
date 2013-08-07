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
using System.Reflection;

namespace Faccts.Model.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CourtCaseHistoryHeading))]
    [KnownType(typeof(CourtCaseHistoryHeading))]
    public partial class CourtCaseHeading: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CourtCaseHeading()
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
    				this.ObservableForProperty(x => x.CourtCaseId)
    				,this.ObservableForProperty(x => x.CaseNumber)
    				,this.ObservableForProperty(x => x.CaseStatus)
    				,this.ObservableForProperty(x => x.Date)
    				,this.ObservableForProperty(x => x.Order)
    				,this.ObservableForProperty(x => x.Party1Name)
    				,this.ObservableForProperty(x => x.Party2Name)
    				,this.ObservableForProperty(x => x.CCPOR_ID)
    				,this.ObservableForProperty(x => x.CourtClerkName)
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
    				OnPropertyChanged("IsDirty", false);
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
        public long CourtCaseId
        {
            get { return _courtCaseId; }
            set
            {
                if (_courtCaseId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'CourtCaseId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
    				OnPropertyChanging("CourtCaseId");
                    _courtCaseId = value;
                    OnPropertyChanged("CourtCaseId");
                }
            }
        }
        private long _courtCaseId;
    
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
        public FACCTS.Server.Model.Enums.CaseStatus CaseStatus
        {
            get { return _caseStatus; }
            set
            {
                if (_caseStatus != value)
                {
    				OnPropertyChanging("CaseStatus");
                    _caseStatus = value;
                    OnPropertyChanged("CaseStatus");
                }
            }
        }
        private FACCTS.Server.Model.Enums.CaseStatus _caseStatus;
    
        [DataMember]
        public Nullable<System.DateTime> Date
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
        private Nullable<System.DateTime> _date;
    
        [DataMember]
        public string Order
        {
            get { return _order; }
            set
            {
                if (_order != value)
                {
    				OnPropertyChanging("Order");
                    _order = value;
                    OnPropertyChanged("Order");
                }
            }
        }
        private string _order;
    
        [DataMember]
        public string Party1Name
        {
            get { return _party1Name; }
            set
            {
                if (_party1Name != value)
                {
    				OnPropertyChanging("Party1Name");
                    _party1Name = value;
                    OnPropertyChanged("Party1Name");
                }
            }
        }
        private string _party1Name;
    
        [DataMember]
        public string Party2Name
        {
            get { return _party2Name; }
            set
            {
                if (_party2Name != value)
                {
    				OnPropertyChanging("Party2Name");
                    _party2Name = value;
                    OnPropertyChanged("Party2Name");
                }
            }
        }
        private string _party2Name;
    
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
        public string CourtClerkName
        {
            get { return _courtClerkName; }
            set
            {
                if (_courtClerkName != value)
                {
    				OnPropertyChanging("CourtClerkName");
                    _courtClerkName = value;
                    OnPropertyChanged("CourtClerkName");
                }
            }
        }
        private string _courtClerkName;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<CourtCaseHistoryHeading> CourtCaseHistoryHeadings
        {
            get
            {
                if (_courtCaseHistoryHeadings == null)
                {
                    _courtCaseHistoryHeadings = new TrackableCollection<CourtCaseHistoryHeading>();
                    _courtCaseHistoryHeadings.CollectionChanged += FixupCourtCaseHistoryHeadings;
                }
                return _courtCaseHistoryHeadings;
            }
            set
            {
                if (!ReferenceEquals(_courtCaseHistoryHeadings, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("CourtCaseHistoryHeadings");
                    if (_courtCaseHistoryHeadings != null)
                    {
                        _courtCaseHistoryHeadings.CollectionChanged -= FixupCourtCaseHistoryHeadings;
                    }
                    _courtCaseHistoryHeadings = value;
                    if (_courtCaseHistoryHeadings != null)
                    {
                        _courtCaseHistoryHeadings.CollectionChanged += FixupCourtCaseHistoryHeadings;
                    }
                    OnNavigationPropertyChanged("CourtCaseHistoryHeadings");
                }
            }
        }
        private TrackableCollection<CourtCaseHistoryHeading> _courtCaseHistoryHeadings;

        #endregion

        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName, bool changeState = true)
        {
            if (changeState && ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
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
            CourtCaseHistoryHeadings.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupCourtCaseHistoryHeadings(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtCaseHistoryHeading item in e.NewItems)
                {
                    item.ParentCourtCaseHeading = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtCaseHistoryHeadings", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtCaseHistoryHeading item in e.OldItems)
                {
                    if (ReferenceEquals(item.ParentCourtCaseHeading, this))
                    {
                        item.ParentCourtCaseHeading = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtCaseHistoryHeadings", item);
                    }
                }
            }
        }

        #endregion

    }
}