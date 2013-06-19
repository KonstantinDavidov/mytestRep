using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtDepartmenets
    {
        public CourtDepartmenets(FACCTS.Server.Model.DataModel.CourtDepartment dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Room = dto.Room;
            this.BranchOfficer = dto.BranchOfficer;
            this.Reporter = dto.Reporter;
            //this.CourtCounty = dto.CourtCounty;
        }
    }
}
