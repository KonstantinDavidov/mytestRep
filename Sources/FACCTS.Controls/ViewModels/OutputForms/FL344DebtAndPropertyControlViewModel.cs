using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;

namespace FACCTS.Controls.ViewModels
{
    public class FL344DebtAndPropertyControlViewModel:CourtOrderBaseViewModel<FL344>
    {
        public FL344DebtAndPropertyControlViewModel()
        {
            DisplayName = "FL344 Debt Property Control";
            OrderType = Server.Model.Enums.CourtOrdersTypes.FL344;
        }
    }
}
