using System;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class TemporaryOrder : OrderBase, ITemporaryOrder
    {
        private DateTime _ordersEndDate;
        private DateTime? _ordersEndTime;

        public TemporaryOrder(ITemporaryOrder temporaryOrder)
        {
            OrdersEndDate = temporaryOrder.OrdersEndDate;
            OrdersEndTime = temporaryOrder.OrdersEndTime;
        }

        protected TemporaryOrder()
        {
        }

        public DateTime OrdersEndDate
        {
            get { return _ordersEndDate; }
            set
            {
                if (value.Equals(_ordersEndDate)) return;
                _ordersEndDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime? OrdersEndTime
        {
            get { return _ordersEndTime; }
            set
            {
                if (value.Equals(_ordersEndTime)) return;
                _ordersEndTime = value;
                OnPropertyChanged();
            }
        }
    }
}