using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class Transportation : ReactiveBase, ITransportation
    {
        private string _transportationDropOffLocation;
        private string _transportationDropOffPersonOtherDescription;
        private CustodyParent _transportationDropOffPerson;
        private string _transportationPickUpLocation;
        private string _transportationPickUpPersonOtherDescription;
        private CustodyParent _transportationPickUpPerson;
        private string _isEnabled;

        public Transportation()
        {
        }

        public Transportation(ITransportation transportation)
        {
            IsEnabled = transportation.IsEnabled;
            TransportationPickUpPerson = transportation.TransportationPickUpPerson;
            TransportationPickUpPersonOtherDescription = transportation.TransportationPickUpPersonOtherDescription;
            TransportationPickUpLocation = transportation.TransportationPickUpLocation;
            TransportationDropOffPerson = transportation.TransportationDropOffPerson;
            TransportationDropOffPersonOtherDescription = transportation.TransportationDropOffPersonOtherDescription;
            TransportationDropOffLocation = transportation.TransportationDropOffLocation;
        }

        public string IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value == _isEnabled) return;
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public CustodyParent TransportationPickUpPerson
        {
            get { return _transportationPickUpPerson; }
            set
            {
                if (value == _transportationPickUpPerson) return;
                _transportationPickUpPerson = value;
                OnPropertyChanged();
            }
        }

        public string TransportationPickUpPersonOtherDescription
        {
            get { return _transportationPickUpPersonOtherDescription; }
            set
            {
                if (value == _transportationPickUpPersonOtherDescription) return;
                _transportationPickUpPersonOtherDescription = value;
                OnPropertyChanged();
            }
        }

        public string TransportationPickUpLocation
        {
            get { return _transportationPickUpLocation; }
            set
            {
                if (value == _transportationPickUpLocation) return;
                _transportationPickUpLocation = value;
                OnPropertyChanged();
            }
        }

        public CustodyParent TransportationDropOffPerson
        {
            get { return _transportationDropOffPerson; }
            set
            {
                if (value == _transportationDropOffPerson) return;
                _transportationDropOffPerson = value;
                OnPropertyChanged();
            }
        }

        public string TransportationDropOffPersonOtherDescription
        {
            get { return _transportationDropOffPersonOtherDescription; }
            set
            {
                if (value == _transportationDropOffPersonOtherDescription) return;
                _transportationDropOffPersonOtherDescription = value;
                OnPropertyChanged();
            }
        }

        public string TransportationDropOffLocation
        {
            get { return _transportationDropOffLocation; }
            set
            {
                if (value == _transportationDropOffLocation) return;
                _transportationDropOffLocation = value;
                OnPropertyChanged();
            }
        }
    }
}