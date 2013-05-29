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
    [KnownType(typeof(CourtLocations))]
    public partial class CourtCounty: IObjectWithChangeTracker, INotifyPropertyChanged
    {
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
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public string court_code
        {
            get { return _court_code; }
            set
            {
                if (_court_code != value)
                {
                    _court_code = value;
                    OnPropertyChanged("court_code");
                }
            }
        }
        private string _court_code;
    
        [DataMember]
        public string county
        {
            get { return _county; }
            set
            {
                if (_county != value)
                {
                    _county = value;
                    OnPropertyChanged("county");
                }
            }
        }
        private string _county;
    
        [DataMember]
        public string court_name
        {
            get { return _court_name; }
            set
            {
                if (_court_name != value)
                {
                    _court_name = value;
                    OnPropertyChanged("court_name");
                }
            }
        }
        private string _court_name;
    
        [DataMember]
        public string location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged("location");
                }
            }
        }
        private string _location;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<CourtLocations> CourtLocations
        {
            get
            {
                if (_courtLocations == null)
                {
                    _courtLocations = new TrackableCollection<CourtLocations>();
                    _courtLocations.CollectionChanged += FixupCourtLocations;
                }
                return _courtLocations;
            }
            set
            {
                if (!ReferenceEquals(_courtLocations, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_courtLocations != null)
                    {
                        _courtLocations.CollectionChanged -= FixupCourtLocations;
                    }
                    _courtLocations = value;
                    if (_courtLocations != null)
                    {
                        _courtLocations.CollectionChanged += FixupCourtLocations;
                    }
                    OnNavigationPropertyChanged("CourtLocations");
                }
            }
        }
        private TrackableCollection<CourtLocations> _courtLocations;

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
            CourtLocations.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupCourtLocations(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtLocations item in e.NewItems)
                {
                    item.CourtCounty = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtLocations", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtLocations item in e.OldItems)
                {
                    if (ReferenceEquals(item.CourtCounty, this))
                    {
                        item.CourtCounty = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtLocations", item);
                    }
                }
            }
        }

        #endregion

    }
}
