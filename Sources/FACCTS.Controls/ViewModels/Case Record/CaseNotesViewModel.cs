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
                    if (x != null)
                    {
                        SelectedUser = null;
                        var caseNoteForCurrentUser = x.CaseNotes.FirstOrDefault(y => y.User == authService.CurrentUser);
                        if (caseNoteForCurrentUser == null)
                        {
                            var newCN = new CaseNotes()
                                {
                                    User = authService.CurrentUser,
                                };
                            this.CurrentCourtCase.CaseNotes.Add(newCN);
                            SelectedUser = authService.CurrentUser;
                            newCN.IsDirty = false;
                            //newCN.MarkAsUnchanged();
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
                    if (this.CurrentCourtCase == null || this.CurrentCourtCase.CaseNotes == null)
                    {
                        return;
                    }
                    this.CaseNoteForSelectedUser = this.CurrentCourtCase.CaseNotes.FirstOrDefault(y => y.User == x);
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
                if (CurrentCourtCase == null || CurrentCourtCase.CaseNotes == null)
                    return null;
                var r = CurrentCourtCase.CaseNotes.Select(x => x.User).ToList();
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
