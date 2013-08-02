using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class OtherOrders : ReactiveBase, IOtherOrders
    {
        private bool _isEnabled;
        private string _otherOrdersDescription;

        public OtherOrders(IOtherOrders orders)
        {
            IsEnabled = orders.IsEnabled;
            OtherOrdersDescription = orders.OtherOrdersDescription;
        }

        public OtherOrders()
        {
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value.Equals(_isEnabled)) return;
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public string OtherOrdersDescription
        {
            get { return _otherOrdersDescription; }
            set
            {
                if (value == _otherOrdersDescription) return;
                _otherOrdersDescription = value;
                OnPropertyChanged();
            }
        }
    }
}