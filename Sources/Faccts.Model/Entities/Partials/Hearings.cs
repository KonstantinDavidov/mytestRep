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

        public Hearings(FACCTS.Server.Model.DataModel.Hearing dto)
            : this()
        {
            if (dto != null)
            {
                this.Id = dto.Id;
                this.HearingDate = dto.HearingDate;
                this.Courtrooms = new Courtrooms(dto.Courtroom);
                this.CourtDepartment = new CourtDepartment(dto.Department);
                this.HearingIssue = new HearingIssue(dto.HearingIssues);
                this.Session = dto.Session;

                this.MarkAsUnchanged();
            }
           

            
        }
        
        public FACCTS.Server.Model.DataModel.Hearing ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Hearing()
            {
                Id = this.Id,
                HearingDate = this.HearingDate,
                Courtroom = this.Courtrooms.ConvertToDTO(),
                Department = this.CourtDepartment.ConvertToDTO(),
                HearingIssues = this.HearingIssue.ConvertToDTO(),
                Session = this.Session,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

        public string Judge
        {
            get
            {
                if (this.Courtroom_Id.HasValue && this.Courtrooms != null)
                {
                    return this.Courtrooms.JudgeName;
                }
                return string.Empty;
            }
        }

    }
}
