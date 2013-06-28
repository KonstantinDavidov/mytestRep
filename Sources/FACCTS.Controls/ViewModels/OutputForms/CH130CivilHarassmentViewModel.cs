using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class CH130CivilHarassmentViewModel : ViewModelBase
    {
        public CH130CivilHarassmentViewModel() : base()
        {
            this.DisplayName = "CH130 - Civil Harassment - Restraining Order";
        }
    }
}
