using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Model.DataModel;

namespace FACCTS.Server.DataContracts
{
    public interface ICourtMemberRepository : IFacctsDataRepository<CourtMember>
    {
        IQueryable<CourtMember> GetCourtMembersByRole(int roleId);
        IQueryable<CourtMemberBrief> GetBriefs();
    }
}
