using FACCTS.Server.Common;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.Repositiries
{
    [Export]
    public class HairColorRepository : RepositoryService<HairColor>
    {
        [ImportingConstructor]
        public HairColorRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
        }
    }
}
