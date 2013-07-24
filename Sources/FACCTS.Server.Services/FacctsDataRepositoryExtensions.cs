using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data
{
    public static class FacctsDataRepositoryExtensions
    {
        public static void SaveData<T>(this IFacctsDataRepository<T> repository, T entity)
            where T : class, IEntityWithState
        {
            if (entity == null)
                return;
            switch (entity.State)
            {
                case ObjectState.Added:
                    repository.Insert(entity);
                    break;
                case ObjectState.Deleted:
                    repository.Delete(entity);
                    break;
                case ObjectState.Modified:
                    repository.Update(entity);
                    break;
            }
            entity.State = ObjectState.Unchanged;
        }

        public static void SaveData<T>(this IFacctsDataRepository<T> repository, IEnumerable<T> entityCollection)
            where T : class, IEntityWithState
        {
            if (entityCollection == null)
                return;
            entityCollection.Aggregate(0, (index, item) =>
                    {
                        SaveData(repository, item);
                        return ++index;
                    }
                );
        }
    }
}