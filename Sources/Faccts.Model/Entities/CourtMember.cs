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
    [KnownType(typeof(CourtMember))]
    [KnownType(typeof(User))]
    public partial class CourtMember: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CourtMember()
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
    				,this.ObservableForProperty(x => x.SubstituteId)
    				,this.ObservableForProperty(x => x.IsCertified)
    				,this.ObservableForProperty(x => x.IsAvilable)
    				,this.ObservableForProperty(x => x.Image)
    				,this.ObservableForProperty(x => x.Phone)
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
                    if (!IsDeserializing)
                    {
                        if (User != null && User.Id != value)
                        {
                            User = null;
                        }
                    }
    				OnPropertyChanging("Id");
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public Nullable<int> SubstituteId
        {
            get { return _substituteId; }
            set
            {
                if (_substituteId != value)
                {
                    ChangeTracker.RecordOriginalValue("SubstituteId", _substituteId);
                    if (!IsDeserializing)
                    {
                        if (CourtMember2 != null && CourtMember2.Id != value)
                        {
                            CourtMember2 = null;
                        }
                    }
    				OnPropertyChanging("SubstituteId");
                    _substituteId = value;
                    OnPropertyChanged("SubstituteId");
                }
            }
        }
        private Nullable<int> _substituteId;
    
        [DataMember]
        public bool IsCertified
        {
            get { return _isCertified; }
            set
            {
                if (_isCertified != value)
                {
    				OnPropertyChanging("IsCertified");
                    _isCertified = value;
                    OnPropertyChanged("IsCertified");
                }
            }
        }
        private bool _isCertified;
    
        [DataMember]
        public bool IsAvilable
        {
            get { return _isAvilable; }
            set
            {
                if (_isAvilable != value)
                {
    				OnPropertyChanging("IsAvilable");
                    _isAvilable = value;
                    OnPropertyChanged("IsAvilable");
                }
            }
        }
        private bool _isAvilable;
    
        [DataMember]
        public byte[] Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
    				OnPropertyChanging("Image");
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
        private byte[] _image;
    
        [DataMember]
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
    				OnPropertyChanging("Phone");
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        private string _phone;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<CourtMember> CourtMember1
        {
            get
            {
                if (_courtMember1 == null)
                {
                    _courtMember1 = new TrackableCollection<CourtMember>();
                    _courtMember1.CollectionChanged += FixupCourtMember1;
                }
                return _courtMember1;
            }
            set
            {
                if (!ReferenceEquals(_courtMember1, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("CourtMember1");
                    if (_courtMember1 != null)
                    {
                        _courtMember1.CollectionChanged -= FixupCourtMember1;
                    }
                    _courtMember1 = value;
                    if (_courtMember1 != null)
                    {
                        _courtMember1.CollectionChanged += FixupCourtMember1;
                    }
                    OnNavigationPropertyChanged("CourtMember1");
                }
            }
        }
        private TrackableCollection<CourtMember> _courtMember1;
    
        [DataMember]
        public CourtMember CourtMember2
        {
            get { return _courtMember2; }
            set
            {
                if (!ReferenceEquals(_courtMember2, value))
                {
                    var previousValue = _courtMember2;
    				OnNavigationPropertyChanging("CourtMember2");
                    _courtMember2 = value;
                    FixupCourtMember2(previousValue);
                    OnNavigationPropertyChanged("CourtMember2");
                }
            }
        }
        private CourtMember _courtMember2;
    
        [DataMember]
        public User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added && value != null)
                    {
                        // This the dependent end of an identifying relationship, so the principal end cannot be changed if it is already set,
                        // otherwise it can only be set to an entity with a primary key that is the same value as the dependent's foreign key.
                        if (Id != value.Id)
                        {
                            throw new InvalidOperationException("The principal end of an identifying relationship can only be changed when the dependent end is in the Added state.");
                        }
                    }
                    var previousValue = _user;
    				OnNavigationPropertyChanging("User");
                    _user = value;
                    FixupUser(previousValue);
                    OnNavigationPropertyChanged("User");
                }
            }
        }
        private User _user;

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
            CourtMember1.Clear();
            CourtMember2 = null;
            User = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCourtMember2(CourtMember previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtMember1.Contains(this))
            {
                previousValue.CourtMember1.Remove(this);
            }
    
            if (CourtMember2 != null)
            {
                CourtMember2.CourtMember1.Add(this);
    
                SubstituteId = CourtMember2.Id;
            }
            else if (!skipKeys)
            {
                SubstituteId = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CourtMember2")
                    && (ChangeTracker.OriginalValues["CourtMember2"] == CourtMember2))
                {
                    ChangeTracker.OriginalValues.Remove("CourtMember2");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CourtMember2", previousValue);
                }
                if (CourtMember2 != null && !CourtMember2.ChangeTracker.ChangeTrackingEnabled)
                {
                    CourtMember2.StartTracking();
                }
            }
        }
    
        private void FixupUser(User previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && ReferenceEquals(previousValue.CourtMember, this))
            {
                previousValue.CourtMember = null;
            }
    
            if (User != null)
            {
                User.CourtMember = this;
                Id = User.Id;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("User")
                    && (ChangeTracker.OriginalValues["User"] == User))
                {
                    ChangeTracker.OriginalValues.Remove("User");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("User", previousValue);
                }
                if (User != null && !User.ChangeTracker.ChangeTrackingEnabled)
                {
                    User.StartTracking();
                }
            }
        }
    
        private void FixupCourtMember1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtMember item in e.NewItems)
                {
                    item.CourtMember2 = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtMember1", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtMember item in e.OldItems)
                {
                    if (ReferenceEquals(item.CourtMember2, this))
                    {
                        item.CourtMember2 = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtMember1", item);
                    }
                }
            }
        }

        #endregion

    }
}
