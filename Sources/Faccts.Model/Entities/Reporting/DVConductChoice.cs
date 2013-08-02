using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class DVConductChoice : ReactiveBase, IDVConductChoice
    {
        private bool _isDontTryToLocate;
        private bool _isExceptionsExist;
        private bool _isNoAbuse;
        private bool _isNoContact;

        public DVConductChoice()
        {
        }

        public DVConductChoice(IDVConductChoice conductChoice)
        {
            IsNoAbuse = conductChoice.IsNoAbuse;
            IsNoContact = conductChoice.IsNoContact;
            IsDontTryToLocate = conductChoice.IsDontTryToLocate;
            IsExceptionsExist = conductChoice.IsExceptionsExist;
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

        public bool IsExceptionsExist
        {
            get { return _isExceptionsExist; }
            set
            {
                if (value.Equals(_isExceptionsExist)) return;
                _isExceptionsExist = value;
                OnPropertyChanged();
            }
        }
    }
}