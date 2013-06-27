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
    public partial class CaseNotesViewModel : CaseRecordItemViewModel
    {
        private IAuthenticationService _authService;

        [ImportingConstructor]
        public CaseNotesViewModel(
            IAuthenticationService authService
            ) : base()
        {
            
            _authService = authService;
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
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
            this.WhenAny(x => x.CaseNoteForSelectedUser, x => x.Value)
                .Subscribe(x =>
                {
                    if (x != null)
                    {
                        this.CanEditNote = x.User == authService.CurrentUser;
                    }
                    else
                    {
                        this.CanEditNote = false;
                    }
                }
                );

            this.DisplayName = "Case Notes";
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

        public void MakePublic()
        {
            if (this.CaseNoteForSelectedUser == null)
                return;
            CaseNoteForSelectedUser.IsPublic = true;
        }

        public void MakePrivate()
        {
            if (this.CaseNoteForSelectedUser == null)
                return;
            CaseNoteForSelectedUser.IsPublic = false;
        }
        
    }
}
