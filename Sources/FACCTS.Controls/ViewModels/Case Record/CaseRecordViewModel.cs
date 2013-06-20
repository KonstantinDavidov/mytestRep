using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using Faccts.Model.Entities;
using FACCTS.Controls.Events;
using FACCTS.Controls.Utils;
using FACCTS.Services;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    
    [Export(typeof(CaseRecordViewModel))]
    public class CaseRecordViewModel : OneActiveViewModelBase
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public CaseRecordViewModel(PersonalInformationViewModel personalInformation
            , ChildrenOtherProtectedViewModel childrenViewModel
            , AttorneysViewModel attorneysViewModel
            , WitnessInterpereterViewModel witnessInterprererViewModel
            , RelatedCasesViewModel relatedCasesViewModel
            , IWindowManager windowManager
            , IEventAggregator eventAggregator
            )
            : base()
        {
            _windowManager = windowManager;
            this.DisplayName = "Case Record";
            PersonalInformationViewModel = personalInformation;
            ChildrenOtherProtectedViewModel = childrenViewModel;
            AttorneysViewModel = attorneysViewModel;
            WitnessInterpereterViewModel = witnessInterprererViewModel;
            RelatedCasesViewModel = relatedCasesViewModel;
            _eventAggregator = eventAggregator;
            Observable.Merge(
                this.ObservableForProperty(x => x.IsActive),
                this.ObservableForProperty(x => x.IsAuthenticated)
                ).Subscribe(_ =>
                {
                    if (this.IsAuthenticated && this.IsActive)
                    {
                        this.Authorized();
                    }
                });
            
            ActivateControl(0);
        }

        public override IDataContainer DataContainer
        {
            protected get
            {
                return base.DataContainer;
            }
            set
            {
                if (base.DataContainer != null)
                {
                    base.DataContainer.PropertyChanged -= DataContainerPropertyChanged;
                }
                base.DataContainer = value;
                if (base.DataContainer != null)
                {
                    base.DataContainer.PropertyChanged += DataContainerPropertyChanged;
                }
            }
        }

        private void DataContainerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
                if (e.PropertyName == "CourtCases")
                {
                    _courtCases = null;
                    this.NotifyOfPropertyChange(() => CourtCases);
                }
        }

        protected override void Authorized()
        {
            this.NotifyOfPropertyChange(() => CourtCases);
        }

        private ObservableCollection<CourtCase> _courtCases;
        public ObservableCollection<CourtCase> CourtCases
        {
            get
            {
                if (IsAuthenticated && _courtCases == null)
                {
                    _courtCases = new ObservableCollection<CourtCase>(DataContainer.CourtCases);
                    if (CurrentCourtCase == null)
                    {
                        CurrentCourtCase = _courtCases.FirstOrDefault();
                    }
                }
                return _courtCases;
            }
        }

        private void _authenticationService_AuthenticationStatusChanged(object sender, AuthenticationStatusChangedEventArgs e)
        {
            this.IsAuthenticated = e.AuthenticationStatus == AuthenticationStatus.Authenticated;
        }

        private IWindowManager _windowManager;
        protected PersonalInformationViewModel PersonalInformationViewModel { get; set; }
        protected ChildrenOtherProtectedViewModel ChildrenOtherProtectedViewModel { get; set; }
        protected AttorneysViewModel AttorneysViewModel {get; set;}
        protected WitnessInterpereterViewModel WitnessInterpereterViewModel { get; set; }
        protected RelatedCasesViewModel RelatedCasesViewModel { get; set; }

        public void ActivateControl(int selectedIndex)
        {
            switch(selectedIndex)
            {
                case 0:
                    ActivateItem(PersonalInformationViewModel);
                    break;
                case 1:
                    ActivateItem(ChildrenOtherProtectedViewModel);
                    break;
                case 2:
                    ActivateItem(AttorneysViewModel);
                    break;
                case 3:
                    ActivateItem(WitnessInterpereterViewModel);
                    break;
                case 4:
                    ActivateItem(RelatedCasesViewModel);
                    break;
                default:
                    ActivateItem(PersonalInformationViewModel);
                    break;
            }
        }

        public void NewCase()
        {
            BusinessLogicHelper.CreateNewCase(ServiceLocatorContainer.Locator.GetInstance<NewCourtCaseDialogViewModel>(), _windowManager);
        }

        private CourtCase _currentCourtCase;
        public CourtCase CurrentCourtCase
        {
            get
            {
                return _currentCourtCase;
            }
            set
            {
                if (_currentCourtCase == value)
                    return;

                this.NotifyOfPropertyChanging();
                _currentCourtCase = value;
                _eventAggregator.Publish(new CurrentCourtCaseChangedEvent(_currentCourtCase));
                this.NotifyOfPropertyChange();
            }
        }
       
    }
}
