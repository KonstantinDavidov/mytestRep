using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class ExchangeAndRemoval: ReactiveBase, IExchangeAndRemoval
    {
        private string _otherCountryAsHabitualResidenceDescription;
        private bool _isOtherCountryOfHabitualResidence;
        private bool _isUsCountryOfHabitualResidence;
        private bool _isDV145Attached;
        private bool _isChildAbductionRiskExist;
        private ITravelRestrict _travelRestrict;
        private ITransportation _transportation;
        private string _isEnabled;

        public ExchangeAndRemoval()
        {
            Transportation = new Transportation();
            TravelRestrict = new TravelRestrict();
        }

        public ExchangeAndRemoval(IExchangeAndRemoval removal)
        {
            IsEnabled = removal.IsEnabled;
            Transportation = new Transportation(removal.Transportation);
            TravelRestrict = new TravelRestrict(removal.TravelRestrict);
            IsChildAbductionRiskExist = removal.IsChildAbductionRiskExist;
            IsDV145Attached = removal.IsDV145Attached;
            IsUSCountryOfHabitualResidence = removal.IsUSCountryOfHabitualResidence;
            IsOtherCountryOfHabitualResidence = removal.IsOtherCountryOfHabitualResidence;
            OtherCountryAsHabitualResidenceDescription = removal.OtherCountryAsHabitualResidenceDescription;
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

        public ITransportation Transportation
        {
            get { return _transportation; }
            set
            {
                if (Equals(value, _transportation)) return;
                _transportation = value;
                OnPropertyChanged();
            }
        }

        public ITravelRestrict TravelRestrict
        {
            get { return _travelRestrict; }
            set
            {
                if (Equals(value, _travelRestrict)) return;
                _travelRestrict = value;
                OnPropertyChanged();
            }
        }

        public bool IsChildAbductionRiskExist
        {
            get { return _isChildAbductionRiskExist; }
            set
            {
                if (value.Equals(_isChildAbductionRiskExist)) return;
                _isChildAbductionRiskExist = value;
                OnPropertyChanged();
            }
        }

        public bool IsDV145Attached
        {
            get { return _isDV145Attached; }
            set
            {
                if (value.Equals(_isDV145Attached)) return;
                _isDV145Attached = value;
                OnPropertyChanged();
            }
        }

        public bool IsUSCountryOfHabitualResidence
        {
            get { return _isUsCountryOfHabitualResidence; }
            set
            {
                if (value.Equals(_isUsCountryOfHabitualResidence)) return;
                _isUsCountryOfHabitualResidence = value;
                OnPropertyChanged();
            }
        }

        public bool IsOtherCountryOfHabitualResidence
        {
            get { return _isOtherCountryOfHabitualResidence; }
            set
            {
                if (value.Equals(_isOtherCountryOfHabitualResidence)) return;
                _isOtherCountryOfHabitualResidence = value;
                OnPropertyChanged();
            }
        }

        public string OtherCountryAsHabitualResidenceDescription
        {
            get { return _otherCountryAsHabitualResidenceDescription; }
            set
            {
                if (value == _otherCountryAsHabitualResidenceDescription) return;
                _otherCountryAsHabitualResidenceDescription = value;
                OnPropertyChanged();
            }
        }
    }
}