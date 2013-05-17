using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using FACCTS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(CaseRecordViewModel))]
    public class CaseRecordViewModel : ReactiveConductor<IScreen>.Collection.OneActive
    {
        [ImportingConstructor]
        public CaseRecordViewModel(PersonalInformationViewModel personalInformation
            , ChildrenOtherProtectedViewModel childrenViewModel
            , AttorneysViewModel attorneysViewModel
            , WitnessInterpereterViewModel witnessInterprererViewModel
            , RelatedCasesViewModel relatedCasesViewModel) : base()
        {
            this.DisplayName = "Case Record";
            PersonalInformationViewModel = personalInformation;
            ChildrenOtherProtectedViewModel = childrenViewModel;
            AttorneysViewModel = attorneysViewModel;
            WitnessInterpereterViewModel = witnessInterprererViewModel;
            RelatedCasesViewModel = relatedCasesViewModel;
            ActivateControl(0);
        }

        protected PersonalInformationViewModel PersonalInformationViewModel { get; set; }
        protected ChildrenOtherProtectedViewModel ChildrenOtherProtectedViewModel { get; set; }
        protected AttorneysViewModel AttorneysViewModel {get; set;}
        protected WitnessInterpereterViewModel WitnessInterpereterViewModel { get; set; }
        protected RelatedCasesViewModel RelatedCasesViewModel { get; set; }

        public void ActivateControl(int selectedIndex)
        {
            switch(selectedIndex)
            {
                case 0:
                    ActivateItem(PersonalInformationViewModel);
                    break;
                case 1:
                    ActivateItem(ChildrenOtherProtectedViewModel);
                    break;
                case 2:
                    ActivateItem(AttorneysViewModel);
                    break;
                case 3:
                    ActivateItem(WitnessInterpereterViewModel);
                    break;
                case 4:
                    ActivateItem(RelatedCasesViewModel);
                    break;
                default:
                    ActivateItem(PersonalInformationViewModel);
                    break;
            }
        }
    }
}
