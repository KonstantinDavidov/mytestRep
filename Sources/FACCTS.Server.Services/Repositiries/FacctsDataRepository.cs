using FACCTS.Server.Common;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
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

        public virtual IQueryable<TEntity> GetAll(params string[] includePaths)
        {
            DbQuery<TEntity> query = Entities;
            query = includePaths.Aggregate(query, (q, s) =>
                {
                    q = q.Include(s);
                    return q;
                });
            return query;
        }

        public virtual IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includePaths)
        {
            IQueryable<TEntity> query = Entities;
            query = includePaths.Aggregate(query, (current, expression) => current.Include(expression));
            return query;
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

        public virtual void ModifyByState(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            if (!(entity is IEntityWithState))
            {
                throw new NotSupportedException("An entity should be a IEntityWithState");
            }

            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Entities.Add(entity);
                Context.ChangeTracker.Entries<IEntityWithState>().Aggregate(0, (index, item) =>
                    {
                        switch((item.Entity as IEntityWithState).State)
                        {
                            case ObjectState.Added:
                                item.State = EntityState.Added;
                                break;
                            case ObjectState.Deleted:
                                item.State = EntityState.Deleted;
                                break;
                            case ObjectState.Modified:
                                item.State = EntityState.Modified;
                                break;
                            default:
                                item.State = EntityState.Unchanged;
                                break;
                        }
                        return 0;
                    }
                    );
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
