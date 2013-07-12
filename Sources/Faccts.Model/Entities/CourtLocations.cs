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
    [KnownType(typeof(CourtCounty))]
    [KnownType(typeof(Courtrooms))]
    public partial class CourtLocations: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CourtLocations()
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
    				,this.ObservableForProperty(x => x.Name)
    				,this.ObservableForProperty(x => x.Description)
    				,this.ObservableForProperty(x => x.StreetAddress)
    				,this.ObservableForProperty(x => x.State)
    				,this.ObservableForProperty(x => x.PostalCode)
    				,this.ObservableForProperty(x => x.City)
    				,this.ObservableForProperty(x => x.CourtCounty_Id)
    				,this.ObservableForProperty(x => x.USAState)
    				,this.ObservableForProperty(x => x.CourtCounty.IsDirty)
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
        public string StreetAddress
        {
            get { return _streetAddress; }
            set
            {
                if (_streetAddress != value)
                {
    				OnPropertyChanging("StreetAddress");
                    _streetAddress = value;
                    OnPropertyChanged("StreetAddress");
                }
            }
        }
        private string _streetAddress;
    
        [DataMember]
        public FACCTS.Server.Model.Enums.USAState State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
    				OnPropertyChanging("State");
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
        }
        private FACCTS.Server.Model.Enums.USAState _state;
    
        [DataMember]
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (_postalCode != value)
                {
    				OnPropertyChanging("PostalCode");
                    _postalCode = value;
                    OnPropertyChanged("PostalCode");
                }
            }
        }
        private string _postalCode;
    
        [DataMember]
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
    				OnPropertyChanging("City");
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        private string _city;
    
        [DataMember]
        public Nullable<long> CourtCounty_Id
        {
            get { return _courtCounty_Id; }
            set
            {
                if (_courtCounty_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("CourtCounty_Id", _courtCounty_Id);
                    if (!IsDeserializing)
                    {
                        if (CourtCounty != null && CourtCounty.Id != value)
                        {
                            CourtCounty = null;
                        }
                    }
    				OnPropertyChanging("CourtCounty_Id");
                    _courtCounty_Id = value;
                    OnPropertyChanged("CourtCounty_Id");
                }
            }
        }
        private Nullable<long> _courtCounty_Id;
    
        [DataMember]
        public int USAState
        {
            get { return _uSAState; }
            set
            {
                if (_uSAState != value)
                {
    				OnPropertyChanging("USAState");
                    _uSAState = value;
                    OnPropertyChanged("USAState");
                }
            }
        }
        private int _uSAState;

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
        public TrackableCollection<Courtrooms> Courtrooms
        {
            get
            {
                if (_courtrooms == null)
                {
                    _courtrooms = new TrackableCollection<Courtrooms>();
                    _courtrooms.CollectionChanged += FixupCourtrooms;
                }
                return _courtrooms;
            }
            set
            {
                if (!ReferenceEquals(_courtrooms, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("Courtrooms");
                    if (_courtrooms != null)
                    {
                        _courtrooms.CollectionChanged -= FixupCourtrooms;
                    }
                    _courtrooms = value;
                    if (_courtrooms != null)
                    {
                        _courtrooms.CollectionChanged += FixupCourtrooms;
                    }
                    OnNavigationPropertyChanged("Courtrooms");
                }
            }
        }
        private TrackableCollection<Courtrooms> _courtrooms;

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
            CourtCounty = null;
            Courtrooms.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupCourtCounty(CourtCounty previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtLocations.Contains(this))
            {
                previousValue.CourtLocations.Remove(this);
            }
    
            if (CourtCounty != null)
            {
                CourtCounty.CourtLocations.Add(this);
    
                CourtCounty_Id = CourtCounty.Id;
            }
            else if (!skipKeys)
            {
                CourtCounty_Id = null;
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
    
        private void FixupCourtrooms(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Courtrooms item in e.NewItems)
                {
                    item.CourtLocations = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Courtrooms", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Courtrooms item in e.OldItems)
                {
                    if (ReferenceEquals(item.CourtLocations, this))
                    {
                        item.CourtLocations = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Courtrooms", item);
                    }
                }
            }
        }

        #endregion

    }
}
