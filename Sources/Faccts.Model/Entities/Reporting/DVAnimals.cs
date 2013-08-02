using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class DVAnimals : ReactiveBase, IDVAnimals
    {
        private string _animalsDescription;
        private int _stayAwayAnimalsDistance;

        public DVAnimals()
        {
        }

        public DVAnimals(IDVAnimals animalsSection)
        {
            StayAwayAnimalsDistance = animalsSection.StayAwayAnimalsDistance;
            AnimalsDescription = animalsSection.AnimalsDescription;
        }

        public int StayAwayAnimalsDistance
        {
            get { return _stayAwayAnimalsDistance; }
            set
            {
                if (value == _stayAwayAnimalsDistance) return;
                _stayAwayAnimalsDistance = value;
                OnPropertyChanged();
            }
        }

        public string AnimalsDescription
        {
            get { return _animalsDescription; }
            set
            {
                if (value == _animalsDescription) return;
                _animalsDescription = value;
                OnPropertyChanged();
            }
        }
    }
}