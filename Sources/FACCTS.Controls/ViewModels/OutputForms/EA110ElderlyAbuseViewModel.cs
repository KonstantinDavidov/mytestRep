using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class EA110ElderlyAbuseViewModel : CourtOrderBase
    {
        public EA110ElderlyAbuseViewModel()
        {
            DisplayName = "EA110 Elderly Abuse - Temporary Restraining Order";
            OrderType = Server.Model.Enums.CourtOrdersTypes.EA110;
        }
    }
}
