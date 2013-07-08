using FACCTS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class GenerateCourtOrdersDialogViewModel : ViewModelBase
    {

        public void GeneratePrint()
        {
            TryClose(true);
        }

        private List<EnumDescript<FACCTS.Server.Model.Enums.MasterOrders>> _masterOrdersList;
        public List<EnumDescript<FACCTS.Server.Model.Enums.MasterOrders>> MasterOrdersList
        {
            get
            {
                if (_masterOrdersList == null)
                {
                    _masterOrdersList = Enum.GetValues(typeof(FACCTS.Server.Model.Enums.MasterOrders))
                        .Cast<FACCTS.Server.Model.Enums.MasterOrders>()
                        .Select(x => new EnumDescript<FACCTS.Server.Model.Enums.MasterOrders>(x))
                        .ToList();
                }
                return _masterOrdersList;
            }
        }

    }

    
}
