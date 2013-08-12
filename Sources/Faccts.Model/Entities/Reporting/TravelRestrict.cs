using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class TravelRestrict : ReactiveBase, ITravelRestrict
    {
        private string _otherLocationsDescription;
        private bool _isOtherLocationsEscapeDenied;
        private bool _isCaEscapeDenied;
        private bool _isUsEscapeDenied;
        private string _otherRestrainedDescription;
        private bool _isOtherRestrained;
        private bool _isDadRestrained;
        private bool _isMomRestrained;
        private string _isEnabled;

        public TravelRestrict()
        {
        }

        public TravelRestrict(ITravelRestrict restrict)
        {
            IsEnabled = restrict.IsEnabled;
            IsMomRestrained = restrict.IsMomRestrained;
            IsDadRestrained = restrict.IsDadRestrained;
            IsOtherRestrained = restrict.IsOtherRestrained;
            OtherRestrainedDescription = restrict.OtherRestrainedDescription;
            IsUSEscapeDenied = restrict.IsUSEscapeDenied;
            IsCAEscapeDenied = restrict.IsCAEscapeDenied;
            IsOtherLocationsEscapeDenied = restrict.IsOtherLocationsEscapeDenied;
            OtherLocationsDescription = restrict.OtherLocationsDescription;
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

        public bool IsMomRestrained
        {
            get { return _isMomRestrained; }
            set
            {
                if (value.Equals(_isMomRestrained)) return;
                _isMomRestrained = value;
                OnPropertyChanged();
            }
        }

        public bool IsDadRestrained
        {
            get { return _isDadRestrained; }
            set
            {
                if (value.Equals(_isDadRestrained)) return;
                _isDadRestrained = value;
                OnPropertyChanged();
            }
        }

        public bool IsOtherRestrained
        {
            get { return _isOtherRestrained; }
            set
            {
                if (value.Equals(_isOtherRestrained)) return;
                _isOtherRestrained = value;
                OnPropertyChanged();
            }
        }

        public string OtherRestrainedDescription
        {
            get { return _otherRestrainedDescription; }
            set
            {
                if (value == _otherRestrainedDescription) return;
                _otherRestrainedDescription = value;
                OnPropertyChanged();
            }
        }

        public bool IsUSEscapeDenied
        {
            get { return _isUsEscapeDenied; }
            set
            {
                if (value.Equals(_isUsEscapeDenied)) return;
                _isUsEscapeDenied = value;
                OnPropertyChanged();
            }
        }

        public bool IsCAEscapeDenied
        {
            get { return _isCaEscapeDenied; }
            set
            {
                if (value.Equals(_isCaEscapeDenied)) return;
                _isCaEscapeDenied = value;
                OnPropertyChanged();
            }
        }

        public bool IsOtherLocationsEscapeDenied
        {
            get { return _isOtherLocationsEscapeDenied; }
            set
            {
                if (value.Equals(_isOtherLocationsEscapeDenied)) return;
                _isOtherLocationsEscapeDenied = value;
                OnPropertyChanged();
            }
        }

        public string OtherLocationsDescription
        {
            get { return _otherLocationsDescription; }
            set
            {
                if (value == _otherLocationsDescription) return;
                _otherLocationsDescription = value;
                OnPropertyChanged();
            }
        }
    }
}