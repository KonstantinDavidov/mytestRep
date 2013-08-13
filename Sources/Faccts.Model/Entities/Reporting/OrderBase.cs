using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;

namespace Faccts.Model.Entities.Reporting
{
    public class OrderBase : ReactiveBase
    {
        private CourtOrdersTypes _ordersType;
        private CourtOrders _modelOrder;

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

        public CourtOrders ModelOrder
        {
            get { return _modelOrder; }
            set
            {
                _modelOrder = value;
                PopulateModelOrderData();
            }
        }

        protected virtual void PopulateModelOrderData()
        {
        }
    }
}