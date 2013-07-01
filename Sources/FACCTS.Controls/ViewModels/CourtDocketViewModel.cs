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
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.CanDropDismiss = x != null;
                    this.CanReissue = x != null;
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

        private TrackableCollection<CaseHistory> _historyRecords;
        public IEnumerable<CaseHistory> HistoryRecords
        {
            get
            {
                if (_historyRecords == null)
                {
                    return null;
                }
                return _historyRecords.Where(x => x.CaseHistoryEvent == (int)FACCTS.Server.Model.Enums.CaseHistoryEvent.Hearing);
            }
            set
            {
                if (!(value is TrackableCollection<CaseHistory>))
                {
                    throw new Exception("Please use TrackableCollection for HistoryRecords");
                }
                this.RaiseAndSetIfChanged(ref _historyRecords, (TrackableCollection<CaseHistory>)value);
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
                        HistoryRecords = _currentCourtCase.CaseRecord.CaseHistory;
                    }
                    else
                    {
                        HistoryRecords = null;
                    }

                }
            }
        }

        private void CaseHistoryChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyOfPropertyChange(() => HistoryRecords);
        }

    }
}
