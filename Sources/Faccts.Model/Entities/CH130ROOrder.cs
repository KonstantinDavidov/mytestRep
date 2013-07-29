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
    [KnownType(typeof(ConductROSection))]
    [KnownType(typeof(ServiceSection))]
    [KnownType(typeof(SAOROSection))]
    [KnownType(typeof(NoGunsSection))]
    [KnownType(typeof(OtherOrdersROSection))]
    [KnownType(typeof(CarposEntrySection))]
    [KnownType(typeof(ExpirationSection))]
    [KnownType(typeof(ServiceFeesSection))]
    [KnownType(typeof(AttorneysFeesSection))]
    public partial class CH130ROOrder: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CH130ROOrder()
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
    				,this.ObservableForProperty(x => x.ConductSection.IsDirty)
    				,this.ObservableForProperty(x => x.ServiceSection.IsDirty)
    				,this.ObservableForProperty(x => x.SAOSection.IsDirty)
    				,this.ObservableForProperty(x => x.NoGunsSection.IsDirty)
    				,this.ObservableForProperty(x => x.OtherOrdersSection.IsDirty)
    				,this.ObservableForProperty(x => x.CarposEntrySection.IsDirty)
    				,this.ObservableForProperty(x => x.ExpirationSection.IsDirty)
    				,this.ObservableForProperty(x => x.ServiceFeesSection.IsDirty)
    				,this.ObservableForProperty(x => x.AttorneysFeesSection.IsDirty)
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

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public ConductROSection ConductSection
        {
            get { return _conductSection; }
            set
            {
                if (!ReferenceEquals(_conductSection, value))
                {
                    var previousValue = _conductSection;
    				OnNavigationPropertyChanging("ConductSection");
                    _conductSection = value;
                    FixupConductSection(previousValue);
                    OnNavigationPropertyChanged("ConductSection");
                }
            }
        }
        private ConductROSection _conductSection;
    
        [DataMember]
        public ServiceSection ServiceSection
        {
            get { return _serviceSection; }
            set
            {
                if (!ReferenceEquals(_serviceSection, value))
                {
                    var previousValue = _serviceSection;
    				OnNavigationPropertyChanging("ServiceSection");
                    _serviceSection = value;
                    FixupServiceSection(previousValue);
                    OnNavigationPropertyChanged("ServiceSection");
                }
            }
        }
        private ServiceSection _serviceSection;
    
        [DataMember]
        public SAOROSection SAOSection
        {
            get { return _sAOSection; }
            set
            {
                if (!ReferenceEquals(_sAOSection, value))
                {
                    var previousValue = _sAOSection;
    				OnNavigationPropertyChanging("SAOSection");
                    _sAOSection = value;
                    FixupSAOSection(previousValue);
                    OnNavigationPropertyChanged("SAOSection");
                }
            }
        }
        private SAOROSection _sAOSection;
    
        [DataMember]
        public NoGunsSection NoGunsSection
        {
            get { return _noGunsSection; }
            set
            {
                if (!ReferenceEquals(_noGunsSection, value))
                {
                    var previousValue = _noGunsSection;
    				OnNavigationPropertyChanging("NoGunsSection");
                    _noGunsSection = value;
                    FixupNoGunsSection(previousValue);
                    OnNavigationPropertyChanged("NoGunsSection");
                }
            }
        }
        private NoGunsSection _noGunsSection;
    
        [DataMember]
        public OtherOrdersROSection OtherOrdersSection
        {
            get { return _otherOrdersSection; }
            set
            {
                if (!ReferenceEquals(_otherOrdersSection, value))
                {
                    var previousValue = _otherOrdersSection;
    				OnNavigationPropertyChanging("OtherOrdersSection");
                    _otherOrdersSection = value;
                    FixupOtherOrdersSection(previousValue);
                    OnNavigationPropertyChanged("OtherOrdersSection");
                }
            }
        }
        private OtherOrdersROSection _otherOrdersSection;
    
        [DataMember]
        public CarposEntrySection CarposEntrySection
        {
            get { return _carposEntrySection; }
            set
            {
                if (!ReferenceEquals(_carposEntrySection, value))
                {
                    var previousValue = _carposEntrySection;
    				OnNavigationPropertyChanging("CarposEntrySection");
                    _carposEntrySection = value;
                    FixupCarposEntrySection(previousValue);
                    OnNavigationPropertyChanged("CarposEntrySection");
                }
            }
        }
        private CarposEntrySection _carposEntrySection;
    
        [DataMember]
        public ExpirationSection ExpirationSection
        {
            get { return _expirationSection; }
            set
            {
                if (!ReferenceEquals(_expirationSection, value))
                {
                    var previousValue = _expirationSection;
    				OnNavigationPropertyChanging("ExpirationSection");
                    _expirationSection = value;
                    FixupExpirationSection(previousValue);
                    OnNavigationPropertyChanged("ExpirationSection");
                }
            }
        }
        private ExpirationSection _expirationSection;
    
        [DataMember]
        public ServiceFeesSection ServiceFeesSection
        {
            get { return _serviceFeesSection; }
            set
            {
                if (!ReferenceEquals(_serviceFeesSection, value))
                {
                    var previousValue = _serviceFeesSection;
    				OnNavigationPropertyChanging("ServiceFeesSection");
                    _serviceFeesSection = value;
                    FixupServiceFeesSection(previousValue);
                    OnNavigationPropertyChanged("ServiceFeesSection");
                }
            }
        }
        private ServiceFeesSection _serviceFeesSection;
    
        [DataMember]
        public AttorneysFeesSection AttorneysFeesSection
        {
            get { return _attorneysFeesSection; }
            set
            {
                if (!ReferenceEquals(_attorneysFeesSection, value))
                {
                    var previousValue = _attorneysFeesSection;
    				OnNavigationPropertyChanging("AttorneysFeesSection");
                    _attorneysFeesSection = value;
                    FixupAttorneysFeesSection(previousValue);
                    OnNavigationPropertyChanged("AttorneysFeesSection");
                }
            }
        }
        private AttorneysFeesSection _attorneysFeesSection;

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
            ConductSection = null;
            ServiceSection = null;
            SAOSection = null;
            NoGunsSection = null;
            OtherOrdersSection = null;
            CarposEntrySection = null;
            ExpirationSection = null;
            ServiceFeesSection = null;
            AttorneysFeesSection = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupConductSection(ConductROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ConductSection")
                    && (ChangeTracker.OriginalValues["ConductSection"] == ConductSection))
                {
                    ChangeTracker.OriginalValues.Remove("ConductSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ConductSection", previousValue);
                }
                if (ConductSection != null && !ConductSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    ConductSection.StartTracking();
                }
            }
        }
    
        private void FixupServiceSection(ServiceSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ServiceSection")
                    && (ChangeTracker.OriginalValues["ServiceSection"] == ServiceSection))
                {
                    ChangeTracker.OriginalValues.Remove("ServiceSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ServiceSection", previousValue);
                }
                if (ServiceSection != null && !ServiceSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    ServiceSection.StartTracking();
                }
            }
        }
    
        private void FixupSAOSection(SAOROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SAOSection")
                    && (ChangeTracker.OriginalValues["SAOSection"] == SAOSection))
                {
                    ChangeTracker.OriginalValues.Remove("SAOSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SAOSection", previousValue);
                }
                if (SAOSection != null && !SAOSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    SAOSection.StartTracking();
                }
            }
        }
    
        private void FixupNoGunsSection(NoGunsSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("NoGunsSection")
                    && (ChangeTracker.OriginalValues["NoGunsSection"] == NoGunsSection))
                {
                    ChangeTracker.OriginalValues.Remove("NoGunsSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("NoGunsSection", previousValue);
                }
                if (NoGunsSection != null && !NoGunsSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    NoGunsSection.StartTracking();
                }
            }
        }
    
        private void FixupOtherOrdersSection(OtherOrdersROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("OtherOrdersSection")
                    && (ChangeTracker.OriginalValues["OtherOrdersSection"] == OtherOrdersSection))
                {
                    ChangeTracker.OriginalValues.Remove("OtherOrdersSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("OtherOrdersSection", previousValue);
                }
                if (OtherOrdersSection != null && !OtherOrdersSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    OtherOrdersSection.StartTracking();
                }
            }
        }
    
        private void FixupCarposEntrySection(CarposEntrySection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CarposEntrySection")
                    && (ChangeTracker.OriginalValues["CarposEntrySection"] == CarposEntrySection))
                {
                    ChangeTracker.OriginalValues.Remove("CarposEntrySection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CarposEntrySection", previousValue);
                }
                if (CarposEntrySection != null && !CarposEntrySection.ChangeTracker.ChangeTrackingEnabled)
                {
                    CarposEntrySection.StartTracking();
                }
            }
        }
    
        private void FixupExpirationSection(ExpirationSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ExpirationSection")
                    && (ChangeTracker.OriginalValues["ExpirationSection"] == ExpirationSection))
                {
                    ChangeTracker.OriginalValues.Remove("ExpirationSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ExpirationSection", previousValue);
                }
                if (ExpirationSection != null && !ExpirationSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    ExpirationSection.StartTracking();
                }
            }
        }
    
        private void FixupServiceFeesSection(ServiceFeesSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ServiceFeesSection")
                    && (ChangeTracker.OriginalValues["ServiceFeesSection"] == ServiceFeesSection))
                {
                    ChangeTracker.OriginalValues.Remove("ServiceFeesSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ServiceFeesSection", previousValue);
                }
                if (ServiceFeesSection != null && !ServiceFeesSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    ServiceFeesSection.StartTracking();
                }
            }
        }
    
        private void FixupAttorneysFeesSection(AttorneysFeesSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("AttorneysFeesSection")
                    && (ChangeTracker.OriginalValues["AttorneysFeesSection"] == AttorneysFeesSection))
                {
                    ChangeTracker.OriginalValues.Remove("AttorneysFeesSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("AttorneysFeesSection", previousValue);
                }
                if (AttorneysFeesSection != null && !AttorneysFeesSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    AttorneysFeesSection.StartTracking();
                }
            }
        }

        #endregion

    }
}
