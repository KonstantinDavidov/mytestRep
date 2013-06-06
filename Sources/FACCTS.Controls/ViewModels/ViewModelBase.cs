using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using FACCTS.Services;
using FACCTS.Services.Authentication;
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

        public ViewModelBase()
            : this(ServiceLocatorContainer.Locator.GetInstance<IAuthenticationService>())
        {

        }

        [ImportingConstructor]
        public ViewModelBase(IAuthenticationService authenticationService) : base()
        {
            _authenticationService = authenticationService;
            _authenticationService.AuthenticationStatusChanged += _authenticationService_AuthenticationStatusChanged;
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

        
    }
}
