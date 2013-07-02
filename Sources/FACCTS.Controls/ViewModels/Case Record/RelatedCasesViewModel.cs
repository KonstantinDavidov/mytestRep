using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Caliburn.Micro;
using FACCTS.Services;
using FACCTS.Controls.Events;
using System.Collections.ObjectModel;
using Faccts.Model.Entities;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(RelatedCasesViewModel))]
    public partial class RelatedCasesViewModel : ViewModelBase, IHandle<CurrentCourtCaseChangedEvent>, IHandle<SelectedCourtCasesChangedEvent>
    {
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator; 

        public RelatedCasesViewModel() : base()
        {
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value).Subscribe(x =>
                    {
                        this.CanSeparate = x != null;
                    }
                );
            this.WhenAny(x => x.SelectedCourtCases, x => x.Value)
                .Subscribe(x =>
                {
                    this.CanConsolidate = x != null && x.Count > 1;

                });
        }

        [ImportingConstructor]
        public RelatedCasesViewModel(IWindowManager windowManager
            , IEventAggregator eventAggregator
            ) : this()
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            this.DisplayName = "Related Cases";
            
        }

        public void Consolidate()
        {
            _windowManager.ShowDialog(ServiceLocatorContainer.Locator.GetInstance<ConsolidateCasesDialogViewModel>());
        }

        public void Separate()
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<SeparateCaseDialogViewModel>();
            vm.CurrentCourtCase = this.CurrentCourtCase;
            _windowManager.ShowDialog(vm);
        }

        private Faccts.Model.Entities.CourtCase _currentCourtCase;
        public Faccts.Model.Entities.CourtCase CurrentCourtCase
        {
            get { return _currentCourtCase; }
            set
            {
                if (_currentCourtCase != value)
                {
                    this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
                    CanSeparate = _currentCourtCase != null;
                }
            }
        }


        public void Handle(CurrentCourtCaseChangedEvent message)
        {
            this.CurrentCourtCase = message.CourtCase;
        }

        public void Handle(SelectedCourtCasesChangedEvent message)
        {
            this.SelectedCourtCases = new ObservableCollection<CourtCase>(message.SelectedCourtCases);
        }
    }
}
