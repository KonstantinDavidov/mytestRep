using Caliburn.Micro;
using FACCTS.Controls.Interfaces;
using FACCTS.Services.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using FACCTS;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export("UserLoginDialogViewModel")]
    public class UserLoginDialogViewModel : ViewModelBase
    {
        private IAuthenticationService _authenticationService;
        private IPasswordSupplier _passwordSupplier;

        [ImportingConstructor]
        public UserLoginDialogViewModel(IAuthenticationService authenticationService,
            IPasswordSupplier passwordSupplier
            ) : base()
        {
            if (authenticationService == null)
            {
                throw new ArgumentNullException("authenticationService");
            }
            if (passwordSupplier == null)
            {
                throw new ArgumentNullException("passwordSupplier");
            }
            _authenticationService = authenticationService;
            _passwordSupplier = passwordSupplier;
        }

        public void Login(string userName)
        {
            Execute.OnUIThreadAsync(() => _authenticationService.Authenticate(userName, _passwordSupplier.GetPassword()));
          
            if (_authenticationService.IsAuthenticated)
            {
                TryClose(true);
            }
        }
    }
}
