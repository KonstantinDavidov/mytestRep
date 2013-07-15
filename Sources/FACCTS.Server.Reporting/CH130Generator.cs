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
                        ch => ch.Party1Attorney,
                        ch => ch.Party2Attorney,
                        ch => ch.CaseRecord).FirstOrDefault(ch => ch.Id == reportData.CaseHistoryId);

            CaseRecord courtCaseRecord = DataManager.CaseRecordRepository.GetAll(
               cc => cc.CourtCase,
               cc => cc.OtherProtected,
               cc => cc.Party1,
               cc => cc.Party1.Designation,
               cc => cc.Party1.EyesColor,
               cc => cc.Party1.HairColor,
               cc => cc.Party1.Race,
               cc => cc.Party2,
               cc => cc.Party2.Designation,
               cc => cc.Party2.EyesColor,
               cc => cc.Party2.HairColor,
               cc => cc.Party2.Race)
               .FirstOrDefault(cc => cc.Id == caseHistory.CaseRecord.Id);

            Hearing caseHearing = caseHistory.Hearing;

            CourtParty protectedParty;
            CourtParty restrainedParty;
            CourtPartyAttorneyData protectedPartyAttoney, restrainedPartyAttoney;

            bool isParty1Protected = courtCaseRecord.Party1.ParticipantRole == Model.Enums.ParticipantRole.PPSC;

            protectedParty = isParty1Protected ? courtCaseRecord.Party1 : courtCaseRecord.Party2;
            protectedPartyAttoney = isParty1Protected ? caseHistory.Party1Attorney : caseHistory.Party2Attorney;
            restrainedParty = isParty1Protected ? courtCaseRecord.Party2 : courtCaseRecord.Party1;
            restrainedPartyAttoney = isParty1Protected ? caseHistory.Party2Attorney : caseHistory.Party1Attorney;

            Utils.SetPdfFormFieldValue(form, mapper, "caseNumber", courtCaseRecord.CourtCase.CaseNumber);
            Utils.SetPdfFormFieldValue(form, mapper, "courtName", "TODO"); 

            //protected
            Utils.SetPdfFormFieldValue(form, mapper, "protectedName", protectedParty.FullName);
            if (protectedPartyAttoney != null && protectedPartyAttoney.HasAttorney.HasValue && protectedPartyAttoney.HasAttorney.Value && (protectedPartyAttoney.Attorney != null))
            {
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAttorneyName", protectedPartyAttoney.Attorney.FullName);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAttorneyFirm", protectedPartyAttoney.Attorney.FirmName);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAttorneyBarID", protectedPartyAttoney.Attorney.StateBarId);

                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressStreet", protectedPartyAttoney.Attorney.StreetAddress);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressCity", protectedPartyAttoney.Attorney.City);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressState", protectedPartyAttoney.Attorney.State.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAddressPostal", protectedPartyAttoney.Attorney.ZipCode);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedPhone", protectedPartyAttoney.Attorney.Phone);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedFax", protectedPartyAttoney.Attorney.Fax);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedEmail", protectedPartyAttoney.Attorney.Email);
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
            if(courtCaseRecord.OtherProtected.Count > 0)
            {
                //First protected
                var firstProtected = courtCaseRecord.OtherProtected.First();
                form.Fields[mapper["protectedAddYes"]].Value = BooleanString; //CheckBox
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Name", firstProtected.FullName);
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Sex", firstProtected.Sex.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Age", firstProtected.Age.ToString());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]Relation", firstProtected.RelationshipToPlaintiff.GetDisplayName());
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]HouseholdYes", firstProtected.IsHouseHold ? BooleanString : null); //CheckBox
                Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[0]HouseholdNo", firstProtected.IsHouseHold ? null : BooleanString); //CheckBox

                if(courtCaseRecord.OtherProtected.Count > 1)
                {
                    var secondProtected = courtCaseRecord.OtherProtected.ElementAt(1);
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Name", secondProtected.FullName);
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Sex", secondProtected.Sex.ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Age", secondProtected.Age.ToString());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]Relation", secondProtected.RelationshipToPlaintiff.GetDisplayName());
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]HouseholdYes", secondProtected.IsHouseHold ? BooleanString : null); //CheckBox
                    Utils.SetPdfFormFieldValue(form, mapper, "protectedAdd[1]HouseholdNo", secondProtected.IsHouseHold ? null : BooleanString); //CheckBox

                    if (courtCaseRecord.OtherProtected.Count > 2)
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
            //caseHistory.Appearances.
            bool protectedAppear = isParty1Protected ? caseHearing.Appearance.Party1Appear : caseHearing.Appearance.Party2Appear;
            bool protectedAttotneyAppear = isParty1Protected ? caseHearing.Appearance.Party1AttorneyPresent : caseHearing.Appearance.Party2Appear;
            //Utils.SetPdfFormFieldValue(form, mapper, "p1AttendYes", protectedAppear);  
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
            //lawyersFees
            if (reportData.LawersFeeAndCourtCostsSection != null && reportData.LawersFeeAndCourtCostsSection.IsEnabled)
            {
                Utils.SetPdfFormFieldValue(form, mapper, "orderPayAttorneyCosts", BooleanString);
                Utils.SetPdfFormFieldValue(form, mapper, "courtCosts", reportData.LawersFeeAndCourtCostsSection.IsCourtCosts ? BooleanString : null);
                bool IsProtectedPayer =  (reportData.LawersFeeAndCourtCostsSection.IsParty1Payer && courtCaseRecord.Party1.ParticipantRole == ParticipantRole.PPSC) ||
                    (!reportData.LawersFeeAndCourtCostsSection.IsParty1Payer && courtCaseRecord.Party2.ParticipantRole == ParticipantRole.PPSC);
                Utils.SetPdfFormFieldValue(form, mapper, "feePaidBy", IsProtectedPayer ? "1" : "2");
                Utils.SetPdfFormFieldValue(form, mapper, "feePaidTo", IsProtectedPayer ? "2" : "1");
                if (reportData.LawersFeeAndCourtCostsSection.IsLawyerFee)
                {
                    string[][] feeItems = new string[][]{
                        new string[]{"lawyersFee[0]Item", "lawyersFee[0]Amount"},
                        new string[]{"lawyersFee[1]Item", "lawyersFee[1]Amount"},
                        new string[]{"lawyersFee[2]Item", "lawyersFee[2]Amount"},
                        new string[]{"lawyersFee[3]Item", "lawyersFee[3]Amount"}
                    };
                    Utils.SetPdfFormFieldValue(form, mapper, "lawyersFees", BooleanString);
                    var feeItemsCount  = reportData.LawersFeeAndCourtCostsSection.LawyersFees.Count;
                    for (int i = 0; i < feeItems.Length; i++)
                    {
                        if (i < feeItemsCount)
                        {
                            Utils.SetPdfFormFieldValue(form, mapper, feeItems[i][0], reportData.LawersFeeAndCourtCostsSection.LawyersFees.ElementAt(i).Key);
                            Utils.SetPdfFormFieldValue(form, mapper, feeItems[i][1], reportData.LawersFeeAndCourtCostsSection.LawyersFees.ElementAt(i).Value);
                        }
                    }
                    Utils.SetPdfFormFieldValue(form, mapper, "lawyersFeesAdditionalYes", feeItemsCount > feeItems.Length ? "2" : "1");
                }
            }
            //Other orders
            Utils.SetPdfFormFieldValue(form, mapper, "otherOrdersAttach", reportData.IsOtherOrdersAttached ? BooleanString : null);
            Utils.SetPdfFormFieldValue(form, mapper, "otherOrdersDetail", reportData.OtherOrderDetail);
            Utils.SetPdfFormFieldValue(form, mapper, "otherOrdersYes", !string.IsNullOrEmpty(reportData.OtherOrderDetail) || reportData.IsOtherOrdersAttached ? BooleanString : null);

            //Service proof


        }

    }
}
