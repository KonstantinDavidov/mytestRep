using FACCTS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class GenerateCourtOrdersDialogViewModel : ViewModelBase
    {

        public GenerateCourtOrdersDialogViewModel()
        {
            this.DisplayName = "Generate Court Orders";
            this.WhenAny(x => x.SelectedIndex, x => x.Value)
                .Subscribe(x =>
                {
                    this.IsValid = x >= 0;
                });
        }

        public void GeneratePrint()
        {
            TryClose(true);
        }

        private List<EnumDescript<FACCTS.Server.Model.Enums.CourtOrdersTypes>> _masterOrdersList;
        public List<EnumDescript<FACCTS.Server.Model.Enums.CourtOrdersTypes>> MasterOrdersList
        {
            get
            {
                if (_masterOrdersList == null)
                {
                    _masterOrdersList = EnumDescript<FACCTS.Server.Model.Enums.CourtOrdersTypes>.GetList<FACCTS.Server.Model.Enums.CourtOrdersTypes>();
                }
                return _masterOrdersList;
            }
        }

    }

    
}
