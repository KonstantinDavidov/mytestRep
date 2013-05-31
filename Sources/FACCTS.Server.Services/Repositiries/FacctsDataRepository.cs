using FACCTS.Server.Common;
using FACCTS.Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.Repositiries
{
    public class FacctsDataRepository<TEntity> : IDisposable, IFacctsDataRepository<TEntity> where TEntity : class 
    {
        protected DbContext Context { get; set; }

        protected DbSet<TEntity> Entities{ get; set;}
        
        public FacctsDataRepository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("dbContext");
            this.Context = context;
            this.Entities = Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public virtual TEntity GetById(long id)
        {
            return Entities.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                Entities.Add(entity);
            }

        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Entities.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            DbEntityEntry dbEntityEntry = this.Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                Entities.Attach(entity);
                Entities.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
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

        ~FacctsDataRepository()
        {
            Dispose(false);
        }
    }
}
