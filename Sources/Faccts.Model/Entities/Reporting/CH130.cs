using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class CH130 : PermanentOrder, ICH130
    {
        private ICAPROSEntry _caprosEntry;
        private ICHConductChoice _conductChoice;
        private bool _isConductChoiceEnabled;
        private bool _isNoGuns;
        private bool _isOtherOrdersAttached;
        private bool? _isPosGeneral;
        private bool _isStayAwayOrdersEnabled;
        private ILawersFeeAndCourtCosts _lawersFeeAndCourtCosts;
        private INoServiceFee _noServiceFee;
        private string _otherOrderDetail;
        private ICHStayAwayOrders _stayAwayOrders;

        public CH130()
        {
            ConductChoice = new CHConductChoice();
            StayAwayOrders = new CHStayAwayOrders();
            CAPROSEntry = new CAPROSEntry();
            NoServiceFee = new NoServiceFee();
            LawersFeeAndCourtCosts = new LawersFeeAndCourtCosts();
        }

        public CH130(ICH130 order)
            : base(order)
        {
            IsConductChoiceEnabled = order.IsConductChoiceEnabled;
            ConductChoice = new CHConductChoice(order.ConductChoice);
            IsStayAwayOrdersEnabled = order.IsStayAwayOrdersEnabled;
            StayAwayOrders = new CHStayAwayOrders(order.StayAwayOrders);
            IsNoGuns = order.IsNoGuns;
            CAPROSEntry = new CAPROSEntry(order.CAPROSEntry);
            NoServiceFee = new NoServiceFee(NoServiceFee);
            IsPOSGeneral = order.IsPOSGeneral;
            LawersFeeAndCourtCosts = new LawersFeeAndCourtCosts(order.LawersFeeAndCourtCosts);
            IsOtherOrdersAttached = order.IsOtherOrdersAttached;
            OtherOrderDetail = order.OtherOrderDetail;
        }

        public bool IsConductChoiceEnabled
        {
            get { return _isConductChoiceEnabled; }
            set
            {
                if (value.Equals(_isConductChoiceEnabled)) return;
                _isConductChoiceEnabled = value;
                OnPropertyChanged();
            }
        }

        public ICHConductChoice ConductChoice
        {
            get { return _conductChoice; }
            set
            {
                if (Equals(value, _conductChoice)) return;
                _conductChoice = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayOrdersEnabled
        {
            get { return _isStayAwayOrdersEnabled; }
            set
            {
                if (value.Equals(_isStayAwayOrdersEnabled)) return;
                _isStayAwayOrdersEnabled = value;
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

        public ICAPROSEntry CAPROSEntry
        {
            get { return _caprosEntry; }
            set
            {
                if (Equals(value, _caprosEntry)) return;
                _caprosEntry = value;
                OnPropertyChanged();
            }
        }

        public INoServiceFee NoServiceFee
        {
            get { return _noServiceFee; }
            set
            {
                if (Equals(value, _noServiceFee)) return;
                _noServiceFee = value;
                OnPropertyChanged();
            }
        }

        public bool? IsPOSGeneral
        {
            get { return _isPosGeneral; }
            set
            {
                if (value.Equals(_isPosGeneral)) return;
                _isPosGeneral = value;
                OnPropertyChanged();
            }
        }

        public ILawersFeeAndCourtCosts LawersFeeAndCourtCosts
        {
            get { return _lawersFeeAndCourtCosts; }
            set
            {
                if (Equals(value, _lawersFeeAndCourtCosts)) return;
                _lawersFeeAndCourtCosts = value;
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