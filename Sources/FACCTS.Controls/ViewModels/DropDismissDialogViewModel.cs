using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel.Composition;
using Faccts.Model.Entities;
using Caliburn.Micro;

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
            CaseHistory ch = new CaseHistory()
            {
                Date = DateTime.Now,
                CaseHistoryEvent = FACCTS.Server.Model.Enums.CaseHistoryEvent.Dropped,
            };
            Execute.OnUIThread(() => this.CurrentCourtCase.CaseRecord.CaseHistory.Add(ch));
        }

        private void ProceedDismissal()
        {
            CaseHistory ch = new CaseHistory()
            {
                Date = DateTime.Now,
                CaseHistoryEvent = FACCTS.Server.Model.Enums.CaseHistoryEvent.Dismissed,
            };
            Execute.OnUIThread(() => this.CurrentCourtCase.CaseRecord.CaseHistory.Add(ch));
        }
    }
}
