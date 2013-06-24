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

            this.WhenAny(x => x.AttorneyForChildrenIsTheSameThenParty1, x => x.Value)
                .Subscribe(x =>
                    {
                        if (CaseRecord == null)
                            return;
                        if (x)
                        {
                            CaseRecord.Attorneys = CaseRecord.CourtParty.Attorneys;
                        }
                        else
                        {
                            CaseRecord.Attorneys = new Attorneys();
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
