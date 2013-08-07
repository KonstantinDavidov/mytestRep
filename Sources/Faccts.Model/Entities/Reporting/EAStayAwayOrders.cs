using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class EAStayAwayOrders : ReactiveBase, IEAStayAwayOrders
    {
        private int _stayAwayDistance;
        private string _otherDescription;
        private bool _isStayAwayFromOther;
        private bool _isStayAwayFromOtherProtected;
        private bool _isStayAwayFromWork;
        private bool _isStayAwayFromVehicle;
        private bool _isStayAwayFromHome;
        private bool _isStayAwayFromPerson;

        public EAStayAwayOrders()
        {
        }

        public EAStayAwayOrders(IEAStayAwayOrders sao)
        {
            IsStayAwayFromPerson = sao.IsStayAwayFromPerson;
            IsStayAwayFromHome = sao.IsStayAwayFromHome;
            IsStayAwayFromVehicle = sao.IsStayAwayFromVehicle;
            IsStayAwayFromWork = sao.IsStayAwayFromWork;
            IsStayAwayFromOtherProtected = sao.IsStayAwayFromOtherProtected;
            IsStayAwayFromOther = sao.IsStayAwayFromOther;
            OtherDescription = sao.OtherDescription;
            StayAwayDistance = sao.StayAwayDistance;
        }

        public bool IsStayAwayFromPerson
        {
            get { return _isStayAwayFromPerson; }
            set
            {
                if (value.Equals(_isStayAwayFromPerson)) return;
                _isStayAwayFromPerson = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayFromHome
        {
            get { return _isStayAwayFromHome; }
            set
            {
                if (value.Equals(_isStayAwayFromHome)) return;
                _isStayAwayFromHome = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayFromVehicle
        {
            get { return _isStayAwayFromVehicle; }
            set
            {
                if (value.Equals(_isStayAwayFromVehicle)) return;
                _isStayAwayFromVehicle = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayFromWork
        {
            get { return _isStayAwayFromWork; }
            set
            {
                if (value.Equals(_isStayAwayFromWork)) return;
                _isStayAwayFromWork = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayFromOtherProtected
        {
            get { return _isStayAwayFromOtherProtected; }
            set
            {
                if (value.Equals(_isStayAwayFromOtherProtected)) return;
                _isStayAwayFromOtherProtected = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayFromOther
        {
            get { return _isStayAwayFromOther; }
            set
            {
                if (value.Equals(_isStayAwayFromOther)) return;
                _isStayAwayFromOther = value;
                OnPropertyChanged();
            }
        }

        public string OtherDescription
        {
            get { return _otherDescription; }
            set
            {
                if (value == _otherDescription) return;
                _otherDescription = value;
                OnPropertyChanged();
            }
        }

        public int StayAwayDistance
        {
            get { return _stayAwayDistance; }
            set
            {
                if (value == _stayAwayDistance) return;
                _stayAwayDistance = value;
                OnPropertyChanged();
            }
        }
    }
}