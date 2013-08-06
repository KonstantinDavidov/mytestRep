using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.Events
{
    public class NewCourtCaseCreatedEvent
    {
        public CourtCase CourtCase { get; private set; }
        public CourtCaseHeading CourtCaseHeading { get; private set; }

        public NewCourtCaseCreatedEvent(CourtCase courtCase, CourtCaseHeading heading)
        {
            if (courtCase == null)
            {
                throw new ArgumentNullException("courtCase");
            }
            if (heading == null)
            {
                throw new ArgumentNullException("heading");
            }
            CourtCase = courtCase;
            CourtCaseHeading = heading;
        }
    }
}
