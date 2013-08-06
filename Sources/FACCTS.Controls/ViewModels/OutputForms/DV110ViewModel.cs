using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;

namespace FACCTS.Controls.ViewModels
{
    public class DV110ViewModel : CourtOrderBaseViewModel<DV110>
    {
        public DV110ViewModel() : base()
        {
            this.DisplayName = "DV110 Temporary Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.DV110;
        }
    }
}
