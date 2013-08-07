using System;
using FACCTS.Server.Model;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class EA110: TemporaryOrder, IEA110
    {
        private bool _isFinancialAbuseInvolved;
        private IFirearms _firearms;
        private bool _isFirearmsGranted;
        private string _otherOrderDetail;
        private bool _isOtherOrdersAttached;
        private INoServiceFee _noServiceFee;
        private ICAPROSEntry _caprosEntry;
        private string _moveoutAddress;
        private OrderRestrictionState _moveoutState;
        private IEAStayAwayOrders _eaStayAwayOrders;
        private OrderRestrictionState _eaStayAwayOrdersState;
        private IEAConductChoice _eaConductChoice;
        private OrderRestrictionState _eaConductChoiceState;

        public EA110()
        {
            EAConductChoice = new EAConductChoice();
            EAStayAwayOrders = new EAStayAwayOrders();
            CAPROSEntry = new CAPROSEntry();
            NoServiceFee = new NoServiceFee();
            Firearms = new Firearms();
        }

        protected EA110(IEA110 order):base(order)
        {
            EAConductChoiceState = order.EAConductChoiceState;
            EAConductChoice = new EAConductChoice(order.EAConductChoice);
            EAStayAwayOrdersState = order.EAStayAwayOrdersState;
            EAStayAwayOrders = new EAStayAwayOrders(order.EAStayAwayOrders);
            MoveoutState = order.MoveoutState;
            MoveoutAddress = order.MoveoutAddress;
            CAPROSEntry = new CAPROSEntry(order.CAPROSEntry);
            NoServiceFee = new NoServiceFee(order.NoServiceFee);
            IsOtherOrdersAttached = order.IsOtherOrdersAttached;
            OtherOrderDetail = order.OtherOrderDetail;
            IsFirearmsGranted = order.IsFirearmsGranted;
            Firearms = new Firearms(order.Firearms);
            IsFinancialAbuseInvolved = order.IsFinancialAbuseInvolved;
        }

        public OrderRestrictionState EAConductChoiceState
        {
            get { return _eaConductChoiceState; }
            set
            {
                if (value == _eaConductChoiceState) return;
                _eaConductChoiceState = value;
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

        public OrderRestrictionState EAStayAwayOrdersState
        {
            get { return _eaStayAwayOrdersState; }
            set
            {
                if (value == _eaStayAwayOrdersState) return;
                _eaStayAwayOrdersState = value;
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

        public OrderRestrictionState MoveoutState
        {
            get { return _moveoutState; }
            set
            {
                if (value == _moveoutState) return;
                _moveoutState = value;
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

        public bool IsFirearmsGranted
        {
            get { return _isFirearmsGranted; }
            set
            {
                if (value.Equals(_isFirearmsGranted)) return;
                _isFirearmsGranted = value;
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