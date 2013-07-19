using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Permission : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Permission>
    {
        partial void Initialize()
        {
            
        }

        public FACCTS.Server.Model.DataModel.Permission ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Permission()
            {
                Id = this.Id,
                Name = this.Name,
                Roles = this.Role.Where(x => x.IsDirty).Select(r => r.ConvertToDTO()).ToArray(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)this.ChangeTracker.State,
            };
        }

    }
}
