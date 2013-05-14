using Caliburn.Micro.ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CaseStatusViewModel))]
    public class CaseStatusViewModel : ViewModelBase
    {
        public CaseStatusViewModel() : base()
        {
            this.DisplayName = "Case Status";
        }


    }
}
