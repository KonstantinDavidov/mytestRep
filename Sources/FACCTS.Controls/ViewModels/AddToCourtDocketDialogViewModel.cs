using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive.Linq;
using System.Collections.ObjectModel;
using Caliburn.Micro;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class AddToCourtDocketDialogViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public AddToCourtDocketDialogViewModel() : base()
        {
            this.DisplayName = "Add Case to Docket";
            if (this.IsAuthenticated && this.Departments == null)
            {
                this.Departments = new ObservableCollection<CourtDepartmenets>(DataContainer.AvailableDepartments);
            }
            if (this.IsAuthenticated && this.Courtrooms == null)
            {
                this.Courtrooms = new ObservableCollection<Courtrooms>(DataContainer.AvailableCourtrooms);
            }
        }

        [Import]
        public CourtDocketViewModel CourtDocketViewModel
        {
            private get;
            set;
        }
        

        public void AddCase()
        {
            TryClose(true);
            Task.Factory.StartNew(() =>
            {
                ProceedAddition();
            });
           
        }

        private void ProceedAddition()
        {
            var totalTime = this.CourtDocketViewModel.CalendarDate.GetValueOrDefault().Add(new TimeSpan(this.Time.Hour, this.Time.Minute, this.Time.Second));
            CaseHistory ch = new CaseHistory()
                {
                    CaseHistoryEvent = (int)FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing,
                    Date = DateTime.Now,
                    Hearing = new Hearings()
                    {
                        HearingDate = totalTime,
                        Courtrooms = this.Courtroom,
                        HearingIssue = new HearingIssue()
                        {
                            PermanentRO = this.IsPermanentRO,
                            ChildCustodyOrChildVisitation = this.IsCCorCV,
                            ChildSupport = this.IsCS,
                            SpousalSupport = this.IsSS,
                            IsOtherIssue = this.IsOtherHearingIssue,
                            OtheIssueText = this.OtherHearingIssueText,
                        }
                    }
                };
            Execute.OnUIThread(() => CurrentCourtCase.CaseRecord.CaseHistory.Add(ch));
        }

        private Faccts.Model.Entities.CourtCase _currentCourtCase;
        public Faccts.Model.Entities.CourtCase CurrentCourtCase
        {
            get { return _currentCourtCase; }
            set
            {
                if (_currentCourtCase != value)
                {
                    _currentCourtCase = value;
                    this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
                    if (_currentCourtCase != null)
                    {
                        this.CaseNumber = _currentCourtCase.CaseNumber;
                        this.Time = DateTime.Now.ToLocalTime();
                    }
                }
            }
        }

       
       

        
        

    }
}
