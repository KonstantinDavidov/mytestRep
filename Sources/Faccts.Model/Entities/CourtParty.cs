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
    [KnownType(typeof(HairColor))]
    [KnownType(typeof(Race))]
    [KnownType(typeof(EyesColor))]
    [KnownType(typeof(CourtCase))]
    [KnownType(typeof(Attorneys))]
    public partial class CourtParty: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CourtParty()
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
    				,this.ObservableForProperty(x => x.FirstName)
    				,this.ObservableForProperty(x => x.MiddleName)
    				,this.ObservableForProperty(x => x.LastName)
    				,this.ObservableForProperty(x => x.Description)
    				,this.ObservableForProperty(x => x.Weight)
    				,this.ObservableForProperty(x => x.HeightFt)
    				,this.ObservableForProperty(x => x.HeightIns)
    				,this.ObservableForProperty(x => x.DateOfBirth)
    				,this.ObservableForProperty(x => x.Age)
    				,this.ObservableForProperty(x => x.HairColor_Id)
    				,this.ObservableForProperty(x => x.EyesColor_Id)
    				,this.ObservableForProperty(x => x.Race_Id)
    				,this.ObservableForProperty(x => x.ParticipantRole)
    				,this.ObservableForProperty(x => x.Sex)
    				,this.ObservableForProperty(x => x.ParentRole)
    				,this.ObservableForProperty(x => x.EntityType)
    				,this.ObservableForProperty(x => x.Email)
    				,this.ObservableForProperty(x => x.RelationToOtherParty)
    				,this.ObservableForProperty(x => x.Designation)
    				,this.ObservableForProperty(x => x.HairColor.IsDirty)
    				,this.ObservableForProperty(x => x.Race.IsDirty)
    				,this.ObservableForProperty(x => x.EyesColor.IsDirty)
    				,this.ObservableForProperty(x => x.Attorney.IsDirty)
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
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
    				OnPropertyChanging("FirstName");
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        private string _firstName;
    
        [DataMember]
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (_middleName != value)
                {
    				OnPropertyChanging("MiddleName");
                    _middleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }
        private string _middleName;
    
        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
    				OnPropertyChanging("LastName");
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        private string _lastName;
    
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
    				OnPropertyChanging("Description");
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public decimal Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
    				OnPropertyChanging("Weight");
                    _weight = value;
                    OnPropertyChanged("Weight");
                }
            }
        }
        private decimal _weight;
    
        [DataMember]
        public decimal HeightFt
        {
            get { return _heightFt; }
            set
            {
                if (_heightFt != value)
                {
    				OnPropertyChanging("HeightFt");
                    _heightFt = value;
                    OnPropertyChanged("HeightFt");
                }
            }
        }
        private decimal _heightFt;
    
        [DataMember]
        public decimal HeightIns
        {
            get { return _heightIns; }
            set
            {
                if (_heightIns != value)
                {
    				OnPropertyChanging("HeightIns");
                    _heightIns = value;
                    OnPropertyChanged("HeightIns");
                }
            }
        }
        private decimal _heightIns;
    
        [DataMember]
        public System.DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (_dateOfBirth != value)
                {
    				OnPropertyChanging("DateOfBirth");
                    _dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        private System.DateTime _dateOfBirth;
    
        [DataMember]
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
    				OnPropertyChanging("Age");
                    _age = value;
                    OnPropertyChanged("Age");
                }
            }
        }
        private int _age;
    
        [DataMember]
        public Nullable<long> HairColor_Id
        {
            get { return _hairColor_Id; }
            set
            {
                if (_hairColor_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("HairColor_Id", _hairColor_Id);
                    if (!IsDeserializing)
                    {
                        if (HairColor != null && HairColor.Id != value)
                        {
                            HairColor = null;
                        }
                    }
    				OnPropertyChanging("HairColor_Id");
                    _hairColor_Id = value;
                    OnPropertyChanged("HairColor_Id");
                }
            }
        }
        private Nullable<long> _hairColor_Id;
    
        [DataMember]
        public Nullable<long> EyesColor_Id
        {
            get { return _eyesColor_Id; }
            set
            {
                if (_eyesColor_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("EyesColor_Id", _eyesColor_Id);
                    if (!IsDeserializing)
                    {
                        if (EyesColor != null && EyesColor.Id != value)
                        {
                            EyesColor = null;
                        }
                    }
    				OnPropertyChanging("EyesColor_Id");
                    _eyesColor_Id = value;
                    OnPropertyChanged("EyesColor_Id");
                }
            }
        }
        private Nullable<long> _eyesColor_Id;
    
        [DataMember]
        public Nullable<long> Race_Id
        {
            get { return _race_Id; }
            set
            {
                if (_race_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Race_Id", _race_Id);
                    if (!IsDeserializing)
                    {
                        if (Race != null && Race.Id != value)
                        {
                            Race = null;
                        }
                    }
    				OnPropertyChanging("Race_Id");
                    _race_Id = value;
                    OnPropertyChanged("Race_Id");
                }
            }
        }
        private Nullable<long> _race_Id;
    
        [DataMember]
        public FACCTS.Server.Model.Enums.ParticipantRole ParticipantRole
        {
            get { return _participantRole; }
            set
            {
                if (_participantRole != value)
                {
    				OnPropertyChanging("ParticipantRole");
                    _participantRole = value;
                    OnPropertyChanged("ParticipantRole");
                }
            }
        }
        private FACCTS.Server.Model.Enums.ParticipantRole _participantRole;
    
        [DataMember]
        public FACCTS.Server.Model.Enums.Gender Sex
        {
            get { return _sex; }
            set
            {
                if (_sex != value)
                {
    				OnPropertyChanging("Sex");
                    _sex = value;
                    OnPropertyChanged("Sex");
                }
            }
        }
        private FACCTS.Server.Model.Enums.Gender _sex;
    
        [DataMember]
        public string ParentRole
        {
            get { return _parentRole; }
            set
            {
                if (_parentRole != value)
                {
    				OnPropertyChanging("ParentRole");
                    _parentRole = value;
                    OnPropertyChanged("ParentRole");
                }
            }
        }
        private string _parentRole;
    
        [DataMember]
        public FACCTS.Server.Model.Enums.FACCTSEntity EntityType
        {
            get { return _entityType; }
            set
            {
                if (_entityType != value)
                {
    				OnPropertyChanging("EntityType");
                    _entityType = value;
                    OnPropertyChanged("EntityType");
                }
            }
        }
        private FACCTS.Server.Model.Enums.FACCTSEntity _entityType;
    
        [DataMember]
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
    				OnPropertyChanging("Email");
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        private string _email;
    
        [DataMember]
        public string RelationToOtherParty
        {
            get { return _relationToOtherParty; }
            set
            {
                if (_relationToOtherParty != value)
                {
    				OnPropertyChanging("RelationToOtherParty");
                    _relationToOtherParty = value;
                    OnPropertyChanged("RelationToOtherParty");
                }
            }
        }
        private string _relationToOtherParty;
    
        [DataMember]
        public Nullable<FACCTS.Server.Model.Enums.Designation> Designation
        {
            get { return _designation; }
            set
            {
                if (_designation != value)
                {
    				OnPropertyChanging("Designation");
                    _designation = value;
                    OnPropertyChanged("Designation");
                }
            }
        }
        private Nullable<FACCTS.Server.Model.Enums.Designation> _designation;

        #endregion

        #region Complex Properties
    
        [DataMember]
        public AddressInfo AddressInfo
        {
            get
            {
                if (!_addressInfoInitialized && _addressInfo == null)
                {
                    _addressInfo = new AddressInfo();
                    ((INotifyComplexPropertyChanging)_addressInfo).ComplexPropertyChanging += HandleAddressInfoChanging;
                }
                _addressInfoInitialized = true;
                return _addressInfo;
            }
            set
            {
                _addressInfoInitialized = true;
                if (!Equals(_addressInfo, value))
                {
                    if (_addressInfo != null)
                    {
                        ((INotifyComplexPropertyChanging)_addressInfo).ComplexPropertyChanging -= HandleAddressInfoChanging;
                    }
    
                    HandleAddressInfoChanging(this, null);
    				OnPropertyChanging("AddressInfo");
                    _addressInfo = value;
                    OnPropertyChanged("AddressInfo");
    
                    if (value != null)
                    {
                        ((INotifyComplexPropertyChanging)_addressInfo).ComplexPropertyChanging += HandleAddressInfoChanging;
                    }
                }
            }
        }
        private AddressInfo _addressInfo;
        private bool _addressInfoInitialized;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public HairColor HairColor
        {
            get { return _hairColor; }
            set
            {
                if (!ReferenceEquals(_hairColor, value))
                {
                    var previousValue = _hairColor;
    				OnNavigationPropertyChanging("HairColor");
                    _hairColor = value;
                    FixupHairColor(previousValue);
                    OnNavigationPropertyChanged("HairColor");
                }
            }
        }
        private HairColor _hairColor;
    
        [DataMember]
        public Race Race
        {
            get { return _race; }
            set
            {
                if (!ReferenceEquals(_race, value))
                {
                    var previousValue = _race;
    				OnNavigationPropertyChanging("Race");
                    _race = value;
                    FixupRace(previousValue);
                    OnNavigationPropertyChanged("Race");
                }
            }
        }
        private Race _race;
    
        [DataMember]
        public EyesColor EyesColor
        {
            get { return _eyesColor; }
            set
            {
                if (!ReferenceEquals(_eyesColor, value))
                {
                    var previousValue = _eyesColor;
    				OnNavigationPropertyChanging("EyesColor");
                    _eyesColor = value;
                    FixupEyesColor(previousValue);
                    OnNavigationPropertyChanged("EyesColor");
                }
            }
        }
        private EyesColor _eyesColor;
    
        [DataMember]
        public TrackableCollection<CourtCase> CourtCase
        {
            get
            {
                if (_courtCase == null)
                {
                    _courtCase = new TrackableCollection<CourtCase>();
                    _courtCase.CollectionChanged += FixupCourtCase;
                }
                return _courtCase;
            }
            set
            {
                if (!ReferenceEquals(_courtCase, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("CourtCase");
                    if (_courtCase != null)
                    {
                        _courtCase.CollectionChanged -= FixupCourtCase;
                    }
                    _courtCase = value;
                    if (_courtCase != null)
                    {
                        _courtCase.CollectionChanged += FixupCourtCase;
                    }
                    OnNavigationPropertyChanged("CourtCase");
                }
            }
        }
        private TrackableCollection<CourtCase> _courtCase;
    
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
        // Records the original values for the complex property AddressInfo
        private void HandleAddressInfoChanging(object sender, EventArgs args)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
        }
    
    
        protected virtual void ClearNavigationProperties()
        {
            HairColor = null;
            Race = null;
            EyesColor = null;
            CourtCase.Clear();
            Attorney = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupHairColor(HairColor previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (HairColor != null)
            {
                HairColor_Id = HairColor.Id;
            }
    
            else if (!skipKeys)
            {
                HairColor_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("HairColor")
                    && (ChangeTracker.OriginalValues["HairColor"] == HairColor))
                {
                    ChangeTracker.OriginalValues.Remove("HairColor");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("HairColor", previousValue);
                }
                if (HairColor != null && !HairColor.ChangeTracker.ChangeTrackingEnabled)
                {
                    HairColor.StartTracking();
                }
            }
        }
    
        private void FixupRace(Race previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (Race != null)
            {
                Race_Id = Race.Id;
            }
    
            else if (!skipKeys)
            {
                Race_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Race")
                    && (ChangeTracker.OriginalValues["Race"] == Race))
                {
                    ChangeTracker.OriginalValues.Remove("Race");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Race", previousValue);
                }
                if (Race != null && !Race.ChangeTracker.ChangeTrackingEnabled)
                {
                    Race.StartTracking();
                }
            }
        }
    
        private void FixupEyesColor(EyesColor previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (EyesColor != null)
            {
                EyesColor_Id = EyesColor.Id;
            }
    
            else if (!skipKeys)
            {
                EyesColor_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("EyesColor")
                    && (ChangeTracker.OriginalValues["EyesColor"] == EyesColor))
                {
                    ChangeTracker.OriginalValues.Remove("EyesColor");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("EyesColor", previousValue);
                }
                if (EyesColor != null && !EyesColor.ChangeTracker.ChangeTrackingEnabled)
                {
                    EyesColor.StartTracking();
                }
            }
        }
    
        private void FixupAttorney(Attorneys previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && ReferenceEquals(previousValue.CourtParty, this))
            {
                previousValue.CourtParty = null;
            }
    
            if (Attorney != null)
            {
                Attorney.CourtParty = this;
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
    
        private void FixupCourtCase(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtCase item in e.NewItems)
                {
                    item.Party1_Id = Id;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtCase", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtCase item in e.OldItems)
                {
                    item.Party1_Id = null;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtCase", item);
                    }
                }
            }
        }

        #endregion

    }
}
