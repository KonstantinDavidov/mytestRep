using Faccts.Model.Entities;
using FACCTS.Services.Data;
using FACCTS.Services.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Clients;

namespace FACCTS.Services.Authentication
{
    [Export(typeof(IAuthenticationService))]
    internal class AuthenticationService : IAuthenticationService
    {
        [ImportingConstructor]
        public AuthenticationService(IDialogService dialogService)
        {
            if (dialogService == null)
            {
                throw new ArgumentNullException("dialogService");
            }
            _dialogService = dialogService;
            _oauth2TokenEndpoint = ConfigurationManager.AppSettings["OAuthAuthenticationEndpoint"];
            UpdateAuthStatus(AuthenticationStatus.Offline);
           
        }

        private IDialogService _dialogService;

        public void Authenticate(string userName, string password)
        {
            UpdateAuthStatus(AuthenticationStatus.TryingToAuthenticate);
            var client = new FacctsOAuth2Client(
               new Uri(_oauth2TokenEndpoint),
               _clientId,
               _clientSecret
               );
            
            var response = client.RequestAccessTokenUserName(userName, password, "urn:facctssecurity");
            if (response != null)
            {
                _token = response.AccessToken;
                UpdateAuthStatus(AuthenticationStatus.Authenticated);
            }
            else
            {
                UpdateAuthStatus(AuthenticationStatus.Offline);
                _dialogService.MessageBox("Authentication failed. Please try to use correct credentials or notify the system administrator", "Authentication", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
            
        }

        public bool IsAuthenticated 
        { 
            get
            {
                return _authenticationStatus == AuthenticationStatus.Authenticated;
            }
        }

        public event EventHandler<AuthenticationStatusChangedEventArgs> AuthenticationStatusChanged;
        private AuthenticationStatus _authenticationStatus;

        private void UpdateAuthStatus(AuthenticationStatus status)
        {
            _authenticationStatus = status;
            if (AuthenticationStatusChanged != null)
            {
                AuthenticationStatusChanged(this, new AuthenticationStatusChangedEventArgs(status));
            }
        }

        private string _oauth2TokenEndpoint;
        private string _token;
        private const string _clientId = "cce45e00-e8ff-4d0b-be2c-00e63b88c80b";
        private static readonly string _clientSecret = "0feb1684-cb91-4a90-b5c1-04c7465c8b21";

        public string GetToken()
        {
            if (!IsAuthenticated)
            {
                throw new AuthenticationException("FACCTS has not been authenticated. Try to authenticate or call the system administrator please.");
            }
            return _token;
        }

        private User _currentUser;
        public User CurrentUser 
        { 
            get
            {
                if (_currentUser == null)
                {
                    _currentUser = Users.GetCurrent();
                }
                return _currentUser;
            }
        }
    }
}
