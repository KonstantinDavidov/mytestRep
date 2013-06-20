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
    [KnownType(typeof(CaseRecord))]
    [KnownType(typeof(CourtParty))]
    [KnownType(typeof(Designation))]
    public partial class Witnesses: IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
    		
    		private MakeObjectReactiveHelper _reactiveHelper;
    
    		public Witnesses()
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
        public int WitnessFor_Id
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
        private int _witnessFor_Id;
    
        [DataMember]
        public Nullable<int> Designation_Id
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
        private Nullable<int> _designation_Id;
    
        [DataMember]
        public Nullable<int> CaseRecord_Id
        {
            get { return _caseRecord_Id; }
            set
            {
                if (_caseRecord_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("CaseRecord_Id", _caseRecord_Id);
                    if (!IsDeserializing)
                    {
                        if (CaseRecord != null && CaseRecord.Id != value)
                        {
                            CaseRecord = null;
                        }
                    }
    				OnPropertyChanging("CaseRecord_Id");
                    _caseRecord_Id = value;
                    OnPropertyChanged("CaseRecord_Id");
                }
            }
        }
        private Nullable<int> _caseRecord_Id;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public CaseRecord CaseRecord
        {
            get { return _caseRecord; }
            set
            {
                if (!ReferenceEquals(_caseRecord, value))
                {
                    var previousValue = _caseRecord;
    				OnNavigationPropertyChanging("CaseRecord");
                    _caseRecord = value;
                    FixupCaseRecord(previousValue);
                    OnNavigationPropertyChanged("CaseRecord");
                }
            }
        }
        private CaseRecord _caseRecord;
    
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
            Witnesses p = obj as Witnesses;
            if ((System.Object)p == null)
            {
                return false;
            }
    
    			if (this.Id != p.Id)
    				return false;
    			if (this.FirstName != p.FirstName)
    				return false;
    			if (this.LastName != p.LastName)
    				return false;
    			if (this.Contact != p.Contact)
    				return false;
    			if (this.WitnessFor_Id != p.WitnessFor_Id)
    				return false;
    			if (this.Designation_Id != p.Designation_Id)
    				return false;
    			if (this.CaseRecord_Id != p.CaseRecord_Id)
    				return false;
    
    		return true;
    	}
    
    	public override int GetHashCode()
    	{
    		int hashCode = 1;
    			
    		hashCode ^= this.Id.GetHashCode();
    		if (this.FirstName != null)
    		{
    			hashCode ^= this.FirstName.GetHashCode();
    		}
    		if (this.LastName != null)
    		{
    			hashCode ^= this.LastName.GetHashCode();
    		}
    		if (this.Contact != null)
    		{
    			hashCode ^= this.Contact.GetHashCode();
    		}
    			
    		hashCode ^= this.WitnessFor_Id.GetHashCode();
    		if (this.Designation_Id != null)
    		{
    			hashCode ^= this.Designation_Id.GetHashCode();
    		}
    		if (this.CaseRecord_Id != null)
    		{
    			hashCode ^= this.CaseRecord_Id.GetHashCode();
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
            CaseRecord = null;
            CourtParty = null;
            Designation = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCaseRecord(CaseRecord previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Witnesses.Contains(this))
            {
                previousValue.Witnesses.Remove(this);
            }
    
            if (CaseRecord != null)
            {
                CaseRecord.Witnesses.Add(this);
    
                CaseRecord_Id = CaseRecord.Id;
            }
            else if (!skipKeys)
            {
                CaseRecord_Id = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("CaseRecord")
                    && (ChangeTracker.OriginalValues["CaseRecord"] == CaseRecord))
                {
                    ChangeTracker.OriginalValues.Remove("CaseRecord");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("CaseRecord", previousValue);
                }
                if (CaseRecord != null && !CaseRecord.ChangeTracker.ChangeTrackingEnabled)
                {
                    CaseRecord.StartTracking();
                }
            }
        }
    
        private void FixupCourtParty(CourtParty previousValue)
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

        #endregion

    }
}
