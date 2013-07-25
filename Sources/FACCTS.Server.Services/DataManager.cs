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
using FACCTS.Server.Model.DataModel.Configuration;

namespace FACCTS.Server.Data
{
    [Export(typeof(IDataManager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataManager : IDataManager
    {
        //[Import(typeof(IRepositoryProvider))]
        protected IRepositoryProvider RepositoryProvider { get; set; }

        public DatabaseContext DbContext { get; set; }

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


        public IFacctsDataRepository<CourtParty> CourtPartyRepository
        {
            get { return GetStandardRepo<CourtParty>(); }
        }

        public IFacctsDataRepository<CourtCase> CourtCaseRepository
        {
            get { return GetStandardRepo<CourtCase>(); }
        }

        public IFacctsDataRepository<Role> FacctsRoleRepository
        {
            get
            {
                return GetStandardRepo<Role>();
            }
        }

        public IFacctsDictionaryDataRepository<FACCTSConfiguration> FACCTSConfigurationRepository
        {
            get
            {
                return GetStandardDictionaryRepo<FACCTSConfiguration>();
            }
        }

        public ICourtMemberRepository CourtMemberRepository
        {
            get
            {
                //return new CourtMemberRepository(this.DbContext);
                return GetRepo<ICourtMemberRepository>();
            }
        }

        public IFacctsDataRepository<User> UserRepository
        {
            get
            {
                return GetStandardRepo<User>();
            }
        }

        public IFacctsDataRepository<CourtCounty> CourtCountyRepository
        {
            get
            {
                return GetStandardRepo<CourtCounty>(); 
            }
        }

        public IFacctsDataRepository<CourtDepartment> CourtDepartmentRepository
        {
            get
            {
                return GetStandardRepo<CourtDepartment>();
            }
        }

        public IFacctsDataRepository<CaseHistory> CaseHistoryRepository
        {
            get
            {
                return GetStandardRepo<CaseHistory>();
            }
        }


        public IFacctsDataRepository<CourtOrder> CourtOrdersRepository
        {
            get
            {
                return GetStandardRepo<CourtOrder>();
            }
        }


        public IFacctsDataRepository<Courtroom> CourtroomRepository
        {
            get
            {
                return GetStandardRepo<Courtroom>();
            }
        }

        public IFacctsDictionaryDataRepository<Race> RaceRepository
        {
            get
            {
                return GetStandardDictionaryRepo<Race>();
            }
        }

        public IFacctsDataRepository<ManualIntegrationTask> ManualIntegrationTaskRepository
        {
            get { return GetStandardRepo<ManualIntegrationTask>(); }
        }

        public IFacctsDataRepository<ScheduledIntegrationTask> ScheduledIntegrationTaskRepository
        {
            get { return GetStandardRepo<ScheduledIntegrationTask>(); }
        }

        public IFacctsDataRepository<Hearing> HearingRepository
        {
            get { return GetStandardRepo<Hearing>(); }
        }

        public IFacctsDataRepository<Attorney> AttorneyRepository
        {
            get
            {
                return GetStandardRepo<Attorney>();
            }
        }

        public IFacctsDataRepository<CaseNote> CaseNoteRepository
        {
            get
            {
                return GetStandardRepo<CaseNote>();
            }
        }

        public IFacctsDataRepository<Witness> WitnessRepository
        {
            get
            {
                return GetStandardRepo<Witness>();
            }
        }

        public IFacctsDataRepository<Interpreter> InterpreterRepository
        {
            get
            {
                return GetStandardRepo<Interpreter>();
            }
        }

        public IFacctsDataRepository<Child> ChildrenRepository
        {
            get
            {
                return GetStandardRepo<Child>();
            }
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
            DbContext.Configuration.LazyLoadingEnabled = true;

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
