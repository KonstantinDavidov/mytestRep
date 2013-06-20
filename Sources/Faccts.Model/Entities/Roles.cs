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
    [KnownType(typeof(Applications))]
    [KnownType(typeof(Users))]
    public partial class Roles: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public Roles()
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
        public System.Guid RoleId
        {
            get { return _roleId; }
            set
            {
                if (_roleId != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'RoleId' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
    				OnPropertyChanging("RoleId");
                    _roleId = value;
                    OnPropertyChanged("RoleId");
                }
            }
        }
        private System.Guid _roleId;
    
        [DataMember]
        public System.Guid ApplicationId
        {
            get { return _applicationId; }
            set
            {
                if (_applicationId != value)
                {
                    ChangeTracker.RecordOriginalValue("ApplicationId", _applicationId);
                    if (!IsDeserializing)
                    {
                        if (Applications != null && Applications.ApplicationId != value)
                        {
                            Applications = null;
                        }
                    }
    				OnPropertyChanging("ApplicationId");
                    _applicationId = value;
                    OnPropertyChanged("ApplicationId");
                }
            }
        }
        private System.Guid _applicationId;
    
        [DataMember]
        public string RoleName
        {
            get { return _roleName; }
            set
            {
                if (_roleName != value)
                {
    				OnPropertyChanging("RoleName");
                    _roleName = value;
                    OnPropertyChanged("RoleName");
                }
            }
        }
        private string _roleName;
    
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

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Applications Applications
        {
            get { return _applications; }
            set
            {
                if (!ReferenceEquals(_applications, value))
                {
                    var previousValue = _applications;
    				OnNavigationPropertyChanging("Applications");
                    _applications = value;
                    FixupApplications(previousValue);
                    OnNavigationPropertyChanged("Applications");
                }
            }
        }
        private Applications _applications;
    
        [DataMember]
        public TrackableCollection<Users> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new TrackableCollection<Users>();
                    _users.CollectionChanged += FixupUsers;
                }
                return _users;
            }
            set
            {
                if (!ReferenceEquals(_users, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("Users");
                    if (_users != null)
                    {
                        _users.CollectionChanged -= FixupUsers;
                    }
                    _users = value;
                    if (_users != null)
                    {
                        _users.CollectionChanged += FixupUsers;
                    }
                    OnNavigationPropertyChanged("Users");
                }
            }
        }
        private TrackableCollection<Users> _users;

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
    
    	public override bool Equals(System.Object obj)
    	{
    		// If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
    
            // If parameter cannot be cast to Point return false.
            Roles p = obj as Roles;
            if ((System.Object)p == null)
            {
                return false;
            }
    
    			if (this.RoleId != p.RoleId)
    				return false;
    			if (this.ApplicationId != p.ApplicationId)
    				return false;
    			if (this.RoleName != p.RoleName)
    				return false;
    			if (this.Description != p.Description)
    				return false;
    
    		return true;
    	}
    
    	public override int GetHashCode()
    	{
    		int hashCode = 1;
    			
    		hashCode ^= this.RoleId.GetHashCode();
    		if (this.RoleId != null)
    		{
    			hashCode ^= this.RoleId.GetHashCode();
    		}
    			
    		hashCode ^= this.ApplicationId.GetHashCode();
    		if (this.ApplicationId != null)
    		{
    			hashCode ^= this.ApplicationId.GetHashCode();
    		}
    			
    		hashCode ^= this.RoleName.GetHashCode();
    		if (this.RoleName != null)
    		{
    			hashCode ^= this.RoleName.GetHashCode();
    		}
     
    		if (this.Description != null)
    		{
    			hashCode ^= this.Description.GetHashCode();
    		}
    		return hashCode;
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
            Applications = null;
            Users.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupApplications(Applications previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Roles.Contains(this))
            {
                previousValue.Roles.Remove(this);
            }
    
            if (Applications != null)
            {
                Applications.Roles.Add(this);
    
                ApplicationId = Applications.ApplicationId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Applications")
                    && (ChangeTracker.OriginalValues["Applications"] == Applications))
                {
                    ChangeTracker.OriginalValues.Remove("Applications");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Applications", previousValue);
                }
                if (Applications != null && !Applications.ChangeTracker.ChangeTrackingEnabled)
                {
                    Applications.StartTracking();
                }
            }
        }
    
        private void FixupUsers(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Users item in e.NewItems)
                {
                    item.Roles.Add(this);
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Users", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Users item in e.OldItems)
                {
                    if (item.Roles.Contains(this))
                    {
                        item.Roles.Remove(this);
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Users", item);
                    }
                }
            }
        }

        #endregion

    }
}