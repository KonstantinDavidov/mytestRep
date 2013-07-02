using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Caliburn.Micro;
using FACCTS.Services;
using Faccts.Model.Entities;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.ComponentModel;
using System.Windows.Data;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CourtDocketViewModel))]
    public partial class CourtDocketViewModel : ViewModelBase
    {
        private IWindowManager _windowManager;
        [ImportingConstructor]
        public CourtDocketViewModel(
            IWindowManager windowManager
            ) : base()
        {
            _windowManager = windowManager;
            this.DisplayName = "Court Docket";
            this.CalendarDate = DateTime.Today;
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.CanDropDismiss = x != null;
                    this.CanReissue = x != null;
                });
            this.WhenAny(x => x.CollectionChangedNotifier, x => 0)
                .Subscribe(_ =>
                {
                    this.NotifyOfPropertyChange(() => CanDrop);
                    this.NotifyOfPropertyChange(() => CanDismiss);
                });
                
        }

        protected override void Authorized()
        {
            base.Authorized();
            this.NotifyOfPropertyChange(() => CourtCases);
        }

        private TrackableCollection<CourtCase> _courtCases;
        public TrackableCollection<CourtCase> CourtCases
        {
            get
            {
                if (this.IsAuthenticated && _courtCases == null)
                {
                    _courtCases = DataContainer.CourtCases;
                }
                return _courtCases;
            }
        }

        public void AddCase()
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<AddToCourtDocketDialogViewModel>();
            vm.CurrentCourtCase = CurrentCourtCase;
            _windowManager.ShowDialog(vm);
        }

        public void Drop()
        {
            DropDismiss(false);
        }

        public void Dismiss()
        {
            DropDismiss(true);
        }

        private void DropDismiss(bool dismiss)
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<DropDismissDialogViewModel>();
            vm.Dismiss = dismiss;
            vm.CurrentCourtCase = CurrentCourtCase;
            _windowManager.ShowDialog(vm);
        }

        public void Reissue()
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<ReissueCaseDialogViewModel>();
            vm.CurrentCourtCase = CurrentCourtCase;
            _windowManager.ShowDialog(vm);
        }

        

        private ReactiveCollection<CaseHistory> _historyRecords;
        public ReactiveCollection<CaseHistory> HistoryRecords
        {
            get
            {
                return _historyRecords;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _historyRecords, value);
            }
        }

        private Faccts.Model.Entities.CourtCase _currentCourtCase;
        public Faccts.Model.Entities.CourtCase CurrentCourtCase
        {
            get { return _currentCourtCase; }
            set
            {
                if (_currentCourtCase != value)
                {
                    if (_currentCourtCase != null && _currentCourtCase.CaseRecord != null && _currentCourtCase.CaseRecord.CaseHistory != null)
                    {
                        _currentCourtCase.CaseRecord.CaseHistory.CollectionChanged -= CaseHistoryChanged;
                    }
                    this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
                    if (_currentCourtCase != null && _currentCourtCase.CaseRecord != null && _currentCourtCase.CaseRecord.CaseHistory != null)
                    {
                        _currentCourtCase.CaseRecord.CaseHistory.CollectionChanged += CaseHistoryChanged;
                    }
                    if (_currentCourtCase != null && _currentCourtCase.CaseRecord != null && _currentCourtCase.CaseRecord.CaseHistory != null)
                    {
                        HistoryRecords = _currentCourtCase.CaseRecord.CaseHistory.CreateDerivedCollection(x => x, filter: FilterHistoryRecord, signalReset: this.WhenAny(x => x.CollectionChangedNotifier, x => x) );
                    }
                    else
                    {
                        HistoryRecords = null;
                    }

                }
            }
        }

        private bool FilterHistoryRecord(CaseHistory ch)
        {
            bool result =  ch.CaseHistoryEvent == (int)FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing;
            result &= (ch.Hearing != null && this.CalendarDate.HasValue && ch.Hearing.HearingDate.Date == this.CalendarDate.GetValueOrDefault()) || !this.CalendarDate.HasValue;
            result &= (this.Courtroom != null && ch.Hearing != null && ch.Hearing.Courtrooms == this.Courtroom) || this.Courtroom == null;
            int hours = ch.Hearing.HearingDate.TimeOfDay.Hours;
            result &= (0 <= hours && hours < 12 && (SessionType)this.SessionIndex == SessionType.AM)
                || ((12 <= hours && hours <= 23 && (SessionType)this.SessionIndex == SessionType.PM)) || (SessionType) SessionIndex == SessionType.Both;
            return result;
        }

        private void CaseHistoryChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                NotifyCollectionUpdated();
            }
            
        }

        private static Random rnd = new Random();
        private double _collectionChangedNotifier;
        public double CollectionChangedNotifier
        {
            get
            {
                return _collectionChangedNotifier;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _collectionChangedNotifier, value);
            }
        }

        public void RefreshDocket()
        {
            NotifyCollectionUpdated();
        }

        private void NotifyCollectionUpdated()
        {
            this.CollectionChangedNotifier = rnd.NextDouble();
        }

        public bool CanDrop
        {
            get
            {
                return CanDropDismiss && CurrentCourtCase.CaseStatus != Server.Model.Enums.CaseStatus.Dropped;
            }
        }

        public bool CanDismiss
        {
            get
            {
                return CanDropDismiss && CurrentCourtCase.CaseStatus != Server.Model.Enums.CaseStatus.Dismissed;
            }
        }

        private List<NameValueWrapper<Courtrooms>> _courtrooms;
        public List<NameValueWrapper<Courtrooms>> Courtrooms
        {
            get
            {
                if (_courtrooms == null)
                {
                    _courtrooms = DataContainer.AvailableCourtrooms.Select(x => new NameValueWrapper<Courtrooms>(x, y => y.RoomName)).ToList();
                    _courtrooms.Insert(0, new NameValueWrapper<Courtrooms>(null, y => y.RoomName, "All"));
                }
                return _courtrooms;
            }
        }

        protected enum SessionType
        {
            AM = 0,
            PM = 1,
            Both = 2,
        }
   
    }
}
