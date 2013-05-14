using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CaseRecordViewModel))]
    public class CaseRecordViewModel : ViewModelBase
    {
        public CaseRecordViewModel() : base()
        {
            this.DisplayName = "Case Record";
        }
    }
}
