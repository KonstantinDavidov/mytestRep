using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Authentication
{
    public interface IAuthenticationService
    {
        string GetToken();
        void Authenticate(string userName, string password);
        bool IsAuthenticated { get; }
        User CurrentUser { get; }
        event EventHandler<AuthenticationStatusChangedEventArgs> AuthenticationStatusChanged;
    }
}
