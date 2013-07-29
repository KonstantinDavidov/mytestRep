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
    public partial class IdentityProvider: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public IdentityProvider()
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
    				this.ObservableForProperty(x => x.Name)
    				,this.ObservableForProperty(x => x.DisplayName)
    				,this.ObservableForProperty(x => x.Type)
    				,this.ObservableForProperty(x => x.ShowInHrdSelection)
    				,this.ObservableForProperty(x => x.WSFederationEndpoint)
    				,this.ObservableForProperty(x => x.IssuerThumbprint)
    				,this.ObservableForProperty(x => x.ClientID)
    				,this.ObservableForProperty(x => x.ClientSecret)
    				,this.ObservableForProperty(x => x.OAuth2ProviderType)
    				,this.ObservableForProperty(x => x.Enabled)
    				,this.ObservableForProperty(x => x.Id)
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
    				OnPropertyChanged("IsDirty", false);
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

        #endregion

        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName, bool changeState = true)
        {
            if (changeState && ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
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
