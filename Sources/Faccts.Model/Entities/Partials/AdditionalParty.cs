using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class AdditionalParty
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.PartyFor, x => x.Value)
                .Subscribe(_ =>
                {
                    this.OnPropertyChanged("PartyToName");
                }
                );
        }

        public string PartyToName
        {
            get
            {
                string result = null;
                switch(this.PartyFor)
                {
                    case Entities.PartyFor.Party1:
                        result = !string.IsNullOrWhiteSpace(CourtCase.Party1.FullName) ? CourtCase.Party1.FullName : Entities.PartyFor.Party1.ToString();
                        break;
                    case Entities.PartyFor.Party2:
                        result = !string.IsNullOrWhiteSpace(CourtCase.Party2.FullName) ? CourtCase.Party2.FullName : Entities.PartyFor.Party2.ToString();
                        break;
                }

                return result;
            }
        }
    }
}
