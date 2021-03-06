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
    [KnownType(typeof(CourtCaseHeading))]
    public partial class CourtCaseHistoryHeading : CourtCaseHeading, IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
        #region Simple Properties
    
        [DataMember]
        public long CourtCaseHeadingCourtCaseId
        {
            get { return _courtCaseHeadingCourtCaseId; }
            set
            {
                if (_courtCaseHeadingCourtCaseId != value)
                {
                    ChangeTracker.RecordOriginalValue("CourtCaseHeadingCourtCaseId", _courtCaseHeadingCourtCaseId);
                    if (!IsDeserializing)
                    {
                        if (ParentCourtCaseHeading != null && ParentCourtCaseHeading.CourtCaseId != value)
                        {
                            ParentCourtCaseHeading = null;
                        }
                    }
    				OnPropertyChanging("CourtCaseHeadingCourtCaseId");
                    _courtCaseHeadingCourtCaseId = value;
                    OnPropertyChanged("CourtCaseHeadingCourtCaseId");
                }
            }
        }
        private long _courtCaseHeadingCourtCaseId;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public CourtCaseHeading ParentCourtCaseHeading
        {
            get { return _parentCourtCaseHeading; }
            set
            {
                if (!ReferenceEquals(_parentCourtCaseHeading, value))
                {
                    var previousValue = _parentCourtCaseHeading;
    				OnNavigationPropertyChanging("ParentCourtCaseHeading");
                    _parentCourtCaseHeading = value;
                    FixupParentCourtCaseHeading(previousValue);
                    OnNavigationPropertyChanged("ParentCourtCaseHeading");
                }
            }
        }
        private CourtCaseHeading _parentCourtCaseHeading;

        #endregion

        #region ChangeTracking
    
        protected override void ClearNavigationProperties()
        {
            base.ClearNavigationProperties();
            ParentCourtCaseHeading = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupParentCourtCaseHeading(CourtCaseHeading previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CourtCaseHistoryHeadings.Contains(this))
            {
                previousValue.CourtCaseHistoryHeadings.Remove(this);
            }
    
            if (ParentCourtCaseHeading != null)
            {
                ParentCourtCaseHeading.CourtCaseHistoryHeadings.Add(this);
    
                CourtCaseHeadingCourtCaseId = ParentCourtCaseHeading.CourtCaseId;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("ParentCourtCaseHeading")
                    && (ChangeTracker.OriginalValues["ParentCourtCaseHeading"] == ParentCourtCaseHeading))
                {
                    ChangeTracker.OriginalValues.Remove("ParentCourtCaseHeading");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("ParentCourtCaseHeading", previousValue);
                }
                if (ParentCourtCaseHeading != null && !ParentCourtCaseHeading.ChangeTracker.ChangeTrackingEnabled)
                {
                    ParentCourtCaseHeading.StartTracking();
                }
            }
        }

        #endregion

    }
}
