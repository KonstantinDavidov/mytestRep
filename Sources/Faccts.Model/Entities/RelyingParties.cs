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

namespace Faccts.Model.Entities
{
    [DataContract(IsReference = true)]
    public partial class RelyingParties: IObjectWithChangeTracker, INotifyPropertyChanged, INavigationPropertiesLoadable
    {
    
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
    
    	public override bool Equals(System.Object obj)
    	{
    		// If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
    
            // If parameter cannot be cast to Point return false.
            RelyingParties p = obj as RelyingParties;
            if ((System.Object)p == null)
            {
                return false;
            }
    
    			if (this.Id != p.Id)
    				return false;
    			if (this.Name != p.Name)
    				return false;
    			if (this.Enabled != p.Enabled)
    				return false;
    			if (this.Realm != p.Realm)
    				return false;
    			if (this.TokenLifeTime != p.TokenLifeTime)
    				return false;
    			if (this.ReplyTo != p.ReplyTo)
    				return false;
    			if (this.EncryptingCertificate != p.EncryptingCertificate)
    				return false;
    			if (this.SymmetricSigningKey != p.SymmetricSigningKey)
    				return false;
    			if (this.ExtraData1 != p.ExtraData1)
    				return false;
    			if (this.ExtraData2 != p.ExtraData2)
    				return false;
    			if (this.ExtraData3 != p.ExtraData3)
    				return false;
    
    		return true;
    	}
    
    	public override int GetHashCode()
    	{
    		int hashCode = 1;
    			
    		hashCode ^= this.Id.GetHashCode();
    		if (this.Id != null)
    		{
    			hashCode ^= this.Id.GetHashCode();
    		}
    			
    		hashCode ^= this.Name.GetHashCode();
    		if (this.Name != null)
    		{
    			hashCode ^= this.Name.GetHashCode();
    		}
    			
    		hashCode ^= this.Enabled.GetHashCode();
    		if (this.Enabled != null)
    		{
    			hashCode ^= this.Enabled.GetHashCode();
    		}
    			
    		hashCode ^= this.Realm.GetHashCode();
    		if (this.Realm != null)
    		{
    			hashCode ^= this.Realm.GetHashCode();
    		}
    			
    		hashCode ^= this.TokenLifeTime.GetHashCode();
    		if (this.TokenLifeTime != null)
    		{
    			hashCode ^= this.TokenLifeTime.GetHashCode();
    		}
     
    		if (this.ReplyTo != null)
    		{
    			hashCode ^= this.ReplyTo.GetHashCode();
    		}
     
    		if (this.EncryptingCertificate != null)
    		{
    			hashCode ^= this.EncryptingCertificate.GetHashCode();
    		}
     
    		if (this.SymmetricSigningKey != null)
    		{
    			hashCode ^= this.SymmetricSigningKey.GetHashCode();
    		}
     
    		if (this.ExtraData1 != null)
    		{
    			hashCode ^= this.ExtraData1.GetHashCode();
    		}
     
    		if (this.ExtraData2 != null)
    		{
    			hashCode ^= this.ExtraData2.GetHashCode();
    		}
     
    		if (this.ExtraData3 != null)
    		{
    			hashCode ^= this.ExtraData3.GetHashCode();
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
        }

        #endregion

    }
}
