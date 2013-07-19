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
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Hearing()
            {
                Id = this.Id,
                HearingDate = this.HearingDate,
                Courtroom = this.Courtrooms.ToDTO(),
                Department = this.CourtDepartment.ToDTO(),
                Judge = this.Judge,
                HearingIssues = this.HearingIssue.ToDTO(),
                Appearance = this.Appearance.ToDTO(),
                Session = this.Session,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
