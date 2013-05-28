using FACCTS.Server.Model;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Services.Repositiries;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

            
        }

        [Import]
        public HairColorRepository HairColorRepository
        {
            get;
            set;
        }

        [Import]
        public EyesColorRepository EyesColorRepository
        {
            get;
            set;
        }


        [Import]
        public CourtCaseStatusesRepository CourtCaseStatusesRepository
        {
            get;
            set;
        }


        [Import]
        public SexRepository SexRepository
        {
            get;
            set;
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
                if (HairColorRepository != null)
                {
                    HairColorRepository.Dispose();
                    HairColorRepository = null;
                }
                if (EyesColorRepository != null)
                {
                    EyesColorRepository.Dispose();
                    EyesColorRepository = null;
                }
                if (CourtCaseStatusesRepository != null)
                {
                    CourtCaseStatusesRepository.Dispose();
                    CourtCaseStatusesRepository = null;
                }
                if (SexRepository != null)
                {
                    SexRepository.Dispose();
                    SexRepository = null;
                }
            }
            //clean up the native resources

            _wasDisposed = true;
        }
    }
}
