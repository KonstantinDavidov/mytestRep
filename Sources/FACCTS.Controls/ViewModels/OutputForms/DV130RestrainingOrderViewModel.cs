using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class DV130RestrainingOrderViewModel : CourtOrderBase
    {
        public DV130RestrainingOrderViewModel()
        {
            DisplayName = "DV130 Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.DV130;
        }
    }
}
