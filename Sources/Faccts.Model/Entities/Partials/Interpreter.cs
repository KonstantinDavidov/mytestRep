using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Interpreter : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Interpreter>
    {

        FACCTS.Server.Model.DataModel.Interpreter IDataTransferConvertible<FACCTS.Server.Model.DataModel.Interpreter>.ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Interpreter()
            {
                Id = this.Id,
                EntityType = this.EntityType,
                InterpreterFor = this.PartyFor == Entities.PartyFor.Party1 ? this.CourtCase.Party1.ConvertToDTO() : this.CourtCase.Party2.ConvertToDTO(),
                FirstName = this.FirstName,
                LastName = this.LastName,
                Language = this.Language,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
