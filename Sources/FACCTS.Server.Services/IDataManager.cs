using FACCTS.Server.Services.Repositiries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Services
{
    public interface IDataManager
    {
        OAuth_NonceRepository NonceRepository { get; }
    }
}
