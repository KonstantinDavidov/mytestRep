using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class SeparateCaseDialogViewModel : ViewModelBase
    {
        public SeparateCaseDialogViewModel() : base()
        {
            this.DisplayName = "Separate Case";
        }
    }
}
