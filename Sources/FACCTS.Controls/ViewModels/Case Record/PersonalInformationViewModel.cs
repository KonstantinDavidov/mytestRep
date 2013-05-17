using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(PersonalInformationViewModel))]
    public class PersonalInformationViewModel : ViewModelBase
    {
        public PersonalInformationViewModel() : base()
        {
            this.DisplayName = "Personal Information";
        }
    }
}
