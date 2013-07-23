using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Dialog
{
    [Export(typeof(IDialogService))]
    public class DialogService : IDialogService
    {
        public event EventHandler<MessageBoxShowingEventArgs> MessageBoxShowing;

        private System.Windows.MessageBoxResult RaiseMessageBoxShowing(MessageBoxShowingEventArgs eventArgs)
        {
            if (MessageBoxShowing != null)
            {
                MessageBoxShowing(this, eventArgs);
                if (eventArgs.MessageBoxResult == null)
                {
                    throw new NullReferenceException("MessageBoxResult is null!!!");
                }
                return eventArgs.MessageBoxResult;
            }
            return System.Windows.MessageBoxResult.Cancel;
        }

        public System.Windows.MessageBoxResult MessageBox(string messageText)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new[] {messageText}));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText }));
        }

        public System.Windows.MessageBoxResult MessageBox(string messageText, string caption)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { messageText, caption }));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText, caption }));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.Style messageBoxStyle)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText, caption, messageBoxStyle }));
        }

        public System.Windows.MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { messageText, caption, button }));
        }

        public System.Windows.MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.Style messageBoxStyle)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { messageText, caption, button, messageBoxStyle }));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText, caption, button }));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.Style messageBoxStyle)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText, caption, button, messageBoxStyle }));
        }

        public System.Windows.MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { messageText, caption, button, icon }));
        }

        public System.Windows.MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.Style messageBoxStyle)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { messageText, caption, button, icon, messageBoxStyle }));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText, caption, button, icon }));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.Style messageBoxStyle)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText, caption, button, icon, messageBoxStyle }));
        }

        public System.Windows.MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { messageText, caption, button, icon, defaultResult }));
        }

        public System.Windows.MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult, System.Windows.Style messageBoxStyle)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { messageText, caption, button, icon, defaultResult, messageBoxStyle }));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText, caption, button, icon, defaultResult }));
        }

        public System.Windows.MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult, System.Windows.Style messageBoxStyle)
        {
            return RaiseMessageBoxShowing(new MessageBoxShowingEventArgs(new Object[] { owner, messageText, caption, button, icon, defaultResult, messageBoxStyle }));
        }
    }
}
