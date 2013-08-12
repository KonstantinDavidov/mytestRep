using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Controls.ViewModels
{
    public class DV140ViewModel:CourtOrderBaseViewModel<DV140>
    {
        public DV140ViewModel()
        {
            this.DisplayName = "DV110 Temporary Restraining Order - Child Custody";
            OrderType = CourtOrdersTypes.DV140;
        }
    }
}
