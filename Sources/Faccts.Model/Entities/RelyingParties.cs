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
    public partial class RelyingParties: IObjectWithChangeTracker, INotifyPropertyChanged
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
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged("Enabled");
                }
            }
        }
        private bool _enabled;
    
        [DataMember]
        public string Realm
        {
            get { return _realm; }
            set
            {
                if (_realm != value)
                {
                    _realm = value;
                    OnPropertyChanged("Realm");
                }
            }
        }
        private string _realm;
    
        [DataMember]
        public int TokenLifeTime
        {
            get { return _tokenLifeTime; }
            set
            {
                if (_tokenLifeTime != value)
                {
                    _tokenLifeTime = value;
                    OnPropertyChanged("TokenLifeTime");
                }
            }
        }
        private int _tokenLifeTime;
    
        [DataMember]
        public string ReplyTo
        {
            get { return _replyTo; }
            set
            {
                if (_replyTo != value)
                {
                    _replyTo = value;
                    OnPropertyChanged("ReplyTo");
                }
            }
        }
        private string _replyTo;
    
        [DataMember]
        public string EncryptingCertificate
        {
            get { return _encryptingCertificate; }
            set
            {
                if (_encryptingCertificate != value)
                {
                    _encryptingCertificate = value;
                    OnPropertyChanged("EncryptingCertificate");
                }
            }
        }
        private string _encryptingCertificate;
    
        [DataMember]
        public string SymmetricSigningKey
        {
            get { return _symmetricSigningKey; }
            set
            {
                if (_symmetricSigningKey != value)
                {
                    _symmetricSigningKey = value;
                    OnPropertyChanged("SymmetricSigningKey");
                }
            }
        }
        private string _symmetricSigningKey;
    
        [DataMember]
        public string ExtraData1
        {
            get { return _extraData1; }
            set
            {
                if (_extraData1 != value)
                {
                    _extraData1 = value;
                    OnPropertyChanged("ExtraData1");
                }
            }
        }
        private string _extraData1;
    
        [DataMember]
        public string ExtraData2
        {
            get { return _extraData2; }
            set
            {
                if (_extraData2 != value)
                {
                    _extraData2 = value;
                    OnPropertyChanged("ExtraData2");
                }
            }
        }
        private string _extraData2;
    
        [DataMember]
        public string ExtraData3
        {
            get { return _extraData3; }
            set
            {
                if (_extraData3 != value)
                {
                    _extraData3 = value;
                    OnPropertyChanged("ExtraData3");
                }
            }
        }
        private string _extraData3;

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
        }

        #endregion

    }
}