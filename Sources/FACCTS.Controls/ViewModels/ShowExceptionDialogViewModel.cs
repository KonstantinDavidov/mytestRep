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

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(ShowExceptionDialogViewModel))]
    public class ShowExceptionDialogViewModel : ViewModelBase
    {
        public ShowExceptionDialogViewModel() : base()
        {
            this.Name = "An Exception occured!";
            var whenExceptionChanged = this.ObservableForProperty(x => x.Exception)
                .Select(x => x.Value)
                .Where(e => e != null)
                .Select(e => e.Message);
            whenExceptionChanged.ToProperty(this, x => x.ExceptionContent);
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
    }
}
