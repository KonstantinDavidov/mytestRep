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
    public partial class AttorneysViewModel : ViewModelBase, IHandle<CurrentCourtCaseChangedEvent>
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public AttorneysViewModel(IEventAggregator eventAggregator) : base()
        {
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x => 
                {
                    this.NotifyOfPropertyChange(() => CaseRecord);
                });

            this.WhenAny(
                x => x.AttorneyForChildrenIsTheSameThenParty1,
                x => x.AttorneyForChildrenIsTheSameThenParty2,
                (x, y) => new { IsParty1 = x.Value, IsParty2 = y.Value})
                .Subscribe(x =>
                    {
                        if (CaseRecord == null)
                            return;
                        if (!x.IsParty1 && !x.IsParty2)
                        {
                            CaseRecord.Attorneys = new Attorneys(); 
                        } else
                        if (x.IsParty1)
                        {
                            CaseRecord.Attorneys = CaseRecord.CourtParty.Attorneys;
                        }
                        else
                        {
                            CaseRecord.Attorneys = CaseRecord.CourtParty1.Attorneys;
                        }
                    }
                );

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            this.DisplayName = "Attorneys";
        }

        public void Handle(CurrentCourtCaseChangedEvent message)
        {
            this.CurrentCourtCase = message.CourtCase;
        }

        public CaseRecord CaseRecord
        {
            get
            {
                if (CurrentCourtCase == null || CurrentCourtCase.CaseRecord == null)
                    return null;
                return CurrentCourtCase.CaseRecord;
            }
        }

        
    }
}
