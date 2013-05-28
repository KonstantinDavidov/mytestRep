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
    public class EyesColorRepository : RepositoryService<EyesColor>
    {
        [ImportingConstructor]
        public EyesColorRepository(IDatabaseContext dbContext)
            : base(dbContext)
        {
        }
    }
}
