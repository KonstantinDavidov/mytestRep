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
                    if (x != null && x.CaseRecord != null)
                    {
                        SelectedUser = null;
                        var caseNoteForCurrentUser = x.CaseRecord.CaseNotes.FirstOrDefault(y => y.User == authService.CurrentUser);
                        if (caseNoteForCurrentUser == null)
                        {
                            var newCN = new CaseNotes()
                                {
                                    User = authService.CurrentUser,
                                };
                            this.CaseRecord.CaseNotes.Add(newCN);
                            SelectedUser = authService.CurrentUser;
                        }
                    }
                    this.NotifyOfPropertyChange(() => AvailableUsers);
                });
            this.WhenAny(x => x.SelectedUser, x => x.Value)
                .Subscribe(x =>
                {
                    if (x == null)
                    {
                        this.CaseNoteForSelectedUser= null;
                        return;
                    }
                    if (this.CaseRecord == null || this.CaseRecord.CaseNotes == null)
                    {
                        return;
                    }
                    this.CaseNoteForSelectedUser = this.CaseRecord.CaseNotes.FirstOrDefault(y => y.User == x);
                }
                );

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

        public List<User> AvailableUsers
        {
            get
            {
                if (CaseRecord == null || CaseRecord.CaseNotes == null)
                    return null;
                var r = CaseRecord.CaseNotes.Select(x => x.User).ToList();
                if (SelectedUser == null)
                {
                    SelectedUser = r.FirstOrDefault();
                }
                return r;
            }
        }

        public void Handle(CurrentCourtCaseChangedEvent message)
        {
            this.CurrentCourtCase = message.CourtCase;
        }

        
    }
}
