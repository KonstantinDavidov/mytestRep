using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class EAConductChoice : ReactiveBase, IEAConductChoice
    {
        private bool _isDontTryToLocate;
        private bool _isInvolveOther;
        private bool _isInvolveOtherProtected;
        private bool _isNoAbuse;
        private bool _isNoContact;
        private bool _isOtherAttached;
        private string _otherDescription;

        public EAConductChoice()
        {
        }

        public EAConductChoice(IEAConductChoice conductChoice)
        {
            IsNoAbuse = conductChoice.IsNoAbuse;
            IsNoContact = conductChoice.IsNoContact;
            IsDontTryToLocate = conductChoice.IsDontTryToLocate;
            IsInvolveOtherProtected = conductChoice.IsInvolveOtherProtected;
            IsInvolveOther = conductChoice.IsInvolveOther;
            OtherDescription = conductChoice.OtherDescription;
            IsOtherAttached = conductChoice.IsOtherAttached;
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

        public bool IsInvolveOtherProtected
        {
            get { return _isInvolveOtherProtected; }
            set
            {
                if (value.Equals(_isInvolveOtherProtected)) return;
                _isInvolveOtherProtected = value;
                OnPropertyChanged();
            }
        }

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