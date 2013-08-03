using Faccts.Model.Entities;
using FACCTS.Controls.TreeListView;
using FACCTS.Services.Data;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class HistoryHeadingViewModel : ITreeModel
    {
        public HistoryHeadingViewModel(CourtCaseHeading heading)
        {
            if (heading == null)
            {
                throw new ArgumentNullException("heading");
            }
            Heading = heading;
            _historyHeadings = new Lazy<TrackableCollection<CourtCaseHeading>>(this.GetChildHeadings, true);
        }

        
        private TrackableCollection<CourtCaseHeading> GetChildHeadings()
        {
            return new TrackableCollection<CourtCaseHeading>(CourtCases.GetHistoryHeadings(Heading.CourtCaseId));
        }

        public CourtCaseHeading Heading
        {
            get;
            private set;
        }

        private Lazy<TrackableCollection<CourtCaseHeading>> _historyHeadings;
        public TrackableCollection<CourtCaseHeading> HistoryHeadings
        {
            get
            {
                return _historyHeadings.Value;
            }
        }

        public System.Collections.IEnumerable GetChildren(object parent)
        {
            return HistoryHeadings;
        }

        public bool HasChildren(object parent)
        {
            return HistoryHeadings.Any();
        }
    }
}
