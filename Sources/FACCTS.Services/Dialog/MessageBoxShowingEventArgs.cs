using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FACCTS.Services.Dialog
{
    public class MessageBoxShowingEventArgs
    {
        public MessageBoxShowingEventArgs(Object[] parameters)
        {
            Parameters = parameters;
        }

        public Object[] Parameters { get; private set; }

        public MessageBoxResult MessageBoxResult {get; set;}
    }
}
