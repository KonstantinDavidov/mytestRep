using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using FACCTS.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Services;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(IShell))]
    public class ShellViewModel : ReactiveConductor<IScreen>.Collection.OneActive, IShell
    {
        [ImportingConstructor]
        public ShellViewModel(CaseStatusViewModel caseStatusViewModel
            , CaseRecordViewModel caseRecordViewModel)
            : base()
        {
            CaseStatusViewModel = caseStatusViewModel;
            CaseRecordViewModel = caseRecordViewModel;
            this.WhenAny(x => x.ActiveItem, x => x.Value)
                .Subscribe(x =>
                {
                    this.NotifyOfPropertyChange(() => Name);
                });
            ShowCaseStatus();
        }
        
        private string _name = "Family Court Case Tracking System";
        public string Name
        {
            get
            {
                string retValue = _name;
                if (ActiveItem != null && ActiveItem is ViewModelBase)
                {
                    retValue += string.Format(" - {0}", (ActiveItem as ViewModelBase).DisplayName);
                }
                return retValue; 
            }
        }

        
        private CaseStatusViewModel _caseStatucViewModel;
        public CaseStatusViewModel CaseStatusViewModel {
            protected get
            {
                return _caseStatucViewModel;
            }
            set
            {
                if (_caseStatucViewModel == value)
                    return;
                _caseStatucViewModel = value;
                this.NotifyOfPropertyChange();
            } 
        }

        public CaseRecordViewModel CaseRecordViewModel { protected get; set; }
       
        public void ShowCaseStatus()
        {
            ActivateItem(CaseStatusViewModel);
        }
        
        public void ShowCaseRecord()
        {
            ActivateItem(CaseRecordViewModel);
        }

       
    }
}
