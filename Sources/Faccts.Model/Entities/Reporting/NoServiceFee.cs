using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class NoServiceFee : ReactiveBase, INoServiceFee
    {
        private bool _isBasedOnViolence;
        private bool _isFeeWaiver;
        private bool _isOrdered;

        public NoServiceFee()
        {
        }

        public NoServiceFee(INoServiceFee fee)
        {
            IsOrdered = fee.IsOrdered;
            IsFeeWaiver = fee.IsFeeWaiver;
            IsBasedOnViolence = fee.IsBasedOnViolence;
        }

        public bool IsOrdered
        {
            get { return _isOrdered; }
            set
            {
                if (value.Equals(_isOrdered)) return;
                _isOrdered = value;
                OnPropertyChanged();
            }
        }

        public bool IsFeeWaiver
        {
            get { return _isFeeWaiver; }
            set
            {
                if (value.Equals(_isFeeWaiver)) return;
                _isFeeWaiver = value;
                OnPropertyChanged();
            }
        }

        public bool IsBasedOnViolence
        {
            get { return _isBasedOnViolence; }
            set
            {
                if (value.Equals(_isBasedOnViolence)) return;
                _isBasedOnViolence = value;
                OnPropertyChanged();
            }
        }
    }
}