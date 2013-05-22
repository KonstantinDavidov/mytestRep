using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity.Extensions.Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Services.Repositiries
{
    [Export(typeof(OAuth_ClientAuthorizationRepository))]
    public class OAuth_ClientAuthorizationRepository : DbContextRepository<OAuth_ClientAuthorization>
    {
        public OAuth_ClientAuthorizationRepository() : base()
        {

        }
    }
}
