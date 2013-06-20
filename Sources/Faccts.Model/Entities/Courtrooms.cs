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
    [KnownType(typeof(CourtLocations))]
    public partial class Courtrooms: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public Courtrooms()
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
        public string RoomName
        {
            get { return _roomName; }
            set
            {
                if (_roomName != value)
                {
    				OnPropertyChanging("RoomName");
                    _roomName = value;
                    OnPropertyChanged("RoomName");
                }
            }
        }
        private string _roomName;
    
        [DataMember]
        public Nullable<int> CourtLocation_Id
        {
            get { return _courtLocation_Id; }
            set
            {
                if (_courtLocation_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("CourtLocation_Id", _courtLocation_Id);
                    if (!IsDeserializing)
                    {
                        if (CourtLocations != null && CourtLocations.Id != value)
                        {
                            CourtLocations = null;
                        }
                    }
    				OnPropertyChanging("CourtLocation_Id");
                    _courtLocation_Id = value;
                    OnPropertyChanged("CourtLocation_Id");
                }
            }
        }
        private Nullable<int> _courtLocation_Id;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public CourtLocations CourtLocations
        {
            get { return _courtLocations; }
            set
            {
                if (!ReferenceEquals(_courtLocations, value))
                {
                    var previousValue = _courtLocations;
    				OnNavigationPropertyChanging("CourtLocations");
                    _courtLocations = value;
                    FixupCourtLocations(previousValue);
                    OnNavigationPropertyChanged("CourtLocations");
                }
            }
        }
        private CourtLocations _courtLocations;

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
            Courtrooms p = obj as Courtrooms;
            if ((System.Object)p == null)
            {
                return false;
            }
    
    			if (this.Id != p.Id)
    				return false;
    			if (this.RoomName != p.RoomName)
    				return false;
    			if (this.CourtLocation_Id != p.CourtLocation_Id)
    				return false;
    
    		return true;
    	}
    
    	public override int GetHashCode()
    	{
    		int hashCode = 1;
    			
    		hashCode ^= this.Id.GetHashCode();
    		if (this.RoomName != null)
    		{
    			hashCode ^= this.RoomName.GetHashCode();
    		}
    		if (this.CourtLocation_Id != null)
    		{
    			hashCode ^= this.CourtLocation_Id.GetHashCode();
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
            CourtLocations = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCourtLocations(CourtLocations previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Courtrooms.Contains(this))
            {
                previousValue.Courtrooms.Remove(this);
            }
    
            if (CourtLocations != null)
            {
                CourtLocations.Courtrooms.Add(this);
    
                CourtLocation_Id = CourtLocations.Id;
            }
            else if (!skipKeys)
            {
                CourtLocation_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CourtLocations")
                    && (ChangeTracker.OriginalValues["CourtLocations"] == CourtLocations))
                {
                    ChangeTracker.OriginalValues.Remove("CourtLocations");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CourtLocations", previousValue);
                }
                if (CourtLocations != null && !CourtLocations.ChangeTracker.ChangeTrackingEnabled)
                {
                    CourtLocations.StartTracking();
                }
            }
        }

        #endregion

    }
}
