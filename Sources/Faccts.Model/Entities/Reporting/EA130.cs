using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class EA130: PermanentOrder, IEA130
    {
        private bool _isFinancialAbuseInvolved;
        private IFirearms _firearms;
        private bool _isNoGuns;
        private string _otherOrderDetail;
        private bool _isOtherOrdersAttached;
        private bool _isOtherOrdersEnabled;
        private INoServiceFee _noServiceFeeSection;
        private ICAPROSEntry _caprosEntrySection;
        private string _moveoutAddress;
        private bool _isMoveoutEnabled;
        private IEAStayAwayOrders _eaStayAwayOrders;
        private bool _eaStayAwayOrdersEnabled;
        private IEAConductChoice _eaConductChoice;
        private bool _isEAConductChoiceEnabled;

        public EA130()
        {
            EAConductChoice = new EAConductChoice();
            EAStayAwayOrders = new EAStayAwayOrders();
            CAPROSEntrySection = new CAPROSEntry();
            NoServiceFeeSection = new NoServiceFee();
            Firearms = new Firearms();
        }

        public EA130(IEA130 order) : base(order)
        {
            IsEAConductChoiceEnabled = order.IsEAConductChoiceEnabled;
            EAConductChoice = new EAConductChoice(order.EAConductChoice);
            EAStayAwayOrdersEnabled = order.EAStayAwayOrdersEnabled;
            EAStayAwayOrders = new EAStayAwayOrders(order.EAStayAwayOrders);
            IsMoveoutEnabled = order.IsMoveoutEnabled;
            MoveoutAddress = order.MoveoutAddress;
            CAPROSEntrySection = new CAPROSEntry(order.CAPROSEntrySection);
            NoServiceFeeSection = new NoServiceFee(order.NoServiceFeeSection);
            IsOtherOrdersEnabled = order.IsOtherOrdersEnabled;
            IsOtherOrdersAttached = order.IsOtherOrdersAttached;
            OtherOrderDetail = order.OtherOrderDetail;
            IsNoGuns = order.IsNoGuns;
            Firearms = new Firearms(order.Firearms);
            IsFinancialAbuseInvolved = order.IsFinancialAbuseInvolved;
        }

        public bool IsEAConductChoiceEnabled
        {
            get { return _isEAConductChoiceEnabled; }
            set
            {
                if (value.Equals(_isEAConductChoiceEnabled)) return;
                _isEAConductChoiceEnabled = value;
                OnPropertyChanged();
            }
        }

        public IEAConductChoice EAConductChoice
        {
            get { return _eaConductChoice; }
            set
            {
                if (Equals(value, _eaConductChoice)) return;
                _eaConductChoice = value;
                OnPropertyChanged();
            }
        }

        public bool EAStayAwayOrdersEnabled
        {
            get { return _eaStayAwayOrdersEnabled; }
            set
            {
                if (value.Equals(_eaStayAwayOrdersEnabled)) return;
                _eaStayAwayOrdersEnabled = value;
                OnPropertyChanged();
            }
        }

        public IEAStayAwayOrders EAStayAwayOrders
        {
            get { return _eaStayAwayOrders; }
            set
            {
                if (Equals(value, _eaStayAwayOrders)) return;
                _eaStayAwayOrders = value;
                OnPropertyChanged();
            }
        }

        public bool IsMoveoutEnabled
        {
            get { return _isMoveoutEnabled; }
            set
            {
                if (value.Equals(_isMoveoutEnabled)) return;
                _isMoveoutEnabled = value;
                OnPropertyChanged();
            }
        }

        public string MoveoutAddress
        {
            get { return _moveoutAddress; }
            set
            {
                if (value == _moveoutAddress) return;
                _moveoutAddress = value;
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

        public bool IsOtherOrdersEnabled
        {
            get { return _isOtherOrdersEnabled; }
            set
            {
                if (value.Equals(_isOtherOrdersEnabled)) return;
                _isOtherOrdersEnabled = value;
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

        public IFirearms Firearms
        {
            get { return _firearms; }
            set
            {
                if (Equals(value, _firearms)) return;
                _firearms = value;
                OnPropertyChanged();
            }
        }

        public bool IsFinancialAbuseInvolved
        {
            get { return _isFinancialAbuseInvolved; }
            set
            {
                if (value.Equals(_isFinancialAbuseInvolved)) return;
                _isFinancialAbuseInvolved = value;
                OnPropertyChanged();
            }
        }
    }
}