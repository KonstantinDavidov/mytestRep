﻿using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;

namespace FACCTS.Controls.ViewModels
{
    public class DV130ViewModel : CourtOrderBaseViewModel<DV130>
    {
        public DV130ViewModel()
        {
            DisplayName = "DV130 Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.DV130;
        }
    }
}
