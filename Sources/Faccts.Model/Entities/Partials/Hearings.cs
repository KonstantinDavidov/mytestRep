using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Hearings : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Hearing>
    {
        partial void Initialize()
        {
            this.HearingIssue = new HearingIssue();
        }
        
        public FACCTS.Server.Model.DataModel.Hearing ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.Hearing()
            {
                Id = this.Id,
                HearingDate = this.HearingDate,
                Courtroom = this.Courtrooms.IsDirty ? this.Courtrooms.ToDTO() : null,
                Department = this.CourtDepartment.IsDirty ? this.CourtDepartment.ToDTO() : null,
                Judge = this.Judge,
                HearingIssues = this.HearingIssue.IsDirty ? this.HearingIssue.ToDTO() : null,
                Appearance = this.Appearance.IsDirty ? this.Appearance.ToDTO() : null,
                Session = this.Session,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
