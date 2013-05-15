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
            , ChildrenOtherProtectedViewModel childrenViewModel) : base()
        {
            this.DisplayName = "Case Record";
            PersonalInformationViewModel = personalInformation;
            ChildrenOtherProtectedViewModel = childrenViewModel;
            ActivateControl(0);
        }

        protected PersonalInformationViewModel PersonalInformationViewModel { get; set; }
        protected ChildrenOtherProtectedViewModel ChildrenOtherProtectedViewModel { get; set; }

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
                default:
                    ActivateItem(PersonalInformationViewModel);
                    break;
            }
        }
    }
}
