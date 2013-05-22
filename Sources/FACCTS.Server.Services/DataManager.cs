using FACCTS.Server.Model.DataModel;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Extensions.UnitOfWork;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Services
{
    public class DataManager
    {
        public DataManager()
        {
            ObjectFactory.Configure(x =>
                {
                    x.For<DbContext>().Use<FACCTS_DBEntities>();
                    x.For<IUnitOfWorkFactory>().Use<DbContextUnitOfWorkFactory>();
                    x.Scan(y => y.Assembly("FACCTS.Server.Services"));
                });

            DbContextUnitOfWorkFactory.SetDbContext(CreateContext);
        }

        private  DbContext CreateContext()
        {
            DbContext context = new FACCTS_DBEntities();

            return context;
        }

    }
}
