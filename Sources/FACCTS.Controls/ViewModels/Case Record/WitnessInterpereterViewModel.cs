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
    public partial class WitnessInterpereterViewModel : ViewModelBase, IHandle<CurrentCourtCaseChangedEvent>
    {
        private IEventAggregator _eventAggregator;
        private IDialogService _dialogService;

        [ImportingConstructor]
        public WitnessInterpereterViewModel(
            IEventAggregator eventAggregator,
            IDialogService dialogService
            ) : base()
        {
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _eventAggregator.Subscribe(this);
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.NotifyOfPropertyChange(() => CaseRecord);
                    this.NotifyOfPropertyChange(() => WitnessesFor);
                }
                );

            this.DisplayName = "Withess and Interpreter";
        }

        public void Handle(CurrentCourtCaseChangedEvent message)
        {
            this.CurrentCourtCase = message.CourtCase;
        }

        public CaseRecord CaseRecord
        {
            get
            {
                if (CurrentCourtCase == null || CurrentCourtCase.CaseRecord == null)
                    return null;
                return CurrentCourtCase.CaseRecord;
            }
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

        public List<WitnessForAdapter> WitnessesFor
        {
            get
            {
                List<WitnessForAdapter> result = new List<WitnessForAdapter>()
                {
                    new WitnessForAdapter(CaseRecord.CourtParty),
                    new WitnessForAdapter(CaseRecord.CourtParty1, false),
                };

                return result;
            }
        }
    }
}
