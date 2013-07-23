using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Race : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Race>
    {
        public Race(FACCTS.Server.Model.DataModel.Race dto) : this()
        {
            this.Id = dto.Id;
            this.RaceName = dto.RaceName;
        }

        public FACCTS.Server.Model.DataModel.Race ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Race()
            {
                Id = this.Id,
                RaceName = this.RaceName,
                State = (FACCTS.Server.Model.DataModel.ObjectState)this.ChangeTracker.State,
            };
        }

    }
}
