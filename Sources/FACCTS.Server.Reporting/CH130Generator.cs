using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Reporting;
using FACCTS.Server.Model.OrderModels;
using System.IO;
using org.pdfclown;
using org.pdfclown.documents;
using org.pdfclown.documents.interaction.forms;
using FACCTS.Server.Model.DataModel;

namespace FACCTS.Server.Reporting
{
    public class CH130Generator : Generator
    {
        protected override void FillForm(Form form, Dictionary<string, string> mapper, object data)
        {
            CH130 reportData = data as CH130;

            CaseRecord caseRecord = DataManager.CaseRecordRepository.GetById(reportData.CaseInfo.CaseId);

            form.Fields[mapper["caseNumber"]].Value = reportData.CaseInfo.CaseNumber;
           
        }
    }
}
