﻿using System;
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
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Common;

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
                        ch => ch.CourtCase).FirstOrDefault(ch => ch.Id == reportData.CaseHistoryId);

            CourtCase courtCase = DataManager.CourtCaseRepository.GetAll(
               cc => cc.OtherProtected,
               cc => cc.Party1,
               cc => cc.Party1.Attorney,
               cc => cc.Party1.Designation,
               cc => cc.Party1.EyesColor,
               cc => cc.Party1.HairColor,
               cc => cc.Party1.Race,
               cc => cc.Party2,
               cc => cc.Party2.Attorney,
               cc => cc.Party2.Designation,
               cc => cc.Party2.EyesColor,
               cc => cc.Party2.HairColor,
               cc => cc.Party2.Race)
               .FirstOrDefault(cc => cc.Id == caseHistory.CourtCase.Id);

            Hearing caseHearing = caseHistory.Hearing;

            CourtParty protectedParty;
            CourtParty restrainedParty;


            if (courtCase.Party1.ParticipantRole == Model.Enums.ParticipantRole.PPSC)
            {
                protectedParty = courtCase.Party1;
                restrainedParty = courtCase.Party2;
            }
            else
            {
                protectedParty = courtCase.Party2;
                restrainedParty = courtCase.Party1;
            }

            Utils.SetPdfFormFieldValue(form, mapper, "caseNumber", courtCase.CaseNumber);
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
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressState", protectedParty.Attorney.State.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressPostal", protectedParty.Attorney.ZipCode);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedPhone", protectedParty.Attorney.Phone);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedFax", protectedParty.Attorney.Fax);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedEmail", protectedParty.Attorney.Email);
            }
            else
            {
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressStreet", protectedParty.Address);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressCity", protectedParty.City);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressState", protectedParty.State.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressPostal", protectedParty.ZipCode);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedPhone", protectedParty.Phone);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedFax", protectedParty.Fax);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedEmail", protectedParty.Email);
            }
            

            //restrained person
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedName", restrainedParty.FullName);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressStreet", restrainedParty.Address);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressCity", restrainedParty.City);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressState", restrainedParty.State.ToString());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAddressPostal", restrainedParty.ZipCode);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedEye", restrainedParty.EyesColor.Color);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedHair", restrainedParty.HairColor.Color);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedRace", restrainedParty.Race.RaceName);
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedHeight", (restrainedParty.HeightFt*12 + restrainedParty.HeightIns).ToString());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedWeight", restrainedParty.Weight.ToString());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedDOB", restrainedParty.DateOfBirth.ToOrderDate());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedAge", restrainedParty.Age.ToString());
            Utils.SetPdfFormFieldValue(form, mapper, "restrainedRelationship", restrainedParty.RelationToOtherParty);
            form.Fields[mapper["restrainedSexM"]].Value = restrainedParty.Sex == Gender.M ? "1" : null ; //CheckBox
            form.Fields[mapper["restrainedSexF"]].Value = restrainedParty.Sex == Gender.F ? "2" : null; //CheckBox
           
            //other protected
            if (courtCase.OtherProtected.Count > 0)
            {
                //First protected
                var firstProtected = courtCase.OtherProtected.First();
                form.Fields[mapper["protectedAddYes"]].Value = BooleanString; //CheckBox
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Name", firstProtected.FullName);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Sex", firstProtected.Sex.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Age", firstProtected.Age.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Relation", firstProtected.RelationshipToPlaintiff.GetDisplayName());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]HouseholdYes", firstProtected.IsHouseHold ? BooleanString : null); //CheckBox
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]HouseholdNo", firstProtected.IsHouseHold ? null : BooleanString); //CheckBox

                if (courtCase.OtherProtected.Count > 1)
                {
                    var secondProtected = courtCase.OtherProtected.ElementAt(1);
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Name", secondProtected.FullName);
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Sex", secondProtected.Sex.ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Age", secondProtected.Age.ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Relation", secondProtected.RelationshipToPlaintiff.GetDisplayName());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]HouseholdYes", secondProtected.IsHouseHold ? BooleanString : null); //CheckBox
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]HouseholdNo", secondProtected.IsHouseHold ? null : BooleanString); //CheckBox

                    if (courtCase.OtherProtected.Count > 2)
                    {
                        Utils.SetPdfFormFieldValue(form, mapper, "protectedAddAttachYes", BooleanString); //CheckBox
                    }
                }

            }

            //Expiration Date
            if (reportData.IsExpire && reportData.OrdersEndDate.HasValue)
            {
                Utils.SetPdfFormFieldValue(form, mapper, "expireDate", reportData.OrdersEndDate.Value.ToOrderDate());

                if (reportData.OrdersEndTime.HasValue && !reportData.OrdersEndTime.Value.IsMidnight())
                {
                    Utils.SetPdfFormFieldValue(form, mapper, "expireTime", reportData.OrdersEndTime.Value.ToOrderTime());
                    Utils.SetPdfFormFieldValue(form, mapper, "expireTimePM", reportData.OrdersEndTime.Value.IsPM() ? BooleanString : null);
                    Utils.SetPdfFormFieldValue(form, mapper, "expireTimeAM", reportData.OrdersEndTime.Value.IsAM() ? BooleanString : null);
                }
                else
                {
                    Utils.SetPdfFormFieldValue(form, mapper, "expireTimeMidnight", BooleanString);
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
                Utils.SetPdfFormFieldValue(form, mapper, "addProtectedConductYes", reportData.ConductSection.IsInvolveOtherProtected ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "conductHarrassYes", reportData.ConductSection.IsNoAbuse ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "conductContactYes", reportData.ConductSection.IsNoContact ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "conductLocationYes", reportData.ConductSection.IsDontTryToLocate ? BooleanString : null);
                if (reportData.ConductSection.IsInvolveOther)
                {
                    Utils.SetPdfFormFieldValue(form, mapper, "conductOtherYes", BooleanString);
                    Utils.SetPdfFormFieldValue(form, mapper, "conductOtherAttach", reportData.ConductSection.IsOtherAttached ? BooleanString : null);
                    Utils.SetPdfFormFieldValue(form, mapper, "conductOtherDetail", reportData.ConductSection.OtherDescription);
                }
            }

            //Stay Away
            if (reportData.StayAwayOrdersSection != null && reportData.StayAwayOrdersSection.IsEnabled)
            {
                Utils.SetPdfFormFieldValue(form, mapper, "stayawayOrdersYes", BooleanString);
                Utils.SetPdfFormFieldValue(form, mapper, "stayawayDistance", reportData.StayAwayOrdersSection.StayAwayDistance.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "stayawayPerson", reportData.StayAwayOrdersSection.IsStayAwayFromPerson ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "stayawayHome", reportData.StayAwayOrdersSection.IsStayAwayFromHome ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "stayawayWork", reportData.StayAwayOrdersSection.IsStayAwayFromWork ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "stayawayVehicle", reportData.StayAwayOrdersSection.IsStayAwayFromVehicle ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "stayawayChildcare", reportData.StayAwayOrdersSection.IsStayAwayFromChildCare ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "stayawayOtherProtected", reportData.StayAwayOrdersSection.IsStayAwayFromOtherProtected ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "stayawaySchool", reportData.StayAwayOrdersSection.IsStayAwayFromChildSchool ? BooleanString : null);

                if (reportData.StayAwayOrdersSection.IsStayAwayFromOther)
                {
                    Utils.SetPdfFormFieldValue(form, mapper, "stayawayOther", BooleanString);
                    Utils.SetPdfFormFieldValue(form, mapper, "stayawayOtherDetail", reportData.StayAwayOrdersSection.OtherDescription);
                }
            }
            //Firearm
            Utils.SetPdfFormFieldValue(form, mapper, "firearmYes", reportData.IsNoGuns ? BooleanString : null);

            //CARPOS
            if (reportData.CAPROSEntrySection != null)
            {
                if (reportData.CAPROSEntrySection.CARPOSEntryType == CARPOSEntryType.ByProtected)
                {
                    Utils.SetPdfFormFieldValue(form, mapper, "carposByProtected", BooleanString);
                    if (reportData.CAPROSEntrySection.LawEnforcementAgencies.Count > 0)
                    {
                        Utils.SetPdfFormFieldValue(form, mapper, "carposLawEnforcement[0]Agency", reportData.CAPROSEntrySection.LawEnforcementAgencies.ElementAt(0).Key);
                        Utils.SetPdfFormFieldValue(form, mapper, "carposLawEnforcement[0]Address", reportData.CAPROSEntrySection.LawEnforcementAgencies.ElementAt(0).Value);
                    }
                    if (reportData.CAPROSEntrySection.LawEnforcementAgencies.Count > 1)
                    {
                        Utils.SetPdfFormFieldValue(form, mapper, "carposLawEnforcement[1]Agency", reportData.CAPROSEntrySection.LawEnforcementAgencies.ElementAt(1).Key);
                        Utils.SetPdfFormFieldValue(form, mapper, "carposLawEnforcement[1]Address", reportData.CAPROSEntrySection.LawEnforcementAgencies.ElementAt(1).Value);
                    }
                    if (reportData.CAPROSEntrySection.LawEnforcementAgencies.Count > 2)
                    {
                        Utils.SetPdfFormFieldValue(form, mapper, "carposAdditionalYes", BooleanString);
                    }
                }
                else
                {
                    Utils.SetPdfFormFieldValue(form, mapper, "carposByClerk", reportData.CAPROSEntrySection.CARPOSEntryType == CARPOSEntryType.ByClerk ? BooleanString : null);
                    Utils.SetPdfFormFieldValue(form, mapper, "carposByLawEnforcement", reportData.CAPROSEntrySection.CARPOSEntryType == CARPOSEntryType.ByClerkToLawEnforcement ? BooleanString : null);
                }
            }

            //No Fee to Serve
            if (reportData.NoServiceFeeSection != null && reportData.NoServiceFeeSection.IsOrdered)
            {
                Utils.SetPdfFormFieldValue(form, mapper, "serviceNoFee", BooleanString);
                Utils.SetPdfFormFieldValue(form, mapper, "feeWaiverViolence", reportData.NoServiceFeeSection.IsBasedOnViolence ? BooleanString : null);
                Utils.SetPdfFormFieldValue(form, mapper, "feeWaiverEntitled", reportData.NoServiceFeeSection.IsFeeWaiver ? BooleanString : null);
            }
        }

    }
}
