using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(WitnessInterpereterViewModel))]
    public class WitnessInterpereterViewModel : ViewModelBase
    {
        public WitnessInterpereterViewModel() : base()
        {
            this.DisplayName = "Withess and Interpreter";
        }
    }
}
