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
    [KnownType(typeof(AvailableCourtOrder))]
    [KnownType(typeof(CaseHistory))]
    [KnownType(typeof(CaseRecord))]
    public partial class CourtCaseOrders: IObjectWithChangeTracker, INotifyPropertyChanged, INavigationPropertiesLoadable
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
        public int AvailableCourtOrderId
        {
            get { return _availableCourtOrderId; }
            set
            {
                if (_availableCourtOrderId != value)
                {
                    ChangeTracker.RecordOriginalValue("AvailableCourtOrderId", _availableCourtOrderId);
                    if (!IsDeserializing)
                    {
                        if (AvailableCourtOrder != null && AvailableCourtOrder.Id != value)
                        {
                            AvailableCourtOrder = null;
                        }
                    }
                    _availableCourtOrderId = value;
                    OnPropertyChanged("AvailableCourtOrderId");
                }
            }
        }
        private int _availableCourtOrderId;
    
        [DataMember]
        public string XMLContent
        {
            get { return _xMLContent; }
            set
            {
                if (_xMLContent != value)
                {
                    _xMLContent = value;
                    OnPropertyChanged("XMLContent");
                }
            }
        }
        private string _xMLContent;
    
        [DataMember]
        public bool IsSigned
        {
            get { return _isSigned; }
            set
            {
                if (_isSigned != value)
                {
                    _isSigned = value;
                    OnPropertyChanged("IsSigned");
                }
            }
        }
        private bool _isSigned;
    
        [DataMember]
        public string ServerFileName
        {
            get { return _serverFileName; }
            set
            {
                if (_serverFileName != value)
                {
                    _serverFileName = value;
                    OnPropertyChanged("ServerFileName");
                }
            }
        }
        private string _serverFileName;
    
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
        public AvailableCourtOrder AvailableCourtOrder
        {
            get { return _availableCourtOrder; }
            set
            {
                if (!ReferenceEquals(_availableCourtOrder, value))
                {
                    var previousValue = _availableCourtOrder;
                    _availableCourtOrder = value;
                    FixupAvailableCourtOrder(previousValue);
                    OnNavigationPropertyChanged("AvailableCourtOrder");
                }
            }
        }
        private AvailableCourtOrder _availableCourtOrder;
    
        [DataMember]
        public TrackableCollection<CaseHistory> CaseHistory
        {
            get
            {
                if (_caseHistory == null)
                {
                    _caseHistory = new TrackableCollection<CaseHistory>();
                    _caseHistory.CollectionChanged += FixupCaseHistory;
                }
                return _caseHistory;
            }
            set
            {
                if (!ReferenceEquals(_caseHistory, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_caseHistory != null)
                    {
                        _caseHistory.CollectionChanged -= FixupCaseHistory;
                    }
                    _caseHistory = value;
                    if (_caseHistory != null)
                    {
                        _caseHistory.CollectionChanged += FixupCaseHistory;
                    }
                    OnNavigationPropertyChanged("CaseHistory");
                }
            }
        }
        private TrackableCollection<CaseHistory> _caseHistory;
    
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
            AvailableCourtOrder = null;
            CaseHistory.Clear();
            CaseRecord = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupAvailableCourtOrder(AvailableCourtOrder previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtCaseOrders.Contains(this))
            {
                previousValue.CourtCaseOrders.Remove(this);
            }
    
            if (AvailableCourtOrder != null)
            {
                AvailableCourtOrder.CourtCaseOrders.Add(this);
    
                AvailableCourtOrderId = AvailableCourtOrder.Id;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("AvailableCourtOrder")
                    && (ChangeTracker.OriginalValues["AvailableCourtOrder"] == AvailableCourtOrder))
                {
                    ChangeTracker.OriginalValues.Remove("AvailableCourtOrder");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("AvailableCourtOrder", previousValue);
                }
                if (AvailableCourtOrder != null && !AvailableCourtOrder.ChangeTracker.ChangeTrackingEnabled)
                {
                    AvailableCourtOrder.StartTracking();
                }
            }
        }
    
        private void FixupCaseRecord(CaseRecord previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtCaseOrders.Contains(this))
            {
                previousValue.CourtCaseOrders.Remove(this);
            }
    
            if (CaseRecord != null)
            {
                CaseRecord.CourtCaseOrders.Add(this);
    
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
    
        private void FixupCaseHistory(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CaseHistory item in e.NewItems)
                {
                    item.CourtCaseOrders = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CaseHistory", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CaseHistory item in e.OldItems)
                {
                    if (ReferenceEquals(item.CourtCaseOrders, this))
                    {
                        item.CourtCaseOrders = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CaseHistory", item);
                    }
                }
            }
        }

        #endregion

    }
}
