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
using System.Reflection;

namespace Faccts.Model.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(ThirdPartyData))]
    [KnownType(typeof(CourtCase))]
    [KnownType(typeof(CourtParty))]
    public partial class Attorneys : PersonBase, IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
        #region Simple Properties
    
        [DataMember]
        public string FirmName
        {
            get { return _firmName; }
            set
            {
                if (_firmName != value)
                {
    				OnPropertyChanging("FirmName");
                    _firmName = value;
                    OnPropertyChanged("FirmName");
                }
            }
        }
        private string _firmName;
    
        [DataMember]
        public string StateBarId
        {
            get { return _stateBarId; }
            set
            {
                if (_stateBarId != value)
                {
    				OnPropertyChanging("StateBarId");
                    _stateBarId = value;
                    OnPropertyChanged("StateBarId");
                }
            }
        }
        private string _stateBarId;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<ThirdPartyData> ThirdPartyData
        {
            get
            {
                if (_thirdPartyData == null)
                {
                    _thirdPartyData = new TrackableCollection<ThirdPartyData>();
                    _thirdPartyData.CollectionChanged += FixupThirdPartyData;
                }
                return _thirdPartyData;
            }
            set
            {
                if (!ReferenceEquals(_thirdPartyData, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("ThirdPartyData");
                    if (_thirdPartyData != null)
                    {
                        _thirdPartyData.CollectionChanged -= FixupThirdPartyData;
                    }
                    _thirdPartyData = value;
                    if (_thirdPartyData != null)
                    {
                        _thirdPartyData.CollectionChanged += FixupThirdPartyData;
                    }
                    OnNavigationPropertyChanged("ThirdPartyData");
                }
            }
        }
        private TrackableCollection<ThirdPartyData> _thirdPartyData;
    
        [DataMember]
        public TrackableCollection<CourtCase> CourtCases
        {
            get
            {
                if (_courtCases == null)
                {
                    _courtCases = new TrackableCollection<CourtCase>();
                    _courtCases.CollectionChanged += FixupCourtCases;
                }
                return _courtCases;
            }
            set
            {
                if (!ReferenceEquals(_courtCases, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("CourtCases");
                    if (_courtCases != null)
                    {
                        _courtCases.CollectionChanged -= FixupCourtCases;
                    }
                    _courtCases = value;
                    if (_courtCases != null)
                    {
                        _courtCases.CollectionChanged += FixupCourtCases;
                    }
                    OnNavigationPropertyChanged("CourtCases");
                }
            }
        }
        private TrackableCollection<CourtCase> _courtCases;
    
        [DataMember]
        public TrackableCollection<CourtParty> CourtParties
        {
            get
            {
                if (_courtParties == null)
                {
                    _courtParties = new TrackableCollection<CourtParty>();
                    _courtParties.CollectionChanged += FixupCourtParties;
                }
                return _courtParties;
            }
            set
            {
                if (!ReferenceEquals(_courtParties, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
    				OnNavigationPropertyChanging("CourtParties");
                    if (_courtParties != null)
                    {
                        _courtParties.CollectionChanged -= FixupCourtParties;
                    }
                    _courtParties = value;
                    if (_courtParties != null)
                    {
                        _courtParties.CollectionChanged += FixupCourtParties;
                    }
                    OnNavigationPropertyChanged("CourtParties");
                }
            }
        }
        private TrackableCollection<CourtParty> _courtParties;

        #endregion

        #region ChangeTracking
    
        protected override void ClearNavigationProperties()
        {
            base.ClearNavigationProperties();
            ThirdPartyData.Clear();
            CourtCases.Clear();
            CourtParties.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupThirdPartyData(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (ThirdPartyData item in e.NewItems)
                {
                    item.Attorney = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("ThirdPartyData", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (ThirdPartyData item in e.OldItems)
                {
                    if (ReferenceEquals(item.Attorney, this))
                    {
                        item.Attorney = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("ThirdPartyData", item);
                    }
                }
            }
        }
    
        private void FixupCourtCases(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtCase item in e.NewItems)
                {
                    item.AttorneyForChild = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtCases", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtCase item in e.OldItems)
                {
                    if (ReferenceEquals(item.AttorneyForChild, this))
                    {
                        item.AttorneyForChild = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtCases", item);
                    }
                }
            }
        }
    
        private void FixupCourtParties(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (CourtParty item in e.NewItems)
                {
                    item.Attorney = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("CourtParties", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (CourtParty item in e.OldItems)
                {
                    if (ReferenceEquals(item.Attorney, this))
                    {
                        item.Attorney = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("CourtParties", item);
                    }
                }
            }
        }

        #endregion

    }
}
