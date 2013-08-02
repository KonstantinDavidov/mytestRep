using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class DVStayAwayOrders : ReactiveBase, IDVStayAwayOrders
    {
        private bool _isAttachOther;
        private bool _isStayAwayFromChildCareOrSchool;
        private bool _isStayAwayFromHome;
        private bool _isStayAwayFromOther;
        private bool _isStayAwayFromOtherProtected;
        private bool _isStayAwayFromPerson;
        private bool _isStayAwayFromPersonSchool;
        private bool _isStayAwayFromVehicle;
        private bool _isStayAwayFromWork;
        private string _otherDescription;
        private int _stayAwayDistance;

        public DVStayAwayOrders()
        {
        }

        public DVStayAwayOrders(IDVStayAwayOrders stayAwayOrders)
        {
            IsStayAwayFromPerson = stayAwayOrders.IsStayAwayFromPerson;
            IsStayAwayFromHome = stayAwayOrders.IsStayAwayFromHome;
            IsStayAwayFromVehicle = stayAwayOrders.IsStayAwayFromVehicle;
            IsStayAwayFromChildCareOrSchool = stayAwayOrders.IsStayAwayFromChildCareOrSchool;
            IsStayAwayFromPersonSchool = stayAwayOrders.IsStayAwayFromPersonSchool;
            IsStayAwayFromWork = stayAwayOrders.IsStayAwayFromWork;
            IsStayAwayFromOtherProtected = stayAwayOrders.IsStayAwayFromOtherProtected;
            IsStayAwayFromOther = stayAwayOrders.IsStayAwayFromOther;
            IsAttachOther = stayAwayOrders.IsAttachOther;
            OtherDescription = stayAwayOrders.OtherDescription;
            StayAwayDistance = stayAwayOrders.StayAwayDistance;
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

        public bool IsStayAwayFromChildCareOrSchool
        {
            get { return _isStayAwayFromChildCareOrSchool; }
            set
            {
                if (value.Equals(_isStayAwayFromChildCareOrSchool)) return;
                _isStayAwayFromChildCareOrSchool = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayFromPersonSchool
        {
            get { return _isStayAwayFromPersonSchool; }
            set
            {
                if (value.Equals(_isStayAwayFromPersonSchool)) return;
                _isStayAwayFromPersonSchool = value;
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

        public bool IsAttachOther
        {
            get { return _isAttachOther; }
            set
            {
                if (value.Equals(_isAttachOther)) return;
                _isAttachOther = value;
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