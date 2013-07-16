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
    [KnownType(typeof(CourtParty))]
    [KnownType(typeof(Designation))]
    [KnownType(typeof(CourtCase))]
    public partial class Witnesses: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public Witnesses()
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
    				,this.ObservableForProperty(x => x.FirstName)
    				,this.ObservableForProperty(x => x.LastName)
    				,this.ObservableForProperty(x => x.Contact)
    				,this.ObservableForProperty(x => x.WitnessFor_Id)
    				,this.ObservableForProperty(x => x.Designation_Id)
    				,this.ObservableForProperty(x => x.EntityType)
    				,this.ObservableForProperty(x => x.CourtCase_Id)
    				,this.ObservableForProperty(x => x.CourtParty.IsDirty)
    				,this.ObservableForProperty(x => x.Designation.IsDirty)
    				,this.ObservableForProperty(x => x.CourtCase.IsDirty)
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
    
        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
    				OnPropertyChanging("FirstName");
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        private string _firstName;
    
        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
    				OnPropertyChanging("LastName");
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        private string _lastName;
    
        [DataMember]
        public string Contact
        {
            get { return _contact; }
            set
            {
                if (_contact != value)
                {
    				OnPropertyChanging("Contact");
                    _contact = value;
                    OnPropertyChanged("Contact");
                }
            }
        }
        private string _contact;
    
        [DataMember]
        public Nullable<long> WitnessFor_Id
        {
            get { return _witnessFor_Id; }
            set
            {
                if (_witnessFor_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("WitnessFor_Id", _witnessFor_Id);
                    if (!IsDeserializing)
                    {
                        if (CourtParty != null && CourtParty.Id != value)
                        {
                            CourtParty = null;
                        }
                    }
    				OnPropertyChanging("WitnessFor_Id");
                    _witnessFor_Id = value;
                    OnPropertyChanged("WitnessFor_Id");
                }
            }
        }
        private Nullable<long> _witnessFor_Id;
    
        [DataMember]
        public Nullable<long> Designation_Id
        {
            get { return _designation_Id; }
            set
            {
                if (_designation_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Designation_Id", _designation_Id);
                    if (!IsDeserializing)
                    {
                        if (Designation != null && Designation.Id != value)
                        {
                            Designation = null;
                        }
                    }
    				OnPropertyChanging("Designation_Id");
                    _designation_Id = value;
                    OnPropertyChanged("Designation_Id");
                }
            }
        }
        private Nullable<long> _designation_Id;
    
        [DataMember]
        public int EntityType
        {
            get { return _entityType; }
            set
            {
                if (_entityType != value)
                {
    				OnPropertyChanging("EntityType");
                    _entityType = value;
                    OnPropertyChanged("EntityType");
                }
            }
        }
        private int _entityType;
    
        [DataMember]
        public Nullable<long> CourtCase_Id
        {
            get { return _courtCase_Id; }
            set
            {
                if (_courtCase_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("CourtCase_Id", _courtCase_Id);
                    if (!IsDeserializing)
                    {
                        if (CourtCase != null && CourtCase.Id != value)
                        {
                            CourtCase = null;
                        }
                    }
    				OnPropertyChanging("CourtCase_Id");
                    _courtCase_Id = value;
                    OnPropertyChanged("CourtCase_Id");
                }
            }
        }
        private Nullable<long> _courtCase_Id;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public CourtParty CourtParty
        {
            get { return _courtParty; }
            set
            {
                if (!ReferenceEquals(_courtParty, value))
                {
                    var previousValue = _courtParty;
    				OnNavigationPropertyChanging("CourtParty");
                    _courtParty = value;
                    FixupCourtParty(previousValue);
                    OnNavigationPropertyChanged("CourtParty");
                }
            }
        }
        private CourtParty _courtParty;
    
        [DataMember]
        public Designation Designation
        {
            get { return _designation; }
            set
            {
                if (!ReferenceEquals(_designation, value))
                {
                    var previousValue = _designation;
    				OnNavigationPropertyChanging("Designation");
                    _designation = value;
                    FixupDesignation(previousValue);
                    OnNavigationPropertyChanged("Designation");
                }
            }
        }
        private Designation _designation;
    
        [DataMember]
        public CourtCase CourtCase
        {
            get { return _courtCase; }
            set
            {
                if (!ReferenceEquals(_courtCase, value))
                {
                    var previousValue = _courtCase;
    				OnNavigationPropertyChanging("CourtCase");
                    _courtCase = value;
                    FixupCourtCase(previousValue);
                    OnNavigationPropertyChanged("CourtCase");
                }
            }
        }
        private CourtCase _courtCase;

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
    
        // This entity type is the dependent end in at least one association that performs cascade deletes.
        // This event handler will process notifications that occur when the principal end is deleted.
        internal void HandleCascadeDelete(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                this.MarkAsDeleted();
            }
        }
    
        protected virtual void ClearNavigationProperties()
        {
            CourtParty = null;
            Designation = null;
            CourtCase = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCourtParty(CourtParty previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Witnesses.Contains(this))
            {
                previousValue.Witnesses.Remove(this);
            }
    
            if (CourtParty != null)
            {
                CourtParty.Witnesses.Add(this);
    
                WitnessFor_Id = CourtParty.Id;
            }
            else if (!skipKeys)
            {
                WitnessFor_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CourtParty")
                    && (ChangeTracker.OriginalValues["CourtParty"] == CourtParty))
                {
                    ChangeTracker.OriginalValues.Remove("CourtParty");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CourtParty", previousValue);
                }
                if (CourtParty != null && !CourtParty.ChangeTracker.ChangeTrackingEnabled)
                {
                    CourtParty.StartTracking();
                }
            }
        }
    
        private void FixupDesignation(Designation previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Witnesses.Contains(this))
            {
                previousValue.Witnesses.Remove(this);
            }
    
            if (Designation != null)
            {
                Designation.Witnesses.Add(this);
    
                Designation_Id = Designation.Id;
            }
            else if (!skipKeys)
            {
                Designation_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Designation")
                    && (ChangeTracker.OriginalValues["Designation"] == Designation))
                {
                    ChangeTracker.OriginalValues.Remove("Designation");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Designation", previousValue);
                }
                if (Designation != null && !Designation.ChangeTracker.ChangeTrackingEnabled)
                {
                    Designation.StartTracking();
                }
            }
        }
    
        private void FixupCourtCase(CourtCase previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Witnesses.Contains(this))
            {
                previousValue.Witnesses.Remove(this);
            }
    
            if (CourtCase != null)
            {
                CourtCase.Witnesses.Add(this);
    
                CourtCase_Id = CourtCase.Id;
            }
            else if (!skipKeys)
            {
                CourtCase_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CourtCase")
                    && (ChangeTracker.OriginalValues["CourtCase"] == CourtCase))
                {
                    ChangeTracker.OriginalValues.Remove("CourtCase");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CourtCase", previousValue);
                }
                if (CourtCase != null && !CourtCase.ChangeTracker.ChangeTrackingEnabled)
                {
                    CourtCase.StartTracking();
                }
            }
        }

        #endregion

    }
}
