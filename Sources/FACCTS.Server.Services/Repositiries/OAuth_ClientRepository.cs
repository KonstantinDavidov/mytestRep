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
    [Export(typeof(OAuth_ClientRepository))]
    public class OAuth_ClientRepository : DbContextRepository<OAuth_Client>
    {
        public OAuth_ClientRepository() : base()
        {

        }
    }
}
