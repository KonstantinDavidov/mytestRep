using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace FACCTS.Server.Code
{
    [Export]
    public class DataSaver
    {


        [Import]
        public IDataManager DataManager { get; set; }

        public CourtCase SaveData(CourtCase cc)
        {
            if (cc.State == ObjectState.Unchanged)
                return cc;
            DataManager.CourtCaseRepository.SaveData(cc);
            DataManager.CaseRecordRepository.SaveData(cc.CaseRecord);
            return null;
        }
    }
}