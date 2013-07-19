using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class EyesColor : IDataTransferConvertible<FACCTS.Server.Model.DataModel.EyesColor>
    {
        public EyesColor(FACCTS.Server.Model.DataModel.EyesColor dto) : this()
        {
            this.Id = dto.Id;
            this.Color = dto.Color;
        }

        public FACCTS.Server.Model.DataModel.EyesColor ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.EyesColor()
            {
                Id = this.Id,
                Color = this.Color,
                State = (FACCTS.Server.Model.DataModel.ObjectState)this.ChangeTracker.State,
            };
        }
    }
}
