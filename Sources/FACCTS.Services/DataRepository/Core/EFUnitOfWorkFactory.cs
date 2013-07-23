using FACCTS.Services.DataRepository.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.DataRepository.Core
{
    public class EFUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private static Func<ObjectContext> _objectContextDelegate;
        private static readonly Object _lockObject = new object();

        public static void SetObjectContext(Func<ObjectContext> objectContextDelegate)
        {
            _objectContextDelegate = objectContextDelegate;
        }

        public IUnitOfWork Create()
        {
            ObjectContext context;

            lock (_lockObject)
            {
                context = _objectContextDelegate();
            }

            return new EFUnitOfWork(context);
        }
    }
}
