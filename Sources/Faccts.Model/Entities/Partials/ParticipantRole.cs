using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class ParticipantRole
    {
        public ParticipantRole(FACCTS.Server.Model.DataModel.ParticipantRole dto) : this()
        {
            this.Id = dto.Id;
            this.ParticipantRoleName = dto.ParticipantRoleName;
        }
    }
}
