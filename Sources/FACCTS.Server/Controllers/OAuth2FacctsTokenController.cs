using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Thinktecture.IdentityServer.Protocols.OAuth2;
using Thinktecture.IdentityServer.Repositories;
using Protocols = Thinktecture.IdentityServer.Protocols;

namespace FACCTS.Server.Controllers
{
    //[Export]
    //[PartCreationPolicy(CreationPolicy.NonShared)]
    //public class OAuth2FacctsTokenController : Protocols.OAuth2.OAuth2TokenController
    //{
    //    [ImportingConstructor]
    //    public OAuth2FacctsTokenController(IUserRepository userRepository,
    //            IConfigurationRepository configurationRepository,
    //            IClientsRepository clientsRepository
    //        )
    //        : base(userRepository, configurationRepository, clientsRepository)
    //    {

    //    }

    //    public new HttpResponseMessage Post([FromBody] TokenRequest tokenRequest)
    //    {
    //        return base.Post(tokenRequest);
    //    }
    //}
}
