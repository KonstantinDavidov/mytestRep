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
    public partial class AdfsIntegrationConfiguration: IObjectWithChangeTracker, INotifyPropertyChanged, INavigationPropertiesLoadable
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
        public bool UsernameAuthenticationEnabled
        {
            get { return _usernameAuthenticationEnabled; }
            set
            {
                if (_usernameAuthenticationEnabled != value)
                {
                    _usernameAuthenticationEnabled = value;
                    OnPropertyChanged("UsernameAuthenticationEnabled");
                }
            }
        }
        private bool _usernameAuthenticationEnabled;
    
        [DataMember]
        public bool SamlAuthenticationEnabled
        {
            get { return _samlAuthenticationEnabled; }
            set
            {
                if (_samlAuthenticationEnabled != value)
                {
                    _samlAuthenticationEnabled = value;
                    OnPropertyChanged("SamlAuthenticationEnabled");
                }
            }
        }
        private bool _samlAuthenticationEnabled;
    
        [DataMember]
        public bool JwtAuthenticationEnabled
        {
            get { return _jwtAuthenticationEnabled; }
            set
            {
                if (_jwtAuthenticationEnabled != value)
                {
                    _jwtAuthenticationEnabled = value;
                    OnPropertyChanged("JwtAuthenticationEnabled");
                }
            }
        }
        private bool _jwtAuthenticationEnabled;
    
        [DataMember]
        public bool PassThruAuthenticationToken
        {
            get { return _passThruAuthenticationToken; }
            set
            {
                if (_passThruAuthenticationToken != value)
                {
                    _passThruAuthenticationToken = value;
                    OnPropertyChanged("PassThruAuthenticationToken");
                }
            }
        }
        private bool _passThruAuthenticationToken;
    
        [DataMember]
        public int AuthenticationTokenLifetime
        {
            get { return _authenticationTokenLifetime; }
            set
            {
                if (_authenticationTokenLifetime != value)
                {
                    _authenticationTokenLifetime = value;
                    OnPropertyChanged("AuthenticationTokenLifetime");
                }
            }
        }
        private int _authenticationTokenLifetime;
    
        [DataMember]
        public string UserNameAuthenticationEndpoint
        {
            get { return _userNameAuthenticationEndpoint; }
            set
            {
                if (_userNameAuthenticationEndpoint != value)
                {
                    _userNameAuthenticationEndpoint = value;
                    OnPropertyChanged("UserNameAuthenticationEndpoint");
                }
            }
        }
        private string _userNameAuthenticationEndpoint;
    
        [DataMember]
        public string FederationEndpoint
        {
            get { return _federationEndpoint; }
            set
            {
                if (_federationEndpoint != value)
                {
                    _federationEndpoint = value;
                    OnPropertyChanged("FederationEndpoint");
                }
            }
        }
        private string _federationEndpoint;
    
        [DataMember]
        public string IssuerUri
        {
            get { return _issuerUri; }
            set
            {
                if (_issuerUri != value)
                {
                    _issuerUri = value;
                    OnPropertyChanged("IssuerUri");
                }
            }
        }
        private string _issuerUri;
    
        [DataMember]
        public string IssuerThumbprint
        {
            get { return _issuerThumbprint; }
            set
            {
                if (_issuerThumbprint != value)
                {
                    _issuerThumbprint = value;
                    OnPropertyChanged("IssuerThumbprint");
                }
            }
        }
        private string _issuerThumbprint;
    
        [DataMember]
        public string EncryptionCertificate
        {
            get { return _encryptionCertificate; }
            set
            {
                if (_encryptionCertificate != value)
                {
                    _encryptionCertificate = value;
                    OnPropertyChanged("EncryptionCertificate");
                }
            }
        }
        private string _encryptionCertificate;

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
            AdfsIntegrationConfiguration p = obj as AdfsIntegrationConfiguration;
            if ((System.Object)p == null)
            {
                return false;
            }
    
    			if (this.Id != p.Id)
    				return false;
    			if (this.Enabled != p.Enabled)
    				return false;
    			if (this.UsernameAuthenticationEnabled != p.UsernameAuthenticationEnabled)
    				return false;
    			if (this.SamlAuthenticationEnabled != p.SamlAuthenticationEnabled)
    				return false;
    			if (this.JwtAuthenticationEnabled != p.JwtAuthenticationEnabled)
    				return false;
    			if (this.PassThruAuthenticationToken != p.PassThruAuthenticationToken)
    				return false;
    			if (this.AuthenticationTokenLifetime != p.AuthenticationTokenLifetime)
    				return false;
    			if (this.UserNameAuthenticationEndpoint != p.UserNameAuthenticationEndpoint)
    				return false;
    			if (this.FederationEndpoint != p.FederationEndpoint)
    				return false;
    			if (this.IssuerUri != p.IssuerUri)
    				return false;
    			if (this.IssuerThumbprint != p.IssuerThumbprint)
    				return false;
    			if (this.EncryptionCertificate != p.EncryptionCertificate)
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
    			
    		hashCode ^= this.Enabled.GetHashCode();
    		if (this.Enabled != null)
    		{
    			hashCode ^= this.Enabled.GetHashCode();
    		}
    			
    		hashCode ^= this.UsernameAuthenticationEnabled.GetHashCode();
    		if (this.UsernameAuthenticationEnabled != null)
    		{
    			hashCode ^= this.UsernameAuthenticationEnabled.GetHashCode();
    		}
    			
    		hashCode ^= this.SamlAuthenticationEnabled.GetHashCode();
    		if (this.SamlAuthenticationEnabled != null)
    		{
    			hashCode ^= this.SamlAuthenticationEnabled.GetHashCode();
    		}
    			
    		hashCode ^= this.JwtAuthenticationEnabled.GetHashCode();
    		if (this.JwtAuthenticationEnabled != null)
    		{
    			hashCode ^= this.JwtAuthenticationEnabled.GetHashCode();
    		}
    			
    		hashCode ^= this.PassThruAuthenticationToken.GetHashCode();
    		if (this.PassThruAuthenticationToken != null)
    		{
    			hashCode ^= this.PassThruAuthenticationToken.GetHashCode();
    		}
    			
    		hashCode ^= this.AuthenticationTokenLifetime.GetHashCode();
    		if (this.AuthenticationTokenLifetime != null)
    		{
    			hashCode ^= this.AuthenticationTokenLifetime.GetHashCode();
    		}
     
    		if (this.UserNameAuthenticationEndpoint != null)
    		{
    			hashCode ^= this.UserNameAuthenticationEndpoint.GetHashCode();
    		}
     
    		if (this.FederationEndpoint != null)
    		{
    			hashCode ^= this.FederationEndpoint.GetHashCode();
    		}
     
    		if (this.IssuerUri != null)
    		{
    			hashCode ^= this.IssuerUri.GetHashCode();
    		}
     
    		if (this.IssuerThumbprint != null)
    		{
    			hashCode ^= this.IssuerThumbprint.GetHashCode();
    		}
     
    		if (this.EncryptionCertificate != null)
    		{
    			hashCode ^= this.EncryptionCertificate.GetHashCode();
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