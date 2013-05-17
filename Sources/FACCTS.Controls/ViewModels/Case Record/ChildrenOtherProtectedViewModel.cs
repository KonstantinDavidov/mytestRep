using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(ChildrenOtherProtectedViewModel))]
    public class ChildrenOtherProtectedViewModel : ViewModelBase
    {
        public ChildrenOtherProtectedViewModel() : base()
        {
            this.DisplayName = "Children - Other Protected";
        }
    }
}
