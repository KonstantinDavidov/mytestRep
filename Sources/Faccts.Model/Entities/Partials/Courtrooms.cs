using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Courtrooms : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Courtroom>
    {
        public Courtrooms(FACCTS.Server.Model.DataModel.Courtroom dto) : this()
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }
            this.Id = dto.Id;
            this.RoomName = dto.RoomName;
            if (dto.CourtLocation != null)
            {
                this.CourtLocation_Id = dto.CourtLocation.Id;
            }
            
        }

        public FACCTS.Server.Model.DataModel.Courtroom ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.Courtroom()
            {
                Id = this.Id,
                RoomName = this.RoomName,
                CourtLocation = this.CourtLocations.IsDirty ? this.CourtLocations.ToDTO() : null,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
