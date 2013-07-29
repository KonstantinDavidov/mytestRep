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
    [KnownType(typeof(CourtOrders))]
    [KnownType(typeof(Hearings))]
    public partial class CourtOrders: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CourtOrders()
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
    				,this.ObservableForProperty(x => x.OrderType)
    				,this.ObservableForProperty(x => x.ParentOrderId)
    				,this.ObservableForProperty(x => x.XMLContent)
    				,this.ObservableForProperty(x => x.IsSigned)
    				,this.ObservableForProperty(x => x.ServerFileName)
    				,this.ObservableForProperty(x => x.HearingId)
    				,this.ObservableForProperty(x => x.ParentOrder.IsDirty)
    				,this.ObservableForProperty(x => x.Hearings.IsDirty)
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
        public int OrderType
        {
            get { return _orderType; }
            set
            {
                if (_orderType != value)
                {
    				OnPropertyChanging("OrderType");
                    _orderType = value;
                    OnPropertyChanged("OrderType");
                }
            }
        }
        private int _orderType;
    
        [DataMember]
        public Nullable<long> ParentOrderId
        {
            get { return _parentOrderId; }
            set
            {
                if (_parentOrderId != value)
                {
                    ChangeTracker.RecordOriginalValue("ParentOrderId", _parentOrderId);
                    if (!IsDeserializing)
                    {
                        if (ParentOrder != null && ParentOrder.Id != value)
                        {
                            ParentOrder = null;
                        }
                    }
    				OnPropertyChanging("ParentOrderId");
                    _parentOrderId = value;
                    OnPropertyChanged("ParentOrderId");
                }
            }
        }
        private Nullable<long> _parentOrderId;
    
        [DataMember]
        public string XMLContent
        {
            get { return _xMLContent; }
            set
            {
                if (_xMLContent != value)
                {
    				OnPropertyChanging("XMLContent");
                    _xMLContent = value;
                    OnPropertyChanged("XMLContent");
                }
            }
        }
        private string _xMLContent;
    
        [DataMember]
        public bool IsSigned
        {
            get { return _isSigned; }
            set
            {
                if (_isSigned != value)
                {
    				OnPropertyChanging("IsSigned");
                    _isSigned = value;
                    OnPropertyChanged("IsSigned");
                }
            }
        }
        private bool _isSigned;
    
        [DataMember]
        public string ServerFileName
        {
            get { return _serverFileName; }
            set
            {
                if (_serverFileName != value)
                {
    				OnPropertyChanging("ServerFileName");
                    _serverFileName = value;
                    OnPropertyChanged("ServerFileName");
                }
            }
        }
        private string _serverFileName;
    
        [DataMember]
        public long HearingId
        {
            get { return _hearingId; }
            set
            {
                if (_hearingId != value)
                {
                    ChangeTracker.RecordOriginalValue("HearingId", _hearingId);
                    if (!IsDeserializing)
                    {
                        if (Hearings != null && Hearings.Id != value)
                        {
                            Hearings = null;
                        }
                    }
    				OnPropertyChanging("HearingId");
                    _hearingId = value;
                    OnPropertyChanged("HearingId");
                }
            }
        }
        private long _hearingId;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<CourtOrders> Attachments
        {
            get
            {
                if (_attachments == null)
                {
                    _attachments = new TrackableCollection<CourtOrders>();
                    _attachments.CollectionChanged += FixupAttachments;
                }
                return _attachments;
            }
            set
            {
                if (!ReferenceEquals(_attachments, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("Attachments");
                    if (_attachments != null)
                    {
                        _attachments.CollectionChanged -= FixupAttachments;
                    }
                    _attachments = value;
                    if (_attachments != null)
                    {
                        _attachments.CollectionChanged += FixupAttachments;
                    }
                    OnNavigationPropertyChanged("Attachments");
                }
            }
        }
        private TrackableCollection<CourtOrders> _attachments;
    
        [DataMember]
        public CourtOrders ParentOrder
        {
            get { return _parentOrder; }
            set
            {
                if (!ReferenceEquals(_parentOrder, value))
                {
                    var previousValue = _parentOrder;
    				OnNavigationPropertyChanging("ParentOrder");
                    _parentOrder = value;
                    FixupParentOrder(previousValue);
                    OnNavigationPropertyChanged("ParentOrder");
                }
            }
        }
        private CourtOrders _parentOrder;
    
        [DataMember]
        public Hearings Hearings
        {
            get { return _hearings; }
            set
            {
                if (!ReferenceEquals(_hearings, value))
                {
                    var previousValue = _hearings;
    				OnNavigationPropertyChanging("Hearings");
                    _hearings = value;
                    FixupHearings(previousValue);
                    OnNavigationPropertyChanged("Hearings");
                }
            }
        }
        private Hearings _hearings;

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
            Attachments.Clear();
            ParentOrder = null;
            Hearings = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupParentOrder(CourtOrders previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Attachments.Contains(this))
            {
                previousValue.Attachments.Remove(this);
            }
    
            if (ParentOrder != null)
            {
                ParentOrder.Attachments.Add(this);
    
                ParentOrderId = ParentOrder.Id;
            }
            else if (!skipKeys)
            {
                ParentOrderId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ParentOrder")
                    && (ChangeTracker.OriginalValues["ParentOrder"] == ParentOrder))
                {
                    ChangeTracker.OriginalValues.Remove("ParentOrder");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ParentOrder", previousValue);
                }
                if (ParentOrder != null && !ParentOrder.ChangeTracker.ChangeTrackingEnabled)
                {
                    ParentOrder.StartTracking();
                }
            }
        }
    
        private void FixupHearings(Hearings previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtOrders.Contains(this))
            {
                previousValue.CourtOrders.Remove(this);
            }
    
            if (Hearings != null)
            {
                Hearings.CourtOrders.Add(this);
    
                HearingId = Hearings.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Hearings")
                    && (ChangeTracker.OriginalValues["Hearings"] == Hearings))
                {
                    ChangeTracker.OriginalValues.Remove("Hearings");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Hearings", previousValue);
                }
                if (Hearings != null && !Hearings.ChangeTracker.ChangeTrackingEnabled)
                {
                    Hearings.StartTracking();
                }
            }
        }
    
        private void FixupAttachments(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtOrders item in e.NewItems)
                {
                    item.ParentOrder = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Attachments", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtOrders item in e.OldItems)
                {
                    if (ReferenceEquals(item.ParentOrder, this))
                    {
                        item.ParentOrder = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Attachments", item);
                    }
                }
            }
        }

        #endregion

    }
}
