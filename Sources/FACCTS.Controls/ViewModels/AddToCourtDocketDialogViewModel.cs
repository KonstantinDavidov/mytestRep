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
using FACCTS.Services;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class AddToCourtDocketDialogViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public AddToCourtDocketDialogViewModel(CourtDocketViewModel vmCourtDocket) : base()
        {
           this.CourtDocketViewModel = vmCourtDocket;
            this.WhenAny(
                x => x.Courtroom,
                x => x.Department,
                x => x.CourtDocketViewModel.CalendarDate,
                x => x.Session,
                x => x.IsPermanentRO,
                x => x.IsCCorCV,
                x => x.IsCS,
                x => x.IsSS,
                x => x.IsOtherHearingIssue,
                x => x.OtherHearingIssueText,
                (courtroom, department, calendarDate, session, isPermanentRO, isCCorCV, isCS, isSS, isOtherHearingIssue, otherHearingIssueText) =>
                new
                    {
                        Courtroom = courtroom.Value,
                        Department = department.Value,
                        CalendarDate = calendarDate.Value,
                        Session = session.Value,
                        IsPermanentRO = isPermanentRO.Value,
                        IsCCorCV = isCCorCV.Value,
                        IsCS = isCS.Value,
                        IsSS = isSS.Value,
                        IsOtherHearingIssue = isOtherHearingIssue.Value,
                        OtherHearingIssueText = otherHearingIssueText.Value
                    }
                )
                .Subscribe(x =>
                    
                    {
                        if (
                            x == null
                            || x.Courtroom == null
                            || x.Department == null
                            ||
                            (
                            !x.IsPermanentRO && !x.IsCCorCV && !x.IsCS && !x.IsSS && (!x.IsOtherHearingIssue || x.IsOtherHearingIssue && string.IsNullOrEmpty(x.OtherHearingIssueText)))
                            )
                        {
                            this.IsValid = false;
                            return;
                        }
                        this.IsValid = true;
                    });


            this.DisplayName = "Add Case to Docket";
            if (this.IsAuthenticated && this.Departments == null)
            {
                this.Departments = new ObservableCollection<CourtDepartment>(DataContainer.AvailableDepartments);
            }
            if (this.IsAuthenticated && this.Courtrooms == null)
            {
                this.Courtrooms = new ObservableCollection<Courtrooms>(DataContainer.AvailableCourtrooms);
            }
        }

        private List<EnumDescript<FACCTS.Server.Model.Enums.DocketSession>> _sessionList;
        public List<EnumDescript<FACCTS.Server.Model.Enums.DocketSession>> SessionList
        {
            get
            {
                if (_sessionList == null)
                {
                    _sessionList = EnumDescript<FACCTS.Server.Model.Enums.DocketSession>.GetList();
                }
                return _sessionList;
            }
        }

        
        private CourtDocketViewModel _courtDocketViewModel;
        public CourtDocketViewModel CourtDocketViewModel
        {
            get
            {
                return _courtDocketViewModel;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _courtDocketViewModel, value);
            }
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
            var totalTime = CourtDocketViewModel.CalendarDate.GetValueOrDefault();
            Hearings cr = new Hearings()
            {
                HearingDate = totalTime,
                Session = this.Session,
                Courtrooms = this.Courtroom,
                CourtDepartment = this.Department,
                HearingIssue = new HearingIssue()
                {
                    PermanentRO = this.IsPermanentRO,
                    ChildCustodyOrChildVisitation = this.IsCCorCV,
                    ChildSupport = this.IsCS,
                    SpousalSupport = this.IsSS,
                    IsOtherIssue = this.IsOtherHearingIssue,
                    OtheIssueText = this.OtherHearingIssueText,
                }
            };

            Execute.OnUIThread(() => DataContainer.Hearings.Add(cr));
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
                    }
                }
            }
        }

       

        
        

    }
}
