using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(RelatedCasesViewModel))]
    public class RelatedCasesViewModel : ViewModelBase
    {
        public RelatedCasesViewModel() : base()
        {
            this.DisplayName = "Related Cases";
        }
    }
}
