using FACCTS.Server.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Services.Repositiries
{
    public class RepositoryService<TEntity> : IFacctsDataRepository<TEntity> where TEntity : class
    {
        private IDatabaseContext Context;

        private IDbSet<TEntity> Entities
        {
            get { return this.Context.Set<TEntity>(); }
        }

        public RepositoryService(IDatabaseContext context)
        {
            this.Context = context;

        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _wasDisposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_wasDisposed)
                return;
            if (disposing)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                    this.Context = null;
                }
            }

            _wasDisposed = true;
        }

        ~RepositoryService()
        {
            Dispose(false);
        }
    }
}
