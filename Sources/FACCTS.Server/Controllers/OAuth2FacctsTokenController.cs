using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Thinktecture.IdentityModel.Authorization;
using Thinktecture.IdentityServer;
using Thinktecture.IdentityServer.Protocols;
using Thinktecture.IdentityServer.Protocols.OAuth2;
using Thinktecture.IdentityServer.Repositories;
using Protocols = Thinktecture.IdentityServer.Protocols;
using Client = Thinktecture.IdentityServer.Models.Client;

namespace FACCTS.Server.Controllers
{
    //public class OAuth2FacctsTokenController : ApiController
    //{
    //    [Import]
    //    public IUserRepository UserRepository { get; set; }

    //    [Import]
    //    public IConfigurationRepository ConfigurationRepository { get; set; }

    //    [Import]
    //    public IClientsRepository ClientsRepository { get; set; }

    //    public OAuth2FacctsTokenController()
    //    {
    //        AttributedModelServices.SatisfyImportsOnce((ICompositionService)Container.Current, (object)this);
    //    }

    //    public OAuth2FacctsTokenController(IUserRepository userRepository, IConfigurationRepository configurationRepository, IClientsRepository clientsRepository)
    //    {
    //        this.UserRepository = userRepository;
    //        this.ConfigurationRepository = configurationRepository;
    //        this.ClientsRepository = clientsRepository;
    //    }

    //    public HttpResponseMessage Post(TokenRequest tokenRequest)
    //    {
    //        Tracing.Information("OAuth2 endpoint called.");
    //        Client client = (Client)null;
    //        if (!this.ValidateClient(out client))
    //        {
    //            Tracing.Error("Invalid client: " + ClaimsPrincipal.Current.Identity.Name);
    //            return this.OAuthErrorResponseMessage("invalid_client");
    //        }
    //        else
    //        {
    //            Tracing.Information("Client: " + client.Name);
    //            string defaultHttpTokenType = this.ConfigurationRepository.Global.DefaultHttpTokenType;
    //            EndpointReference appliesTo;
    //            try
    //            {
    //                appliesTo = new EndpointReference(tokenRequest.Scope);
    //                Tracing.Information("OAuth2 endpoint called for scope: " + tokenRequest.Scope);
    //            }
    //            catch
    //            {
    //                Tracing.Error("Malformed scope: " + tokenRequest.Scope);
    //                return this.OAuthErrorResponseMessage("invalid_scope");
    //            }
    //            if (string.Equals(tokenRequest.Grant_Type, "password", StringComparison.Ordinal) && this.ConfigurationRepository.OAuth2.EnableResourceOwnerFlow)
    //            {
    //                if (client.AllowResourceOwnerFlow)
    //                    return this.ProcessResourceOwnerCredentialRequest(tokenRequest.UserName, tokenRequest.Password, appliesTo, defaultHttpTokenType, client);
    //                Tracing.Error("Client is not allowed to use the resource owner password flow:" + client.Name);
    //            }
    //            Tracing.Error("invalid grant type: " + tokenRequest.Grant_Type);
    //            return this.OAuthErrorResponseMessage("unsupported_grant_type");
    //        }
    //    }

    //    private HttpResponseMessage ProcessResourceOwnerCredentialRequest(string userName, string password, EndpointReference appliesTo, string tokenType, Client client)
    //    {
    //        Tracing.Information("Starting resource owner password credential flow for client: " + client.Name);
    //        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
    //        {
    //            Tracing.Error("Invalid resource owner credentials for: " + appliesTo.Uri.AbsoluteUri);
    //            return this.OAuthErrorResponseMessage("invalid_grant");
    //        }
    //        else
    //        {
    //            AuthenticationHelper authenticationHelper = new AuthenticationHelper();
    //            if (this.UserRepository.ValidateUser(userName, password))
    //            {
    //                ClaimsPrincipal principal = authenticationHelper.CreatePrincipal(userName, "OAuth2", (IEnumerable<Claim>)new Claim[2]
    //                  {
    //                    new Claim("http://identityserver.thinktecture.com/claims/client", client.Name),
    //                    new Claim("http://identityserver.thinktecture.com/claims/scope", appliesTo.Uri.AbsoluteUri)
    //                  });
    //                if (!ClaimsAuthorization.CheckAccess(principal, "Issue", new string[1]
    //                      {
    //                        "OAuth2"
    //                      }))
    //                {
    //                    Tracing.Error("OAuth2 endpoint authorization failed for user: " + userName);
    //                    return this.OAuthErrorResponseMessage("invalid_grant");
    //                }
    //                else
    //                {
    //                    TokenResponse response;
    //                    if (new STS().TryIssueToken(appliesTo, principal, tokenType, out response))
    //                        return this.Request.CreateResponse<TokenResponse>(HttpStatusCode.OK, response);
    //                    else
    //                        return this.OAuthErrorResponseMessage("invalid_request");
    //                }
    //            }
    //            else
    //            {
    //                Tracing.Error("Resource owner credential validation failed: " + userName);
    //                return this.OAuthErrorResponseMessage("invalid_grant");
    //            }
    //        }
    //    }

    //    private HttpResponseMessage OAuthErrorResponseMessage(string error)
    //    {
    //        return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format("{{ \"{0}\": \"{1}\" }}", (object)"error", (object)error));
    //    }

    //    private bool ValidateClient(out Client client)
    //    {
    //        client = null;

    //        if (!ClaimsPrincipal.Current.Identity.IsAuthenticated)
    //        {
    //            Tracing.Error("Anonymous client.");
    //            return false;
    //        }

    //        var passwordClaim = ClaimsPrincipal.Current.FindFirst("password");
    //        if (passwordClaim == null)
    //        {
    //            Tracing.Error("No client secret provided.");
    //            return false;
    //        }

    //        return ClientsRepository.ValidateAndGetClient(
    //            ClaimsPrincipal.Current.Identity.Name,
    //            passwordClaim.Value,
    //            out client);
    //    }
    //}
}
