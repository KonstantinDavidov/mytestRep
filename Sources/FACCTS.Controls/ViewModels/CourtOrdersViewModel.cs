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

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CourtOrdersViewModel))]
    public class CourtOrdersViewModel : ReactiveConductor<IScreen>.Collection.OneActive, IReactiveNotifyPropertyChanged
    {
        private IAuthenticationService _authenticationService;
        public IDataContainer DataContainer { get; private set; }
        private MakeObjectReactiveHelper _reactiveHelper;

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
        public CourtOrdersViewModel(IAuthenticationService authenticationService, IDataContainer dataContainer)
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
            _authenticationService = authenticationService;
            _authenticationService.AuthenticationStatusChanged += _authenticationService_AuthenticationStatusChanged;
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

        public void Activate(ViewModelBase viewModel)
        {
            if (viewModel != null)
            {
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

    }
}
