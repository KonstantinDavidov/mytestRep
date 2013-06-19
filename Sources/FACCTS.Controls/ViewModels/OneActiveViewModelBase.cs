using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public abstract class OneActiveViewModelBase : ReactiveConductor<IScreen>.Collection.OneActive, IReactiveNotifyPropertyChanged
    {
        private MakeObjectReactiveHelper _reactiveHelper;
        public OneActiveViewModelBase()
        {
            _reactiveHelper = new MakeObjectReactiveHelper(this);
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
        }

        protected abstract void Authorized();

        private void AuthenticationService_AuthenticationStatusChanged(object sender, AuthenticationStatusChangedEventArgs e)
        {
            IsAuthenticated = e.AuthenticationStatus == AuthenticationStatus.Authenticated;
        }

        
        private IAuthenticationService _authenticationService;
        [Import]
        public IAuthenticationService AuthenticationService 
        {
            protected get
            {
                return _authenticationService;
            }
            set
            {
                var oldValue = _authenticationService;
                if (oldValue != null)
                {
                    oldValue.AuthenticationStatusChanged -= AuthenticationService_AuthenticationStatusChanged;
                }
                _authenticationService = value;
                IsAuthenticated = _authenticationService.IsAuthenticated;
                if (_authenticationService != null)
                {
                    _authenticationService.AuthenticationStatusChanged += AuthenticationService_AuthenticationStatusChanged;
                }
            }
        }
        [Import]
        public virtual IDataContainer DataContainer { protected get; set; }

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

        private bool _isActive;
        public new bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if (_isActive == value)
                    return;
                this.NotifyOfPropertyChanging();
                _isActive = value;
                this.NotifyOfPropertyChange();
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
