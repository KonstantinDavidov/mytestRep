using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FACCTS.Server.DataContracts;
using System.ComponentModel.Composition;

namespace FACCTS.Server.Data.Repositiries.Helpers
{
    [Export(typeof(IRepositoryProvider))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RepositoryProvider : IRepositoryProvider
    {
        [ImportingConstructor]
        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Get and set the <see cref="DbContext"/> with which to initialize a repository
        /// if one must be created.
        /// </summary>
        public DbContext DbContext { get; set; }

        /// <summary>
        /// Get or create-and-cache the default <see cref="IRepository{T}"/> for an entity of type T.
        /// </summary>
        /// <typeparam name="T">
        /// Root entity type of the <see cref="IRepository{T}"/>.
        /// </typeparam>
        /// <remarks>
        /// If can't find repository in cache, use a factory to create one.
        /// </remarks>
        public IFacctsDataRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IFacctsDataRepository<T>>(
                _repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }


        public Object GetRepositoryForEntityType(Type type)
        {
            Type d1 = typeof(IFacctsDataRepository<>);
            Type constructed = d1.MakeGenericType(type);
            return GetRepository(constructed, _repositoryFactories.GetRepositoryFactoryForEntityType(type));
        }
        /// <summary>
        /// Get or create-and-cache the default <see cref="IRepository{T}"/> for an entity of type T.
        /// </summary>
        /// <typeparam name="T">
        /// Root entity type of the <see cref="IRepository{T}"/>.
        /// </typeparam>
        /// <remarks>
        /// If can't find repository in cache, use a factory to create one.
        /// </remarks>
        public IFacctsDictionaryDataRepository<T> GetDictionaryRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IFacctsDictionaryDataRepository<T>>(
                _repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        /// <summary>
        /// Get or create-and-cache a repository of type T.
        /// </summary>
        /// <typeparam name="T">
        /// Type of the repository, typically a custom repository interface.
        /// </typeparam>
        /// <param name="factory">
        /// An optional repository creation function that takes a DbContext argument
        /// and returns a repository of T. Used if the repository must be created and
        /// caller wants to specify the specific factory to use rather than one
        /// of the injected <see cref="RepositoryFactories"/>.
        /// </param>
        /// <remarks>
        /// Looks for the requested repository in its cache, returning if found.
        /// If not found, tries to make one using <see cref="MakeRepository{T}"/>.
        /// </remarks>
        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            return (T)GetRepository(typeof(T), factory);
        }

        public virtual Object GetRepository(Type type, Func<DbContext, object> factory = null)
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            Repositories.TryGetValue(type, out repoObj);
            if (repoObj != null)
            {
                return repoObj;
            }

            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository(type, factory, DbContext);
        }

        /// <summary>
        /// Get the dictionary of repository objects, keyed by repository type.
        /// </summary>
        /// <remarks>
        /// Caller must know how to cast the repository object to a useful type.
        /// <p>This is an extension point. You can register fully made repositories here
        /// and they will be used instead of the ones this provider would otherwise create.</p>
        /// </remarks>
        protected Dictionary<Type, object> Repositories { get; private set; }

        /// <summary>Make a repository of type T.</summary>
        /// <typeparam name="T">Type of repository to make.</typeparam>
        /// <param name="dbContext">
        /// The <see cref="DbContext"/> with which to initialize the repository.
        /// </param>        
        /// <param name="factory">
        /// Factory with <see cref="DbContext"/> argument. Used to make the repository.
        /// If null, gets factory from <see cref="_repositoryFactories"/>.
        /// </param>
        /// <returns></returns>
        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            return (T)MakeRepository(typeof(T), factory, dbContext);
        }

        protected virtual Object MakeRepository(Type type, Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory(type);
            if (f == null)
            {
                throw new NotImplementedException("No factory for repository type, " + type.FullName);
            }
            var repo = f(dbContext);
            Repositories[type] = repo;
            return repo;
        }

        /// <summary>
        /// Set the repository for type T that this provider should return.
        /// </summary>
        /// <remarks>
        /// Plug in a custom repository if you don't want this provider to create one.
        /// Useful in testing and when developing without a backend
        /// implementation of the object returned by a repository of type T.
        /// </remarks>
        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }

        /// <summary>
        /// The <see cref="RepositoryFactories"/> with which to create a new repository.
        /// </summary>
        /// <remarks>
        /// Should be initialized by constructor injection
        /// </remarks>
        private RepositoryFactories _repositoryFactories;

    }
}
