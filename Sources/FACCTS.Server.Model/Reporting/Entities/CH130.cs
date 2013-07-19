﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Model.Reporting.Entities;

namespace FACCTS.Server.Model.OrderModels
{
    public partial class CH130 : PermanentOrder
    {
        public CH130()
        {
            CAPROSEntrySection = new CAPROSEntry();
            ConductSection = new CH130ConductChoice();
            IsPOSGeneral = null;
            LawersFeeAndCourtCostsSection = new LawersFeeAndCourtCosts();
            NoServiceFeeSection = new NoServiceFee();
            StayAwayOrdersSection = new CH130StayAwayOrders();
        }
    }
}
