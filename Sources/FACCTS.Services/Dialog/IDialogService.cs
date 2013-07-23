using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FACCTS.Services.Dialog
{
    public interface IDialogService
    {
        MessageBoxResult MessageBox(string messageText);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText);
        MessageBoxResult MessageBox(string messageText, string caption);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.Style messageBoxStyle);
        MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button);
        MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.Style messageBoxStyle);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.Style messageBoxStyle);
        MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon);
        MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.Style messageBoxStyle);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.Style messageBoxStyle);
        MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult);
        MessageBoxResult MessageBox(string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult, System.Windows.Style messageBoxStyle);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult);
        MessageBoxResult MessageBox(System.Windows.Window owner, string messageText, string caption, System.Windows.MessageBoxButton button, System.Windows.MessageBoxImage icon, System.Windows.MessageBoxResult defaultResult, System.Windows.Style messageBoxStyle);
    }
}
