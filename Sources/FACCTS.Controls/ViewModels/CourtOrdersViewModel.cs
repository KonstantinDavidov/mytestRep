using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using Faccts.Model.Entities;
using Faccts.Model.Entities.Reporting;
using FACCTS.Server.Model.Enums;
using FACCTS.Services;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof (CourtOrdersViewModel))]
    public class CourtOrdersViewModel : ReactiveConductor<IScreen>.Collection.OneActive, IReactiveNotifyPropertyChanged
    {
        private readonly MakeObjectReactiveHelper _reactiveHelper;
        private readonly IWindowManager _windowManager;
        private IAuthenticationService _authenticationService;
        private bool _isActive;
        private bool _isAuthenticated;
        private Hearings _selectedHearing;

        public CourtOrdersViewModel()
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
            RxApp.DeferredScheduler = new DispatcherScheduler(Application.Current.Dispatcher);
            this.ObservableForProperty(x => x.IsActive)
                .Merge(this.ObservableForProperty(x => x.IsAuthenticated))
                .Subscribe(_ =>
                {
                    if (IsAuthenticated && IsActive)
                    {
                        Authorized();
                    }
                });
            DisplayName = "Court Orders";
        }


        [ImportingConstructor]
        public CourtOrdersViewModel(IAuthenticationService authenticationService
            , IDataContainer dataContainer
            , IWindowManager windowManager
            )
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
            _authenticationService = authenticationService;
            _authenticationService.AuthenticationStatusChanged += _authenticationService_AuthenticationStatusChanged;
            _windowManager = windowManager;
            DataContainer = dataContainer;
        }

        public IDataContainer DataContainer { get; private set; }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                if (_isAuthenticated == value)
                    return;
                NotifyOfPropertyChanging();
                _isAuthenticated = value;
                NotifyOfPropertyChange();
            }
        }

        public new bool IsActive
        {
            get { return _isActive; }
            private set
            {
                if (value == _isActive)
                    return;
                NotifyOfPropertyChanging();
                _isActive = value;
                NotifyOfPropertyChange();
            }
        }

        public ObservableCollection<CourtCaseHeading> CourtCases
        {
            get { return DataContainer.CourtCaseHeadings; }
        }

        public TrackableCollection<Hearings> CurrentHearings
        {
            get { return DataContainer.Hearings; }
        }

        public Hearings SelectedHearing
        {
            get
            {
                if (_selectedHearing == null)
                    _selectedHearing = CurrentHearings.FirstOrDefault();
                return _selectedHearing;
            }

            set
            {
                _selectedHearing = value;
                NotifyOfPropertyChange(() => SelectedHearing);
            }
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

        private void Authorized()
        {
            //this.NotifyOfPropertyChange(() => CourtCases);
        }

        private void _authenticationService_AuthenticationStatusChanged(object sender,
            AuthenticationStatusChangedEventArgs e)
        {
            IsAuthenticated = e.AuthenticationStatus == AuthenticationStatus.Authenticated;
        }

        public void Activate(CourtOrderWithTypeViewModel viewModel)
        {
            if (viewModel == null) return;
            switch (viewModel.OrderType)
            {
                case CourtOrdersTypes.CH110:
                    PopulateOrderIfNotExists((CourtOrderBaseViewModel<CH110>) viewModel);
                    break;
                case CourtOrdersTypes.CH130:
                    PopulateOrderIfNotExists((CourtOrderBaseViewModel<CH130>)viewModel);
                    break;
                case CourtOrdersTypes.DV110:
                    PopulateOrderIfNotExists((CourtOrderBaseViewModel<DV110>)viewModel);
                    break;
                case CourtOrdersTypes.DV130:
                    PopulateOrderIfNotExists((CourtOrderBaseViewModel<DV130>)viewModel);
                    break;
            }
            ActivateItem(viewModel);
        }

        protected void NotifyOfPropertyChanging([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            IsActive = true;
        }

        protected override void OnDeactivate(bool close)
        {
            IsActive = false;
            base.OnDeactivate(close);
        }

        public void ShowGenerateDialog()
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<GenerateCourtOrdersDialogViewModel>();
            _windowManager.ShowDialog(vm);
        }

        private void PopulateOrderIfNotExists<T>(CourtOrderBaseViewModel<T> orderViewModel) where T: OrderBase
        {
            if (SelectedHearing == null)
                return;
            CourtOrders courtOrder =
                SelectedHearing.CourtOrders.FirstOrDefault(o => o.OrderType == orderViewModel.OrderType);
            if (courtOrder == null)
            {
                courtOrder = new CourtOrders
                {
                    Hearings = SelectedHearing,
                    OrderType = orderViewModel.OrderType
                };
            }
            if (courtOrder.InnerOrder == null)
            {
                courtOrder.InnerOrder = CreateOrder(courtOrder.OrderType);
            }
            orderViewModel.Order = (T) courtOrder.InnerOrder;
        }

        private OrderBase CreateOrder(CourtOrdersTypes courtOrdersType)
        {
            OrderBase result = null;
            switch (courtOrdersType)
            {
                case CourtOrdersTypes.DV110:
                    result = new DV110();
                    break;
                case CourtOrdersTypes.DV130:
                    result = new DV130();
                    break;
                case CourtOrdersTypes.CH110:
                    result = new CH110();
                    break;
                case CourtOrdersTypes.CH130:
                    result = new CH130();
                    break;
                /*case CourtOrdersTypes.EA110:
                    result = new EA110TROOrder();
                    break;
                case CourtOrdersTypes.EA130:
                    result = new EA110TROOrder();
                    break;*/
            }
            return result;
        }
    }
}