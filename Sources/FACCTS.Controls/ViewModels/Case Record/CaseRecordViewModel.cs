using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using Faccts.Model.Entities;
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
    public class CaseRecordViewModel : ReactiveConductor<IScreen>.Collection.OneActive, IReactiveNotifyPropertyChanged
    {
        [ImportingConstructor]
        public CaseRecordViewModel(PersonalInformationViewModel personalInformation
            , ChildrenOtherProtectedViewModel childrenViewModel
            , AttorneysViewModel attorneysViewModel
            , WitnessInterpereterViewModel witnessInterprererViewModel
            , RelatedCasesViewModel relatedCasesViewModel
            , IWindowManager windowManager
            , IAuthenticationService authenticationService 
            , IDataContainer dataContainer)
            : base()
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
            _windowManager = windowManager;
            this.DisplayName = "Case Record";
            PersonalInformationViewModel = personalInformation;
            ChildrenOtherProtectedViewModel = childrenViewModel;
            AttorneysViewModel = attorneysViewModel;
            WitnessInterpereterViewModel = witnessInterprererViewModel;
            RelatedCasesViewModel = relatedCasesViewModel;
            _authenticationService = authenticationService;
            _authenticationService.AuthenticationStatusChanged += _authenticationService_AuthenticationStatusChanged;
            DataContainer = dataContainer;
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

        private void Authorized()
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
                }
                return _courtCases;
            }
        }

        private void _authenticationService_AuthenticationStatusChanged(object sender, AuthenticationStatusChangedEventArgs e)
        {
            this.IsAuthenticated = e.AuthenticationStatus == AuthenticationStatus.Authenticated;
        }

        private IAuthenticationService _authenticationService;
        public IDataContainer DataContainer { get; private set; }
        private MakeObjectReactiveHelper _reactiveHelper;
        private IWindowManager _windowManager;
        protected PersonalInformationViewModel PersonalInformationViewModel { get; set; }
        protected ChildrenOtherProtectedViewModel ChildrenOtherProtectedViewModel { get; set; }
        protected AttorneysViewModel AttorneysViewModel {get; set;}
        protected WitnessInterpereterViewModel WitnessInterpereterViewModel { get; set; }
        protected RelatedCasesViewModel RelatedCasesViewModel { get; set; }

        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
            set
            {
                if (_isAuthenticated == value)
                    return;
                this.NotifyOfPropertyChanging();
                _isAuthenticated = value;
                this.NotifyOfPropertyChange();
            }
        }

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

        public IObservable<IObservedChange<object, object>> Changed
        {
            get { return _reactiveHelper.Changed; }
        }
        public IObservable<IObservedChange<object, object>> Changing
        {
            get { return _reactiveHelper.Changing; }
        }
        public IDisposable SuppressChangeNotifications()
        {
            return _reactiveHelper.SuppressChangeNotifications();
        }
        public event PropertyChangingEventHandler PropertyChanging;

        protected void NotifyOfPropertyChanging([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
