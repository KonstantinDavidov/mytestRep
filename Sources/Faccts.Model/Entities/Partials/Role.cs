using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Role : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Role>
    {
        partial void Initialize()
        {
            
        }

        public FACCTS.Server.Model.DataModel.Role ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Role()
            {
                Id = this.Id,
                RoleName = this.RoleName,
                Description = this.Description,
                IsIdentityServerUser = this.IsIdentityServerUser,
                Users = this.User.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                Permissions = this.Permissions.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

    }
}
