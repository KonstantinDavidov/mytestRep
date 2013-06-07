using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Models;
using Thinktecture.IdentityServer.Repositories;


namespace FACCTS.Server.Data.Repositiries
{
    [Export(typeof(ICodeTokenRepository))]
    public class CodeTokenRepository : ICodeTokenRepository
    {
        public string AddCode(CodeTokenType type, int clientId, string userName, string scope)
        {
            using (var entities = DatabaseContext.Get())
            {
                var code = Guid.NewGuid().ToString("N");

                var refreshToken = new Model.DataModel.CodeToken
                {
                    Type = (int)type,
                    Code = code,
                    ClientId = clientId,
                    Scope = scope,
                    UserName = userName,
                    TimeStamp = DateTime.UtcNow
                };

                entities.CodeTokens.Add(refreshToken);
                entities.SaveChanges();

                return code;
            }
        }

        public bool TryGetCode(string code, out Thinktecture.IdentityServer.Models.CodeToken token)
        {
            token = null;

            using (var entities = DatabaseContext.Get())
            {
                var entity = (from t in entities.CodeTokens
                              where t.Code.Equals(code, StringComparison.OrdinalIgnoreCase)
                              select t)
                             .FirstOrDefault();

                if (entity != null)
                {
                    token = entity.ToDomainModel();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void DeleteCode(string code)
        {
            using (var entities = DatabaseContext.Get())
            {
                var item = entities.CodeTokens.Where(x => x.Code.Equals(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (item != null)
                {
                    entities.CodeTokens.Remove(item);
                    entities.SaveChanges();
                }
            }
        }

        public IEnumerable<Thinktecture.IdentityServer.Models.CodeToken> Search(int? clientId, string username, string scope, CodeTokenType type)
        {
            using (var entities = DatabaseContext.Get())
            {
                var query =
                    from t in entities.CodeTokens
                    where t.Type == (int)type
                    select t;

                if (clientId != null)
                {
                    query =
                        from t in query
                        where t.ClientId == clientId.Value
                        select t;
                }

                if (!String.IsNullOrWhiteSpace(username))
                {
                    query =
                        from t in query
                        where t.UserName.Contains(username)
                        select t;
                }

                if (!String.IsNullOrWhiteSpace(scope))
                {
                    query =
                        from t in query
                        where t.Scope.Contains(scope)
                        select t;
                }

                var results = query.ToArray().Select(x => x.ToDomainModel());
                return results;
            }
        }
    }
}
