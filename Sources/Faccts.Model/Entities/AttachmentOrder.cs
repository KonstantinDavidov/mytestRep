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
    [KnownType(typeof(MasterOrder))]
    public partial class AttachmentOrder: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public AttachmentOrder()
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
    				,this.ObservableForProperty(x => x.MasterOrderId)
    				,this.ObservableForProperty(x => x.OrderType)
    				,this.ObservableForProperty(x => x.XmlContent)
    				,this.ObservableForProperty(x => x.ServerFileName)
    				,this.ObservableForProperty(x => x.MasterOrder.IsDirty)
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
        public long MasterOrderId
        {
            get { return _masterOrderId; }
            set
            {
                if (_masterOrderId != value)
                {
                    ChangeTracker.RecordOriginalValue("MasterOrderId", _masterOrderId);
                    if (!IsDeserializing)
                    {
                        if (MasterOrder != null && MasterOrder.Id != value)
                        {
                            MasterOrder = null;
                        }
                    }
    				OnPropertyChanging("MasterOrderId");
                    _masterOrderId = value;
                    OnPropertyChanged("MasterOrderId");
                }
            }
        }
        private long _masterOrderId;
    
        [DataMember]
        public FACCTS.Server.Model.Enums.AttachmentOrders OrderType
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
        private FACCTS.Server.Model.Enums.AttachmentOrders _orderType;
    
        [DataMember]
        public string XmlContent
        {
            get { return _xmlContent; }
            set
            {
                if (_xmlContent != value)
                {
    				OnPropertyChanging("XmlContent");
                    _xmlContent = value;
                    OnPropertyChanged("XmlContent");
                }
            }
        }
        private string _xmlContent;
    
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

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public MasterOrder MasterOrder
        {
            get { return _masterOrder; }
            set
            {
                if (!ReferenceEquals(_masterOrder, value))
                {
                    var previousValue = _masterOrder;
    				OnNavigationPropertyChanging("MasterOrder");
                    _masterOrder = value;
                    FixupMasterOrder(previousValue);
                    OnNavigationPropertyChanged("MasterOrder");
                }
            }
        }
        private MasterOrder _masterOrder;

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
            MasterOrder = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupMasterOrder(MasterOrder previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.AttachmentOrder.Contains(this))
            {
                previousValue.AttachmentOrder.Remove(this);
            }
    
            if (MasterOrder != null)
            {
                MasterOrder.AttachmentOrder.Add(this);
    
                MasterOrderId = MasterOrder.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("MasterOrder")
                    && (ChangeTracker.OriginalValues["MasterOrder"] == MasterOrder))
                {
                    ChangeTracker.OriginalValues.Remove("MasterOrder");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("MasterOrder", previousValue);
                }
                if (MasterOrder != null && !MasterOrder.ChangeTracker.ChangeTrackingEnabled)
                {
                    MasterOrder.StartTracking();
                }
            }
        }

        #endregion

    }
}
