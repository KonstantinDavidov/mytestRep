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
        }

        protected override void Authorized()
        {
            base.Authorized();
            this.NotifyOfPropertyChange(() => CourtCases);
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

                this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
            }
        }


        private DateTime? _calendarDate;
        public DateTime? CalendarDate
        {
            get
            {
                return _calendarDate;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _calendarDate, value);
            }
        }

        private ObservableCollection<CourtCase> _courtCases;
        public ObservableCollection<CourtCase> CourtCases
        {
            get
            {
                if (this.IsAuthenticated && _courtCases == null)
                {
                    _courtCases = new ObservableCollection<CourtCase>(DataContainer.CourtCases);
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
    }
}
