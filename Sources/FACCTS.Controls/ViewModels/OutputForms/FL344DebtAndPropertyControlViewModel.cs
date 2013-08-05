using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class FL344DebtAndPropertyControlViewModel:CourtOrderViewModelBase
    {
        public FL344DebtAndPropertyControlViewModel()
        {
            DisplayName = "FL344 Debt Property Control";
            OrderType = Server.Model.Enums.CourtOrdersTypes.FL344;
        }
    }
}
