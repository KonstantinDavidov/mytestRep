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
    [KnownType(typeof(ConductDVTROSection))]
    [KnownType(typeof(DV110ServiceSection))]
    [KnownType(typeof(SAOTROSection))]
    [KnownType(typeof(MoveOutTROSection))]
    [KnownType(typeof(CommunicationsRecordingTROSection))]
    [KnownType(typeof(AnimalsTROSection))]
    [KnownType(typeof(OtherOrdersTROSection))]
    [KnownType(typeof(NoGunsSection))]
    [KnownType(typeof(BatterInterventionSection))]
    [KnownType(typeof(ExpirationSection))]
    [KnownType(typeof(PropertyControlTROSection))]
    [KnownType(typeof(PaymentsTROSection))]
    [KnownType(typeof(PropertyRestrainingOrdersTROSection))]
    public partial class DV110TROOrder: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public DV110TROOrder()
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
    				,this.ObservableForProperty(x => x.ConductDVTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.DV110ServiceSection.IsDirty)
    				,this.ObservableForProperty(x => x.SAOTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.MoveOutTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.CommunicationsRecordingTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.AnimalsTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.OtherOrdersTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.NoGunsSection.IsDirty)
    				,this.ObservableForProperty(x => x.BatterInterventionSection.IsDirty)
    				,this.ObservableForProperty(x => x.ExpirationSection.IsDirty)
    				,this.ObservableForProperty(x => x.PropertyControlTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.PaymentsTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.PropertyRestrainingOrdersTROSection.IsDirty)
    				,this.ObservableForProperty(x => x.OtherPropertyOrdersTROSection.IsDirty)
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
        public ConductDVTROSection ConductDVTROSection
        {
            get { return _conductDVTROSection; }
            set
            {
                if (!ReferenceEquals(_conductDVTROSection, value))
                {
                    var previousValue = _conductDVTROSection;
    				OnNavigationPropertyChanging("ConductDVTROSection");
                    _conductDVTROSection = value;
                    FixupConductDVTROSection(previousValue);
                    OnNavigationPropertyChanged("ConductDVTROSection");
                }
            }
        }
        private ConductDVTROSection _conductDVTROSection;
    
        [DataMember]
        public DV110ServiceSection DV110ServiceSection
        {
            get { return _dV110ServiceSection; }
            set
            {
                if (!ReferenceEquals(_dV110ServiceSection, value))
                {
                    var previousValue = _dV110ServiceSection;
    				OnNavigationPropertyChanging("DV110ServiceSection");
                    _dV110ServiceSection = value;
                    FixupDV110ServiceSection(previousValue);
                    OnNavigationPropertyChanged("DV110ServiceSection");
                }
            }
        }
        private DV110ServiceSection _dV110ServiceSection;
    
        [DataMember]
        public SAOTROSection SAOTROSection
        {
            get { return _sAOTROSection; }
            set
            {
                if (!ReferenceEquals(_sAOTROSection, value))
                {
                    var previousValue = _sAOTROSection;
    				OnNavigationPropertyChanging("SAOTROSection");
                    _sAOTROSection = value;
                    FixupSAOTROSection(previousValue);
                    OnNavigationPropertyChanged("SAOTROSection");
                }
            }
        }
        private SAOTROSection _sAOTROSection;
    
        [DataMember]
        public MoveOutTROSection MoveOutTROSection
        {
            get { return _moveOutTROSection; }
            set
            {
                if (!ReferenceEquals(_moveOutTROSection, value))
                {
                    var previousValue = _moveOutTROSection;
    				OnNavigationPropertyChanging("MoveOutTROSection");
                    _moveOutTROSection = value;
                    FixupMoveOutTROSection(previousValue);
                    OnNavigationPropertyChanged("MoveOutTROSection");
                }
            }
        }
        private MoveOutTROSection _moveOutTROSection;
    
        [DataMember]
        public CommunicationsRecordingTROSection CommunicationsRecordingTROSection
        {
            get { return _communicationsRecordingTROSection; }
            set
            {
                if (!ReferenceEquals(_communicationsRecordingTROSection, value))
                {
                    var previousValue = _communicationsRecordingTROSection;
    				OnNavigationPropertyChanging("CommunicationsRecordingTROSection");
                    _communicationsRecordingTROSection = value;
                    FixupCommunicationsRecordingTROSection(previousValue);
                    OnNavigationPropertyChanged("CommunicationsRecordingTROSection");
                }
            }
        }
        private CommunicationsRecordingTROSection _communicationsRecordingTROSection;
    
        [DataMember]
        public AnimalsTROSection AnimalsTROSection
        {
            get { return _animalsTROSection; }
            set
            {
                if (!ReferenceEquals(_animalsTROSection, value))
                {
                    var previousValue = _animalsTROSection;
    				OnNavigationPropertyChanging("AnimalsTROSection");
                    _animalsTROSection = value;
                    FixupAnimalsTROSection(previousValue);
                    OnNavigationPropertyChanged("AnimalsTROSection");
                }
            }
        }
        private AnimalsTROSection _animalsTROSection;
    
        [DataMember]
        public OtherOrdersTROSection OtherOrdersTROSection
        {
            get { return _otherOrdersTROSection; }
            set
            {
                if (!ReferenceEquals(_otherOrdersTROSection, value))
                {
                    var previousValue = _otherOrdersTROSection;
    				OnNavigationPropertyChanging("OtherOrdersTROSection");
                    _otherOrdersTROSection = value;
                    FixupOtherOrdersTROSection(previousValue);
                    OnNavigationPropertyChanged("OtherOrdersTROSection");
                }
            }
        }
        private OtherOrdersTROSection _otherOrdersTROSection;
    
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
        public PropertyControlTROSection PropertyControlTROSection
        {
            get { return _propertyControlTROSection; }
            set
            {
                if (!ReferenceEquals(_propertyControlTROSection, value))
                {
                    var previousValue = _propertyControlTROSection;
    				OnNavigationPropertyChanging("PropertyControlTROSection");
                    _propertyControlTROSection = value;
                    FixupPropertyControlTROSection(previousValue);
                    OnNavigationPropertyChanged("PropertyControlTROSection");
                }
            }
        }
        private PropertyControlTROSection _propertyControlTROSection;
    
        [DataMember]
        public PaymentsTROSection PaymentsTROSection
        {
            get { return _paymentsTROSection; }
            set
            {
                if (!ReferenceEquals(_paymentsTROSection, value))
                {
                    var previousValue = _paymentsTROSection;
    				OnNavigationPropertyChanging("PaymentsTROSection");
                    _paymentsTROSection = value;
                    FixupPaymentsTROSection(previousValue);
                    OnNavigationPropertyChanged("PaymentsTROSection");
                }
            }
        }
        private PaymentsTROSection _paymentsTROSection;
    
        [DataMember]
        public PropertyRestrainingOrdersTROSection PropertyRestrainingOrdersTROSection
        {
            get { return _propertyRestrainingOrdersTROSection; }
            set
            {
                if (!ReferenceEquals(_propertyRestrainingOrdersTROSection, value))
                {
                    var previousValue = _propertyRestrainingOrdersTROSection;
    				OnNavigationPropertyChanging("PropertyRestrainingOrdersTROSection");
                    _propertyRestrainingOrdersTROSection = value;
                    FixupPropertyRestrainingOrdersTROSection(previousValue);
                    OnNavigationPropertyChanged("PropertyRestrainingOrdersTROSection");
                }
            }
        }
        private PropertyRestrainingOrdersTROSection _propertyRestrainingOrdersTROSection;
    
        [DataMember]
        public OtherOrdersTROSection OtherPropertyOrdersTROSection
        {
            get { return _otherPropertyOrdersTROSection; }
            set
            {
                if (!ReferenceEquals(_otherPropertyOrdersTROSection, value))
                {
                    var previousValue = _otherPropertyOrdersTROSection;
    				OnNavigationPropertyChanging("OtherPropertyOrdersTROSection");
                    _otherPropertyOrdersTROSection = value;
                    FixupOtherPropertyOrdersTROSection(previousValue);
                    OnNavigationPropertyChanged("OtherPropertyOrdersTROSection");
                }
            }
        }
        private OtherOrdersTROSection _otherPropertyOrdersTROSection;

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
            ConductDVTROSection = null;
            DV110ServiceSection = null;
            SAOTROSection = null;
            MoveOutTROSection = null;
            CommunicationsRecordingTROSection = null;
            AnimalsTROSection = null;
            OtherOrdersTROSection = null;
            NoGunsSection = null;
            BatterInterventionSection = null;
            ExpirationSection = null;
            PropertyControlTROSection = null;
            PaymentsTROSection = null;
            PropertyRestrainingOrdersTROSection = null;
            OtherPropertyOrdersTROSection = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupConductDVTROSection(ConductDVTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ConductDVTROSection")
                    && (ChangeTracker.OriginalValues["ConductDVTROSection"] == ConductDVTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("ConductDVTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ConductDVTROSection", previousValue);
                }
                if (ConductDVTROSection != null && !ConductDVTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    ConductDVTROSection.StartTracking();
                }
            }
        }
    
        private void FixupDV110ServiceSection(DV110ServiceSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("DV110ServiceSection")
                    && (ChangeTracker.OriginalValues["DV110ServiceSection"] == DV110ServiceSection))
                {
                    ChangeTracker.OriginalValues.Remove("DV110ServiceSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("DV110ServiceSection", previousValue);
                }
                if (DV110ServiceSection != null && !DV110ServiceSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    DV110ServiceSection.StartTracking();
                }
            }
        }
    
        private void FixupSAOTROSection(SAOTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("SAOTROSection")
                    && (ChangeTracker.OriginalValues["SAOTROSection"] == SAOTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("SAOTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("SAOTROSection", previousValue);
                }
                if (SAOTROSection != null && !SAOTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    SAOTROSection.StartTracking();
                }
            }
        }
    
        private void FixupMoveOutTROSection(MoveOutTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("MoveOutTROSection")
                    && (ChangeTracker.OriginalValues["MoveOutTROSection"] == MoveOutTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("MoveOutTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("MoveOutTROSection", previousValue);
                }
                if (MoveOutTROSection != null && !MoveOutTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    MoveOutTROSection.StartTracking();
                }
            }
        }
    
        private void FixupCommunicationsRecordingTROSection(CommunicationsRecordingTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CommunicationsRecordingTROSection")
                    && (ChangeTracker.OriginalValues["CommunicationsRecordingTROSection"] == CommunicationsRecordingTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("CommunicationsRecordingTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CommunicationsRecordingTROSection", previousValue);
                }
                if (CommunicationsRecordingTROSection != null && !CommunicationsRecordingTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    CommunicationsRecordingTROSection.StartTracking();
                }
            }
        }
    
        private void FixupAnimalsTROSection(AnimalsTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("AnimalsTROSection")
                    && (ChangeTracker.OriginalValues["AnimalsTROSection"] == AnimalsTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("AnimalsTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("AnimalsTROSection", previousValue);
                }
                if (AnimalsTROSection != null && !AnimalsTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    AnimalsTROSection.StartTracking();
                }
            }
        }
    
        private void FixupOtherOrdersTROSection(OtherOrdersTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("OtherOrdersTROSection")
                    && (ChangeTracker.OriginalValues["OtherOrdersTROSection"] == OtherOrdersTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("OtherOrdersTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("OtherOrdersTROSection", previousValue);
                }
                if (OtherOrdersTROSection != null && !OtherOrdersTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    OtherOrdersTROSection.StartTracking();
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
    
        private void FixupPropertyControlTROSection(PropertyControlTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PropertyControlTROSection")
                    && (ChangeTracker.OriginalValues["PropertyControlTROSection"] == PropertyControlTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("PropertyControlTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PropertyControlTROSection", previousValue);
                }
                if (PropertyControlTROSection != null && !PropertyControlTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    PropertyControlTROSection.StartTracking();
                }
            }
        }
    
        private void FixupPaymentsTROSection(PaymentsTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PaymentsTROSection")
                    && (ChangeTracker.OriginalValues["PaymentsTROSection"] == PaymentsTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("PaymentsTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PaymentsTROSection", previousValue);
                }
                if (PaymentsTROSection != null && !PaymentsTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    PaymentsTROSection.StartTracking();
                }
            }
        }
    
        private void FixupPropertyRestrainingOrdersTROSection(PropertyRestrainingOrdersTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("PropertyRestrainingOrdersTROSection")
                    && (ChangeTracker.OriginalValues["PropertyRestrainingOrdersTROSection"] == PropertyRestrainingOrdersTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("PropertyRestrainingOrdersTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("PropertyRestrainingOrdersTROSection", previousValue);
                }
                if (PropertyRestrainingOrdersTROSection != null && !PropertyRestrainingOrdersTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    PropertyRestrainingOrdersTROSection.StartTracking();
                }
            }
        }
    
        private void FixupOtherPropertyOrdersTROSection(OtherOrdersTROSection previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("OtherPropertyOrdersTROSection")
                    && (ChangeTracker.OriginalValues["OtherPropertyOrdersTROSection"] == OtherPropertyOrdersTROSection))
                {
                    ChangeTracker.OriginalValues.Remove("OtherPropertyOrdersTROSection");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("OtherPropertyOrdersTROSection", previousValue);
                }
                if (OtherPropertyOrdersTROSection != null && !OtherPropertyOrdersTROSection.ChangeTracker.ChangeTrackingEnabled)
                {
                    OtherPropertyOrdersTROSection.StartTracking();
                }
            }
        }

        #endregion

    }
}
