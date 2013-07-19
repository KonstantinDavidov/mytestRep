using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtDepartment : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtDepartment>
    {
        public CourtDepartment(FACCTS.Server.Model.DataModel.CourtDepartment dto)
            : this()
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Room = dto.Room;
            this.BranchOfficer = dto.BranchOfficer;
            this.Reporter = dto.Reporter;
            //this.CourtCounty = dto.CourtCounty;
        }

        partial void Initialize()
        {
            
        }

        public FACCTS.Server.Model.DataModel.CourtDepartment ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.CourtDepartment()
            {
                Id = this.Id,
                Name = this.Name,
                Room = this.Room,
                BranchOfficer = this.BranchOfficer,
                Reporter = this.Reporter,
                CourtCounty = this.CourtCounty.IsDirty ? this.CourtCounty.ToDTO() : null,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
