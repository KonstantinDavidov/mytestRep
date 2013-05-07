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
    [Export(typeof(IShell))]
    public class ShellViewModel : ReactiveConductor<IScreen>.Collection.OneActive, IShell
    {
        public ShellViewModel() : base()
        {
        }
        
        private string _name = "Main Window";
        public string Name
        {
            get { return _name; }
        }

        public void GenerateException()
        {
            throw new ArgumentNullException("noArg");
        }

       
    }
}
