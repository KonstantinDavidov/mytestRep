﻿using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CourtPartyAttorneyData : IEntityWithId, IEntityWithState
    {
        public bool? HasAttorney { get; set; }

        public virtual Attorney Attorney { get; set; }

        public long Id { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
