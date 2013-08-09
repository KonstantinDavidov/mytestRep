using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Courtrooms : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtRoom>
    {
        public Courtrooms(FACCTS.Server.Model.DataModel.CourtRoom dto) : this()
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto");
            }
            this.Id = dto.Id;
            this.RoomName = dto.Name;
            this.JudgeId = dto.JudgeId;
            if (dto.CourtLocation != null)
            {
                this.CourtLocation_Id = dto.CourtLocation.Id;
            }
            
        }

        public FACCTS.Server.Model.DataModel.CourtRoom ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.CourtRoom()
            {
                Id = this.Id,
                Name = this.RoomName,
                CourtLocation = this.CourtLocations.ConvertToDTO(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
                JudgeId = this.JudgeId,
            };
        }

    }
}
