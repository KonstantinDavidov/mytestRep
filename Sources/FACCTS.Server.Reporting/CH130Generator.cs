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
            CourtCase courtCase = DataManager.CourtCaseRepository.GetAll(
                cc =>cc.CaseRecord,
                cc=>cc.CaseRecord.OtherProtected,
                cc=>cc.CaseRecord.Party1,
                cc=>cc.CaseRecord.Party1.Attorney,
                cc=>cc.CaseRecord.Party1.Designation,
                cc=>cc.CaseRecord.Party1.EyesColor,
                cc=>cc.CaseRecord.Party1.HairColor,
                cc=>cc.CaseRecord.Party1.Race,
                cc=>cc.CaseRecord.Party1.Sex,
                cc=>cc.CaseRecord.Party2,
                cc=>cc.CaseRecord.Party2.Attorney,
                cc=>cc.CaseRecord.Party2.Designation,
                cc=>cc.CaseRecord.Party2.EyesColor,
                cc=>cc.CaseRecord.Party2.HairColor,
                cc=>cc.CaseRecord.Party2.Race,
                cc=>cc.CaseRecord.Party2.Sex)
                .FirstOrDefault(cc => cc.Id == reportData.CaseInfo.CaseId);

            CourtParty protectedParty;
            CourtParty restrainedParty;
            

            if(courtCase.CaseRecord.Party1.ParticipantRole == Model.Enums.ParticipantRole.Protected)
            {
                protectedParty = courtCase.CaseRecord.Party1;
                restrainedParty = courtCase.CaseRecord.Party2;
            }
            else
            {
                protectedParty = courtCase.CaseRecord.Party2;
                restrainedParty = courtCase.CaseRecord.Party1;
            }

            Utils.SetPdfFormFieldValue(form, mapper, "caseNumber", courtCase.CaseNumber);
            Utils.SetPdfFormFieldValue(form, mapper, "courtName", "TODO"); 

            //protected
            Utils.SetPdfFormFieldValue(form, mapper, "protectedName", protectedParty.FirstName + " " + protectedParty.LastName);
            if (protectedParty.HasAttorney.HasValue && protectedParty.HasAttorney.Value && (protectedParty.Attorney != null))
            {
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAttorneyName", protectedParty.Attorney.FirstName + " " + protectedParty.Attorney.LastName);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAttorneyFirm", protectedParty.Attorney.FirmName);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAttorneyBarID", protectedParty.Attorney.StateBarId);

                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressStreet", protectedParty.Attorney.StreetAddress);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressCity", protectedParty.Attorney.City);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressState", protectedParty.Attorney.State);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressPostal", protectedParty.Attorney.ZipCode);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedPhone", protectedParty.Attorney.Phone);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedFax", protectedParty.Attorney.Fax);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedEmail", protectedParty.Attorney.Email);
            }
            else
            {
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressStreet", protectedParty.Address);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressCity", protectedParty.City);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressState", protectedParty.State);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressPostal", protectedParty.ZipCode);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedPhone", protectedParty.Phone);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedFax", protectedParty.Fax);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedEmail", "TODO");
            }
            

            //restrained person
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedName", restrainedParty.FirstName + " " + restrainedParty.LastName);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressStreet", restrainedParty.Address);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressCity", restrainedParty.City);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressState", restrainedParty.State);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressPostal", restrainedParty.ZipCode);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedEye", restrainedParty.EyesColor.Color);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedHair", restrainedParty.HairColor.Color);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedRace", restrainedParty.Race.RaceName);


            Utils.SetPdfFormFieldValue(form, mapper, "restrainedDOB", restrainedParty.DateOfBirth.ToShortDateString());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAge", restrainedParty.Age.ToString());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedRelationship", "TODO");
            form.Fields[mapper["restrainedSexM"]].Value = restrainedParty.Sex.Id == 1 ? "1" : null ; //CheckBox
            form.Fields[mapper["restrainedSexF"]].Value = restrainedParty.Sex.Id == 10 ? "2" : null; //CheckBox
           
            //other protected
            if(courtCase.CaseRecord.OtherProtected.Count > 0)
            {
                //First protected
                var firstProtected = courtCase.CaseRecord.OtherProtected.First();
                form.Fields[mapper["protectedAddYes"]].Value = "1"; //CheckBox
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Name", firstProtected.FirstName + " " + firstProtected.LastName);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Sex", firstProtected.Sex.SexName.First().ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Age", firstProtected.Age.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Relation", firstProtected.RelationshipToPlaintiff.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]HouseholdYes", firstProtected.IsHouseHold ? "1" : null); //CheckBox
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]HouseholdNo", firstProtected.IsHouseHold ? null : "1"); //CheckBox

                if(courtCase.CaseRecord.OtherProtected.Count > 1)
                {
                    var secondProtected = courtCase.CaseRecord.OtherProtected.ElementAt(1);
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Name", secondProtected.FirstName + " " + secondProtected.LastName);
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Sex", secondProtected.Sex.SexName.First().ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Age", secondProtected.Age.ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Relation", secondProtected.RelationshipToPlaintiff.ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]HouseholdYes", secondProtected.IsHouseHold ? "1" : null); //CheckBox
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]HouseholdNo", secondProtected.IsHouseHold ? null : "1"); //CheckBox

                    if (courtCase.CaseRecord.OtherProtected.Count > 2)
                    {
                        Utils.SetPdfFormFieldValue(form, mapper, "protectedAddAttachYes", "1"); //CheckBox
                    }
                }

            }

            //Docket
        }

    }
}
