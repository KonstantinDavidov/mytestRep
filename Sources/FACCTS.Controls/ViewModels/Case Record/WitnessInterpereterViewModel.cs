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
using FACCTS.Server.Model.Enums;


namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(WitnessInterpereterViewModel))]
    public partial class WitnessInterpereterViewModel : CaseRecordItemViewModel, IHandle<CurrentHearingChanged>
    {
        private IDialogService _dialogService;
        private IDisposable _observer1, _observer2, _observer3;



        [ImportingConstructor]
        public WitnessInterpereterViewModel(
            IDialogService dialogService
            ) : base()
        {
            _dialogService = dialogService;
            this.WhenAny(x => x.CurrentCourtCase, x => x.IsActive, (x1, x2) => new { CourtCase = x1.Value, IsActive = x2.Value })
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
                    if (_observer3 != null)
                    {
                        _observer3.Dispose();
                        _observer3 = null;
                    }
                    System.Action updater = () => this.HasUIErrors = x.CourtCase.IsDirty &&
                                (
                                x.CourtCase.Witnesses.Any(z1 => !z1.IsValid)
                                || x.CourtCase.IsDirty && x.CourtCase.Interpreters.Any(z1 => !z1.IsValid)
                                );
                    if (x.CourtCase != null)
                    {
                        x.CourtCase.Witnesses.ChangeTrackingEnabled = x.IsActive;
                        x.CourtCase.Interpreters.ChangeTrackingEnabled = x.IsActive;
                        if (x.IsActive)
                        {
                            _observer1 = x.CourtCase.Witnesses.ItemChanged.Subscribe(z =>
                            {
                                updater.Invoke();
                            }
                            );
                            _observer2 = x.CourtCase.Interpreters.ItemChanged.Subscribe(z =>
                            {
                                updater.Invoke();
                            }
                            );
                            _observer3 = Observable.Merge(
                                x.CourtCase.Witnesses.CollectionCountChanged,
                                x.CourtCase.Interpreters.CollectionCountChanged
                                ).Subscribe(_ =>
                                {
                                    updater.Invoke();
                                }
                                );
                        }
                       
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

        private static List<string> predefinedLanguages = new List<string>()
        {
                "English", 
                "French",
                "Italian",
                "Polish",
                "Portuguese",
                "Spanish",
                "Romanian",
                "German",
                "Dutch",
                "Greek",
                "Albanian",
                "Swedish",
                "Danish",
                "Norwegian",
                "Icelandic",
                "Russian",
        };

        public List<string> PredefinedLanguages
        {
            get
            {
                return predefinedLanguages;
            }
        }
    }
}
