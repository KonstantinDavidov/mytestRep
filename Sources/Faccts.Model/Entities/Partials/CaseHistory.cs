using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class CaseHistory
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.CaseHistoryEvent, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("CaseEventName");
                });
            this.Appearance = new Appearance();
            this.Hearing = new Hearings();
        }

        public string CaseEventName
        {
            get
            {
                return ((FACCTS.Server.Model.Enums.CaseHistoryEvent)this.CaseHistoryEvent).ToDescription();
            }
        }

        public string CourtCaseNumber
        {
            get
            {
                return this.CaseRecord.CourtCase[0].CaseNumber;
            }

        }
    }
}
