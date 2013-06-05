﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Clients;

namespace FACCTS.Services.Authentication
{
    [Export(typeof(IAuthenticationService))]
    internal class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {
            _oauth2TokenEndpoint = ConfigurationManager.AppSettings["OAuthAuthenticationEndpoint"];
           
        }

        public void Authenticate(string userName, string password)
        {
            var client = new OAuth2Client(
               new Uri(_oauth2TokenEndpoint),
               _clientId,
               _clientSecret
               );
            var response = client.RequestAccessTokenUserName(userName, password, "urn:facctssecurity");
            _token = response.AccessToken;
            IsAuthenticated = true;
        }

        public bool IsAuthenticated { get; private set;}



        private string _oauth2TokenEndpoint;
        private string _token;
        private const string _clientId = "cce45e00-e8ff-4d0b-be2c-00e63b88c80b";
        private static readonly string _clientSecret = CryptoHelper.HashPassword("0feb1684-cb91-4a90-b5c1-04c7465c8b21");

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