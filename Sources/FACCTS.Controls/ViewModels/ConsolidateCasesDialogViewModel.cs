using Caliburn.Micro;
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
            this.IsValid = CourtCases != null && CourtCases.Count > 1 && SelectedCourtCase != null;
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

        public void PerformMerge()
        {
            this.TryClose(true);
            Task.Factory.StartNew(() => PerformMergeBackground(), TaskCreationOptions.AttachedToParent);
        }

        private void PerformMergeBackground()
        {
            this.CourtCases.Where(x => !Object.ReferenceEquals(x, SelectedCourtCase))
                .Aggregate(0, (index, cc) =>
                {
                    cc.ParentCase = SelectedCourtCase;
                    CaseHistory ch = new CaseHistory()
                    {
                        Date = DateTime.Now,
                        CaseHistoryEvent = (int)FACCTS.Server.Model.Enums.CaseHistoryEvent.Merged,
                        MergeCase = SelectedCourtCase,

                    };
                    Execute.OnUIThread(() => cc.CaseRecord.CaseHistory.Add(ch));
                    return ++index;
                });
        }
    }
}
