using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CourtOrdersViewModel))]
    public class CourtOrdersViewModel : ReactiveConductor<IScreen>.Collection.OneActive
    {
        public CourtOrdersViewModel() : base()
        {
            this.DisplayName = "Court Orders";
        }

        public void Activate(ViewModelBase viewModel)
        {
            if (viewModel != null)
            {
                this.ActivateItem(viewModel);
            }
        }
    }
}
