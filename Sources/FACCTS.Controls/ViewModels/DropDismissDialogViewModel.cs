using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel.Composition;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class DropDismissDialogViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public DropDismissDialogViewModel() : base()
        {
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.IsValid = x != null;
                    if (x != null)
                    {
                        this.CaseNumber = x.CaseNumber;
                    }
                }
                );
            this.WhenAny(x => x.Dismiss, x => x.Value)
                .Subscribe(x =>
                    {
                        if (x)
                        {
                            this.DisplayName = "Dismiss Case - Confirmation";
                        }
                        else
                        {
                            this.DisplayName = "Drop Case - Confirmation";
                        }
                    }
                );
        }
        

        public void DropDismiss()
        {
            TryClose(true);
            Task.Factory.StartNew(() => 
            {
                if (Dismiss)
                {
                    ProceedDismissal();
                }
                else
                {
                    ProceedDrop();
                }
            });
        }

        private void ProceedDrop()
        {
            //TODO: implement the DROP operation
        }

        private void ProceedDismissal()
        {
            //TODO: implement the DISMISS operation
        }
    }
}
