using FACCTS.Server.Services.Repositiries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Services
{
    public interface IDataManager : IDisposable
    {
        OAuth_NonceRepository NonceRepository { get; }
        OAuth_ClientRepository ClientRepository { get; }
        OAuth_ClientAuthorizationRepository ClientAuthorizationRepository { get; }
        OAuth_SymmetricCryptoKeyRepository SymmetricCryptoKeyRepository { get; }
        OAuth_UsersRepository UsersRepository { get; }
        HairColorRepository HairColorRepository { get; }
    }
}
