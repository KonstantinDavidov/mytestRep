using Caliburn.Micro;
using Faccts.Model.Entities;
using FACCTS.Controls.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Services.Dialog;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(WitnessInterpereterViewModel))]
    public partial class WitnessInterpereterViewModel : CaseRecordItemViewModel
    {
        private IDialogService _dialogService;

        [ImportingConstructor]
        public WitnessInterpereterViewModel(
            IDialogService dialogService
            ) : base()
        {
            _dialogService = dialogService;
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.NotifyOfPropertyChange(() => WitnessesFor);
                    this.NotifyOfPropertyChange(() => InterpretersFor);
                }
                );

            this.DisplayName = "Withess and Interpreter";
        }


        public void AddWitness()
        {
            var newWitness = new Witnesses()
                {
                    CourtParty = CaseRecord.CourtParty,
                    Designation = DataContainer.Designations.FirstOrDefault(),
                };

            CaseRecord.Witnesses.Add(newWitness);
        }

        public void RemoveWitness(Witnesses witness)
        {
            if (_dialogService.MessageBox("Do you really want to remove the witness?", "Witness removal", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                CaseRecord.Witnesses.Remove(witness);
            }
        }

        public void AddInterpreter()
        {
            var newInterpreter = new Interpreters()
            {
                CourtParty = CaseRecord.CourtParty,
                Language = "English",
            };
            CaseRecord.Interpreters.Add(newInterpreter);
        }

        public void RemoveInterpreter(Interpreters interpreter)
        {
            if (_dialogService.MessageBox("Do you really want to remove the interpreter?", "Interpreter removal", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                CaseRecord.Interpreters.Remove(interpreter);
            }
        }

        public List<CourtPartyAdapter> WitnessesFor
        {
            get
            {
                if (CaseRecord == null)
                    return null;
                List<CourtPartyAdapter> result = new List<CourtPartyAdapter>()
                {
                    new CourtPartyAdapter(CaseRecord.CourtParty),
                    new CourtPartyAdapter(CaseRecord.CourtParty1, false),
                };

                return result;
            }
        }

        public List<CourtPartyAdapter> InterpretersFor
        {
            get
            {
                if (CaseRecord == null)
                    return null;
                List<CourtPartyAdapter> result = new List<CourtPartyAdapter>()
                {
                    new CourtPartyAdapter(CaseRecord.CourtParty, true, "Interpreter For:"),
                    new CourtPartyAdapter(CaseRecord.CourtParty1, false, "Interpreter For:"),
                };

                return result;
            }
        }
    }
}
