﻿using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public class CourtRooms : WebApiClientBase
    {
        protected List<Courtrooms> GetCourtRooms(int courtCountyId)
        {
            return this.CallServiceGet<List<FACCTS.Server.Model.DataModel.Courtroom>>(string.Format("{0}?courtCountyId={1}", "Courtrooms",courtCountyId))
                .Select(x => new Courtrooms(x))
                .ToList();
        }

        public static List<Courtrooms> GetAll(int? courtCountyId)
        {
            if (courtCountyId == null)
            {
                return null;
            }
            return new CourtRooms().GetCourtRooms(courtCountyId.GetValueOrDefault(0));
        }
    }
}