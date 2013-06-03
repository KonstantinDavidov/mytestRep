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

namespace FACCTS.Server.App_Start
{
    public class ProtocolConfig
    {
        private static ILog _logger = ServiceLocator.Current.GetInstance<ILog>();

        public static void RegisterProtocols(HttpConfiguration httpConfiguration, RouteCollection routes, IConfigurationRepository configuration, IUserRepository users, IRelyingPartyRepository relyingParties)
        {
            _logger.MethodEntry("ProtocolConfig.RegisterProtocols");
            var basicAuthConfig = CreateBasicAuthConfig(users);
            var clientAuthConfig = CreateClientAuthConfig();

            // require SSL for all web api endpoints
            httpConfiguration.MessageHandlers.Add(new RequireHttpsHandler());

            #region Protocols

            // oauth2 endpoint
            if (configuration.OAuth2.Enabled)
            {
                _logger.Info("OAuth2 is enabled.");
                // authorize endpoint
                routes.MapRoute(
                    "oauth2authorize",
                    Thinktecture.IdentityServer.Endpoints.Paths.OAuth2Authorize,
                    new { controller = "OAuth2Authorize", action = "index" }
                );
               
                // token endpoint
                routes.MapHttpRoute(
                    name: "oauth2token",
                    routeTemplate: Thinktecture.IdentityServer.Endpoints.Paths.OAuth2Token,
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
            var authConfig = new AuthenticationConfiguration
            {
                InheritHostClientIdentity = false,
                //RequireSsl = true,
                ClaimsAuthenticationManager = new ClaimsTransformer()
            };

            authConfig.AddBasicAuthentication((userName, password) => userRepository.ValidateUser(userName, password));
            return authConfig;
        }

        public static AuthenticationConfiguration CreateClientAuthConfig()
        {
            var authConfig = new AuthenticationConfiguration
            {
                InheritHostClientIdentity = false,
                //RequireSsl = true,
            };

            // accept arbitrary credentials on basic auth header,
            // validation will be done in the protocol endpoint
            authConfig.AddBasicAuthentication((id, secret) => true, retainPassword: true);
            return authConfig;
        }
    }
}