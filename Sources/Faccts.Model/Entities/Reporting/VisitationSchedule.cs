using System;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class VisitationSchedule : ReactiveBase, IVisitationSchedule
    {
        private bool _isOtherVisitationAvilable;
        private DateTime _lastAvailableWeekdayTime;
        private DayOfWeek _lastAvailableWeekdayDay;
        private DateTime _firstAvailableWeekdayTime;
        private DayOfWeek _firstAvailableWeekdayDay;
        private DateTime _weekdaysStartingDate;
        private bool _isWeekdaysAvailableForVisitation;
        private DateTime _lastAvailableWeekendTime;
        private DayOfWeek _lastAvailableWeekendDay;
        private DateTime _firstAvailableWeekendTime;
        private DayOfWeek _firstAvailableWeekendDay;
        private bool _isFifthWeekendAvailableForVisitation;
        private bool _isFourthWeekendAvailableForVisitation;
        private bool _isThirdWeekendAvailableForVisitation;
        private bool _isSecondWeekendAvailableForVisitation;
        private bool _isFirstWeekendAvailableForVisitation;
        private DateTime _weekendsStartingDate;
        private bool _isWeekendsAvailableForVisitation;
        private bool _isEnabled;

        public VisitationSchedule()
        {
        }

        public VisitationSchedule(IVisitationSchedule schedule)
        {
            IsEnabled = schedule.IsEnabled;
            IsWeekendsAvailableForVisitation = schedule.IsWeekendsAvailableForVisitation;
            WeekendsStartingDate = schedule.WeekendsStartingDate;
            IsFirstWeekendAvailableForVisitation = schedule.IsFirstWeekendAvailableForVisitation;
            IsSecondWeekendAvailableForVisitation = schedule.IsSecondWeekendAvailableForVisitation;
            IsThirdWeekendAvailableForVisitation = schedule.IsThirdWeekendAvailableForVisitation;
            IsFourthWeekendAvailableForVisitation = schedule.IsFourthWeekendAvailableForVisitation;
            IsFifthWeekendAvailableForVisitation = schedule.IsFifthWeekendAvailableForVisitation;
            FirstAvailableWeekendDay = schedule.FirstAvailableWeekendDay;
            FirstAvailableWeekendTime = schedule.FirstAvailableWeekendTime;
            LastAvailableWeekendDay = schedule.LastAvailableWeekendDay;
            LastAvailableWeekendTime = schedule.LastAvailableWeekendTime;
            IsWeekdaysAvailableForVisitation = schedule.IsWeekdaysAvailableForVisitation;
            WeekdaysStartingDate = schedule.WeekdaysStartingDate;
            FirstAvailableWeekdayDay = schedule.FirstAvailableWeekdayDay;
            FirstAvailableWeekdayTime = schedule.FirstAvailableWeekdayTime;
            LastAvailableWeekdayDay = schedule.LastAvailableWeekdayDay;
            LastAvailableWeekdayTime = schedule.LastAvailableWeekdayTime;
            IsOtherVisitationAvilable = schedule.IsOtherVisitationAvilable;
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

        public bool IsWeekendsAvailableForVisitation
        {
            get { return _isWeekendsAvailableForVisitation; }
            set
            {
                if (value.Equals(_isWeekendsAvailableForVisitation)) return;
                _isWeekendsAvailableForVisitation = value;
                OnPropertyChanged();
            }
        }

        public DateTime WeekendsStartingDate
        {
            get { return _weekendsStartingDate; }
            set
            {
                if (value.Equals(_weekendsStartingDate)) return;
                _weekendsStartingDate = value;
                OnPropertyChanged();
            }
        }

        public bool IsFirstWeekendAvailableForVisitation
        {
            get { return _isFirstWeekendAvailableForVisitation; }
            set
            {
                if (value.Equals(_isFirstWeekendAvailableForVisitation)) return;
                _isFirstWeekendAvailableForVisitation = value;
                OnPropertyChanged();
            }
        }

        public bool IsSecondWeekendAvailableForVisitation
        {
            get { return _isSecondWeekendAvailableForVisitation; }
            set
            {
                if (value.Equals(_isSecondWeekendAvailableForVisitation)) return;
                _isSecondWeekendAvailableForVisitation = value;
                OnPropertyChanged();
            }
        }

        public bool IsThirdWeekendAvailableForVisitation
        {
            get { return _isThirdWeekendAvailableForVisitation; }
            set
            {
                if (value.Equals(_isThirdWeekendAvailableForVisitation)) return;
                _isThirdWeekendAvailableForVisitation = value;
                OnPropertyChanged();
            }
        }

        public bool IsFourthWeekendAvailableForVisitation
        {
            get { return _isFourthWeekendAvailableForVisitation; }
            set
            {
                if (value.Equals(_isFourthWeekendAvailableForVisitation)) return;
                _isFourthWeekendAvailableForVisitation = value;
                OnPropertyChanged();
            }
        }

        public bool IsFifthWeekendAvailableForVisitation
        {
            get { return _isFifthWeekendAvailableForVisitation; }
            set
            {
                if (value.Equals(_isFifthWeekendAvailableForVisitation)) return;
                _isFifthWeekendAvailableForVisitation = value;
                OnPropertyChanged();
            }
        }

        public DayOfWeek FirstAvailableWeekendDay
        {
            get { return _firstAvailableWeekendDay; }
            set
            {
                if (value == _firstAvailableWeekendDay) return;
                _firstAvailableWeekendDay = value;
                OnPropertyChanged();
            }
        }

        public DateTime FirstAvailableWeekendTime
        {
            get { return _firstAvailableWeekendTime; }
            set
            {
                if (value.Equals(_firstAvailableWeekendTime)) return;
                _firstAvailableWeekendTime = value;
                OnPropertyChanged();
            }
        }

        public DayOfWeek LastAvailableWeekendDay
        {
            get { return _lastAvailableWeekendDay; }
            set
            {
                if (value == _lastAvailableWeekendDay) return;
                _lastAvailableWeekendDay = value;
                OnPropertyChanged();
            }
        }

        public DateTime LastAvailableWeekendTime
        {
            get { return _lastAvailableWeekendTime; }
            set
            {
                if (value.Equals(_lastAvailableWeekendTime)) return;
                _lastAvailableWeekendTime = value;
                OnPropertyChanged();
            }
        }

        public bool IsWeekdaysAvailableForVisitation
        {
            get { return _isWeekdaysAvailableForVisitation; }
            set
            {
                if (value.Equals(_isWeekdaysAvailableForVisitation)) return;
                _isWeekdaysAvailableForVisitation = value;
                OnPropertyChanged();
            }
        }

        public DateTime WeekdaysStartingDate
        {
            get { return _weekdaysStartingDate; }
            set
            {
                if (value.Equals(_weekdaysStartingDate)) return;
                _weekdaysStartingDate = value;
                OnPropertyChanged();
            }
        }

        public DayOfWeek FirstAvailableWeekdayDay
        {
            get { return _firstAvailableWeekdayDay; }
            set
            {
                if (value == _firstAvailableWeekdayDay) return;
                _firstAvailableWeekdayDay = value;
                OnPropertyChanged();
            }
        }

        public DateTime FirstAvailableWeekdayTime
        {
            get { return _firstAvailableWeekdayTime; }
            set
            {
                if (value.Equals(_firstAvailableWeekdayTime)) return;
                _firstAvailableWeekdayTime = value;
                OnPropertyChanged();
            }
        }

        public DayOfWeek LastAvailableWeekdayDay
        {
            get { return _lastAvailableWeekdayDay; }
            set
            {
                if (value == _lastAvailableWeekdayDay) return;
                _lastAvailableWeekdayDay = value;
                OnPropertyChanged();
            }
        }

        public DateTime LastAvailableWeekdayTime
        {
            get { return _lastAvailableWeekdayTime; }
            set
            {
                if (value.Equals(_lastAvailableWeekdayTime)) return;
                _lastAvailableWeekdayTime = value;
                OnPropertyChanged();
            }
        }

        public bool IsOtherVisitationAvilable
        {
            get { return _isOtherVisitationAvilable; }
            set
            {
                if (value.Equals(_isOtherVisitationAvilable)) return;
                _isOtherVisitationAvilable = value;
                OnPropertyChanged();
            }
        }
    }
}