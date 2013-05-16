using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CourtDocketViewModel))]
    public class CourtDocketViewModel : ViewModelBase
    {
        public CourtDocketViewModel() : base()
        {
            this.DisplayName = "Court Docket";
        }
    }
}
