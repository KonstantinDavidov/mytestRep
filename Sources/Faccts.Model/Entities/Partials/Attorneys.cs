﻿using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Attorneys : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Attorney>
    {
        public FACCTS.Server.Model.DataModel.Attorney ToDTO()
        {
            if (!this.IsDirty)
                return null;
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
                USAState = (USAState)this.USAState,
                StateBarId = this.StateBarId,
                StreetAddress = this.StreetAddress,
                ZipCode = this.ZipCode,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
