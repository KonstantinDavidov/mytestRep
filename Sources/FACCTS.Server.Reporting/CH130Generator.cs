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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FACCTS.Server.Reporting
{
    public class CH130Generator : Generator
    {
        protected override void FillForm(Form form, Dictionary<string, string> mapper, object data)
        {
            CH130 reportData = data as CH130;

            //CourtCase courtCase = DataManager.CourtCaseRepository.GetById(reportData.CaseInfo.CaseId);
            CourtCase courtCase = DataManager.CourtCaseRepository.GetAll()
                .Include(cc =>cc.CaseRecord)
                .Include(cc=>cc.CaseRecord.Party1)
                .Include(cc=>cc.CaseRecord.Party2)
                .FirstOrDefault(cc => cc.Id == reportData.CaseInfo.CaseId);
            //CaseRecord cr = DataManager.CaseRecordRepository.GetById(courtCase.CaseRecord.Id);
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
            form.Fields[mapper["restrainedAddressState"]].Value = restrainedParty.State;
            form.Fields[mapper["restrainedAddressPostal"]].Value = "TODO";
            //form.Fields[mapper["restrainedPhone"]].Value = restrainedParty.Phone; not foutd
            //form.Fields[mapper["restrainedFax"]].Value = restrainedParty.Fax;
            //form.Fields[mapper["restrainedEmail"]].Value = "TODO";
            //form.Fields[mapper["restrainedEye"]].Value = restrainedParty.EyesColor.Color;
            //form.Fields[mapper["restrainedHair"]].Value = restrainedParty.HairColor.Color;
            //form.Fields[mapper["restrainedRace"]].Value = restrainedParty.Race.RaceName;
            form.Fields[mapper["restrainedDOB"]].Value = restrainedParty.DateOfBirth.ToShortDateString();
            form.Fields[mapper["restrainedAge"]].Value = restrainedParty.Age.ToString();
            form.Fields[mapper["restrainedRelationship"]].Value = "TODO";
            
            //form.Fields[mapper[]].Value = restrainedParty;
        }

    }
}
