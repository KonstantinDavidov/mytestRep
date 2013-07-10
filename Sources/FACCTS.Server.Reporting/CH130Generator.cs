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
            const string BooleanString = "1";

            CH130 reportData = data as CH130;
            //CourtCase courtCase = DataManager.CourtCaseRepository.GetById(reportData.CaseInfo.CaseId);

            CaseHistory caseHistory = DataManager.CaseHistoryRepository.GetAll(
                        ch => ch.Hearing,
                        ch => ch.CaseRecord).FirstOrDefault(ch => ch.Id == reportData.CaseHistoryId);

            CaseRecord courtCaseRecord = DataManager.CaseRecordRepository.GetAll(
               cc => cc.CourtCase,
               cc => cc.OtherProtected,
               cc => cc.Party1,
               cc => cc.Party1.Attorney,
               cc => cc.Party1.Designation,
               cc => cc.Party1.EyesColor,
               cc => cc.Party1.HairColor,
               cc => cc.Party1.Race,
               cc => cc.Party1.Sex,
               cc => cc.Party2,
               cc => cc.Party2.Attorney,
               cc => cc.Party2.Designation,
               cc => cc.Party2.EyesColor,
               cc => cc.Party2.HairColor,
               cc => cc.Party2.Race,
               cc => cc.Party2.Sex)
               .FirstOrDefault(cc => cc.Id == caseHistory.CaseRecord.Id);

            Hearing caseHearing = caseHistory.Hearing;

            CourtParty protectedParty;
            CourtParty restrainedParty;


            if (courtCaseRecord.Party1.ParticipantRole == Model.Enums.ParticipantRole.PPSC)
            {
                protectedParty = courtCaseRecord.Party1;
                restrainedParty = courtCaseRecord.Party2;
            }
            else
            {
                protectedParty = courtCaseRecord.Party2;
                restrainedParty = courtCaseRecord.Party1;
            }

            Utils.SetPdfFormFieldValue(form, mapper, "caseNumber", courtCaseRecord.CourtCase.CaseNumber);
            Utils.SetPdfFormFieldValue(form, mapper, "courtName", "TODO"); 

            //protected
            Utils.SetPdfFormFieldValue(form, mapper, "protectedName", protectedParty.FullName);
            if (protectedParty.HasAttorney.HasValue && protectedParty.HasAttorney.Value && (protectedParty.Attorney != null))
            {
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAttorneyName", protectedParty.Attorney.FullName);
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
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedName", restrainedParty.FullName);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressStreet", restrainedParty.Address);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressCity", restrainedParty.City);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressState", restrainedParty.State);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressPostal", restrainedParty.ZipCode);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedEye", restrainedParty.EyesColor.Color);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedHair", restrainedParty.HairColor.Color);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedRace", restrainedParty.Race.RaceName);


            Utils.SetPdfFormFieldValue(form, mapper, "restrainedDOB", restrainedParty.DateOfBirth.ToOrderDate());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAge", restrainedParty.Age.ToString());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedRelationship", "TODO");
            form.Fields[mapper["restrainedSexM"]].Value = restrainedParty.Sex.Id == 1 ? "1" : null ; //CheckBox
            form.Fields[mapper["restrainedSexF"]].Value = restrainedParty.Sex.Id == 10 ? "2" : null; //CheckBox
           
            //other protected
            if(courtCaseRecord.OtherProtected.Count > 0)
            {
                //First protected
                var firstProtected = courtCaseRecord.OtherProtected.First();
                form.Fields[mapper["protectedAddYes"]].Value = BooleanString; //CheckBox
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Name", firstProtected.FullName);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Sex", firstProtected.Sex.SexName.First().ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Age", firstProtected.Age.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Relation", firstProtected.RelationshipToPlaintiff.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]HouseholdYes", firstProtected.IsHouseHold ? BooleanString : null); //CheckBox
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]HouseholdNo", firstProtected.IsHouseHold ? null : BooleanString); //CheckBox

                if(courtCaseRecord.OtherProtected.Count > 1)
                {
                    var secondProtected = courtCaseRecord.OtherProtected.ElementAt(1);
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Name", secondProtected.FullName);
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Sex", secondProtected.Sex.SexName.First().ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Age", secondProtected.Age.ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Relation", secondProtected.RelationshipToPlaintiff.ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]HouseholdYes", secondProtected.IsHouseHold ? BooleanString : null); //CheckBox
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]HouseholdNo", secondProtected.IsHouseHold ? null : BooleanString); //CheckBox

                    if (courtCaseRecord.OtherProtected.Count > 2)
                    {
                        Utils.SetPdfFormFieldValue(form, mapper, "protectedAddAttachYes", BooleanString); //CheckBox
                    }
                }

            }

            //Docket
            //Utils.SetPdfFormFieldValue(form, mapper, "", ); hearingJudicialOfficer
            Utils.SetPdfFormFieldValue(form, mapper, "hearingDate", caseHearing.HearingDate.ToOrderDate());
            Utils.SetPdfFormFieldValue(form, mapper, "hearingDepartment", caseHearing.Department != null ? caseHearing.Department.Name : null);
            Utils.SetPdfFormFieldValue(form, mapper, "hearingCourtroom", caseHearing.Courtroom != null ? caseHearing.Courtroom.RoomName : null);
            Utils.SetPdfFormFieldValue(form, mapper, "hearingJudicialOfficer", caseHearing.Judge);

            //Conduct
            if (reportData.ConductSection != null && reportData.ConductSection.IsEnabled)
            {
                Utils.SetPdfFormFieldValue(form, mapper, "conductOrdersYes", BooleanString);
                Utils.SetPdfFormFieldValue(form, mapper, "conductHarrassYes", reportData.ConductSection.NoAbuse ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "conductContactYes", reportData.ConductSection.NoContact ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "conductLocationYes", reportData.ConductSection.DontTryToLocate ? BooleanString : null);
                if (reportData.ConductSection.Other)
                {
                    Utils.SetPdfFormFieldValue(form, mapper, "conductOtherYes", BooleanString);
                    Utils.SetPdfFormFieldValue(form, mapper, "conductOtherAttach", reportData.ConductSection.IsOtherAttached ? BooleanString : null);
                    Utils.SetPdfFormFieldValue(form, mapper, "conductOtherDetail", reportData.ConductSection.OtherDescription);
                }
            }
            //Stay Away
            if (reportData.StayAwayOrdersSection != null && reportData.StayAwayOrdersSection.IsEnabled)
            {

            }
        }

    }
}
