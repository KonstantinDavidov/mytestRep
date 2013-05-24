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


        private OAuth_NonceRepository _nonceRepository;
        public OAuth_NonceRepository NonceRepository
        {
            get
            {
                if (_nonceRepository == null)
                {
                    _nonceRepository = ObjectFactory.GetInstance<OAuth_NonceRepository>();
                }
                return _nonceRepository;
            }
        }


        private OAuth_ClientRepository _clientRepository;
        public OAuth_ClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = ObjectFactory.GetInstance<OAuth_ClientRepository>();
                }
                return _clientRepository;
            }
            
        }


        private OAuth_ClientAuthorizationRepository _clientAuthorizationRepository;
        public OAuth_ClientAuthorizationRepository ClientAuthorizationRepository
        {
            get
            {
                if (_clientAuthorizationRepository == null)
                {
                    _clientAuthorizationRepository = ObjectFactory.GetInstance<OAuth_ClientAuthorizationRepository>();
                }
                return _clientAuthorizationRepository;
            }
            
        }


        private OAuth_SymmetricCryptoKeyRepository _symmetricCryptoKeyRepository;
        public OAuth_SymmetricCryptoKeyRepository SymmetricCryptoKeyRepository
        {
            get
            {
                if (_symmetricCryptoKeyRepository == null)
                {
                    _symmetricCryptoKeyRepository = ObjectFactory.GetInstance<OAuth_SymmetricCryptoKeyRepository>();
                }
                return _symmetricCryptoKeyRepository;
            }
            
        }


        private OAuth_UsersRepository _usersRepository;
        public OAuth_UsersRepository UsersRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = ObjectFactory.GetInstance<OAuth_UsersRepository>();
                }
                return _usersRepository;
            }
            
        }

        private HairColorRepository _hairColorRepository;

        public HairColorRepository HairColorRepository
        {
            get {
                if (_hairColorRepository == null)
                {
                    _hairColorRepository = ObjectFactory.GetInstance<HairColorRepository>();
                }
                return _hairColorRepository;
            }
        }
        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DataManager()
        {
            Dispose(false);
        }

        private bool _wasDisposed = false;
        protected virtual void Dispose(bool isDisposing)
        {
            if (_wasDisposed)
                return;
            if (isDisposing)
            {
                //clean up managed resources
                if (_nonceRepository != null)
                {
                    _nonceRepository.Dispose();
                    _nonceRepository = null;
                }
                if (_clientRepository != null)
                {
                    _clientRepository.Dispose();
                    _clientRepository = null;
                }
                if (_clientAuthorizationRepository != null)
                {
                    _clientAuthorizationRepository.Dispose();
                    _clientAuthorizationRepository = null;
                }
                if (_symmetricCryptoKeyRepository != null)
                {
                    _symmetricCryptoKeyRepository.Dispose();
                    _symmetricCryptoKeyRepository = null;
                }
                if (_usersRepository != null)
                {
                    _usersRepository.Dispose();
                    _usersRepository = null;
                }
            }
            //clean up the native resources

            _wasDisposed = true;
        }
    }
}
