using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.DataModel;
using System.ComponentModel.Composition;
using FACCTS.Services.Data;
using FACCTS.Services.Logger;
using System.ComponentModel;
using FACCTS.Services;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public class NewCourtCaseDialogViewModel : ViewModelBase, IDataErrorInfo
    {

        public NewCourtCaseDialogViewModel() : base()
        {
            this.Title = "Create New Case";
                
        }

        private ILogger _logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();

        protected override void Authorized()
        {
            base.Authorized();

        }

        #region UI properties
        
        private bool _isEditing;
        public bool IsEditing
        {
            get
            {
                return _isEditing;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isEditing, value);
            }
        }
       

        private string _caseNumber;
        public string CaseNumber
        {
            get
            {
                return _caseNumber;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _caseNumber, value);
            }
        }
        #endregion

        public void CreateNewCase()
        {
            this.TryClose(true);
            var tsk = Task.Factory.StartNew(() =>
                {
                    ProceedCreation();
                }, TaskCreationOptions.AttachedToParent);

        }

        protected virtual void ProceedCreation()
        {
            _logger.Info("Start creation the new case...");
            CourtCase cc = new CourtCase();
            cc.CaseNumber = this.CaseNumber;
            _logger.Info("Saving the new case to the database...");
            CourtCases.CreateNew(cc);
        }

        public string Error
        {
            get 
            {
                throw new NotImplementedException();
            }
        }

        public void Edit()
        {
            IsEditing = true;
        }

        public string this[string columnName]
        {
            get 
            {
                string result = null;
                switch(columnName)
                {
                    case "CaseNumber":
                        return "Please specify the court case number";
                        break;
                }
                return result;
            }
        }
    }
}
