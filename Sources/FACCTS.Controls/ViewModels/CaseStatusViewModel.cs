using Caliburn.Micro.ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CaseStatusViewModel))]
    public class CaseStatusViewModel : ViewModelBase
    {
        public CaseStatusViewModel() : base()
        {
            this.DisplayName = "Case Status";
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

        private DateTime? _firstActivityStartDate;
        public DateTime? FirstActivityStartDate
        {
            get
            {
                return _firstActivityStartDate;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _firstActivityStartDate, value);
            }
        }

        private DateTime? _lastActivityStartDate;
        public DateTime? LastActivityStartDate
        {
            get
            {
                return _lastActivityStartDate;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _lastActivityStartDate, value);
            }
        }

        private DateTime? _firstActivityEndDate;
        public DateTime? FirstActivityEndDate
        {
            get
            {
                return _firstActivityEndDate;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _firstActivityEndDate, value);
            }
        }

        private DateTime? _lastActivityEndDate;
        public DateTime? LastActivityEndDate
        {
            get
            {
                return _lastActivityEndDate;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _lastActivityEndDate, value);
            }
        }

        private string _ccpor_Id;
        public string CCPOR_ID
        {
            get
            {
                return _ccpor_Id;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _ccpor_Id, value);
            }
        }

        private string _party1FirstName;
        public string Party1FirstName
        {
            get
            {
                return _party1FirstName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _party1FirstName, value);
            }
        }

        private string _party1MiddleName;
        public string Party1MiddleName
        {
            get
            {
                return _party1MiddleName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _party1MiddleName, value);
            }
        }

        private string _party1LastName;
        public string Party1LastName
        {
            get
            {
                return _party1LastName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _party1LastName, value);
            }
        }

        private string _party2FirstName;
        public string Party2FirstName
        {
            get
            {
                return _party2FirstName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _party2FirstName, value);
            }
        }

        private string _party2MiddleName;
        public string Party2MiddleName
        {
            get
            {
                return _party2MiddleName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _party2MiddleName, value);
            }
        }

        private string _party2LastName;
        public string Party2LastName
        {
            get
            {
                return _party2LastName;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _party2LastName, value);
            }
        }

        public void Clear()
        {
            CaseNumber = string.Empty;
            FirstActivityStartDate = null;
            FirstActivityEndDate = null;
            LastActivityStartDate = null;
            LastActivityEndDate = null;
            CCPOR_ID = string.Empty;
            Party1FirstName = string.Empty;
            Party1MiddleName = string.Empty;
            Party1LastName = string.Empty;
            Party2FirstName = string.Empty;
            Party2MiddleName = string.Empty;
            Party2LastName = string.Empty;
        }

        public void Find()
        {
            //TODO implement Find()
        }
    }
}
