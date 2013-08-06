using System;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class PermanentOrder : OrderBase, IPermanentOrder
    {
        private bool _isExpire;
        private DateTime? _ordersEndDate;
        private DateTime? _ordersEndTime;

        public PermanentOrder()
        {
        }

        public PermanentOrder(IPermanentOrder order)
        {
            IsExpire = order.IsExpire;
            OrdersEndDate = order.OrdersEndDate;
            OrdersEndTime = order.OrdersEndTime;
        }

        public bool IsExpire
        {
            get { return _isExpire; }
            set
            {
                if (value.Equals(_isExpire)) return;
                _isExpire = value;
                OnPropertyChanged();
            }
        }

        public bool IsNoExpire
        {
            get { return !IsExpire; }
            set
            {
                if (value.Equals(IsNoExpire)) return;
                IsExpire = !value;
                OnPropertyChanged();
            }
        }

        public DateTime? OrdersEndDate
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