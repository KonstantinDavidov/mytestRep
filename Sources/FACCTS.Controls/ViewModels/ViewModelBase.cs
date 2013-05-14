using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class ViewModelBase : ReactiveScreen
    {
        
        public ViewModelBase() : base()
        {
            
        }

        [Import]
        public IWindowManager WindowManager { get; protected set; }

        
    }
}
