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
    [KnownType(typeof(User))]
    [KnownType(typeof(CourtCase))]
    public partial class CaseNotes: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public CaseNotes()
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
    				,this.ObservableForProperty(x => x.Status)
    				,this.ObservableForProperty(x => x.Text)
    				,this.ObservableForProperty(x => x.Author_Id)
    				,this.ObservableForProperty(x => x.CourtCase_Id)
    				,this.ObservableForProperty(x => x.CaseRecord_Id)
    				,this.ObservableForProperty(x => x.CourtCase_Id1)
    				,this.ObservableForProperty(x => x.User.IsDirty)
    				,this.ObservableForProperty(x => x.CourtCase.IsDirty)
    				,this.ObservableForProperty(x => x.CourtCase1.IsDirty)
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
        public int Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
    				OnPropertyChanging("Status");
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        private int _status;
    
        [DataMember]
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
    				OnPropertyChanging("Text");
                    _text = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        private string _text;
    
        [DataMember]
        public Nullable<long> Author_Id
        {
            get { return _author_Id; }
            set
            {
                if (_author_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Author_Id", _author_Id);
                    if (!IsDeserializing)
                    {
                        if (User != null && User.Id != value)
                        {
                            User = null;
                        }
                    }
    				OnPropertyChanging("Author_Id");
                    _author_Id = value;
                    OnPropertyChanged("Author_Id");
                }
            }
        }
        private Nullable<long> _author_Id;
    
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
    
        [DataMember]
        public Nullable<long> CaseRecord_Id
        {
            get { return _caseRecord_Id; }
            set
            {
                if (_caseRecord_Id != value)
                {
    				OnPropertyChanging("CaseRecord_Id");
                    _caseRecord_Id = value;
                    OnPropertyChanged("CaseRecord_Id");
                }
            }
        }
        private Nullable<long> _caseRecord_Id;
    
        [DataMember]
        public Nullable<long> CourtCase_Id1
        {
            get { return _courtCase_Id1; }
            set
            {
                if (_courtCase_Id1 != value)
                {
                    ChangeTracker.RecordOriginalValue("CourtCase_Id1", _courtCase_Id1);
                    if (!IsDeserializing)
                    {
                        if (CourtCase1 != null && CourtCase1.Id != value)
                        {
                            CourtCase1 = null;
                        }
                    }
    				OnPropertyChanging("CourtCase_Id1");
                    _courtCase_Id1 = value;
                    OnPropertyChanged("CourtCase_Id1");
                }
            }
        }
        private Nullable<long> _courtCase_Id1;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public User User
        {
            get { return _user; }
            set
            {
                if (!ReferenceEquals(_user, value))
                {
                    var previousValue = _user;
    				OnNavigationPropertyChanging("User");
                    _user = value;
                    FixupUser(previousValue);
                    OnNavigationPropertyChanged("User");
                }
            }
        }
        private User _user;
    
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
    
        [DataMember]
        public CourtCase CourtCase1
        {
            get { return _courtCase1; }
            set
            {
                if (!ReferenceEquals(_courtCase1, value))
                {
                    var previousValue = _courtCase1;
    				OnNavigationPropertyChanging("CourtCase1");
                    _courtCase1 = value;
                    FixupCourtCase1(previousValue);
                    OnNavigationPropertyChanged("CourtCase1");
                }
            }
        }
        private CourtCase _courtCase1;

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
            User = null;
            CourtCase = null;
            CourtCase1 = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupUser(User previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CaseNotes.Contains(this))
            {
                previousValue.CaseNotes.Remove(this);
            }
    
            if (User != null)
            {
                User.CaseNotes.Add(this);
    
                Author_Id = User.Id;
            }
            else if (!skipKeys)
            {
                Author_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("User")
                    && (ChangeTracker.OriginalValues["User"] == User))
                {
                    ChangeTracker.OriginalValues.Remove("User");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("User", previousValue);
                }
                if (User != null && !User.ChangeTracker.ChangeTrackingEnabled)
                {
                    User.StartTracking();
                }
            }
        }
    
        private void FixupCourtCase(CourtCase previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CaseNotes.Contains(this))
            {
                previousValue.CaseNotes.Remove(this);
            }
    
            if (CourtCase != null)
            {
                CourtCase.CaseNotes.Add(this);
    
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
    
        private void FixupCourtCase1(CourtCase previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CaseNotes1.Contains(this))
            {
                previousValue.CaseNotes1.Remove(this);
            }
    
            if (CourtCase1 != null)
            {
                CourtCase1.CaseNotes1.Add(this);
    
                CourtCase_Id1 = CourtCase1.Id;
            }
            else if (!skipKeys)
            {
                CourtCase_Id1 = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CourtCase1")
                    && (ChangeTracker.OriginalValues["CourtCase1"] == CourtCase1))
                {
                    ChangeTracker.OriginalValues.Remove("CourtCase1");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CourtCase1", previousValue);
                }
                if (CourtCase1 != null && !CourtCase1.ChangeTracker.ChangeTrackingEnabled)
                {
                    CourtCase1.StartTracking();
                }
            }
        }

        #endregion

    }
}
