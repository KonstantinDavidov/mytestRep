using FACCTS.Server.Model;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Data.Repositiries;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.DataContracts;

namespace FACCTS.Server.Data
{
    [Export(typeof(IDataManager))]
    internal class DataManager : IDataManager
    {
        [Import(typeof(IRepositoryProvider))]
        protected IRepositoryProvider RepositoryProvider { get; set; }

        private DatabaseContext DbContext { get; set; }

        [ImportingConstructor]
        public DataManager(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;       
  
        }
        #region IDataManager

        #region Repositories
        public IFacctsDictionaryDataRepository<HairColor> HairColorRepository
        {
            get { return GetStandardDictionaryRepo<HairColor>(); }
        }

        public IFacctsDictionaryDataRepository<EyesColor> EyesColorRepository
        {
            get { return GetStandardDictionaryRepo<EyesColor>(); }
        }

        public IFacctsDictionaryDataRepository<Sex> SexRepository
        {
            get { return GetStandardDictionaryRepo<Sex>(); }
        }

        public IFacctsDictionaryDataRepository<CourtCaseStatus> CourtCaseStatusesRepository
        {
            get { return GetStandardDictionaryRepo<CourtCaseStatus>(); }
        }

        public IFacctsDataRepository<CourtParty> CourtPartyRepository
        {
            get { return GetStandardRepo<CourtParty>(); }
        }

        public IFacctsDataRepository<CourtCase> CourtCaseRepository
        {
            get { return GetStandardRepo<CourtCase>(); }
        }
        #endregion

        //Commit
        public void Commit()
        {
            //System.Diagnostics.Debug.WriteLine("Committed");
            DbContext.SaveChanges();
        }
        #endregion

        #region helpers
        protected void CreateDbContext()
        {
            DbContext = new DatabaseContext();
            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        private IFacctsDataRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private IFacctsDictionaryDataRepository<T> GetStandardDictionaryRepo<T>() where T : class
        {
            return RepositoryProvider.GetDictionaryRepositoryForEntityType<T>();
        }

        #endregion
        
        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
