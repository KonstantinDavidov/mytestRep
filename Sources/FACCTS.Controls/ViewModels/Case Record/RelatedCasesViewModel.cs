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

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(RelatedCasesViewModel))]
    public partial class RelatedCasesViewModel : ViewModelBase, IHandle<CurrentCourtCaseChangedEvent>
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
        }

        [ImportingConstructor]
        public RelatedCasesViewModel(IWindowManager windowManager
            , IEventAggregator eventAggregator) : this()
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            this.DisplayName = "Related Cases";
            //TODO: correct two following lines once that functionality implemented
            CanConsolidate = true;
            
        }

        public void Consolidate()
        {

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
    }
}
