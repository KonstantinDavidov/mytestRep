using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.Events
{
    public class CurrentCourtCaseChangedEvent
    {
        public CourtCase CourtCase { get; private set; }

        public CurrentCourtCaseChangedEvent(CourtCase courtCase)
        {
            CourtCase = courtCase;
        }
    }
}
