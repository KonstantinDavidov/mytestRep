using Faccts.Model.Entities.Reporting;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Controls.ViewModels
{
    public class CourtOrderViewModelBase : ViewModelBase
    {
        public CourtOrdersTypes OrderType { get; set; }

        public OrderBase Order { get; set; }
    }
}