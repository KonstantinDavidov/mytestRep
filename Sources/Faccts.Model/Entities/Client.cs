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
    public partial class Client: IObjectWithChangeTracker, INotifyPropertyChanged, INavigationPropertiesLoadable
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
    
        [DataMember]
        public string ClientId
        {
            get { return _clientId; }
            set
            {
                if (_clientId != value)
                {
                    _clientId = value;
                    OnPropertyChanged("ClientId");
                }
            }
        }
        private string _clientId;
    
        [DataMember]
        public string ClientSecret
        {
            get { return _clientSecret; }
            set
            {
                if (_clientSecret != value)
                {
                    _clientSecret = value;
                    OnPropertyChanged("ClientSecret");
                }
            }
        }
        private string _clientSecret;
    
        [DataMember]
        public string RedirectUri
        {
            get { return _redirectUri; }
            set
            {
                if (_redirectUri != value)
                {
                    _redirectUri = value;
                    OnPropertyChanged("RedirectUri");
                }
            }
        }
        private string _redirectUri;
    
        [DataMember]
        public bool AllowRefreshToken
        {
            get { return _allowRefreshToken; }
            set
            {
                if (_allowRefreshToken != value)
                {
                    _allowRefreshToken = value;
                    OnPropertyChanged("AllowRefreshToken");
                }
            }
        }
        private bool _allowRefreshToken;
    
        [DataMember]
        public bool AllowImplicitFlow
        {
            get { return _allowImplicitFlow; }
            set
            {
                if (_allowImplicitFlow != value)
                {
                    _allowImplicitFlow = value;
                    OnPropertyChanged("AllowImplicitFlow");
                }
            }
        }
        private bool _allowImplicitFlow;
    
        [DataMember]
        public bool AllowResourceOwnerFlow
        {
            get { return _allowResourceOwnerFlow; }
            set
            {
                if (_allowResourceOwnerFlow != value)
                {
                    _allowResourceOwnerFlow = value;
                    OnPropertyChanged("AllowResourceOwnerFlow");
                }
            }
        }
        private bool _allowResourceOwnerFlow;
    
        [DataMember]
        public bool AllowCodeFlow
        {
            get { return _allowCodeFlow; }
            set
            {
                if (_allowCodeFlow != value)
                {
                    _allowCodeFlow = value;
                    OnPropertyChanged("AllowCodeFlow");
                }
            }
        }
        private bool _allowCodeFlow;

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
