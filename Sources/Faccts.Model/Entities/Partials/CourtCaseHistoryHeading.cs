﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CourtCaseHistoryHeading
    {
        public CourtCaseHistoryHeading(FACCTS.Server.Model.Calculations.CourtCaseHeading dto) 
            : base(dto)
        {

        }
    }
}
