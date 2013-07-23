using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Child : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Child>
    {
        public Child() : base()
        {
            this.RelationToProtected = FACCTS.Server.Model.Enums.Relationship.C;
        }

        FACCTS.Server.Model.DataModel.Child IDataTransferConvertible<FACCTS.Server.Model.DataModel.Child>.ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Child()
            {
                Id = this.Id,
                EntityType = this.EntityType,
                FirstName = this.FirstName,
                LastName = this.LastName,
                RelationshipToProtected = this.RelationToProtected,
                Sex = this.Sex,
                DateOfBirth = this.DateOfBirth.GetValueOrDefault(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

    }
}
