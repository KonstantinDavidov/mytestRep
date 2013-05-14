using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Routing;
using ReactiveUI.Xaml;
using System.Windows.Input;

namespace FACCTS.Controls.ViewModels
{
    public interface IShowExceptionDialogViewModel
    {
        Exception Exception { get; set; }
        string ExceptionContent { get; }
    }

    [Export(typeof(IShowExceptionDialogViewModel))]
    public class ShowExceptionDialogViewModel : ViewModelBase, IShowExceptionDialogViewModel
    {
        public ShowExceptionDialogViewModel() : base()
        {
            this.Name = "An Exception occured!";
            this.WhenAny(x => x.Exception, x => x.Value)
                .Subscribe(x => 
                    {
                        if (x != null)
                        {
                            this.ExceptionContent = string.Format("An exception {0} occured: {1}", x.GetType().Name, x.Message);
                        }
                    });
                
           
        }

        public ShowExceptionDialogViewModel(Exception ex) : this()
        {
            this.Exception = ex;
        }

        private Exception _exception;
        public Exception Exception 
        {
            get
            {
                return _exception;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _exception, value);
            }
        }

        private string _exceptionContent;
        public string ExceptionContent
        {
            get
            {
                return _exceptionContent;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _exceptionContent, value);
            }
        }

        public void Close()
        {
            this.TryClose(true);
        }
    }
}
