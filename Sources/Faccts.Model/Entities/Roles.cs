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
using System.Runtime.Serialization;

namespace Faccts.Model.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Applications))]
    [KnownType(typeof(Users))]
    public partial class Roles: IObjectWithChangeTracker, INotifyPropertyChanged
    {
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
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
