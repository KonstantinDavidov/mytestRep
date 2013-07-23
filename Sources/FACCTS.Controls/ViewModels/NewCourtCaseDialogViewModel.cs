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
using FACCTS.Controls.Utils;
using Caliburn.Micro;

namespace FACCTS.Controls.ViewModels
{
    [Export]
    public partial class NewCourtCaseDialogViewModel :  ViewModelBase, IDataErrorInfo
    {

        public NewCourtCaseDialogViewModel() : base()
        {
            this.DisplayName = "Create New Case";
            
            this.WhenAny(x => x.CaseNumber, x => x.Value)
                .Subscribe(s => this.IsValid = !string.IsNullOrEmpty(s));
        }

        private ILogger _logger = ServiceLocatorContainer.Locator.GetInstance<ILogger>();

        protected override void Authorized()
        {
            base.Authorized();

        }

        protected override void OnActivate()
        {
            base.OnActivate();
            CaseNumber = BusinessLogicHelper.AutoGenerateCaseNumber();
        }

        

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
            Faccts.Model.Entities.CourtCase newCase = new Faccts.Model.Entities.CourtCase()
            {
                CaseNumber = this.CaseNumber,
                CaseHistory = Faccts.Model.Entities.CaseHistory.GetHistoryCollectionForNewCase(),
            };
            Execute.OnUIThread(() => DataContainer.CourtCases.Add(newCase));
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
                }
                return result;
            }
        }
    }
}
