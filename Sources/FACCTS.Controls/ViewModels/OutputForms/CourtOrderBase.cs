using FACCTS.Server.Model.Enums;
using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class CourtOrderBase: ViewModelBase
    {
        public CourtOrdersTypes OrderType { get; set; }

        public OrderBase Order { get; set; }
    }
}
