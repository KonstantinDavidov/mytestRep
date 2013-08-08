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
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.Interfaces;

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

            this.WhenAny(x => x.CalendarDate
                ,x => x.Courtroom
                ,x => x.Session
                ,(x1, x2, x3) => new {CalendarDate = x1.Value, Courtroom = x2.Value, Session = x3.Value}
                ).Subscribe(x =>
                    {
                        ICourtDocketSearchCriteria criteria = ServiceLocatorContainer.Locator.GetInstance<ICourtDocketSearchCriteria>();
                        criteria.Session = x.Session;
                        criteria.Date = x.CalendarDate.GetValueOrDefault(DateTime.Now);
                        criteria.CourtRoomId = x.Courtroom != null ? x.Courtroom.Id : (long?)null;
                    }
                    );

            _windowManager = windowManager;
            this.DisplayName = "Court Docket";
            this.CalendarDate = DateTime.Today;
            DataContainer.SearchDocket();
               
        }

        protected override void Authorized()
        {
            base.Authorized();
            this.NotifyOfPropertyChange(() => CourtCases);
        }

        private ReactiveCollection<CourtCaseHeading> _courtCases;
        public ReactiveCollection<CourtCaseHeading> CourtCases
        {
            get
            {
                if (this.IsAuthenticated && _courtCases == null)
                {
                    _courtCases = DataContainer.CourtCaseHeadings.CreateDerivedCollection(x => x, filter: x => !x.HasDocket, signalReset: this.WhenAny(y => y.CollectionChangedNotifier, y => y));
                }
                return _courtCases;
            }
        }

        public void AddCase()
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<AddToCourtDocketDialogViewModel>();
            vm.CurrentCourtCase = CurrentCourtCase;
            if (_windowManager.ShowDialog(vm).GetValueOrDefault(false))
            {
                RefreshDocket();
            }
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
            //vm.CurrentCourtCase = CurrentCourtCase;
            //_windowManager.ShowDialog(vm);
        }

        public void Reissue()
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<ReissueCaseDialogViewModel>();
            //vm.CurrentCourtCase = CurrentCourtCase;
            //_windowManager.ShowDialog(vm);
        }

        private TrackableCollection<DocketRecord> _hearings;
        public TrackableCollection<DocketRecord> Hearings
        {
            get
            {
                if (_hearings == null)
                {
                    //_hearings = DataContainer.Hearings;
                }
                return _hearings;
            }
        }




        private Faccts.Model.Entities.CourtCaseHeading _currentCourtCase;
        public Faccts.Model.Entities.CourtCaseHeading CurrentCourtCase
        {
            get { return _currentCourtCase; }
            set
            {
                this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
            }
        }

        public void Save()
        {
            bool succeeded = false;
            try
            {
                DataContainer.SaveDocket();
                succeeded = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            if (succeeded)
            {
                DataContainer.SearchDocket();
                _courtCases = null;
                NotifyOfPropertyChange(() => CourtCases);
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

        private List<Courtrooms> _courtrooms;
        public List<Courtrooms> Courtrooms
        {
            get
            {
                if (_courtrooms == null)
                {
                    _courtrooms = DataContainer.AvailableCourtrooms;
                }
                return _courtrooms;
            }
        }

        private List<EnumDescript<DocketSession>> _sessionList;
        public List<EnumDescript<DocketSession>> SessionList
        {
            get
            {
                if (_sessionList == null)
                {
                    _sessionList = EnumDescript<DocketSession>.GetList();
                }
                return _sessionList;
            }
        }

        private DocketSession? _session;
        public DocketSession? Session
        {
            get
            {
                return _session;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _session, value);
            }
        }

    }
}
