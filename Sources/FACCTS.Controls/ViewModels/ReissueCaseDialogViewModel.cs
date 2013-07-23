using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive.Linq;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using Faccts.Model.Entities;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class ReissueCaseDialogViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public ReissueCaseDialogViewModel() : base()
        {
            this.DisplayName = "Reissuance";
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x => 
                {
                    if (x != null)
                    {
                        this.CaseNumber = x.CaseNumber;
                    }
                });

            Observable.Merge<Object>(
                    this.ObservableForProperty(x => x.NewCourtDate),
                    this.ObservableForProperty(x => x.Time),
                    this.ObservableForProperty(x => x.Courtroom),
                    this.ObservableForProperty(x => x.Department),
                    this.ObservableForProperty(x => x.NoPOS),
                    this.ObservableForProperty(x => x.FCSReferral),
                    this.ObservableForProperty(x => x.GetAttyToPrepare),
                    this.ObservableForProperty(x => x.IsOtherReason),
                    this.ObservableForProperty(x => x.OtherReason)
                )
                .Subscribe(_ =>
                {
                    if (!this.NewCourtDate.HasValue)
                    {
                        IsValid = false;
                        return;
                    }
                    if (this.Courtroom == null || this.Department == null)
                    {
                        IsValid = false;
                        return;
                    }
                    if (!(this.NoPOS || this.FCSReferral || this.GetAttyToPrepare || this.IsOtherReason))
                    {
                        IsValid = false;
                        return;
                    } else
                    if (!(this.NoPOS || this.FCSReferral || this.GetAttyToPrepare) && this.IsOtherReason && string.IsNullOrWhiteSpace(this.OtherReason))
                    {
                        IsValid = false;
                        return;
                    }
                    IsValid = true;
                });
            this.NoServiceRequired = true;
            this.Time = DateTime.Now.ToLocalTime();
            if (this.IsAuthenticated && this.Departments == null)
            {
                this.Departments = new ObservableCollection<CourtDepartment>(DataContainer.AvailableDepartments);
            }
            if (this.IsAuthenticated && this.Courtrooms == null)
            {
                this.Courtrooms = new ObservableCollection<Courtrooms>(DataContainer.AvailableCourtrooms);
            }
            
        }

        public void Reissue()
        {
            TryClose(true);
            Task.Factory.StartNew(() => ProceedReissue());
        }

        private void ProceedReissue()
        {
            //TODO: implement the reissuance ont the client and the server
        }


    }
}
