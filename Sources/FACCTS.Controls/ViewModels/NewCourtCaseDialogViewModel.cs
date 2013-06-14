using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.DataModel;
using System.ComponentModel.Composition;
using FACCTS.Services.Data;
using FACCTS.Services.Logger;
using System.ComponentModel;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public class NewCourtCaseDialogViewModel : ViewModelBase, IDataErrorInfo
    {
        [ImportingConstructor]
        public NewCourtCaseDialogViewModel(ILogger logger) : base()
        {
            _logger = logger;
            SelectedDate = DateTime.Today;
            SelectedTime = DateTime.Now.ToLocalTime();
            this.WhenAny(x => x.SelectedLocation, x => FACCTS.Services.Data.CourtDepartments.GetByCourtCountyId(x.Value))
                .Subscribe(x =>
                {
                    this.CourtDepartments = x;
                });
                
        }

        private ILogger _logger;

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

        public CourtDepartment _dept;
        public CourtDepartment Dept
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

        private List<CourtCounty> _courtCounties;
        public List<CourtCounty> CourtCounties
        {
            get
            {
                if (_courtCounties == null)
                { 
                    _courtCounties = FACCTS.Services.Data.CourtCounties.GetAll();
                }
                return _courtCounties;
            }
        }

        private CourtCounty _selectedLocation;
        public CourtCounty SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedLocation, value);
            }
        }

        private List<CourtDepartment> _courtDepartments;
        public List<CourtDepartment> CourtDepartments
        {
            get
            {
                return _courtDepartments;
            }
            protected set
            {
                this.RaiseAndSetIfChanged(ref _courtDepartments, value);
            }
        }


        private string _caseNumber;
        public string CaseNumber
        {
            get
            {
                return _caseNumber;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _caseNumber, value);
            }
        }
        #endregion

        public void CreateNewCase()
        {
            this.TryClose(true);
            var tsk = Task.Factory.StartNew(() =>
                {
                    ProceedCreation();
                }, TaskCreationOptions.AttachedToParent);

        }

        protected virtual void ProceedCreation()
        {
            _logger.Info("Start creation the new case...");
            CourtCase cc = new CourtCase();
            cc.CreationDateTime = this.SelectedDate.GetValueOrDefault(DateTime.Today).Add(this.SelectedTime.GetValueOrDefault(DateTime.Now.ToLocalTime()).TimeOfDay);
            cc.CaseNumber = this.CaseNumber;
            cc.CourtCounty = this.SelectedLocation;
            cc.CourtDepartment = this.Dept;
            _logger.Info("Saving the new case to the database...");
            CourtCases.CreateNew(cc);
        }

        public string Error
        {
            get 
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get 
            {
                string result = null;
                switch(columnName)
                {
                    case "CaseNumber":
                        return "Please specify the court case number";
                        break;
                }
                return result;
            }
        }
    }
}
