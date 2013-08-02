using FACCTS.Server.Model;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class CH110 : TemporaryOrder, ICH110
    {
        private ICAPROSEntry _caprosEntrySection;
        private ICHConductChoice _conductSection;
        private OrderRestrictionState _conductSectionState;
        private bool _isNoGuns;
        private bool _isOtherOrdersAttached;
        private INoServiceFee _noServiceFeeSection;
        private string _otherOrderDetail;
        private ICHStayAwayOrders _stayAwayOrders;
        private OrderRestrictionState _stayAwayOrdersState;

        public CH110()
        {
            ConductSection = new CHConductChoice();
            StayAwayOrders = new CHStayAwayOrders();
            CAPROSEntrySection = new CAPROSEntry();
            NoServiceFeeSection = new NoServiceFee();
        }

        public CH110(ICH110 order)
            : base(order)
        {
            ConductSectionState = order.ConductSectionState;
            ConductSection = new CHConductChoice(order.ConductSection);
            StayAwayOrdersState = order.StayAwayOrdersState;
            StayAwayOrders = new CHStayAwayOrders(order.StayAwayOrders);
            IsNoGuns = order.IsNoGuns;
            CAPROSEntrySection = new CAPROSEntry(order.CAPROSEntrySection);
            NoServiceFeeSection = new NoServiceFee(order.NoServiceFeeSection);
            IsOtherOrdersAttached = order.IsOtherOrdersAttached;
            OtherOrderDetail = order.OtherOrderDetail;
        }

        public OrderRestrictionState ConductSectionState
        {
            get { return _conductSectionState; }
            set
            {
                if (value == _conductSectionState) return;
                _conductSectionState = value;
                OnPropertyChanged();
            }
        }

        public ICHConductChoice ConductSection
        {
            get { return _conductSection; }
            set
            {
                if (Equals(value, _conductSection)) return;
                _conductSection = value;
                OnPropertyChanged();
            }
        }

        public OrderRestrictionState StayAwayOrdersState
        {
            get { return _stayAwayOrdersState; }
            set
            {
                if (value == _stayAwayOrdersState) return;
                _stayAwayOrdersState = value;
                OnPropertyChanged();
            }
        }

        public ICHStayAwayOrders StayAwayOrders
        {
            get { return _stayAwayOrders; }
            set
            {
                if (Equals(value, _stayAwayOrders)) return;
                _stayAwayOrders = value;
                OnPropertyChanged();
            }
        }

        public bool IsNoGuns
        {
            get { return _isNoGuns; }
            set
            {
                if (value.Equals(_isNoGuns)) return;
                _isNoGuns = value;
                OnPropertyChanged();
            }
        }

        public ICAPROSEntry CAPROSEntrySection
        {
            get { return _caprosEntrySection; }
            set
            {
                if (Equals(value, _caprosEntrySection)) return;
                _caprosEntrySection = value;
                OnPropertyChanged();
            }
        }

        public INoServiceFee NoServiceFeeSection
        {
            get { return _noServiceFeeSection; }
            set
            {
                if (Equals(value, _noServiceFeeSection)) return;
                _noServiceFeeSection = value;
                OnPropertyChanged();
            }
        }

        public bool IsOtherOrdersAttached
        {
            get { return _isOtherOrdersAttached; }
            set
            {
                if (value.Equals(_isOtherOrdersAttached)) return;
                _isOtherOrdersAttached = value;
                OnPropertyChanged();
            }
        }

        public string OtherOrderDetail
        {
            get { return _otherOrderDetail; }
            set
            {
                if (value == _otherOrderDetail) return;
                _otherOrderDetail = value;
                OnPropertyChanged();
            }
        }
    }
}