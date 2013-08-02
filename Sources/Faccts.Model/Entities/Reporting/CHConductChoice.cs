using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class CHConductChoice : ReactiveBase, ICHConductChoice
    {
        private bool _isDontTryToLocate;
        private bool _isInvolveOther;
        private bool _isNoAbuse;
        private bool _isNoContact;
        private bool _isOtherAttached;
        private string _otherDescription;

        public CHConductChoice(ICHConductChoice choice)
        {
            IsNoAbuse = choice.IsNoAbuse;
            IsNoContact = choice.IsNoContact;
            IsDontTryToLocate = choice.IsDontTryToLocate;
            IsInvolveOtherProtected = choice.IsInvolveOtherProtected;
            OtherDescription = choice.OtherDescription;
            IsOtherAttached = choice.IsOtherAttached;
        }

        public CHConductChoice()
        {
        }

        public bool IsNoAbuse
        {
            get { return _isNoAbuse; }
            set
            {
                if (value.Equals(_isNoAbuse)) return;
                _isNoAbuse = value;
                OnPropertyChanged();
            }
        }

        public bool IsNoContact
        {
            get { return _isNoContact; }
            set
            {
                if (value.Equals(_isNoContact)) return;
                _isNoContact = value;
                OnPropertyChanged();
            }
        }

        public bool IsDontTryToLocate
        {
            get { return _isDontTryToLocate; }
            set
            {
                if (value.Equals(_isDontTryToLocate)) return;
                _isDontTryToLocate = value;
                OnPropertyChanged();
            }
        }

        public bool IsInvolveOtherProtected { get; set; }

        public bool IsInvolveOther
        {
            get { return _isInvolveOther; }
            set
            {
                if (value.Equals(_isInvolveOther)) return;
                _isInvolveOther = value;
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

        public bool IsOtherAttached
        {
            get { return _isOtherAttached; }
            set
            {
                if (value.Equals(_isOtherAttached)) return;
                _isOtherAttached = value;
                OnPropertyChanged();
            }
        }
    }
}