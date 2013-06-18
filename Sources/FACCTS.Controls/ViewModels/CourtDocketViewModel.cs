using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Caliburn.Micro;
using FACCTS.Services;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CourtDocketViewModel))]
    public class CourtDocketViewModel : ViewModelBase
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

        public void AddCase()
        {
            _windowManager.ShowDialog(ServiceLocatorContainer.Locator.GetInstance<AddToCourtDocketDialogViewModel>());
        }
    }
}
