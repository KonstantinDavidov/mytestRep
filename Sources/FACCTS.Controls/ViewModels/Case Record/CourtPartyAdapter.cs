using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    public class CourtPartyAdapter : ViewModelBase
    {
        private string _prefix;
        private Func<PartyFor, string> _partyNameFactory;
        public CourtPartyAdapter(PartyFor partyFor, Func<PartyFor, string> partyNameFactory, string prefix = "Witness for:", params IObservable<IObservedChange<CourtParty, string>>[] observables)
            : base()
        {
            if (partyNameFactory == null)
            {
                throw new ArgumentNullException("partyNameFactory");
            }
            PartyFor = partyFor;
            _partyNameFactory = partyNameFactory;
            _prefix = prefix;
            observables.Aggregate(0, (index, ob) =>
                {
                    ob.Subscribe(_ =>
                        {
                            UpdateDisplayName();
                        }
                        );
                    return 0;
                }
                );
            UpdateDisplayName();
        }

        private void UpdateDisplayName()
        {
            string partyName = _partyNameFactory.Invoke(PartyFor);
            if (string.IsNullOrWhiteSpace(partyName))
            {
                DisplayName = string.Format("{0} {1}", _prefix, PartyFor.ToString());
            }
            else
            {
                DisplayName = string.Format("{0} {1}", _prefix, partyName);
            }
        }

        public PartyFor PartyFor
        {
            get;
            private set;
        }


        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
