using System;
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
            CAPROSEntry = new CAPROSEntry();
            ConductChoice = new CHConductChoice();
            IsPOSGeneral = null;
            LawersFeeAndCourtCosts = new LawersFeeAndCourtCosts();
            NoServiceFee = new NoServiceFee();
            StayAwayOrders = new CHStayAwayOrders();
        }
    }
}
