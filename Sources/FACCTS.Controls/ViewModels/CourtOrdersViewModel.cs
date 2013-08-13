using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using Faccts.Model.Entities;
using Faccts.Model.Entities.Reporting;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.OrderModels;
using FACCTS.Services;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using ReactiveUI;
using CH110 = Faccts.Model.Entities.Reporting.CH110;
using CH130 = Faccts.Model.Entities.Reporting.CH130;
using Child = Faccts.Model.Entities.Child;
using CourtCase = Faccts.Model.Entities.CourtCase;
using CourtOrders = Faccts.Model.Entities.CourtOrders;
using DV110 = Faccts.Model.Entities.Reporting.DV110;
using DV130 = Faccts.Model.Entities.Reporting.DV130;
using DV140 = Faccts.Model.Entities.Reporting.DV140;
using EA110 = Faccts.Model.Entities.Reporting.EA110;
using EA130 = Faccts.Model.Entities.Reporting.EA130;

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
            var courtCase = new CourtCase
            {
                CaseNumber = "1234-567",
            };
            courtCase.Persons.Add(new Child
            {
                FirstName = "Carrie",
                LastName = "Smith",
                RelationToProtected = Relationship.C,
                DateOfBirth = DateTime.Now.AddYears(-10),
                Sex = Gender.F,
                PersonType = PersonType.Child
            });
            courtCase.Persons.Add(new Child
            {
                FirstName = "Sandra",
                LastName = "Smith",
                RelationToProtected = Relationship.C,
                DateOfBirth = DateTime.Now.AddYears(-8),
                Sex = Gender.F,
                PersonType = PersonType.Child
            });
            var hearing = new Hearings
            {
                CourtCase = courtCase,
                CourtOrders = new TrackableCollection<CourtOrders>
                {
                    new CourtOrders
                    {
                        OrderType = CourtOrdersTypes.DV110
                    },
                    new CourtOrders
                    {
                        OrderType = CourtOrdersTypes.DV130
                    },
                    new CourtOrders
                    {
                        OrderType = CourtOrdersTypes.CH110
                    },
                    new CourtOrders
                    {
                        OrderType = CourtOrdersTypes.CH130
                    },
                    new CourtOrders
                    {
                        OrderType = CourtOrdersTypes.EA110
                    },
                    new CourtOrders
                    {
                        OrderType = CourtOrdersTypes.EA130
                    }
                }
            };
            _currentHearings = new TrackableCollection<Hearings>
            {
                hearing
            };
        }


        [ImportingConstructor]
        public CourtOrdersViewModel(IAuthenticationService authenticationService
            , IDataContainer dataContainer
            , IWindowManager windowManager
            ):this()
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

        private TrackableCollection<Hearings> _currentHearings; 

        public TrackableCollection<Hearings> CurrentHearings
        {
            get { return _currentHearings; }
        }

        public Hearings SelectedHearing
        {
            get { return _selectedHearing ?? (_selectedHearing = CurrentHearings.FirstOrDefault()); }

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

        public void Activate(CourtOrderWithTypeViewModel viewModel, TreeViewItem selectedItem)
        {
            if (viewModel == null) return;
            switch (viewModel.OrderType)
            {
                case CourtOrdersTypes.CH110:
                    PopulateMasterOrderIfNotExists((CourtOrderBaseViewModel<CH110>) viewModel);
                    break;
                case CourtOrdersTypes.CH130:
                    PopulateMasterOrderIfNotExists((CourtOrderBaseViewModel<CH130>) viewModel);
                    break;
                case CourtOrdersTypes.DV110:
                    PopulateMasterOrderIfNotExists((CourtOrderBaseViewModel<DV110>) viewModel);
                    break;
                case CourtOrdersTypes.DV130:
                    PopulateMasterOrderIfNotExists((CourtOrderBaseViewModel<DV130>) viewModel);
                    break;
                case CourtOrdersTypes.EA110:
                    PopulateMasterOrderIfNotExists((CourtOrderBaseViewModel<EA110>) viewModel);
                    break;
                case CourtOrdersTypes.EA130:
                    PopulateMasterOrderIfNotExists((CourtOrderBaseViewModel<EA130>) viewModel);
                    break;
                case CourtOrdersTypes.DV140:
                    PopulateAttachmentOrderIfNotExists((CourtOrderBaseViewModel<DV140>) viewModel, selectedItem);
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

        private void PopulateMasterOrderIfNotExists<T>(CourtOrderBaseViewModel<T> orderViewModel) where T: OrderBase, new()
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
                SelectedHearing.CourtOrders.Add(courtOrder);
            }
            if (courtOrder.InnerOrder == null)
            {
                courtOrder.InnerOrder = new T {ModelOrder = courtOrder};
            }
            orderViewModel.Order = (T) courtOrder.InnerOrder;
        }

        private void PopulateAttachmentOrderIfNotExists<T>(CourtOrderBaseViewModel<T> orderViewModel,
            TreeViewItem treeNode) where T : OrderBase, new()
        {
            if (SelectedHearing == null)
                return;
            if (! (treeNode.Parent is TreeViewItem))
                return;
            OrderBase parentOrder;
            switch (((CourtOrderWithTypeViewModel) (treeNode.Parent as TreeViewItem).DataContext).OrderType)
            {
                case CourtOrdersTypes.DV110:
                    parentOrder = ((CourtOrderBaseViewModel<DV110>) (treeNode.Parent as TreeViewItem).DataContext).Order;
                    break;
                case CourtOrdersTypes.DV130:
                    parentOrder = ((CourtOrderBaseViewModel<DV130>) (treeNode.Parent as TreeViewItem).DataContext).Order;
                    break;
                case CourtOrdersTypes.DV140:
                    parentOrder = ((CourtOrderBaseViewModel<DV140>) (treeNode.Parent as TreeViewItem).DataContext).Order;
                    break;
                default:
                    parentOrder = null;
                    break;
            }
            if (parentOrder == null)
                return;
            CourtOrders order =
                parentOrder.ModelOrder.Attachments.FirstOrDefault(o => o.OrderType == orderViewModel.OrderType);
            if (order == null)
            {
                order = new CourtOrders
                {
                    Hearings = SelectedHearing,
                    OrderType = orderViewModel.OrderType
                };
                parentOrder.ModelOrder.Attachments.Add(order);
            }
            if (order.InnerOrder == null)
            {
                order.InnerOrder = new T {ModelOrder = order};
            }
            orderViewModel.Order = (T) order.InnerOrder;
        }
    }
}