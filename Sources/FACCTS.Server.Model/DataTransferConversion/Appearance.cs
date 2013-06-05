using FACCTS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class Appearance
    {
        public AppearanceDTO ToDTO()
        {
            return new AppearanceDTO()
            {
                Id = this.Id,
                Date = this.Date,
                FirstName = this.FirstName,
                LastName = this.LastName,
                DesignationID = this.Designation != null ? (int?)this.Designation.Id : null,
                Appear = this.Appear,
                Sworn = this.Sworn,
                AttorneyPresent = this.AttorneyPresent,

            };
        }
    }
}
