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
    public partial class GlobalConfiguration: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public GlobalConfiguration()
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
    				OnPropertyChanging("Id");
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        private int _id;
    
        [DataMember]
        public string SiteName
        {
            get { return _siteName; }
            set
            {
                if (_siteName != value)
                {
    				OnPropertyChanging("SiteName");
                    _siteName = value;
                    OnPropertyChanged("SiteName");
                }
            }
        }
        private string _siteName;
    
        [DataMember]
        public string IssuerUri
        {
            get { return _issuerUri; }
            set
            {
                if (_issuerUri != value)
                {
    				OnPropertyChanging("IssuerUri");
                    _issuerUri = value;
                    OnPropertyChanged("IssuerUri");
                }
            }
        }
        private string _issuerUri;
    
        [DataMember]
        public string IssuerContactEmail
        {
            get { return _issuerContactEmail; }
            set
            {
                if (_issuerContactEmail != value)
                {
    				OnPropertyChanging("IssuerContactEmail");
                    _issuerContactEmail = value;
                    OnPropertyChanged("IssuerContactEmail");
                }
            }
        }
        private string _issuerContactEmail;
    
        [DataMember]
        public string DefaultWSTokenType
        {
            get { return _defaultWSTokenType; }
            set
            {
                if (_defaultWSTokenType != value)
                {
    				OnPropertyChanging("DefaultWSTokenType");
                    _defaultWSTokenType = value;
                    OnPropertyChanged("DefaultWSTokenType");
                }
            }
        }
        private string _defaultWSTokenType;
    
        [DataMember]
        public string DefaultHttpTokenType
        {
            get { return _defaultHttpTokenType; }
            set
            {
                if (_defaultHttpTokenType != value)
                {
    				OnPropertyChanging("DefaultHttpTokenType");
                    _defaultHttpTokenType = value;
                    OnPropertyChanged("DefaultHttpTokenType");
                }
            }
        }
        private string _defaultHttpTokenType;
    
        [DataMember]
        public int DefaultTokenLifetime
        {
            get { return _defaultTokenLifetime; }
            set
            {
                if (_defaultTokenLifetime != value)
                {
    				OnPropertyChanging("DefaultTokenLifetime");
                    _defaultTokenLifetime = value;
                    OnPropertyChanged("DefaultTokenLifetime");
                }
            }
        }
        private int _defaultTokenLifetime;
    
        [DataMember]
        public int MaximumTokenLifetime
        {
            get { return _maximumTokenLifetime; }
            set
            {
                if (_maximumTokenLifetime != value)
                {
    				OnPropertyChanging("MaximumTokenLifetime");
                    _maximumTokenLifetime = value;
                    OnPropertyChanged("MaximumTokenLifetime");
                }
            }
        }
        private int _maximumTokenLifetime;
    
        [DataMember]
        public int SsoCookieLifetime
        {
            get { return _ssoCookieLifetime; }
            set
            {
                if (_ssoCookieLifetime != value)
                {
    				OnPropertyChanging("SsoCookieLifetime");
                    _ssoCookieLifetime = value;
                    OnPropertyChanged("SsoCookieLifetime");
                }
            }
        }
        private int _ssoCookieLifetime;
    
        [DataMember]
        public bool RequireEncryption
        {
            get { return _requireEncryption; }
            set
            {
                if (_requireEncryption != value)
                {
    				OnPropertyChanging("RequireEncryption");
                    _requireEncryption = value;
                    OnPropertyChanged("RequireEncryption");
                }
            }
        }
        private bool _requireEncryption;
    
        [DataMember]
        public bool RequireRelyingPartyRegistration
        {
            get { return _requireRelyingPartyRegistration; }
            set
            {
                if (_requireRelyingPartyRegistration != value)
                {
    				OnPropertyChanging("RequireRelyingPartyRegistration");
                    _requireRelyingPartyRegistration = value;
                    OnPropertyChanged("RequireRelyingPartyRegistration");
                }
            }
        }
        private bool _requireRelyingPartyRegistration;
    
        [DataMember]
        public bool EnableClientCertificateAuthentication
        {
            get { return _enableClientCertificateAuthentication; }
            set
            {
                if (_enableClientCertificateAuthentication != value)
                {
    				OnPropertyChanging("EnableClientCertificateAuthentication");
                    _enableClientCertificateAuthentication = value;
                    OnPropertyChanged("EnableClientCertificateAuthentication");
                }
            }
        }
        private bool _enableClientCertificateAuthentication;
    
        [DataMember]
        public bool EnforceUsersGroupMembership
        {
            get { return _enforceUsersGroupMembership; }
            set
            {
                if (_enforceUsersGroupMembership != value)
                {
    				OnPropertyChanging("EnforceUsersGroupMembership");
                    _enforceUsersGroupMembership = value;
                    OnPropertyChanged("EnforceUsersGroupMembership");
                }
            }
        }
        private bool _enforceUsersGroupMembership;
    
        [DataMember]
        public int HttpPort
        {
            get { return _httpPort; }
            set
            {
                if (_httpPort != value)
                {
    				OnPropertyChanging("HttpPort");
                    _httpPort = value;
                    OnPropertyChanged("HttpPort");
                }
            }
        }
        private int _httpPort;
    
        [DataMember]
        public int HttpsPort
        {
            get { return _httpsPort; }
            set
            {
                if (_httpsPort != value)
                {
    				OnPropertyChanging("HttpsPort");
                    _httpsPort = value;
                    OnPropertyChanged("HttpsPort");
                }
            }
        }
        private int _httpsPort;

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
        }

        #endregion

    }
}
