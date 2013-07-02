using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class ConsolidateCasesDialogViewModel : ViewModelBase
    {
        private CaseRecordViewModel _caseRecordViewModel;

        [ImportingConstructor]
        public ConsolidateCasesDialogViewModel(CaseRecordViewModel caseRecordViewModel) : base()
        {
            _caseRecordViewModel = caseRecordViewModel;
            this.DisplayName = "Consolidate Cases";
        }

        public List<CourtCase> CourtCases
        {
            get
            {
                return _caseRecordViewModel.SelectedCourtCases;
            }
        }

        public CourtCase SelectedCourtCase
        {
            get
            {
                return _caseRecordViewModel.CurrentCourtCase;
            }
        }
    }
}
