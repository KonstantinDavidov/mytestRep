using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Authorization.Mvc;
using Thinktecture.IdentityServer;
using Thinktecture.IdentityServer.Models;
using Thinktecture.IdentityServer.Protocols;
using Thinktecture.IdentityServer.Protocols.OAuth2;
using Thinktecture.IdentityServer.Repositories;
using Protocols = Thinktecture.IdentityServer.Protocols;

namespace FACCTS.Server.Controllers
{
  //[ClaimsAuthorize("Issue", new string[] {"OAuth2"})]
  //public class OAuth2FacctsAuthorizeController : Controller
  //{
  //  [Import]
  //  public IClientsRepository Clients { get; set; }

  //  [Import]
  //  public IConfigurationRepository Configuration { get; set; }

  //  [Import]
  //  public IRelyingPartyRepository RPRepository { get; set; }

  //  public OAuth2FacctsAuthorizeController()
  //  {
  //    AttributedModelServices.SatisfyImportsOnce((ICompositionService) Container.Current, (object) this);
  //  }

  //  public OAuth2FacctsAuthorizeController(IConfigurationRepository configuration, IClientsRepository client, IRelyingPartyRepository rpRepository)
  //  {
  //    this.Configuration = configuration;
  //    this.Clients = client;
  //    this.RPRepository = rpRepository;
  //  }

  //  private ActionResult CheckRequest(AuthorizeRequest request, out Client client)
  //  {
  //      if (request == null)
  //      {
  //          client = null;
  //          ViewBag.Message = "Invalid request parameters";
  //          Tracing.Error(ViewBag.Message);
  //          return View("Error");
  //      }

  //      // validate client
  //      if (!Clients.TryGetClient(request.client_id, out client))
  //      {
  //          ViewBag.Message = "Invalid client_id : " + request.client_id;
  //          Tracing.Error(ViewBag.Message);
  //          return View("Error");
  //      }

  //      // validate redirect uri
  //      if (string.IsNullOrEmpty(request.redirect_uri) ||
  //          !string.Equals(request.redirect_uri, client.RedirectUri.AbsoluteUri, StringComparison.OrdinalIgnoreCase))
  //      {
  //          ViewBag.Message = "The redirect_uri in the request: " + request.redirect_uri + " did not match a registered redirect URI.";
  //          Tracing.Error(ViewBag.Message);
  //          return View("Error");
  //      }

  //      Uri redirectUrl;
  //      if (Uri.TryCreate(request.redirect_uri, UriKind.Absolute, out redirectUrl))
  //      {
  //          if (redirectUrl.Scheme == Uri.UriSchemeHttp)
  //          {
  //              Tracing.Error("Redirect URI not over SSL : " + request.redirect_uri);
  //              return ClientError(client.RedirectUri, OAuth2Constants.Errors.InvalidRequest, string.Empty, request.state);
  //          }
  //      }
  //      else
  //      {
  //          Tracing.Error("Redirect URI not a valid URI : " + request.redirect_uri);
  //          return ClientError(client.RedirectUri, OAuth2Constants.Errors.InvalidRequest, string.Empty, request.state);
  //      }

  //      if (String.IsNullOrWhiteSpace(request.response_type))
  //      {
  //          Tracing.Error("response_type is null or empty");
  //          return ClientError(client.RedirectUri, OAuth2Constants.Errors.InvalidRequest, string.Empty, request.state);
  //      }

  //      // check response type (only code and token are supported)
  //      if (!request.response_type.Equals(OAuth2Constants.ResponseTypes.Token, StringComparison.Ordinal) &&
  //          !request.response_type.Equals(OAuth2Constants.ResponseTypes.Code, StringComparison.Ordinal))
  //      {
  //          Tracing.Error("response_type is not token or code: " + request.response_type);
  //          return ClientError(client.RedirectUri, OAuth2Constants.Errors.UnsupportedResponseType, string.Empty, request.state);
  //      }

  //      // validate scope (must be a valid URI)
  //      Uri uri;
  //      if (!Uri.TryCreate(request.scope, UriKind.Absolute, out uri))
  //      {
  //          Tracing.Error("scope is not a URI: " + request.scope);
  //          return ClientError(client.RedirectUri, OAuth2Constants.Errors.InvalidScope, request.response_type, request.state);
  //      }

  //      // validate if request grant type is allowed for client (implicit vs code flow)
  //      if (request.response_type.Equals(OAuth2Constants.ResponseTypes.Token) &&
  //          !client.AllowImplicitFlow)
  //      {
  //          Tracing.Error("response_type is token and client does not allow implicit flow. client: " + client.Name);
  //          return ClientError(client.RedirectUri, OAuth2Constants.Errors.UnsupportedResponseType, request.response_type, request.state);
  //      }

  //      if (request.response_type.Equals(OAuth2Constants.ResponseTypes.Code) &&
  //          !client.AllowCodeFlow)
  //      {
  //          Tracing.Error("response_type is code and client does not allow code flow. client: " + client.Name);
  //          return ClientError(client.RedirectUri, OAuth2Constants.Errors.UnsupportedResponseType, request.response_type, request.state);
  //      }

  //      return null;
  //  }

  //  private ActionResult ClientError(Uri redirectUri, string error, string responseType, string state = null)
  //  {
  //      string url;
  //      string separator = "?";

  //      if (responseType == OAuth2Constants.ResponseTypes.Token)
  //      {
  //          separator = "#";
  //      }

  //      if (string.IsNullOrEmpty(state))
  //      {
  //          url = string.Format("{0}{1}error={2}", redirectUri.AbsoluteUri, separator, error);
  //      }
  //      else
  //      {
  //          url = string.Format("{0}{1}error={2}&state={3}", redirectUri.AbsoluteUri, separator, error, Server.UrlEncode(state));
  //      }

  //      return new RedirectResult(url);
  //  }

  //  [System.Web.Mvc.HttpGet]
  //  [System.Web.Mvc.ActionName("Index")]
  //  public ActionResult HandleRequest(AuthorizeRequest request)
  //  {
  //    Client client;
  //    ActionResult actionResult1 = this.CheckRequest(request, out client);
  //    if (actionResult1 != null)
  //      return actionResult1;
  //    if (request.response_type.Equals("token", StringComparison.Ordinal) || request.response_type.Equals("code", StringComparison.Ordinal))
  //    {
  //      if (this.Configuration.OAuth2.EnableConsent)
  //      {
  //        RelyingParty relyingParty;
  //        if (this.RPRepository.TryGet(request.scope, out relyingParty))
  //          return (ActionResult) this.View("ShowConsent", (object) new OAuth2ConsentViewModel()
  //          {
  //            ResourceUri = relyingParty.Realm.AbsoluteUri,
  //            ResourceName = relyingParty.Name,
  //            ClientName = client.ClientId
  //          });
  //      }
  //      else
  //      {
  //        ActionResult actionResult2 = this.PerformGrant(request, client);
  //        if (actionResult2 != null)
  //          return actionResult2;
  //      }
  //    }
  //    return this.Error(client.RedirectUri, "unsupported_response_type", request.state);
  //  }

  //  [System.Web.Mvc.HttpPost]
  //  [System.Web.Mvc.ActionName("Index")]
  //  [ValidateAntiForgeryToken]
  //  public ActionResult HandleResponse(string button, AuthorizeRequest request)
  //  {
  //    Client client;
  //    ActionResult actionResult1 = this.CheckRequest(request, out client);
  //    if (actionResult1 != null)
  //      return actionResult1;
  //    if (button == "no")
  //      return this.Error(client.RedirectUri, "access_denied", request.state);
  //    if (button == "yes")
  //    {
  //      ActionResult actionResult2 = this.PerformGrant(request, client);
  //      if (actionResult2 != null)
  //        return actionResult2;
  //    }
  //    return this.Error(client.RedirectUri, "unsupported_response_type", request.state);
  //  }

  //  private ActionResult PerformGrant(AuthorizeRequest request, Client client)
  //  {
  //    if (request.response_type.Equals("token", StringComparison.Ordinal))
  //      return this.HandleImplicitGrant(request, client);
  //    if (request.response_type.Equals("code", StringComparison.Ordinal))
  //      return this.HandleAuthorizationCodeGrant(request, client);
  //    else
  //      return (ActionResult) null;
  //  }

  //  private ActionResult HandleAuthorizationCodeGrant(AuthorizeRequest request, Client client)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  private ActionResult HandleImplicitGrant(AuthorizeRequest request, Client client)
  //  {
  //    TokenResponse response;
  //    if (!new STS().TryIssueToken(new EndpointReference(request.scope), ClaimsPrincipal.Current, this.Configuration.Global.DefaultHttpTokenType, out response))
  //      return this.Error(client.RedirectUri, "invalid_request", request.state);
  //    string str = string.Format("access_token={0}&token_type={1}&expires_in={2}", (object) response.AccessToken, (object) response.TokenType, (object) response.ExpiresIn);
  //    if (!string.IsNullOrEmpty(request.state))
  //      str = string.Format("{0}&state={1}", (object) str, (object) request.state);
  //    return (ActionResult) this.Redirect(string.Format("{0}#{1}", (object) client.RedirectUri.AbsoluteUri, (object) str));
  //  }

  //  private ActionResult Error(Uri redirectUri, string error, string state = null)
  //  {
  //    return (ActionResult) new RedirectResult(!string.IsNullOrEmpty(state) ? string.Format("{0}#error={1}&state={2}", (object) redirectUri.AbsoluteUri, (object) error, (object) state) : string.Format("{0}#error={1}", (object) redirectUri.AbsoluteUri, (object) error));
  //  }
  //}
}
