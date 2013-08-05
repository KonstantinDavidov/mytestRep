using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;

namespace FACCTS.Controls.ViewModels
{
    public class EA130ElderlyAbuseViewModel : CourtOrderBaseViewModel<EA130>
    {
        public EA130ElderlyAbuseViewModel()
        {
            DisplayName = "EA130 Elderly Abuse - Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.EA130;
        }
    }
}