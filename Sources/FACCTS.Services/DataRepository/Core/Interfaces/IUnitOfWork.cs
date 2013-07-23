using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.DataRepository.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
