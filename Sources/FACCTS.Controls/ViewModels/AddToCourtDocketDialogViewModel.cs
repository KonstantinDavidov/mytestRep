using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class AddToCourtDocketDialogViewModel : ViewModelBase
    {
        public AddToCourtDocketDialogViewModel()
        {
            this.Title = "Add Case to Docket";
        }

        public void AddCase()
        {
            TryClose(true);
            Task.Factory.StartNew(() =>
            {
                ProceedAddition();
            });
           
        }

        private void ProceedAddition()
        {
            
        }

        

    }
}
