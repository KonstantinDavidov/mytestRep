using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.DataContracts
{
    public interface IFacctsDictionaryDataRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(params string[] includePaths);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includePaths);
        TEntity GetById(long id);
    }
}
