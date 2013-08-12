using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;

namespace Faccts.Model.Entities.Reporting
{
    public class OrderBase : ReactiveBase
    {
        private CourtOrdersTypes _ordersType;

        public CourtOrdersTypes OrdersType
        {
            get { return _ordersType; }
            set
            {
                if (value == _ordersType) return;
                _ordersType = value;
                OnPropertyChanged();
            }
        }

        public CourtOrders ModelOrder { get; set; }
    }
}