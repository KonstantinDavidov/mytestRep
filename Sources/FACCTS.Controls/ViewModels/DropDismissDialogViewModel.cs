using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel.Composition;
using Faccts.Model.Entities;
using Caliburn.Micro;
using FACCTS.Services.BusinessOperations;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class DropDismissDialogViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public DropDismissDialogViewModel() : base()
        {
            this.WhenAny(x => x.DocketRecord, x => x.Value)
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
            })
            .ContinueWith(t =>
            {
                TryClose(true);
            }
            , TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        private void ProceedDrop()
        {
            DropStrategy ds = new DropStrategy(DocketRecord);
            ds.Execute();
            
        }

        private void ProceedDismissal()
        {
            
        }
    }
}
