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
    public partial class WitnessInterpereterViewModel : CaseRecordItemViewModel, IHandle<CurrentHearingChanged>
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
                    CourtParty = CurrentCourtCase.Party1,
                    Designation = DataContainer.Designations.FirstOrDefault(),
                };
            if (this.CurrentHistoryRecord != null)
            {
                this.CurrentHistoryRecord.Witnesses.Add(newWitness);
            }
            else
            {
                CurrentCourtCase.Witnesses.Add(newWitness);
            }
            
        }

        public void RemoveWitness(Witnesses witness)
        {
            if (_dialogService.MessageBox("Do you really want to remove the witness?", "Witness removal", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                if (this.CurrentHistoryRecord != null)
                {
                    this.CurrentHistoryRecord.Witnesses.Remove(witness);
                }
                else
                {
                    this.CurrentCourtCase.Witnesses.Remove(witness);
                }
                
            }
        }

        public void AddInterpreter()
        {
            var newInterpreter = new Interpreters()
            {
                CourtParty = CurrentCourtCase.Party1,
                Language = "English",
            };
            var collection = this.CurrentHistoryRecord != null ? this.CurrentHistoryRecord.Interpreters : this.CurrentCourtCase.Interpreters;
            collection.Add(newInterpreter);
        }

        public void RemoveInterpreter(Interpreters interpreter)
        {
            if (_dialogService.MessageBox("Do you really want to remove the interpreter?", "Interpreter removal", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                var collection = this.CurrentHistoryRecord != null ? this.CurrentHistoryRecord.Interpreters : this.CurrentCourtCase.Interpreters;
                collection.Remove(interpreter);
            }
        }

        public List<CourtPartyAdapter> WitnessesFor
        {
            get
            {
                if (CurrentCourtCase == null)
                    return null;
                List<CourtPartyAdapter> result = new List<CourtPartyAdapter>()
                {
                    new CourtPartyAdapter(CurrentCourtCase.Party1),
                    new CourtPartyAdapter(CurrentCourtCase.Party2, false),
                };

                return result;
            }
        }

        public List<CourtPartyAdapter> InterpretersFor
        {
            get
            {
                if (CurrentCourtCase == null)
                    return null;
                List<CourtPartyAdapter> result = new List<CourtPartyAdapter>()
                {
                    new CourtPartyAdapter(CurrentCourtCase.Party1, true, "Interpreter For:"),
                    new CourtPartyAdapter(CurrentCourtCase.Party2, false, "Interpreter For:"),
                };

                return result;
            }
        }

        public void Handle(CurrentHearingChanged message)
        {
            if (message == null || message.Hearing == null)
            {
                this.CurrentHistoryRecord = null;
                return;
            }
            this.CurrentHistoryRecord = message.Hearing.CaseHistory;
        }
    }
}
