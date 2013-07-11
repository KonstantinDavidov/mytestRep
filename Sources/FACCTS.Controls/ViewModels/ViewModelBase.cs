using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using FACCTS.Controls.Events;
using FACCTS.Services;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using FACCTS.Services.Logger;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class ViewModelBase : ReactiveScreen
    {
        private IAuthenticationService _authenticationService;
        private IEventAggregator _eventAggregator;

        private ILogger _logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();

        public ViewModelBase()
            : this(ServiceLocatorContainer.Locator.GetInstance<IAuthenticationService>(),
                ServiceLocatorContainer.Locator.GetInstance<IDataContainer>(),
                ServiceLocatorContainer.Locator.GetInstance<IEventAggregator>()
            )
        {
            this.WhenAny(x => x.IsAuthenticated, x => x.IsActive, (x, y) => x.Value && y.Value)
                .Subscribe(x =>
                {
                    if (x)
                    {
                        _logger.InfoFormat("IsAuthenticated = {0}.", x);
                        Authorized();
                    }
                });
            this.WhenAny(x => x.IsDirty, x => x.Value)
                .Subscribe(x =>
                {
                    this.NotifyOfPropertyChange(() => DisplayName);
                });
            
            IsAuthenticated = _authenticationService.IsAuthenticated;
            if (IsAuthenticated)
            {
                Authorized();
            }
        }

        public override string DisplayName
        {
            get
            {
                if (this.IsDirty)
                {
                    return string.Format("{0} *", base.DisplayName);
                }
                else
                {
                    return base.DisplayName;
                }
            }
            set
            {
                base.DisplayName = value;
            }
        }

        protected virtual void Authorized()
        {
            DataContainer.SearchCourtCases();
            DataContainer.UpdateDictionaries();
        }

        [ImportingConstructor]
        public ViewModelBase(IAuthenticationService authenticationService, 
            IDataContainer dataContainer,
            IEventAggregator eventAggregator
            ) : base()
        {
            _logger.InfoFormat("{0}.{}1", this.GetType().Name, "ctor");
            _authenticationService = authenticationService;
            _authenticationService.AuthenticationStatusChanged += _authenticationService_AuthenticationStatusChanged;
            _eventAggregator = eventAggregator;
            DataContainer = dataContainer;

            _eventAggregator.Subscribe(this);
        }

        private void _authenticationService_AuthenticationStatusChanged(object sender, AuthenticationStatusChangedEventArgs e)
        {
            this.IsAuthenticated = e.AuthenticationStatus == AuthenticationStatus.Authenticated;
        }

        [Import]
        public IWindowManager WindowManager { get; protected set; }

        private bool _isAuthenticated;
        public bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isAuthenticated, value);
            }
        }

        private bool _isValid;
        public virtual bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isValid, value);
            }
        }

        private bool _isDirty;
        public virtual bool IsDirty
        {
            get
            {
                return _isDirty;
            }
            protected set
            {
                this.RaiseAndSetIfChanged(ref _isDirty, value);
            }
        }

        private IDataContainer _dataContainer;
        public virtual IDataContainer DataContainer 
        {
            get
            {
                return _dataContainer;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref _dataContainer, value);
            } 
        }

        public virtual void Cancel()
        {
            _logger.InfoFormat("Closing {0}", this.GetType().Name);
            TryClose(false);
        }


        protected virtual void SaveData()
        {

        }
    }
}
