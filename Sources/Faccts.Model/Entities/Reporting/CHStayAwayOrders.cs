using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class CHStayAwayOrders : ReactiveBase, ICHStayAwayOrders
    {
        private bool _isAttachOther;
        private bool _isStayAwayFromChildCare;
        private bool _isStayAwayFromChildSchool;
        private bool _isStayAwayFromHome;
        private bool _isStayAwayFromOther;
        private bool _isStayAwayFromPerson;
        private bool _isStayAwayFromVehicle;
        private bool _isStayAwayFromWork;
        private string _otherDescription;
        private int _stayAwayDistance;

        public CHStayAwayOrders()
        {
        }

        public CHStayAwayOrders(ICHStayAwayOrders orders)
        {
            IsStayAwayFromPerson = orders.IsStayAwayFromPerson;
            IsStayAwayFromHome = orders.IsStayAwayFromHome;
            IsStayAwayFromVehicle = orders.IsStayAwayFromVehicle;
            IsStayAwayFromChildCare = orders.IsStayAwayFromChildCare;
            IsStayAwayFromChildSchool = orders.IsStayAwayFromChildSchool;
            IsStayAwayFromWork = orders.IsStayAwayFromWork;
            IsStayAwayFromOtherProtected = orders.IsStayAwayFromOtherProtected;
            IsStayAwayFromOther = orders.IsStayAwayFromOther;
            IsAttachOther = orders.IsAttachOther;
            OtherDescription = orders.OtherDescription;
            StayAwayDistance = orders.StayAwayDistance;
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

        public bool IsStayAwayFromChildCare
        {
            get { return _isStayAwayFromChildCare; }
            set
            {
                if (value.Equals(_isStayAwayFromChildCare)) return;
                _isStayAwayFromChildCare = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayFromChildSchool
        {
            get { return _isStayAwayFromChildSchool; }
            set
            {
                if (value.Equals(_isStayAwayFromChildSchool)) return;
                _isStayAwayFromChildSchool = value;
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

        public bool IsStayAwayFromOtherProtected { get; set; }

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