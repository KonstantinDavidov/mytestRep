using FACCTS.Server.Common;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Services.Repositiries
{
    [Export]
    public class CourtCaseStatusesRepository : RepositoryService<CourtCaseStatus>
    {
        [ImportingConstructor]
        public CourtCaseStatusesRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
            
        }
    }
}
