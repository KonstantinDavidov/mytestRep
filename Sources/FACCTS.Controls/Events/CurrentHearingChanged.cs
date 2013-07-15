using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.Events
{
    public class CurrentHearingChanged
    {
        public Hearings Hearing { get; private set; }

        public CurrentHearingChanged(Hearings hearing)
        {
            Hearing = hearing;
        }
    }
}
