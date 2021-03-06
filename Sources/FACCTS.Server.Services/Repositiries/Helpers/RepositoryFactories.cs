﻿using FACCTS.Server.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.Repositiries.Helpers
{
    [Export(typeof(RepositoryFactories))]
    public class RepositoryFactories
    {
        private IDictionary<Type, Func<DbContext, object>> GetFacctsFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                {
                   {typeof(ICourtMemberRepository), dbContext => new CourtMemberRepository(dbContext)},
                };
        }

        /// <summary>
        /// Constructor that initializes with runtime Code Camper repository factories
        /// </summary>
        public RepositoryFactories()
        {
            _repositoryFactories = GetFacctsFactories();
        }

        /// <summary>
        /// Constructor that initializes with an arbitrary collection of factories
        /// </summary>
        /// <param name="factories">
        /// The repository factory functions for this instance. 
        /// </param>
        /// <remarks>
        /// This ctor is primarily useful for testing this class
        /// </remarks>
        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        /// <summary>
        /// Get the repository factory function for the type.
        /// </summary>
        /// <typeparam name="T">Type serving as the repository factory lookup key.</typeparam>
        /// <returns>The repository function if found, else null.</returns>
        /// <remarks>
        /// The type parameter, T, is typically the repository type 
        /// but could be any type (e.g., an entity type)
        /// </remarks>
        public Func<DbContext, object> GetRepositoryFactory<T>()
        {

            return GetRepositoryFactory(typeof(T));
        }


        public Func<DbContext, object> GetRepositoryFactory(Type entityType)
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(entityType, out factory);
            return factory;
        }

        /// <summary>
        /// Get the factory for <see cref="IRepository{T}"/> where T is an entity type.
        /// </summary>
        /// <typeparam name="T">The root type of the repository, typically an entity type.</typeparam>
        /// <returns>
        /// A factory that creates the <see cref="IRepository{T}"/>, given an EF <see cref="DbContext"/>.
        /// </returns>
        /// <remarks>
        /// Looks first for a custom factory in <see cref="_repositoryFactories"/>.
        /// If not, falls back to the <see cref="DefaultEntityRepositoryFactory{T}"/>.
        /// You can substitute an alternative factory for the default one by adding
        /// a repository factory for type "T" to <see cref="_repositoryFactories"/>.
        /// </remarks>
        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType(Type entityType)
        {
            return GetRepositoryFactory(entityType) ?? DefaultEntityRepositoryFactory(entityType);
        }

        /// <summary>
        /// Default factory for a <see cref="IRepository{T}"/> where T is an entity.
        /// </summary>
        /// <typeparam name="T">Type of the repository's root entity</typeparam>
        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new FacctsDataRepository<T>(dbContext);
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory(Type type)
        {
            return dbContext =>
                {
                    Type f1 = typeof(FacctsDataRepository<>);
                    Type constructed = f1.MakeGenericType(type);
                    return Activator.CreateInstance(constructed);
                };
        }

        /// <summary>
        /// Get the dictionary of repository factory functions.
        /// </summary>
        /// <remarks>
        /// A dictionary key is a System.Type, typically a repository type.
        /// A value is a repository factory function
        /// that takes a <see cref="DbContext"/> argument and returns
        /// a repository object. Caller must know how to cast it.
        /// </remarks>
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

    }
}
