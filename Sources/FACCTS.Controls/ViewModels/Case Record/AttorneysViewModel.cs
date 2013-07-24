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
using System.Reactive.Linq;

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
                            //CurrentCourtCase.Attorneys = new Attorneys(); 
                        } else
                        if (x.IsParty1)
                        {
                            CurrentCourtCase.AttorneyForChild = CurrentCourtCase.Party1.AttorneyData.Attorney;
                        }
                        else
                        {
                            CurrentCourtCase.AttorneyForChild = CurrentCourtCase.Party2.AttorneyData.Attorney;
                        }
                    }
                );

            this.DisplayName = "Attorneys";
        }

        private IDisposable _subscriber;
        public override void Handle(CurrentCourtCaseChangedEvent message)
        {
            if (_subscriber != null)
            {
                _subscriber.Dispose();
                _subscriber = null;
            }
            base.Handle(message);
            if (this.CurrentCourtCase != null)
            {
                _subscriber = Observable.Merge(
                    this.CurrentCourtCase.Party1.AttorneyData.Attorney.Changed,
                    this.CurrentCourtCase.Party2.AttorneyData.Attorney.Changed,
                    this.CurrentCourtCase.AttorneyForChild.Changed,
                    this.CurrentCourtCase.ThirdPartyAttorneyData.Attorney.Changed
                    ).Subscribe(_ =>
                    {

                        this.HasUIErrors = this.CurrentCourtCase.Party1.AttorneyData != null && this.CurrentCourtCase.Party1.AttorneyData.IsDirty && !this.CurrentCourtCase.Party1.AttorneyData.Attorney.IsValid
                                    || this.CurrentCourtCase.Party2.AttorneyData != null && this.CurrentCourtCase.Party2.AttorneyData.IsDirty && !this.CurrentCourtCase.Party2.AttorneyData.Attorney.IsValid
                                    || this.CurrentCourtCase.AttorneyForChild != null && this.CurrentCourtCase.AttorneyForChild.IsDirty && !this.CurrentCourtCase.AttorneyForChild.IsValid
                                    || this.CurrentCourtCase.ThirdPartyAttorneyData != null && this.CurrentCourtCase.ThirdPartyAttorneyData.IsDirty && !this.CurrentCourtCase.ThirdPartyAttorneyData.Attorney.IsValid;

                    }
                    );
               
            }
        }

        
    }
}
