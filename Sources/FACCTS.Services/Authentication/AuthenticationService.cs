using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Authentication
{
    [Export(typeof(IAuthenticationService))]
    internal class AuthenticationService : IAuthenticationService
    {
        private string _token;

        public bool IsAuthenticated { get; protected set; }

        public string GetToken()
        {
            if (!IsAuthenticated)
            {
                throw new AuthenticationException("FACCTS has not been authenticated. Try to authenticate or call the system administrator please.");
            }
            return _token;
        }
    }
}
