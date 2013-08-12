using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Data;

namespace FACCTS.Server.BusinessLogic.BusinessOperations
{
    public class SaveCourtCaseStrategy : BusinessOperationStrategyBase
    {
        private CourtCase _courtCase;
        public SaveCourtCaseStrategy(CourtCase cc)
            : base()
        {
            if (cc == null)
            {
                throw new ArgumentNullException("courtCase");
            }
            _courtCase = cc;
        }

        public override void Execute()
        {
            this.Logger.Info("DataSaver: trying to save the Court Case...");

            try
            {
                DataManager.CourtCaseRepository.SaveData(_courtCase);
                DataManager.Commit();
            }
            catch (Exception ex)
            {
                this.Logger.Error("An error while saving the Court Case: ", ex);
                throw;
            }
        }
    }
}
