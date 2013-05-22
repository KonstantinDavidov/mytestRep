using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Services.Repositiries;
using StructureMap;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Extensions.UnitOfWork;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Services
{
    [Export(typeof(IDataManager))]
    internal class DataManager : IDataManager
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

        [Import]
        public OAuth_NonceRepository NonceRepository
        {
            get;
            set;
        }

        [Import]
        public OAuth_ClientRepository ClientRepository
        {
            get;
            set;
        }

        [Import]
        public OAuth_ClientAuthorizationRepository ClientAuthorizationRepository
        {
            get;
            set;
        }

        [Import]
        public OAuth_SymmetricCryptoKeyRepository SymmetricCryptoKeyRepository
        {
            get;
            set;
        }

        [Import]
        public OAuth_UsersRepository UsersRepository
        {
            get;
            set;
        }

    }
}
