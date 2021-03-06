﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtLocations : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtLocation>
    {
        partial void Initialize()
        {
            this.ChangeTracker.ChangeTrackingEnabled = false;
        }

        public FACCTS.Server.Model.DataModel.CourtLocation ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.CourtLocation()
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                StreetAddress = this.StreetAddress,
                USAState = this.USAState,
                PostalCode = this.PostalCode,
                City = this.City,
                //CourtCounty = this.
                CourtRooms = this.Courtrooms.Where(x => x.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

    }
}
