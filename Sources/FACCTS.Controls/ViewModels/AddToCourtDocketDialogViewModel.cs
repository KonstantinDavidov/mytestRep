using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive.Linq;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class AddToCourtDocketDialogViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public AddToCourtDocketDialogViewModel() : base()
        {
            this.DisplayName = "Add Case to Docket";
        }

        public void AddCase()
        {
            TryClose(true);
            Task.Factory.StartNew(() =>
            {
                ProceedAddition();
            });
           
        }

        private void ProceedAddition()
        {
            
        }

        private Faccts.Model.Entities.CourtCase _currentCourtCase;
        public Faccts.Model.Entities.CourtCase CurrentCourtCase
        {
            get { return _currentCourtCase; }
            set
            {
                if (_currentCourtCase != value)
                {
                    _currentCourtCase = value;
                    this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
                    if (_currentCourtCase != null)
                    {
                        this.CaseNumber = _currentCourtCase.CaseNumber;
                        this.Time = DateTime.Now.ToLocalTime();
                        //this.Courtrooms = 
                        //this.Department = 
                    }
                }
            }
        }

       
       

        
        

    }
}
