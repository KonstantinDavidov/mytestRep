using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data
{
    public static class FacctsDataRepositoryExtensions
    {
        public static void SaveData<T>(this IFacctsDataRepository<T> repository, T entity)
            where T : BaseEntity
        {
            switch(entity.State)
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
        }
    }
}
