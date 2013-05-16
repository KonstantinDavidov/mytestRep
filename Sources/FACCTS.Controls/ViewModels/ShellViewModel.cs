﻿using Caliburn.Micro;
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
            , CaseRecordViewModel caseRecordViewModel
            , CourtDocketViewModel courtDocketViewModel
            , CourtOrdersViewModel courtOrdersViewModel)
            : base()
        {
            CaseStatusViewModel = caseStatusViewModel;
            CaseRecordViewModel = caseRecordViewModel;
            CourtDocketViewModel = courtDocketViewModel;
            CourtOrdersViewModel = courtOrdersViewModel;
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
                if (ActiveItem != null && ActiveItem is IScreen)
                {
                    retValue += string.Format(" - {0}", (ActiveItem as IScreen).DisplayName);
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

        public CourtDocketViewModel CourtDocketViewModel  { protected get; set; }

        public CourtOrdersViewModel CourtOrdersViewModel { protected get; set; }
       
        public void ShowCaseStatus()
        {
            ActivateItem(CaseStatusViewModel);
        }
        
        public void ShowCaseRecord()
        {
            ActivateItem(CaseRecordViewModel);
        }

        public void ShowCourtDocket()
        {
            ActivateItem(CourtDocketViewModel);
        }

        public void ShowCourtOrders()
        {
            ActivateItem(CourtOrdersViewModel);
        }

       
    }
}
