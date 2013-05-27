using FACCTS.Server.Model;
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
        [ImportingConstructor]
        public DataManager(FacctsDatabaseInitializer initializer)
        {
            Database.SetInitializer(initializer);

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
            DatabaseContext context = new DatabaseContext();
            context.Database.Initialize(false);
            return (DbContext)context;
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

        private EyesColorRepository _eyesColorRepository;

        public EyesColorRepository EyesColorRepository
        {
            get
            {
                if (_eyesColorRepository == null)
                {
                    _eyesColorRepository = ObjectFactory.GetInstance<EyesColorRepository>();
                }
                return _eyesColorRepository;
            }
        }

        private CourtCaseStatusesRepository _courtCaseStatusesRepository;

        public CourtCaseStatusesRepository CourtCaseStatusesRepository
        {
            get
            {
                if (_courtCaseStatusesRepository == null)
                {
                    _courtCaseStatusesRepository = ObjectFactory.GetInstance<CourtCaseStatusesRepository>();
                }
                return _courtCaseStatusesRepository;
            }
        }

        private SexRepository _sexRepository;

        public SexRepository SexRepository
        {
            get
            {
                if (_sexRepository == null)
                {
                    _sexRepository = ObjectFactory.GetInstance<SexRepository>();
                }
                return _sexRepository;
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
                if (_eyesColorRepository != null)
                {
                    _eyesColorRepository.Dispose();
                    _eyesColorRepository = null;
                }
                if (_courtCaseStatusesRepository != null)
                {
                    _courtCaseStatusesRepository.Dispose();
                    _courtCaseStatusesRepository = null;
                }
                if (_sexRepository != null)
                {
                    _sexRepository.Dispose();
                    _sexRepository = null;
                }
            }
            //clean up the native resources

            _wasDisposed = true;
        }
    }
}
