using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
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

        private ILogger _logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();

        public ViewModelBase()
            : this(ServiceLocatorContainer.Locator.GetInstance<IAuthenticationService>(),
                ServiceLocatorContainer.Locator.GetInstance<IDataContainer>())
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
        }

        protected virtual void Authorized()
        {
            DataContainer.SearchCourtCases();
        }

        [ImportingConstructor]
        public ViewModelBase(IAuthenticationService authenticationService, IDataContainer dataContainer) : base()
        {
            _authenticationService = authenticationService;
            _authenticationService.AuthenticationStatusChanged += _authenticationService_AuthenticationStatusChanged;
            DataContainer = dataContainer;
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

        private string _title;
        public virtual string Title
        {
            get
            {
                return _title;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _title, value);
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

        public virtual IDataContainer DataContainer { get; private set; }

        public virtual void Cancel()
        {
            TryClose(false);
        }
        
    }
}
