﻿using FACCTS.Services.Logger;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Clients;
using Thinktecture.IdentityModel.Tokens.Http;

namespace FACCTS.Services
{
    public class FacctsOAuth2Client 
    {
        protected ILogger Logger { get; set; }

        HttpClient _client;

        protected HttpClient HttpClient
        {
            get
            {
                return _client;
            }
        }

        public FacctsOAuth2Client(Uri address)
        {
            _client = new HttpClient { BaseAddress = address };
            Logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();
        }

        public FacctsOAuth2Client(Uri address, string clientId, string clientSecret)
            : this(address)
        {
            _client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(clientId, clientSecret);
        }

        public static string CreateCodeFlowUrl(string endpoint, string clientId, string scope, string redirectUri, string state = null)
        {
            return CreateUrl(endpoint, clientId, scope, redirectUri, OAuth2Constants.ResponseTypes.Code, state);
        }

        public static string CreateImplicitFlowUrl(string endpoint, string clientId, string scope, string redirectUri, string state = null)
        {
            return CreateUrl(endpoint, clientId, scope, redirectUri, OAuth2Constants.ResponseTypes.Token, state);
        }

        private static string CreateUrl(string endpoint, string clientId, string scope, string redirectUri, string responseType, string state = null)
        {
            var url = string.Format("{0}?client_id={1}&scope={2}&redirect_uri={3}&response_type={4}",
                endpoint,
                clientId,
                scope,
                redirectUri,
                responseType);

            if (!string.IsNullOrWhiteSpace(state))
            {
                url = string.Format("{0}&state={1}", url, state);
            }

            return url;
        }

        public AccessTokenResponse RequestAccessTokenUserName(string userName, string password, string scope)
        {
            Logger.Info("Requesting the token from the server...");
            var response = _client.PostAsync("", CreateFormUserName(userName, password, scope)).Result;
            if (!response.IsSuccessStatusCode)
            {
                Logger.Info("Requesting the token failed.");
                Logger.InfoFormat("Response status: {0}", response.StatusCode);
                Logger.InfoFormat("ReasonPhrase: {0}", response.ReasonPhrase);
                //Logger.Fatal("User authentication failed. Please try again using correct user name/password or notify the system administrator");
                
                return null;
            }
            response.EnsureSuccessStatusCode();

            var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            return CreateResponseFromJson(json);
        }

        public AccessTokenResponse RequestAccessTokenRefreshToken(string refreshToken)
        {
            var response = _client.PostAsync("", CreateFormRefreshToken(refreshToken)).Result;
            response.EnsureSuccessStatusCode();

            var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            return CreateResponseFromJson(json);
        }

        public AccessTokenResponse RequestAccessTokenCode(string code)
        {
            var response = _client.PostAsync("", CreateFormCode(code)).Result;
            response.EnsureSuccessStatusCode();

            var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            return CreateResponseFromJson(json);
        }

        public AccessTokenResponse RequestAccessTokenAssertion(string assertion, string assertionType, string scope)
        {
            var response = _client.PostAsync("", CreateFormAssertion(assertion, assertionType, scope)).Result;
            response.EnsureSuccessStatusCode();

            var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            return CreateResponseFromJson(json);
        }

        protected virtual FormUrlEncodedContent CreateFormUserName(string userName, string password, string scope)
        {
            var values = new Dictionary<string, string>
            {
                { OAuth2Constants.GrantType, OAuth2Constants.GrantTypes.Password },
                { OAuth2Constants.UserName, userName },
                { OAuth2Constants.Password, password },
                { OAuth2Constants.Scope, scope }
            };

            return new FormUrlEncodedContent(values);
        }

        protected virtual FormUrlEncodedContent CreateFormRefreshToken(string refreshToken)
        {
            var values = new Dictionary<string, string>
            {
                { OAuth2Constants.GrantType, OAuth2Constants.GrantTypes.RefreshToken },
                { OAuth2Constants.GrantTypes.RefreshToken, refreshToken}
            };

            return new FormUrlEncodedContent(values);
        }

        protected virtual FormUrlEncodedContent CreateFormCode(string code)
        {
            var values = new Dictionary<string, string>
            {
                { OAuth2Constants.GrantType, OAuth2Constants.GrantTypes.AuthorizationCode },
                { OAuth2Constants.Code, code}
            };

            return new FormUrlEncodedContent(values);
        }

        protected virtual FormUrlEncodedContent CreateFormAssertion(string assertion, string assertionType, string scope)
        {
            var values = new Dictionary<string, string>
            {
                { OAuth2Constants.GrantType, assertionType },
                { OAuth2Constants.Assertion, assertion },
                { OAuth2Constants.Scope, scope }
            };

            return new FormUrlEncodedContent(values);
        }

        private AccessTokenResponse CreateResponseFromJson(JObject json)
        {
            var response = new AccessTokenResponse
            {
                AccessToken = json["access_token"].ToString(),
                //TokenType = json["token_type"].ToString(),
                ExpiresIn = int.Parse(json["expires_in"].ToString())
            };

            if (json["refresh_token"] != null)
            {
                response.RefreshToken = json["refresh_token"].ToString();
            }

            return response;
        }
    }
}
