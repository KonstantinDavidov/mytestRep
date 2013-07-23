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
    [KnownType(typeof(SAOTROSection))]
    public partial class SAOROSection : SAOEAROSection, IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
        #region Simple Properties
    
        [DataMember]
        public decimal Distance
        {
            get { return _distance; }
            set
            {
                if (_distance != value)
                {
    				OnPropertyChanging("Distance");
                    _distance = value;
                    OnPropertyChanged("Distance");
                }
            }
        }
        private decimal _distance;
    
        [DataMember]
        public bool FromChildSchool
        {
            get { return _fromChildSchool; }
            set
            {
                if (_fromChildSchool != value)
                {
    				OnPropertyChanging("FromChildSchool");
                    _fromChildSchool = value;
                    OnPropertyChanged("FromChildSchool");
                }
            }
        }
        private bool _fromChildSchool;
    
        [DataMember]
        public bool FromChildCare
        {
            get { return _fromChildCare; }
            set
            {
                if (_fromChildCare != value)
                {
    				OnPropertyChanging("FromChildCare");
                    _fromChildCare = value;
                    OnPropertyChanged("FromChildCare");
                }
            }
        }
        private bool _fromChildCare;

        #endregion

        #region ChangeTracking
    
        protected override void ClearNavigationProperties()
        {
            base.ClearNavigationProperties();
        }

        #endregion

    }
}