using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Extensions.Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Services.Repositiries
{
    public class SexRepository : DbContextRepository<Sex>
    {
        public SexRepository()
            : base()
        {
        }

    }
}
