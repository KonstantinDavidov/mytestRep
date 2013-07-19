using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public static class DataTransferConvertibleExtensions
    {
        public static T ConvertToDTO<T>(this IDataTransferConvertible<T> entity)
            where T : class
        {
            if (entity == null)
                return null;
            return entity.ToDTO();
        }
            
    }
}
