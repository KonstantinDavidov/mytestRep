using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Model.Reporting.Entities;

namespace FACCTS.Server.Model.OrderModels
{
    public partial class CH130
    {
        public CH130()
        {
            _cAPROSEntrySection = new CAPROSEntry();
            _conductSection = new CH130ConductChoice();
            _isPOSGeneral = null;
            _lawersFeeAndCourtCostsSection = new LawersFeeAndCourtCosts();
            _noServiceFeeSection = new NoServiceFee();
            _stayAwayOrdersSection = new CH130StayAwayOrders();
        }
    }
}
