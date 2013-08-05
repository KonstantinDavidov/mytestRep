using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class CH130CivilHarassmentViewModel : CourtOrderViewModelBase
    {
        public CH130CivilHarassmentViewModel() : base()
        {
            this.DisplayName = "CH130 - Civil Harassment - Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.CH130;
        }
    }
}
