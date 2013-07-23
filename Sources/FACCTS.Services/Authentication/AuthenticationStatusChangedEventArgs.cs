using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Authentication
{
    public class AuthenticationStatusChangedEventArgs : EventArgs
    {
        public AuthenticationStatusChangedEventArgs(AuthenticationStatus authenticationStatus)
        {
            AuthenticationStatus = authenticationStatus;
        }

        public AuthenticationStatus AuthenticationStatus { get; private set; }
    }
}
