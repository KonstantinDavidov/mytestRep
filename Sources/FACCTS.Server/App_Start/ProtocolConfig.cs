using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Thinktecture.IdentityModel.Tokens.Http;
using Thinktecture.IdentityServer;
using Thinktecture.IdentityServer.Repositories;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Http;
using Thinktecture.IdentityModel.Clients;
using Thinktecture.IdentityServer.Protocols.WSTrust;
using Thinktecture.IdentityServer.TokenService;
using System.ServiceModel.Activation;
using log4net;
using FACCTS.Server.Common;
using Thinktecture.IdentityModel.Constants;
using Microsoft.Practices.ServiceLocation;

namespace FACCTS.Server.App_Start
{
    public class ProtocolConfig
    {
        private static ILog _logger = ServiceLocator.Current.GetInstance<ILog>();

        public static void RegisterProtocols(HttpConfiguration httpConfiguration, RouteCollection routes, IConfigurationRepository configuration, IUserRepository users, IRelyingPartyRepository relyingParties)
        {
            _logger.MethodEntry("ProtocolConfig.RegisterProtocols");
            var basicAuthConfig = CreateBasicAuthConfig(users);
            var clientAuthConfig = CreateClientAuthConfig(httpConfiguration, configuration);

            // require SSL for all web api endpoints
            httpConfiguration.MessageHandlers.Add(new RequireHttpsHandler());

            #region Protocols

            // oauth2 endpoint
            if (configuration.OAuth2.Enabled)
            {
                _logger.Info("OAuth2 is enabled.");
                // authorize endpoint
                routes.MapRoute(
                    "facctsoauth2authorize",
                    Endpoints.OAuth2Authorize,
                    new { controller = "OAuth2Authorize", action = "index" }
                );
               
                // token endpoint
                routes.MapHttpRoute(
                    name: "facctsoauth2token",
                    routeTemplate: Endpoints.OAuth2Token,
                    defaults: new { controller = "OAuth2Token" },
                    constraints: null,
                    handler: new AuthenticationHandler(clientAuthConfig, httpConfiguration)
                );
            }

           

            // simple http endpoint
            if (configuration.SimpleHttp.Enabled)
            {
                _logger.Info("SimpleHTTP is enabled.");
                routes.MapHttpRoute(
                    name: "simplehttp",
                    routeTemplate: Thinktecture.IdentityServer.Endpoints.Paths.SimpleHttp,
                    defaults: new { controller = "SimpleHttp" },
                    constraints: null,
                    handler: new AuthenticationHandler(basicAuthConfig, httpConfiguration)
                );
            }

            // ws-trust
            if (configuration.WSTrust.Enabled)
            {
                _logger.Info("WSTrust is enabled.");
                routes.Add(new ServiceRoute(
                    Thinktecture.IdentityServer.Endpoints.Paths.WSTrustBase,
                    new TokenServiceHostFactory(),
                    typeof(TokenServiceConfiguration))
                );
            }
            #endregion

            _logger.MethodExit("ProtocolConfig.RegisterProtocols");
        }

        public static AuthenticationConfiguration CreateBasicAuthConfig(IUserRepository userRepository)
        {
            _logger.Info("Creating basic auth configuration...");
            var authConfig = new AuthenticationConfiguration
            {
                InheritHostClientIdentity = false,
                //RequireSsl = true,
                ClaimsAuthenticationManager = new FACCTS.Server.Data.ClaimsTransformer()
            };

            authConfig.AddBasicAuthentication((userName, password) => userRepository.ValidateUser(userName, password));
            _logger.Info("Basic auth configuration done!");
            return authConfig;
        }

        public static AuthenticationConfiguration CreateClientAuthConfig(HttpConfiguration httpConfiguration, IConfigurationRepository configuration)
        {
            _logger.Info("Creating client auth configuration... ");
            var authConfig = new AuthenticationConfiguration
            {
                InheritHostClientIdentity = false,
                RequireSsl = false,
                //EnableSessionToken = true,
               // DefaultAuthenticationScheme = JwtConstants.JWT,
            };

            // accept arbitrary credentials on basic auth header,
            // validation will be done in the protocol endpoint
            authConfig.AddBasicAuthentication((id, secret) => true, retainPassword: true);
            authConfig.AddJsonWebToken(
                issuer: configuration.Global.IssuerUri,
                audience: FACCTS.Server.Common.Constants.RelyingParties.FACCTS,
                signingKey: configuration.Keys.SymmetricSigningKey
                );
            httpConfiguration.MessageHandlers.Add(new AuthenticationHandler(authConfig));
            _logger.Info("Client auth configuration done! ");
            return authConfig;
        }
    }
}