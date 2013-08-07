using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class Firearms : ReactiveBase, IFirearms
    {
        private bool _isCourtHasFirearmsInformation;
        private bool _isNoGuns;

        public Firearms()
        {
        }

        public Firearms(IFirearms firearms)
        {
            IsNoGuns = firearms.IsNoGuns;
            IsCourtHasFirearmsInformation = firearms.IsCourtHasFirearmsInformation;
        }

        public bool IsNoGuns
        {
            get { return _isNoGuns; }
            set
            {
                if (value.Equals(_isNoGuns)) return;
                _isNoGuns = value;
                OnPropertyChanged();
            }
        }

        public bool IsCourtHasFirearmsInformation
        {
            get { return _isCourtHasFirearmsInformation; }
            set
            {
                if (value.Equals(_isCourtHasFirearmsInformation)) return;
                _isCourtHasFirearmsInformation = value;
                OnPropertyChanged();
            }
        }
    }
}