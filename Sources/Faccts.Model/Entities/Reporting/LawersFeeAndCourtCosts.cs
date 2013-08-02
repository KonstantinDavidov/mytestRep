using System.Collections.Generic;
using System.Collections.ObjectModel;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.OrderModels;
using FACCTS.Server.Model.Reporting.Entities;

namespace Faccts.Model.Entities.Reporting
{
    public class LawersFeeAndCourtCosts : ReactiveBase, ILawersFeeAndCourtCosts
    {
        private bool _isCourtCosts;
        private bool _isLawyerFee;
        private ICollection<IDataItem> _lawyersFees;
        private ParticipantRole _payer;

        public LawersFeeAndCourtCosts()
        {
            LawyersFees = new TrackableCollection<IDataItem>();
        }

        public LawersFeeAndCourtCosts(ILawersFeeAndCourtCosts costs)
        {
            IsLawyerFee = costs.IsLawyerFee;
            IsCourtCosts = costs.IsCourtCosts;
            Payer = costs.Payer;
            LawyersFees = new ObservableCollection<IDataItem>(costs.LawyersFees);
        }

        public bool IsLawyerFee
        {
            get { return _isLawyerFee; }
            set
            {
                if (value.Equals(_isLawyerFee)) return;
                _isLawyerFee = value;
                OnPropertyChanged();
            }
        }

        public bool IsCourtCosts
        {
            get { return _isCourtCosts; }
            set
            {
                if (value.Equals(_isCourtCosts)) return;
                _isCourtCosts = value;
                OnPropertyChanged();
            }
        }

        public ParticipantRole Payer
        {
            get { return _payer; }
            set
            {
                if (value == _payer) return;
                _payer = value;
                OnPropertyChanged();
            }
        }

        public ICollection<IDataItem> LawyersFees
        {
            get { return _lawyersFees; }
            set
            {
                if (Equals(value, _lawyersFees)) return;
                _lawyersFees = value;
                OnPropertyChanged();
            }
        }
    }
}