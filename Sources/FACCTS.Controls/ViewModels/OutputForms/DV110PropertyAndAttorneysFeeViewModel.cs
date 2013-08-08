using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Controls.ViewModels
{
    public class DV110PropertyAndAttorneysFeeViewModel : CourtOrderBaseViewModel<DV110>
    {
        public DV110PropertyAndAttorneysFeeViewModel() : base()
        {
            this.DisplayName = "DV110 Temporary Restraining Order - Property and Attorney's Fees";
            OrderType=CourtOrdersTypes.DV110;
        }
    }
}
