using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using Faccts.Model.Entities;
using FACCTS.Controls.Events;
using FACCTS.Controls.Utils;
using FACCTS.Services;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FACCTS.Controls.ViewModels
{
    
    [Export(typeof(CaseRecordViewModel))]
    public class CaseRecordViewModel : OneActiveViewModelBase
    {
        private IEventAggregator _eventAggregator;

        [ImportingConstructor]
        public CaseRecordViewModel(PersonalInformationViewModel personalInformation
            , ChildrenOtherProtectedViewModel childrenViewModel
            , AttorneysViewModel attorneysViewModel
            , WitnessInterpereterViewModel witnessInterprererViewModel
            , RelatedCasesViewModel relatedCasesViewModel
            , CaseNotesViewModel caseNotesViewModel
            , CaseHistoryViewModel caseHistoryViewModel
            , IWindowManager windowManager
            , IEventAggregator eventAggregator
            )
            : base()
        {
            _windowManager = windowManager;
            this.DisplayName = "Case Record";
            PersonalInformationViewModel = personalInformation;
            ChildrenOtherProtectedViewModel = childrenViewModel;
            AttorneysViewModel = attorneysViewModel;
            WitnessInterpereterViewModel = witnessInterprererViewModel;
            RelatedCasesViewModel = relatedCasesViewModel;
            CaseNotesViewModel = caseNotesViewModel;
            CaseHistoryViewModel = caseHistoryViewModel;
            _eventAggregator = eventAggregator;
            Observable.Merge(
                this.ObservableForProperty(x => x.IsActive),
                this.ObservableForProperty(x => x.IsAuthenticated)
                ).Subscribe(_ =>
                {
                    if (this.IsAuthenticated && this.IsActive)
                    {
                        this.Authorized();
                    }
                });
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    if (x == null)
                    {
                        CurrentHearing = null;
                    }
                    else
                    {
                        CurrentHearing = x.Hearings.FirstOrDefault();
                    }
                }
                );
            this.WhenAny(
                x => x.PersonalInformationViewModel.HasUIErrors,
                x => x.ChildrenOtherProtectedViewModel.HasUIErrors,
                x => x.AttorneysViewModel.HasUIErrors,
                x => x.WitnessInterpereterViewModel.HasUIErrors,
                x => x.CaseNotesViewModel.HasUIErrors,
                x => x.CaseHistoryViewModel.HasUIErrors,
                (x1, x2, x3, x4, x5, x6) =>
                    x1.Value || x2.Value || x3.Value || x4.Value || x5.Value || x6.Value
                ).Subscribe(x =>
                {
                    this.HasUIErrors = x;
                }
                );

            ActivateControl(PersonalInformationViewModel);
        }

        public override IDataContainer DataContainer
        {
            protected get
            {
                return base.DataContainer;
            }
            set
            {
                if (base.DataContainer != null)
                {
                    base.DataContainer.PropertyChanged -= DataContainerPropertyChanged;
                }
                base.DataContainer = value;
                if (base.DataContainer != null)
                {
                    base.DataContainer.PropertyChanged += DataContainerPropertyChanged;
                }
            }
        }

        private void DataContainerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
                if (e.PropertyName == "CourtCases")
                {
                    _courtCases = null;
                    this.NotifyOfPropertyChange(() => CourtCases);
                }
        }

        protected override void Authorized()
        {
            this.NotifyOfPropertyChange(() => CourtCases);
        }

        private TrackableCollection<CourtCase> _courtCases;
        public TrackableCollection<CourtCase> CourtCases
        {
            get
            {
                if (IsAuthenticated && _courtCases == null)
                {
                    _courtCases = DataContainer.CourtCases;
                    if (CurrentCourtCase == null)
                    {
                        CurrentCourtCase = _courtCases.FirstOrDefault();
                    }
                }
                return _courtCases;
            }
        }


        public void SelectedHistoryChanged(RoutedPropertyChangedEventArgs<Object> e)
        {
            if (!(e.NewValue is Hearings))
                return;
            this.CurrentHearing = (Hearings)e.NewValue;
        }

        private Hearings _currentHearing;
        public Hearings CurrentHearing
        {
            get
            {
                return _currentHearing;
            }
            set
            {
                if (_currentHearing == value)
                    return;

                this.NotifyOfPropertyChanging();
                _currentHearing = value;
                _eventAggregator.Publish(new CurrentHearingChanged(_currentHearing));
                this.NotifyOfPropertyChange();
            }
        }

        private void _authenticationService_AuthenticationStatusChanged(object sender, AuthenticationStatusChangedEventArgs e)
        {
            this.IsAuthenticated = e.AuthenticationStatus == AuthenticationStatus.Authenticated;
        }

        private IWindowManager _windowManager;
        public PersonalInformationViewModel PersonalInformationViewModel { get; protected set; }
        public ChildrenOtherProtectedViewModel ChildrenOtherProtectedViewModel { get; protected set; }
        public AttorneysViewModel AttorneysViewModel { get; protected set; }
        public WitnessInterpereterViewModel WitnessInterpereterViewModel { get; protected set; }
        public RelatedCasesViewModel RelatedCasesViewModel { get; protected set; }
        public CaseNotesViewModel CaseNotesViewModel { get; protected set; }
        public CaseHistoryViewModel CaseHistoryViewModel { get; protected set; }

        public void ActivateControl(CaseRecordItemViewModel selectedViewModel)
        {
            if (selectedViewModel == null)
                return;
            ActivateItem(selectedViewModel);
        }

        public void NewCase()
        {
            BusinessLogicHelper.CreateNewCase(ServiceLocatorContainer.Locator.GetInstance<NewCourtCaseDialogViewModel>(), _windowManager);
        }

        private CourtCase _currentCourtCase;
        public CourtCase CurrentCourtCase
        {
            get
            {
                return _currentCourtCase;
            }
            set
            {
                if (_currentCourtCase == value)
                    return;

                this.NotifyOfPropertyChanging();
                _currentCourtCase = value;
                _eventAggregator.Publish(new CurrentCourtCaseChangedEvent(_currentCourtCase));
                this.NotifyOfPropertyChange();
            }
        }

        private List<CourtCase> _selectedCourtCases;
        public List<CourtCase> SelectedCourtCases
        {
            get
            {
                return _selectedCourtCases;
            }
            set
            {
                if (_selectedCourtCases == value)
                    return;

                this.NotifyOfPropertyChanging();
                _selectedCourtCases = value;
                this.NotifyOfPropertyChange();
                _eventAggregator.Publish(new SelectedCourtCasesChangedEvent(_selectedCourtCases));
            }
        }

        public void SelectionCourtCasesChanged(SelectionChangedEventArgs e)
        {
            if (e.Source == null || (e.Source as ListBox) == null)
                return;
            this.SelectedCourtCases = (e.Source as ListBox).SelectedItems
                .Cast<CourtCase>()
                .ToList();
            
        }

        public void CaseRecordSave()
        {
            if (CurrentCourtCase != null && this.CurrentCourtCase.IsDirty)
            {
                DataContainer.SaveData(this.CurrentCourtCase);
            }
            
        }

        private bool _hasUIErrors = false;
        public bool HasUIErrors
        {
            get
            {
                return _hasUIErrors;
            }
            protected set
            {
                if (_hasUIErrors == value)
                    return;

                this.NotifyOfPropertyChanging();
                _hasUIErrors = value;
                this.NotifyOfPropertyChange();
            }
        }
       
    }
}
