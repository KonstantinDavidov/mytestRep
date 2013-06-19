using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class SeparateCaseDialogViewModel : ViewModelBase
    {
        public SeparateCaseDialogViewModel() : base()
        {
            this.DisplayName = "Separate Case";
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


        }

        public void Separate()
        {
            this.TryClose(true);
            Task.Factory.StartNew(() => ProceedSeparation());
        }

        private void ProceedSeparation()
        {
            //TODO: implement separation
        }



    }
}
