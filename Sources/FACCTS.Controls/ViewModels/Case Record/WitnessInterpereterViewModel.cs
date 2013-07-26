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
using System.Reactive.Linq;


namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(WitnessInterpereterViewModel))]
    public partial class WitnessInterpereterViewModel : CaseRecordItemViewModel, IHandle<CurrentHearingChanged>
    {
        private IDialogService _dialogService;
        private IDisposable _observer1, _observer2;



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

                    if (_observer1 != null)
                    {
                        _observer1.Dispose();
                        _observer1 = null;
                    }
                    if (_observer2 != null)
                    {
                        _observer2.Dispose();
                        _observer2 = null;
                    }
                    if (this.CurrentCourtCase != null)
                    {
                        _observer1 = this.CurrentCourtCase.Witnesses.ItemChanged.Subscribe(z => 
                        {
                            this.HasUIErrors = this.CurrentCourtCase.IsDirty && 
                                (
                                this.CurrentCourtCase.Witnesses.Any(z1 => !z1.IsValid)
                                || this.CurrentCourtCase.IsDirty && this.CurrentCourtCase.Interpreters.Any(z1 => !z1.IsValid)
                                );
                        }
                        );
                        _observer2 = this.CurrentCourtCase.Interpreters.ItemChanged.Subscribe(z =>
                        {
                            this.HasUIErrors = this.CurrentCourtCase.IsDirty &&  (
                                this.CurrentCourtCase.Witnesses.Any(z1 => !z1.IsValid)
                                || this.CurrentCourtCase.IsDirty && this.CurrentCourtCase.Interpreters.Any(z1 => !z1.IsValid)
                                );
                        }
                        );
                    }
                }
                );

            this.DisplayName = "Withess and Interpreter";
        }


        public void AddWitness()
        {
            this.CurrentCourtCase.NewWitness();
            
        }

        public void RemoveWitness(PersonBase witness)
        {
            if (_dialogService.MessageBox("Do you really want to remove the witness?", "Witness removal", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                this.CurrentCourtCase.RemoveAdditionalParty(witness);
            }
        }

        public void AddInterpreter()
        {
            this.CurrentCourtCase.NewInterpreter();
        }

        public void RemoveInterpreter(Interpreter interpreter)
        {
            if (_dialogService.MessageBox("Do you really want to remove the interpreter?", "Interpreter removal", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                CurrentCourtCase.RemoveInterpreter(interpreter);
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
                    new CourtPartyAdapter(PartyFor.Party1, GetNameForParty, "Witness for: ", CurrentCourtCase.Party1.FullNameChanged, CurrentCourtCase.Party2.FullNameChanged),
                    new CourtPartyAdapter(PartyFor.Party2, GetNameForParty, "Witness for: ", CurrentCourtCase.Party1.FullNameChanged, CurrentCourtCase.Party2.FullNameChanged),
                };

                return result;
            }
        }

        private string GetNameForParty(PartyFor pf)
        {
            switch (pf)
            {
                case PartyFor.Party1:
                    return CurrentCourtCase.Party1.FullName;
                case PartyFor.Party2:
                    return CurrentCourtCase.Party2.FullName;
            }
            return null;
        }

        public List<CourtPartyAdapter> InterpretersFor
        {
            get
            {
                if (CurrentCourtCase == null)
                    return null;
                List<CourtPartyAdapter> result = new List<CourtPartyAdapter>()
                {
                    new CourtPartyAdapter(PartyFor.Party1, GetNameForParty, "Interpreter For:", CurrentCourtCase.Party1.FullNameChanged, CurrentCourtCase.Party2.FullNameChanged),
                    new CourtPartyAdapter(PartyFor.Party2, GetNameForParty, "Interpreter For:", CurrentCourtCase.Party1.FullNameChanged, CurrentCourtCase.Party2.FullNameChanged),
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
            //this.CurrentHistoryRecord = message.Hearing.CaseHistory;
        }
    }
}
