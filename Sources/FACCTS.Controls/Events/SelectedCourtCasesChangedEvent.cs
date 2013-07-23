using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.Events
{
    public class SelectedCourtCasesChangedEvent
    {
        public List<CourtCase> SelectedCourtCases { get; private set; }

        public SelectedCourtCasesChangedEvent(List<CourtCase> selectedCourtCases)
        {
            SelectedCourtCases = selectedCourtCases;
        }
    }
}
