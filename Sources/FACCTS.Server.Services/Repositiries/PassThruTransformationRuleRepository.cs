using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.Claims;
using Thinktecture.IdentityServer.Models;
using Thinktecture.IdentityServer.Repositories;
using Thinktecture.IdentityServer.TokenService;

namespace FACCTS.Server.Data.Repositiries
{
    [Export(typeof(IClaimsTransformationRulesRepository))]
    public class PassThruTransformationRuleRepository : IClaimsTransformationRulesRepository
    {
        public IEnumerable<Claim> ProcessClaims(ClaimsPrincipal incomingPrincipal, IdentityProvider identityProvider, RequestDetails details)
        {
            return incomingPrincipal.Claims;
        }
    }
}