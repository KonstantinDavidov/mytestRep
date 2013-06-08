using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Controls.ViewModels
{
    public class NewCourtCaseDialogViewModel : ViewModelBase
    {
        public NewCourtCaseDialogViewModel() : base()
        {
            SelectedDate = DateTime.Today;
        }

        protected override void Authorized()
        {
            base.Authorized();

        }

        #region UI properties
        

        private DateTime? _dateTime;
        public DateTime? SelectedDate
        {
            get
            {
                return _dateTime;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _dateTime, value);
            }
        }

        private DateTime? _selectedTime;
        public DateTime? SelectedTime
        {
            get
            {
                return _selectedTime;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedTime, value);
            }
        }

        public Depts _dept;
        public Depts Dept
        {
            get
            {
                return _dept;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _dept, value);
            }
        }

        private string _courtNotice;
        public string CourtNotice
        {
            get
            {
                return _courtNotice;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _courtNotice, value);
            }
        }

        private bool _isPermanent;
        public bool IsPermanent
        {
            get
            {
                return _isPermanent;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isPermanent, value);
            }
        }

        private bool _CCorCV;
        public bool IsCCorCV
        {
            get
            {
                return _CCorCV;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _CCorCV, value);
            }
        }

        private bool _isCS;
        public bool IsCS
        {
            get
            {
                return _isCS;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isCS, value);
            }
        }

        private bool _isSS;
        public bool IsSS
        {
            get
            {
                return _isSS;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isSS, value);
            }
        }

        private bool _isBatteriesIntervention;
        public bool IsBatteriesIntervention
        {
            get
            {
                return _isBatteriesIntervention;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isBatteriesIntervention, value);
            }
        }

        private bool _isComlianceWithOther;
        public bool IsComlianceWithOther
        {
            get
            {
                return _isComlianceWithOther;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isComlianceWithOther, value);
            }
        }

        #endregion
    }
}
