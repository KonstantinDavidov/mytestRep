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
            , WitnessInterpereterViewModel witnessInterprererViewModel) : base()
        {
            this.DisplayName = "Case Record";
            PersonalInformationViewModel = personalInformation;
            ChildrenOtherProtectedViewModel = childrenViewModel;
            AttorneysViewModel = attorneysViewModel;
            WitnessInterpereterViewModel = witnessInterprererViewModel;
            ActivateControl(0);
        }

        protected PersonalInformationViewModel PersonalInformationViewModel { get; set; }
        protected ChildrenOtherProtectedViewModel ChildrenOtherProtectedViewModel { get; set; }
        protected AttorneysViewModel AttorneysViewModel {get; set;}
        protected WitnessInterpereterViewModel WitnessInterpereterViewModel { get; set; }

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
                default:
                    ActivateItem(PersonalInformationViewModel);
                    break;
            }
        }
    }
}
