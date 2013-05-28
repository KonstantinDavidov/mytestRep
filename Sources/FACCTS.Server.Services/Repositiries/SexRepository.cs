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
    public class SexRepository : RepositoryService<Sex>
    {
        [ImportingConstructor]
        public SexRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
        }

    }
}
