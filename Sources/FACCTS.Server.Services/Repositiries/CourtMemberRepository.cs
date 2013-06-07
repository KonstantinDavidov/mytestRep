using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.DataContracts;
using System.Data.Entity;

namespace FACCTS.Server.Data.Repositiries
{
    public class CourtMemberRepository : FacctsDataRepository<CourtMember>, ICourtMemberRepository
    {
        public CourtMemberRepository(DbContext context) : base(context) { }

        public IQueryable<CourtMember> GetCourtMembersByRole(int roleId)
        {
            return Entities.Where(cm => cm.Roles.Any(r => r.RoleId >= roleId));
        }
    }
}
