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
    public partial class MoveOutTROSection : MoveOutROSection, IObjectWithChangeTracker, IReactiveNotifyPropertyChanged, INavigationPropertiesLoadable
    {
        #region Simple Properties
    
        [DataMember]
        public FACCTS.Server.Model.OrderRestrictionState OrderState
        {
            get { return _orderState; }
            set
            {
                if (_orderState != value)
                {
    				OnPropertyChanging("OrderState");
                    _orderState = value;
                    OnPropertyChanged("OrderState");
                }
            }
        }
        private FACCTS.Server.Model.OrderRestrictionState _orderState;

        #endregion

        #region ChangeTracking
    
        protected override void ClearNavigationProperties()
        {
            base.ClearNavigationProperties();
        }

        #endregion

    }
}
