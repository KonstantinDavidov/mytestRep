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
    public partial class IdentityProvider: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public IdentityProvider()
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
        public int ID
        {
            get { return _iD; }
            set
            {
                if (_iD != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
    				OnPropertyChanging("ID");
                    _iD = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        private int _iD;
    
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
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
    				OnPropertyChanging("DisplayName");
                    _displayName = value;
                    OnPropertyChanged("DisplayName");
                }
            }
        }
        private string _displayName;
    
        [DataMember]
        public int Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
    				OnPropertyChanging("Type");
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        private int _type;
    
        [DataMember]
        public bool ShowInHrdSelection
        {
            get { return _showInHrdSelection; }
            set
            {
                if (_showInHrdSelection != value)
                {
    				OnPropertyChanging("ShowInHrdSelection");
                    _showInHrdSelection = value;
                    OnPropertyChanged("ShowInHrdSelection");
                }
            }
        }
        private bool _showInHrdSelection;
    
        [DataMember]
        public string WSFederationEndpoint
        {
            get { return _wSFederationEndpoint; }
            set
            {
                if (_wSFederationEndpoint != value)
                {
    				OnPropertyChanging("WSFederationEndpoint");
                    _wSFederationEndpoint = value;
                    OnPropertyChanged("WSFederationEndpoint");
                }
            }
        }
        private string _wSFederationEndpoint;
    
        [DataMember]
        public string IssuerThumbprint
        {
            get { return _issuerThumbprint; }
            set
            {
                if (_issuerThumbprint != value)
                {
    				OnPropertyChanging("IssuerThumbprint");
                    _issuerThumbprint = value;
                    OnPropertyChanged("IssuerThumbprint");
                }
            }
        }
        private string _issuerThumbprint;
    
        [DataMember]
        public string ClientID
        {
            get { return _clientID; }
            set
            {
                if (_clientID != value)
                {
    				OnPropertyChanging("ClientID");
                    _clientID = value;
                    OnPropertyChanged("ClientID");
                }
            }
        }
        private string _clientID;
    
        [DataMember]
        public string ClientSecret
        {
            get { return _clientSecret; }
            set
            {
                if (_clientSecret != value)
                {
    				OnPropertyChanging("ClientSecret");
                    _clientSecret = value;
                    OnPropertyChanged("ClientSecret");
                }
            }
        }
        private string _clientSecret;
    
        [DataMember]
        public Nullable<int> OAuth2ProviderType
        {
            get { return _oAuth2ProviderType; }
            set
            {
                if (_oAuth2ProviderType != value)
                {
    				OnPropertyChanging("OAuth2ProviderType");
                    _oAuth2ProviderType = value;
                    OnPropertyChanged("OAuth2ProviderType");
                }
            }
        }
        private Nullable<int> _oAuth2ProviderType;
    
        [DataMember]
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
    				OnPropertyChanging("Enabled");
                    _enabled = value;
                    OnPropertyChanged("Enabled");
                }
            }
        }
        private bool _enabled;

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
            IdentityProvider p = obj as IdentityProvider;
            if ((System.Object)p == null)
            {
                return false;
            }
    
    			if (this.ID != p.ID)
    				return false;
    			if (this.Name != p.Name)
    				return false;
    			if (this.DisplayName != p.DisplayName)
    				return false;
    			if (this.Type != p.Type)
    				return false;
    			if (this.ShowInHrdSelection != p.ShowInHrdSelection)
    				return false;
    			if (this.WSFederationEndpoint != p.WSFederationEndpoint)
    				return false;
    			if (this.IssuerThumbprint != p.IssuerThumbprint)
    				return false;
    			if (this.ClientID != p.ClientID)
    				return false;
    			if (this.ClientSecret != p.ClientSecret)
    				return false;
    			if (this.OAuth2ProviderType != p.OAuth2ProviderType)
    				return false;
    			if (this.Enabled != p.Enabled)
    				return false;
    
    		return true;
    	}
    
    	public override int GetHashCode()
    	{
    		int hashCode = 1;
    			
    		hashCode ^= this.ID.GetHashCode();
    		if (this.ID != null)
    		{
    			hashCode ^= this.ID.GetHashCode();
    		}
    			
    		hashCode ^= this.Name.GetHashCode();
    		if (this.Name != null)
    		{
    			hashCode ^= this.Name.GetHashCode();
    		}
    			
    		hashCode ^= this.DisplayName.GetHashCode();
    		if (this.DisplayName != null)
    		{
    			hashCode ^= this.DisplayName.GetHashCode();
    		}
    			
    		hashCode ^= this.Type.GetHashCode();
    		if (this.Type != null)
    		{
    			hashCode ^= this.Type.GetHashCode();
    		}
    			
    		hashCode ^= this.ShowInHrdSelection.GetHashCode();
    		if (this.ShowInHrdSelection != null)
    		{
    			hashCode ^= this.ShowInHrdSelection.GetHashCode();
    		}
     
    		if (this.WSFederationEndpoint != null)
    		{
    			hashCode ^= this.WSFederationEndpoint.GetHashCode();
    		}
     
    		if (this.IssuerThumbprint != null)
    		{
    			hashCode ^= this.IssuerThumbprint.GetHashCode();
    		}
     
    		if (this.ClientID != null)
    		{
    			hashCode ^= this.ClientID.GetHashCode();
    		}
     
    		if (this.ClientSecret != null)
    		{
    			hashCode ^= this.ClientSecret.GetHashCode();
    		}
     
    		if (this.OAuth2ProviderType != null)
    		{
    			hashCode ^= this.OAuth2ProviderType.GetHashCode();
    		}
    			
    		hashCode ^= this.Enabled.GetHashCode();
    		if (this.Enabled != null)
    		{
    			hashCode ^= this.Enabled.GetHashCode();
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
