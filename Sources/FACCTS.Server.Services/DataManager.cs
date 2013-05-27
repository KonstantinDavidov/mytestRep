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
                    x.For<DbContext>().Use<DatabaseContext>();
                    x.For<IUnitOfWorkFactory>().Use<DbContextUnitOfWorkFactory>();
                    x.Scan(y => y.Assembly("FACCTS.Server.Services"));
                });

            DbContextUnitOfWorkFactory.SetDbContext(CreateContext);
        }

        private  DbContext CreateContext()
        {
            DbContext context = DatabaseContext.Get();

            return context;
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
                if (_hairColorRepository != null)
                {
                    _hairColorRepository.Dispose();
                    _hairColorRepository = null;
                }
            }
            //clean up the native resources

            _wasDisposed = true;
        }
    }
}
