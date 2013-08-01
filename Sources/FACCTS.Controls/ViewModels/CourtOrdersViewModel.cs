using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Faccts.Model.Entities;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Reactive.Concurrency;
using System.Windows;
using FACCTS.Services;
using FACCTS.Server.Model.Enums;
using Faccts.Model.Entities;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CourtOrdersViewModel))]
    public class CourtOrdersViewModel : ReactiveConductor<IScreen>.Collection.OneActive, IReactiveNotifyPropertyChanged
    {
        private IAuthenticationService _authenticationService;
        public IDataContainer DataContainer { get; private set; }
        private MakeObjectReactiveHelper _reactiveHelper;
        private IWindowManager _windowManager;

        public CourtOrdersViewModel() : base()
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
            RxApp.DeferredScheduler = new DispatcherScheduler(Application.Current.Dispatcher);
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
            this.DisplayName = "Court Orders";
        }

        private void Authorized()
        {
            //this.NotifyOfPropertyChange(() => CourtCases);
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

        private void _authenticationService_AuthenticationStatusChanged(object sender, AuthenticationStatusChangedEventArgs e)
        {
            this.IsAuthenticated = e.AuthenticationStatus == AuthenticationStatus.Authenticated;
        }

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

        public void Activate(CourtOrderBase viewModel)
        {
            if (viewModel != null)
            {
                PopulateOrderIfNotExists(viewModel);
                this.ActivateItem(viewModel);
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

        protected void NotifyOfPropertyChanging([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanging != null)
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }

        private bool _isActive;
        public new bool IsActive
        {
            get
            {
                return _isActive;
            }
            private set
            {
                if (value == _isActive)
                    return;
                NotifyOfPropertyChanging();
                _isActive = value;
                NotifyOfPropertyChange();
            }
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

        public ObservableCollection<CourtCase> CourtCases
        {
            get 
            { 
                return DataContainer.CourtCases; 
            }
        }

        public TrackableCollection<Hearings> CurrentHearings
        {
            get
            {
                return DataContainer.Hearings;
            }
        }

        private Hearings _selectedHearing;

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

        private void PopulateOrderIfNotExists(CourtOrderBase orderViewModel)
        {
            if (SelectedHearing == null)
                return;
            CourtOrders courtOrder = SelectedHearing.CourtOrders.FirstOrDefault(o => o.OrderType == orderViewModel.OrderType);
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
            orderViewModel.Order = courtOrder.InnerOrder;
        }

        private OrderBase CreateOrder(CourtOrdersTypes courtOrdersType)
        {
            OrderBase result = null;
            switch (courtOrdersType)
            {
                case CourtOrdersTypes.DV110:
                    result = new DV110TROOrder();
                    break;
                case CourtOrdersTypes.DV130:
                    result = new DV130ROOrder();
                    break;
                case CourtOrdersTypes.CH110:
                    result = new CH110TROOrder();
                    break;
                case CourtOrdersTypes.CH130:
                    result = new CH130ROOrder();
                    break;
                case CourtOrdersTypes.EA110:
                    result = new EA110TROOrder();
                    break;
                case CourtOrdersTypes.EA130:
                    result = new EA110TROOrder();
                    break;
            }
            return result;
        }
    }
}
