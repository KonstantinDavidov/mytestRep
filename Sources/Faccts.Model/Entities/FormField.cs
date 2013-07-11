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
    public partial class FormField: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public FormField()
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
    				this.ObservableForProperty(x => x.Id)
    				,this.ObservableForProperty(x => x.form_field_name)
    				,this.ObservableForProperty(x => x.form_name)
    				,this.ObservableForProperty(x => x.field_type)
    				,this.ObservableForProperty(x => x.screen_name)
    				,this.ObservableForProperty(x => x.form_field_id)
    				,this.ObservableForProperty(x => x.dupe)
    				,this.ObservableForProperty(x => x.dropdown_options)
    				,this.ObservableForProperty(x => x.bool_options)
    				,this.ObservableForProperty(x => x.screen_panel)
    				,this.ObservableForProperty(x => x.panel_section)
    				,this.ObservableForProperty(x => x.xml_export)
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
    				OnPropertyChanged("IsDirty");
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
        public string form_field_name
        {
            get { return _form_field_name; }
            set
            {
                if (_form_field_name != value)
                {
    				OnPropertyChanging("form_field_name");
                    _form_field_name = value;
                    OnPropertyChanged("form_field_name");
                }
            }
        }
        private string _form_field_name;
    
        [DataMember]
        public string form_name
        {
            get { return _form_name; }
            set
            {
                if (_form_name != value)
                {
    				OnPropertyChanging("form_name");
                    _form_name = value;
                    OnPropertyChanged("form_name");
                }
            }
        }
        private string _form_name;
    
        [DataMember]
        public string field_type
        {
            get { return _field_type; }
            set
            {
                if (_field_type != value)
                {
    				OnPropertyChanging("field_type");
                    _field_type = value;
                    OnPropertyChanged("field_type");
                }
            }
        }
        private string _field_type;
    
        [DataMember]
        public string screen_name
        {
            get { return _screen_name; }
            set
            {
                if (_screen_name != value)
                {
    				OnPropertyChanging("screen_name");
                    _screen_name = value;
                    OnPropertyChanged("screen_name");
                }
            }
        }
        private string _screen_name;
    
        [DataMember]
        public int form_field_id
        {
            get { return _form_field_id; }
            set
            {
                if (_form_field_id != value)
                {
    				OnPropertyChanging("form_field_id");
                    _form_field_id = value;
                    OnPropertyChanged("form_field_id");
                }
            }
        }
        private int _form_field_id;
    
        [DataMember]
        public string dupe
        {
            get { return _dupe; }
            set
            {
                if (_dupe != value)
                {
    				OnPropertyChanging("dupe");
                    _dupe = value;
                    OnPropertyChanged("dupe");
                }
            }
        }
        private string _dupe;
    
        [DataMember]
        public string dropdown_options
        {
            get { return _dropdown_options; }
            set
            {
                if (_dropdown_options != value)
                {
    				OnPropertyChanging("dropdown_options");
                    _dropdown_options = value;
                    OnPropertyChanged("dropdown_options");
                }
            }
        }
        private string _dropdown_options;
    
        [DataMember]
        public string bool_options
        {
            get { return _bool_options; }
            set
            {
                if (_bool_options != value)
                {
    				OnPropertyChanging("bool_options");
                    _bool_options = value;
                    OnPropertyChanged("bool_options");
                }
            }
        }
        private string _bool_options;
    
        [DataMember]
        public string screen_panel
        {
            get { return _screen_panel; }
            set
            {
                if (_screen_panel != value)
                {
    				OnPropertyChanging("screen_panel");
                    _screen_panel = value;
                    OnPropertyChanged("screen_panel");
                }
            }
        }
        private string _screen_panel;
    
        [DataMember]
        public string panel_section
        {
            get { return _panel_section; }
            set
            {
                if (_panel_section != value)
                {
    				OnPropertyChanging("panel_section");
                    _panel_section = value;
                    OnPropertyChanged("panel_section");
                }
            }
        }
        private string _panel_section;
    
        [DataMember]
        public string xml_export
        {
            get { return _xml_export; }
            set
            {
                if (_xml_export != value)
                {
    				OnPropertyChanging("xml_export");
                    _xml_export = value;
                    OnPropertyChanged("xml_export");
                }
            }
        }
        private string _xml_export;

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
