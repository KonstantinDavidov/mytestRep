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
    [KnownType(typeof(MoveOutROSection))]
    [KnownType(typeof(CommunicationsRecordingROSection))]
    [KnownType(typeof(AnimalsROSection))]
    [KnownType(typeof(OtherOrdersROSection))]
    [KnownType(typeof(BatterInterventionSection))]
    [KnownType(typeof(NoGunsSection))]
    [KnownType(typeof(ExpirationSection))]
    [KnownType(typeof(PropertyControlROSection))]
    [KnownType(typeof(PaymentsROSection))]
    [KnownType(typeof(PropertyRestrainingOrdersROSection))]
    public partial class DV130ROOrder: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public DV130ROOrder()
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
    				,this.ObservableForProperty(x => x.ConductROSection.IsDirty)
    				,this.ObservableForProperty(x => x.ServiceSection.IsDirty)
    				,this.ObservableForProperty(x => x.SAOROSection.IsDirty)
    				,this.ObservableForProperty(x => x.MoveOutROSection.IsDirty)
    				,this.ObservableForProperty(x => x.CommunicationsRecordingROSection.IsDirty)
    				,this.ObservableForProperty(x => x.AnimalsROSection.IsDirty)
    				,this.ObservableForProperty(x => x.OtherOrdersROSection.IsDirty)
    				,this.ObservableForProperty(x => x.BatterInterventionSection.IsDirty)
    				,this.ObservableForProperty(x => x.NoGunsSection.IsDirty)
    				,this.ObservableForProperty(x => x.ExpirationSection.IsDirty)
    				,this.ObservableForProperty(x => x.PropertyControlROSection.IsDirty)
    				,this.ObservableForProperty(x => x.PaymentsROSection.IsDirty)
    				,this.ObservableForProperty(x => x.PropertyRestrainingOrdersROSection.IsDirty)
    				,this.ObservableForProperty(x => x.OtherPropertyOrdersROSection.IsDirty)
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

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public ConductROSection ConductROSection
        {
            get { return _conductROSection; }
            set
            {
                if (!ReferenceEquals(_conductROSection, value))
                {
                    var previousValue = _conductROSection;
    				OnNavigationPropertyChanging("ConductROSection");
                    _conductROSection = value;
                    FixupConductROSection(previousValue);
                    OnNavigationPropertyChanged("ConductROSection");
                }
            }
        }
        private ConductROSection _conductROSection;
    
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
        public SAOROSection SAOROSection
        {
            get { return _sAOROSection; }
            set
            {
                if (!ReferenceEquals(_sAOROSection, value))
                {
                    var previousValue = _sAOROSection;
    				OnNavigationPropertyChanging("SAOROSection");
                    _sAOROSection = value;
                    FixupSAOROSection(previousValue);
                    OnNavigationPropertyChanged("SAOROSection");
                }
            }
        }
        private SAOROSection _sAOROSection;
    
        [DataMember]
        public MoveOutROSection MoveOutROSection
        {
            get { return _moveOutROSection; }
            set
            {
                if (!ReferenceEquals(_moveOutROSection, value))
                {
                    var previousValue = _moveOutROSection;
    				OnNavigationPropertyChanging("MoveOutROSection");
                    _moveOutROSection = value;
                    FixupMoveOutROSection(previousValue);
                    OnNavigationPropertyChanged("MoveOutROSection");
                }
            }
        }
        private MoveOutROSection _moveOutROSection;
    
        [DataMember]
        public CommunicationsRecordingROSection CommunicationsRecordingROSection
        {
            get { return _communicationsRecordingROSection; }
            set
            {
                if (!ReferenceEquals(_communicationsRecordingROSection, value))
                {
                    var previousValue = _communicationsRecordingROSection;
    				OnNavigationPropertyChanging("CommunicationsRecordingROSection");
                    _communicationsRecordingROSection = value;
                    FixupCommunicationsRecordingROSection(previousValue);
                    OnNavigationPropertyChanged("CommunicationsRecordingROSection");
                }
            }
        }
        private CommunicationsRecordingROSection _communicationsRecordingROSection;
    
        [DataMember]
        public AnimalsROSection AnimalsROSection
        {
            get { return _animalsROSection; }
            set
            {
                if (!ReferenceEquals(_animalsROSection, value))
                {
                    var previousValue = _animalsROSection;
    				OnNavigationPropertyChanging("AnimalsROSection");
                    _animalsROSection = value;
                    FixupAnimalsROSection(previousValue);
                    OnNavigationPropertyChanged("AnimalsROSection");
                }
            }
        }
        private AnimalsROSection _animalsROSection;
    
        [DataMember]
        public OtherOrdersROSection OtherOrdersROSection
        {
            get { return _otherOrdersROSection; }
            set
            {
                if (!ReferenceEquals(_otherOrdersROSection, value))
                {
                    var previousValue = _otherOrdersROSection;
    				OnNavigationPropertyChanging("OtherOrdersROSection");
                    _otherOrdersROSection = value;
                    FixupOtherOrdersROSection(previousValue);
                    OnNavigationPropertyChanged("OtherOrdersROSection");
                }
            }
        }
        private OtherOrdersROSection _otherOrdersROSection;
    
        [DataMember]
        public BatterInterventionSection BatterInterventionSection
        {
            get { return _batterInterventionSection; }
            set
            {
                if (!ReferenceEquals(_batterInterventionSection, value))
                {
                    var previousValue = _batterInterventionSection;
    				OnNavigationPropertyChanging("BatterInterventionSection");
                    _batterInterventionSection = value;
                    FixupBatterInterventionSection(previousValue);
                    OnNavigationPropertyChanged("BatterInterventionSection");
                }
            }
        }
        private BatterInterventionSection _batterInterventionSection;
    
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
        public PropertyControlROSection PropertyControlROSection
        {
            get { return _propertyControlROSection; }
            set
            {
                if (!ReferenceEquals(_propertyControlROSection, value))
                {
                    var previousValue = _propertyControlROSection;
    				OnNavigationPropertyChanging("PropertyControlROSection");
                    _propertyControlROSection = value;
                    FixupPropertyControlROSection(previousValue);
                    OnNavigationPropertyChanged("PropertyControlROSection");
                }
            }
        }
        private PropertyControlROSection _propertyControlROSection;
    
        [DataMember]
        public PaymentsROSection PaymentsROSection
        {
            get { return _paymentsROSection; }
            set
            {
                if (!ReferenceEquals(_paymentsROSection, value))
                {
                    var previousValue = _paymentsROSection;
    				OnNavigationPropertyChanging("PaymentsROSection");
                    _paymentsROSection = value;
                    FixupPaymentsROSection(previousValue);
                    OnNavigationPropertyChanged("PaymentsROSection");
                }
            }
        }
        private PaymentsROSection _paymentsROSection;
    
        [DataMember]
        public PropertyRestrainingOrdersROSection PropertyRestrainingOrdersROSection
        {
            get { return _propertyRestrainingOrdersROSection; }
            set
            {
                if (!ReferenceEquals(_propertyRestrainingOrdersROSection, value))
                {
                    var previousValue = _propertyRestrainingOrdersROSection;
    				OnNavigationPropertyChanging("PropertyRestrainingOrdersROSection");
                    _propertyRestrainingOrdersROSection = value;
                    FixupPropertyRestrainingOrdersROSection(previousValue);
                    OnNavigationPropertyChanged("PropertyRestrainingOrdersROSection");
                }
            }
        }
        private PropertyRestrainingOrdersROSection _propertyRestrainingOrdersROSection;
    
        [DataMember]
        public OtherOrdersROSection OtherPropertyOrdersROSection
        {
            get { return _otherPropertyOrdersROSection; }
            set
            {
                if (!ReferenceEquals(_otherPropertyOrdersROSection, value))
                {
                    var previousValue = _otherPropertyOrdersROSection;
    				OnNavigationPropertyChanging("OtherPropertyOrdersROSection");
                    _otherPropertyOrdersROSection = value;
                    FixupOtherPropertyOrdersROSection(previousValue);
                    OnNavigationPropertyChanged("OtherPropertyOrdersROSection");
                }
            }
        }
        private OtherOrdersROSection _otherPropertyOrdersROSection;

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
            ConductROSection = null;
            ServiceSection = null;
            SAOROSection = null;
            MoveOutROSection = null;
            CommunicationsRecordingROSection = null;
            AnimalsROSection = null;
            OtherOrdersROSection = null;
            BatterInterventionSection = null;
            NoGunsSection = null;
            ExpirationSection = null;
            PropertyControlROSection = null;
            PaymentsROSection = null;
            PropertyRestrainingOrdersROSection = null;
            OtherPropertyOrdersROSection = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupConductROSection(ConductROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ConductROSection")
                    && (ChangeTracker.OriginalValues["ConductROSection"] == ConductROSection))
                {
                    ChangeTracker.OriginalValues.Remove("ConductROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ConductROSection", previousValue);
                }
                if (ConductROSection != null && !ConductROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    ConductROSection.StartTracking();
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
    
        private void FixupSAOROSection(SAOROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SAOROSection")
                    && (ChangeTracker.OriginalValues["SAOROSection"] == SAOROSection))
                {
                    ChangeTracker.OriginalValues.Remove("SAOROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SAOROSection", previousValue);
                }
                if (SAOROSection != null && !SAOROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    SAOROSection.StartTracking();
                }
            }
        }
    
        private void FixupMoveOutROSection(MoveOutROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("MoveOutROSection")
                    && (ChangeTracker.OriginalValues["MoveOutROSection"] == MoveOutROSection))
                {
                    ChangeTracker.OriginalValues.Remove("MoveOutROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("MoveOutROSection", previousValue);
                }
                if (MoveOutROSection != null && !MoveOutROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    MoveOutROSection.StartTracking();
                }
            }
        }
    
        private void FixupCommunicationsRecordingROSection(CommunicationsRecordingROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CommunicationsRecordingROSection")
                    && (ChangeTracker.OriginalValues["CommunicationsRecordingROSection"] == CommunicationsRecordingROSection))
                {
                    ChangeTracker.OriginalValues.Remove("CommunicationsRecordingROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CommunicationsRecordingROSection", previousValue);
                }
                if (CommunicationsRecordingROSection != null && !CommunicationsRecordingROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    CommunicationsRecordingROSection.StartTracking();
                }
            }
        }
    
        private void FixupAnimalsROSection(AnimalsROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("AnimalsROSection")
                    && (ChangeTracker.OriginalValues["AnimalsROSection"] == AnimalsROSection))
                {
                    ChangeTracker.OriginalValues.Remove("AnimalsROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("AnimalsROSection", previousValue);
                }
                if (AnimalsROSection != null && !AnimalsROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    AnimalsROSection.StartTracking();
                }
            }
        }
    
        private void FixupOtherOrdersROSection(OtherOrdersROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("OtherOrdersROSection")
                    && (ChangeTracker.OriginalValues["OtherOrdersROSection"] == OtherOrdersROSection))
                {
                    ChangeTracker.OriginalValues.Remove("OtherOrdersROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("OtherOrdersROSection", previousValue);
                }
                if (OtherOrdersROSection != null && !OtherOrdersROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    OtherOrdersROSection.StartTracking();
                }
            }
        }
    
        private void FixupBatterInterventionSection(BatterInterventionSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("BatterInterventionSection")
                    && (ChangeTracker.OriginalValues["BatterInterventionSection"] == BatterInterventionSection))
                {
                    ChangeTracker.OriginalValues.Remove("BatterInterventionSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("BatterInterventionSection", previousValue);
                }
                if (BatterInterventionSection != null && !BatterInterventionSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    BatterInterventionSection.StartTracking();
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
    
        private void FixupPropertyControlROSection(PropertyControlROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PropertyControlROSection")
                    && (ChangeTracker.OriginalValues["PropertyControlROSection"] == PropertyControlROSection))
                {
                    ChangeTracker.OriginalValues.Remove("PropertyControlROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PropertyControlROSection", previousValue);
                }
                if (PropertyControlROSection != null && !PropertyControlROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    PropertyControlROSection.StartTracking();
                }
            }
        }
    
        private void FixupPaymentsROSection(PaymentsROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PaymentsROSection")
                    && (ChangeTracker.OriginalValues["PaymentsROSection"] == PaymentsROSection))
                {
                    ChangeTracker.OriginalValues.Remove("PaymentsROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PaymentsROSection", previousValue);
                }
                if (PaymentsROSection != null && !PaymentsROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    PaymentsROSection.StartTracking();
                }
            }
        }
    
        private void FixupPropertyRestrainingOrdersROSection(PropertyRestrainingOrdersROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PropertyRestrainingOrdersROSection")
                    && (ChangeTracker.OriginalValues["PropertyRestrainingOrdersROSection"] == PropertyRestrainingOrdersROSection))
                {
                    ChangeTracker.OriginalValues.Remove("PropertyRestrainingOrdersROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PropertyRestrainingOrdersROSection", previousValue);
                }
                if (PropertyRestrainingOrdersROSection != null && !PropertyRestrainingOrdersROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    PropertyRestrainingOrdersROSection.StartTracking();
                }
            }
        }
    
        private void FixupOtherPropertyOrdersROSection(OtherOrdersROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("OtherPropertyOrdersROSection")
                    && (ChangeTracker.OriginalValues["OtherPropertyOrdersROSection"] == OtherPropertyOrdersROSection))
                {
                    ChangeTracker.OriginalValues.Remove("OtherPropertyOrdersROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("OtherPropertyOrdersROSection", previousValue);
                }
                if (OtherPropertyOrdersROSection != null && !OtherPropertyOrdersROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    OtherPropertyOrdersROSection.StartTracking();
                }
            }
        }

        #endregion

    }
}
