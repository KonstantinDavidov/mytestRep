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
using FACCTS.Services;
using FACCTS.Services.Dialog;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(ChildrenOtherProtectedViewModel))]
    public partial class ChildrenOtherProtectedViewModel : CaseRecordItemViewModel
    {
        private IDialogService _dialogService;
        private IDisposable _sub1, _sub2;

        [ImportingConstructor]
        public ChildrenOtherProtectedViewModel(
            IDialogService dialogService
            ) : base()
        {
            _dialogService = dialogService;
            this.DisplayName = "Children - Other Protected";

            this.WhenAny(x => x.CurrentCourtCase, x => x.IsActive, (x1, x2) => new { CourtCase = x1.Value, IsActive = x2.Value})
                .Subscribe(x =>
                {
                    if (_sub1 != null)
                    {
                        _sub1.Dispose();
                        _sub1 = null;
                    }
                    if (_sub2 != null)
                    {
                        _sub2.Dispose();
                        _sub2 = null;
                    }

                    if (x == null || x.CourtCase == null)
                        return;
                    if (!x.CourtCase.IsDirty)
                        return;

                    x.CourtCase.Children.ChangeTrackingEnabled = x.IsActive;
                    x.CourtCase.Interpreters.ChangeTrackingEnabled = x.IsActive;
                    if (x.IsActive)
                    {
                        _sub2 = x.CourtCase.Interpreters.ItemChanged.Subscribe(_ =>
                        {
                            this.HasUIErrors = x.CourtCase.Children.Any(y => !y.IsValid) || x.CourtCase.Interpreters.Any(y => !y.IsValid);
                        }
                        );
                           

                        _sub1 = x.CourtCase.Children.ItemChanged.Subscribe(_ =>
                            {
                                this.HasUIErrors = x.CourtCase.Children.Any(y => !y.IsValid) || x.CourtCase.Interpreters.Any(y => !y.IsValid);
                            }
                            );
                    }
                }
                ); 
        }


        private List<EnumDescript<FACCTS.Server.Model.Enums.Relationship>> _relationShips;
        public List<EnumDescript<FACCTS.Server.Model.Enums.Relationship>> Relationships
        {
            get
            {
                if (_relationShips == null)
                {
                    _relationShips = Enum.GetValues(typeof(FACCTS.Server.Model.Enums.Relationship))
                        .Cast<FACCTS.Server.Model.Enums.Relationship>()
                        .Select(x => new EnumDescript<FACCTS.Server.Model.Enums.Relationship>(x))
                        .ToList();
                }
                return _relationShips;
            }
        }


        public void AddChild()
        {
            CurrentCourtCase.NewChild();
        }

        public void RemoveChild(Child child)
        {
            if (_dialogService.MessageBox("Do you really want to delete the child from the Court Case record?", "Deletion of the Child", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                CurrentCourtCase.RemoveChild(child);
            }
        }

        public void AddOtherProtected()
        {
            CurrentCourtCase.NewOtherProtected();
        }

        public void RemoveOtherProtected(OtherProtected otherProtected)
        {
            if (_dialogService.MessageBox("Do you really want to delete the other protected person from the Court Case record?", "Deletion of the Other Protected", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                CurrentCourtCase.RemoveOtherProtected(otherProtected);
            }
            
        }


        
    }
}
