using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class CaseRecord
    {
        partial void Initialize()
        {
            this.CaseHistory = new TrackableCollection<CaseHistory>();
            this.CaseNotes = new TrackableCollection<CaseNotes>();
            this.Witnesses = new TrackableCollection<Witnesses>();
            this.Interpreters = new TrackableCollection<Interpreters>();
            this.OtherProtected = new TrackableCollection<OtherProtected>();
            this.CourtParty1 = new CourtParty();
            this.CourtParty = new CourtParty();
            this.CourtCaseOrders = new TrackableCollection<CourtCaseOrders>();
        }
    }
}
