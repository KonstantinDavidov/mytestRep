using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CourtDocketViewModel))]
    public class CourtDocketViewModel : ViewModelBase
    {
        public CourtDocketViewModel() : base()
        {
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
    }
}
