using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Attorneys
    {
        public FACCTS.Server.Model.DataModel.Attorney ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.Attorney()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                City = this.City,
                Email = this.Email,
                Fax = this.Fax,
                FirmName = this.FirmName,
                Phone = this.Phone,
                State = this.State,
                StateBarId = this.StateBarId,
                StreetAddress = this.StreetAddress,
                ZipCode = this.ZipCode,
            };
        }
    }
}
