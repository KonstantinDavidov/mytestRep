using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Authorization.Mvc;
using Thinktecture.IdentityServer;
using Thinktecture.IdentityServer.Protocols.OAuth2;
using Thinktecture.IdentityServer.Repositories;
using Protocols = Thinktecture.IdentityServer.Protocols;

namespace FACCTS.Server.Controllers
{
    [ClaimsAuthorize(Constants.Actions.Issue, Constants.Resources.OAuth2)]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OAuth2FacctsAuthorizeController : Protocols.OAuth2.OAuth2AuthorizeController
    {
        public OAuth2FacctsAuthorizeController(IConfigurationRepository configurationRepository,
            IClientsRepository clientsRepository, IRelyingPartyRepository relyingPartyRepository)
            : base(configurationRepository, clientsRepository, relyingPartyRepository)
        {

        }

        [System.Web.Mvc.ActionName("Index")]
        [System.Web.Mvc.HttpGet]
        public new ActionResult HandleRequest(AuthorizeRequest request)
        {
            return base.HandleRequest(request);
        }

        [System.Web.Mvc.ActionName("Index")]
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public new ActionResult HandleResponse(string button, AuthorizeRequest request)
        {
            return base.HandleResponse(button, request);
        }
    }
}
