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
    public partial class AttorneysViewModel : CaseRecordItemViewModel, IHandle<CurrentHearingChanged>
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
                            //CurrentCourtCase.Attorneys = new Attorneys(); 
                        } else
                        if (x.IsParty1)
                        {
                            CurrentHistoryRecord.AttorneyForChild = CurrentHistoryRecord.Party1AttorneyData.Attorney;
                        }
                        else
                        {
                            CurrentHistoryRecord.AttorneyForChild = CurrentHistoryRecord.Party2AttorneyData.Attorney;
                        }
                    }
                );

            this.DisplayName = "Attorneys";
        }




        public void Handle(CurrentHearingChanged message)
        {
            if (message == null || message.Hearing == null)
            {
                this.CurrentHistoryRecord = null;
                return;
            }
            this.CurrentHistoryRecord = message.Hearing.CaseHistory;
        }
    }
}
