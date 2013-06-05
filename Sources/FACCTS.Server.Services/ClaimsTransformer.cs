using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer;
using FACCTS.Server.Common;

namespace FACCTS.Server.Data
{
    public class ClaimsTransformer : Thinktecture.IdentityServer.ClaimsTransformer
    {
        public ClaimsTransformer() : base()
        {
            Logger.Info("ClaimsTransformer.ctor()");
        }

        [Import]
        public ILog Logger { private get; set; }

        [Import]
        public IDataManager DataManager { protected get; set; }

        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            Logger.MethodEntry("ClaimsTransformer.Authenticate");
            ClaimsPrincipal result =  base.Authenticate(resourceName, incomingPrincipal);
            UserRepository.GetRoles(incomingPrincipal.Identity.Name)
                .Where(r => DataManager.FacctsRoleRepository.GetAll().First(r2 => r2.RoleName == r).IsIdentityServerUser)
                .ToList()
                .ForEach(role =>
                {
                    Logger.InfoFormat("{0} -> {1}", role, Constants.Roles.IdentityServerUsers);
                    incomingPrincipal.Identities.First().AddClaim(new Claim(ClaimTypes.Role, Constants.Roles.IdentityServerUsers, ClaimValueTypes.String, Constants.InternalIssuer));
                    //hack for the compatibility with the identity server
                });

            Logger.MethodExit("ClaimsTransformer.Authenticate");
            return result;
        }
    }
}
