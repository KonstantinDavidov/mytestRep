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
using System.Runtime.Serialization;

namespace Faccts.Model.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CaseRecord))]
    [KnownType(typeof(Sex))]
    public partial class Children: IObjectWithChangeTracker, INotifyPropertyChanged
    {
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
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
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
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        private string _lastName;
    
        [DataMember]
        public bool RelationshipToProtected
        {
            get { return _relationshipToProtected; }
            set
            {
                if (_relationshipToProtected != value)
                {
                    _relationshipToProtected = value;
                    OnPropertyChanged("RelationshipToProtected");
                }
            }
        }
        private bool _relationshipToProtected;
    
        [DataMember]
        public System.DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (_dateOfBirth != value)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }
        private System.DateTime _dateOfBirth;
    
        [DataMember]
        public int Sex_Id
        {
            get { return _sex_Id; }
            set
            {
                if (_sex_Id != value)
                {
                    ChangeTracker.RecordOriginalValue("Sex_Id", _sex_Id);
                    if (!IsDeserializing)
                    {
                        if (Sex != null && Sex.Id != value)
                        {
                            Sex = null;
                        }
                    }
                    _sex_Id = value;
                    OnPropertyChanged("Sex_Id");
                }
            }
        }
        private int _sex_Id;
    
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
                    _caseRecord = value;
                    FixupCaseRecord(previousValue);
                    OnNavigationPropertyChanged("CaseRecord");
                }
            }
        }
        private CaseRecord _caseRecord;
    
        [DataMember]
        public Sex Sex
        {
            get { return _sex; }
            set
            {
                if (!ReferenceEquals(_sex, value))
                {
                    var previousValue = _sex;
                    _sex = value;
                    FixupSex(previousValue);
                    OnNavigationPropertyChanged("Sex");
                }
            }
        }
        private Sex _sex;

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
            Sex = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupCaseRecord(CaseRecord previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Children.Contains(this))
            {
                previousValue.Children.Remove(this);
            }
    
            if (CaseRecord != null)
            {
                CaseRecord.Children.Add(this);
    
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
    
        private void FixupSex(Sex previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Children.Contains(this))
            {
                previousValue.Children.Remove(this);
            }
    
            if (Sex != null)
            {
                Sex.Children.Add(this);
    
                Sex_Id = Sex.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Sex")
                    && (ChangeTracker.OriginalValues["Sex"] == Sex))
                {
                    ChangeTracker.OriginalValues.Remove("Sex");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Sex", previousValue);
                }
                if (Sex != null && !Sex.ChangeTracker.ChangeTrackingEnabled)
                {
                    Sex.StartTracking();
                }
            }
        }

        #endregion

    }
}