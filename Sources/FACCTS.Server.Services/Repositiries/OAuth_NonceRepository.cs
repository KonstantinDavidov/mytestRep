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
    [Export(typeof(OAuth_NonceRepository))]
    public class OAuth_NonceRepository : DbContextRepository<OAuth_Nonce>
    {
        public OAuth_NonceRepository() : base()
        {

        }
    }
}
