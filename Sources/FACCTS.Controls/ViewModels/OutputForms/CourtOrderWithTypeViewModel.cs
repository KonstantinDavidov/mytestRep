using System.Collections.Generic;
using FACCTS.Server.Model;
using FACCTS.Server.Model.Enums;
using FACCTS.Services;

namespace FACCTS.Controls.ViewModels
{
    public class CourtOrderWithTypeViewModel: ViewModelBase
    {
        private List<EnumDescript<OrderRestrictionState>> _restrictionStates;
        public CourtOrdersTypes OrderType { get; set; }

        public List<EnumDescript<OrderRestrictionState>> RestrictionStates
        {
            get { return _restrictionStates ?? (_restrictionStates = EnumDescript<OrderRestrictionState>.GetList()); }
            set { _restrictionStates = value; }
        }
    }
}