using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using FACCTS.Controls.Events;
using FACCTS.Services.Authentication;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class CaseNotesViewModel : ViewModelBase, IHandle<CurrentCourtCaseChangedEvent>
    {
        private IEventAggregator _eventAggregator;
        private IAuthenticationService _authService;

        [ImportingConstructor]
        public CaseNotesViewModel(IEventAggregator eventAggregator,
            IAuthenticationService authService
            ) : base()
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            _authService = authService;
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.NotifyOfPropertyChange(() => CaseRecord);
                });

            this.DisplayName = "Case Notes";
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

        public void Handle(CurrentCourtCaseChangedEvent message)
        {
            this.CurrentCourtCase = message.CourtCase;
        }
    }
}
