using FACCTS.Server.Model.Enums;
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
            this.Attorneys = new Attorneys();
            this.Children = new TrackableCollection<Children>();
            this.RestrainingpartyIdentificationInformation = new RestrainingPartyIDInfo();
        }

        public DateTime? FileDate
        {
            get
            {
                if (this.CaseHistory == null || !CaseHistory.Any())
                {
                    return null;
                }
                var fileEvent = CaseHistory.FirstOrDefault(x => x.CaseHistoryEvent == (int)CaseHistoryEvent.New);
                if (fileEvent == null)
                    return null;
                return fileEvent.Date;
            }
        }
    }
}
