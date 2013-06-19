using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Caliburn.Micro;
using FACCTS.Services;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(RelatedCasesViewModel))]
    public partial class RelatedCasesViewModel : ViewModelBase
    {
        private IWindowManager _windowManager;

        [ImportingConstructor]
        public RelatedCasesViewModel(IWindowManager windowManager) : base()
        {
            _windowManager = windowManager;
            this.DisplayName = "Related Cases";
            //TODO: correct two following lines once that functionality implemented
            CanConsolidate = true;
            CanSeparate = true;
        }

        public void Consolidate()
        {

        }

        public void Separate()
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<SeparateCaseDialogViewModel>();

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
                    _currentCourtCase = value;
                    this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
                    CanSeparate = _currentCourtCase != null;
                }
            }
        }

    }
}
