using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class CH110CivilHarassmentViewModel: CourtOrderViewModelBase
    {
        public CH110CivilHarassmentViewModel()
        {
            DisplayName = "CH110 Civil Harassment - Temporary Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.CH110;
        }
    }
}
