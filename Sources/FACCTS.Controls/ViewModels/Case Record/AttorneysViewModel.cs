using Caliburn.Micro;
using Faccts.Model.Entities;
using FACCTS.Controls.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(AttorneysViewModel))]
    public partial class AttorneysViewModel : CaseRecordItemViewModel
    {

        [ImportingConstructor]
        public AttorneysViewModel() : base()
        {
            this.WhenAny(
                x => x.AttorneyForChildrenIsTheSameThenParty1,
                x => x.AttorneyForChildrenIsTheSameThenParty2,
                (x, y) => new { IsParty1 = x.Value, IsParty2 = y.Value})
                .Subscribe(x =>
                    {
                        if (CurrentCourtCase == null)
                            return;
                        if (!x.IsParty1 && !x.IsParty2)
                        {
                            CurrentCourtCase.Attorneys = new Attorneys(); 
                        } else
                        if (x.IsParty1)
                        {
                            CurrentCourtCase.Attorneys = CurrentCourtCase.Party1.Attorneys;
                        }
                        else
                        {
                            CurrentCourtCase.Attorneys = CurrentCourtCase.Party2.Attorneys;
                        }
                    }
                );

            this.DisplayName = "Attorneys";
        }

        
        
    }
}
