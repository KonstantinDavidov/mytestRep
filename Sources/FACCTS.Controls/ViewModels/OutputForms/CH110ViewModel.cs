using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;

namespace FACCTS.Controls.ViewModels
{
    public class CH110ViewModel: CourtOrderBaseViewModel<CH110>
    {
        public CH110ViewModel()
        {
            DisplayName = "CH110 Civil Harassment - Temporary Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.CH110;
        }
    }
}
