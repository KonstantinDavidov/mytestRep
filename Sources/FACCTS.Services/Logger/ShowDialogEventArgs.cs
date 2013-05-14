using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Logger
{
    public class ShowDialogEventArgs : EventArgs
    {
        public Exception Exception { get; private set; }
        public ShowDialogEventArgs(Exception ex) : base()
        {
            Exception = ex;
        }
    }
}
