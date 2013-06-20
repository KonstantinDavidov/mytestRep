using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Courtrooms
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
    }
}
