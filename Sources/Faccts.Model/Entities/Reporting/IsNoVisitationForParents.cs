using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class IsNoVisitationForParents : ReactiveBase, IIsNoVisitationForParents
    {
        private string _otherDescription;
        private CustodyParent _isNoVisitationParent;
        private bool _isEnabled;

        public IsNoVisitationForParents()
        {
        }

        public IsNoVisitationForParents(IIsNoVisitationForParents info)
        {
            IsEnabled = info.IsEnabled;
            IsNoVisitationParent = info.IsNoVisitationParent;
            OtherDescription = info.OtherDescription;
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value.Equals(_isEnabled)) return;
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public CustodyParent IsNoVisitationParent
        {
            get { return _isNoVisitationParent; }
            set
            {
                if (value == _isNoVisitationParent) return;
                _isNoVisitationParent = value;
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
    }
}