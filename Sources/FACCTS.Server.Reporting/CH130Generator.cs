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

            CourtCase courtCase = DataManager.CourtCaseRepository.GetById(reportData.CaseInfo.CaseId);
            //TO DO : filter by participant role
            var protectedParty = courtCase.CaseRecord.Party1;
            var restrainedParty = courtCase.CaseRecord.Party2;

            form.Fields[mapper["caseNumber"]].Value = courtCase.CaseNumber;
            form.Fields[mapper["courtName"]].Value = "TO DO";

            //protected person
            form.Fields[mapper["protectedName"]].Value = protectedParty.FirstName + " " + protectedParty.LastName;
            //if(protectedParty.HasAttorney

            //restrained person
            form.Fields[mapper["restrainedName"]].Value = restrainedParty.FirstName + " " + restrainedParty.LastName;
            form.Fields[mapper["restrainedAddressStreet"]].Value = restrainedParty.Address;
            form.Fields[mapper["restrainedAddressCity"]].Value = restrainedParty.City;
        }

    }
}
