using DotNetOpenAuth.OAuth2;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DotNetOpenAuth.Messaging;
using FACCTS.Server.Code;
using System.Web;
using System.Web.Mvc;
using FACCTS.Server.Services;
using FACCTS.Server.Models;
using FACCTS.Server.Model.DataModel;

namespace FACCTS.Server.Controllers
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OAuthController : Controller
    {
        public OAuthController() : base()
        {
            _authorizationServer = new AuthorizationServer(AuthorizationServerHost);
        }

        [Import]
        public IAuthorizationServerHost AuthorizationServerHost { protected get; set; }

        [Import]
        public IDataManager DataManager { protected get; set; }

        private readonly AuthorizationServer _authorizationServer;

        /// <summary>
        /// The OAuth 2.0 token endpoint.
        /// </summary>
        /// <returns>The response to the Client.</returns>
        public ActionResult Token()
        {
            return this._authorizationServer.HandleTokenRequest(this.Request).AsActionResult();
        }

        /// <summary>
        /// Prompts the user to authorize a client to access the user's private data.
        /// </summary>
        /// <returns>The browser HTML response that prompts the user to authorize the client.</returns>
        [System.Web.Mvc.Authorize, System.Web.Mvc.AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [HttpHeader("x-frame-options", "SAMEORIGIN")] // mitigates clickjacking
        public ActionResult Authorize()
        {
            var pendingRequest = this._authorizationServer.ReadAuthorizationRequest();
            if (pendingRequest == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Missing authorization request.");
            }

            var requestingClient = DataManager.ClientRepository.Get(c => c.ClientIdentifier == pendingRequest.ClientIdentifier).First();

            // Consider auto-approving if safe to do so.
            if (((OAuth2AuthorizationServer)this._authorizationServer.AuthorizationServerServices).CanBeAutoApproved(pendingRequest))
            {
                var approval = this._authorizationServer.PrepareApproveAuthorizationRequest(pendingRequest, HttpContext.User.Identity.Name);
                return this._authorizationServer.Channel.PrepareResponse(approval).AsActionResult();
            }

            var model = new AccountAuthorizeModel
            {
                ClientApp = requestingClient.Name,
                Scope = pendingRequest.Scope,
                AuthorizationRequest = pendingRequest,
            };

            return View(model);
        }

        /// <summary>
        /// Processes the user's response as to whether to authorize a Client to access his/her private data.
        /// </summary>
        /// <param name="isApproved">if set to <c>true</c>, the user has authorized the Client; <c>false</c> otherwise.</param>
        /// <returns>HTML response that redirects the browser to the Client.</returns>
        [System.Web.Mvc.Authorize, System.Web.Mvc.HttpPost, ValidateAntiForgeryToken]
        public ActionResult AuthorizeResponse(bool isApproved)
        {
            var pendingRequest = this._authorizationServer.ReadAuthorizationRequest();
            if (pendingRequest == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Missing authorization request.");
            }

            IDirectedProtocolMessage response;
            if (isApproved)
            {
                // The authorization we file in our database lasts until the user explicitly revokes it.
                // You can cause the authorization to expire by setting the ExpirationDateUTC
                // property in the below created ClientAuthorization.
                var client = DataManager.ClientRepository.Get(c => c.ClientIdentifier == pendingRequest.ClientIdentifier).First();
                DataManager.ClientAuthorizationRepository.Insert(new OAuth_ClientAuthorization
                    {
                        Scope = OAuthUtilities.JoinScopes(pendingRequest.Scope),
                        OAuth_Users = WebApiApplication.LoggedInUser,
                        CreatedOnUtc = DateTime.UtcNow,
                        OAuth_Client = client,
                    });
               

                // In this simple sample, the user either agrees to the entire scope requested by the client or none of it.  
                // But in a real app, you could grant a reduced scope of access to the client by passing a scope parameter to this method.
                response = this._authorizationServer.PrepareApproveAuthorizationRequest(pendingRequest, User.Identity.Name);
            }
            else
            {
                response = this._authorizationServer.PrepareRejectAuthorizationRequest(pendingRequest);
            }

            return this._authorizationServer.Channel.PrepareResponse(response).AsActionResult();
        }
    }
}
