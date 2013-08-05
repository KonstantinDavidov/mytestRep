using Faccts.Model.Entities.Reporting;

namespace Faccts.Model.Entities
{
    public partial class CourtOrders
    {
        private OrderBase _innerOrder;

        public OrderBase InnerOrder
        {
            get { return _innerOrder; }
            set
            {
                if (_innerOrder == value)
                    return;
                OnPropertyChanging("InnerOrder");
                _innerOrder = value;
                OnPropertyChanged("InnerOrder", false);
            }
        }
    }
}