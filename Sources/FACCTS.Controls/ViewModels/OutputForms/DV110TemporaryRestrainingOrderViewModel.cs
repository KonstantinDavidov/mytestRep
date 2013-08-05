﻿using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;

namespace FACCTS.Controls.ViewModels
{
    public class DV110TemporaryRestrainingOrderViewModel : CourtOrderBaseViewModel<DV110>
    {
        public DV110TemporaryRestrainingOrderViewModel() : base()
        {
            this.DisplayName = "DV110 Temporary Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.DV110;
        }
    }
}
