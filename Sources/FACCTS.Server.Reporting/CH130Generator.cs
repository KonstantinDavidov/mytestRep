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
            CH130 reportData = data as CH130;

            CaseHistory caseHistory = DataManager.CaseHistoryRepository.GetAll(
                        ch => ch.Hearing,
                        ch => ch.CourtCase
                       ).FirstOrDefault(ch => ch.Id == reportData.CaseHistoryId);

            CourtCase courtCase = DataManager.CourtCaseRepository.GetAll(
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
               .FirstOrDefault(cc => cc.Id == caseHistory.CourtCase.Id);

            Hearing caseHearing = caseHistory.Hearing;
            bool isParty1Protected = courtCase.Party1.ParticipantRole == Model.Enums.ParticipantRole.PPSC;

            //Protected party
            CourtParty protectedParty = isParty1Protected ? courtCase.Party1 : courtCase.Party2;
            Attorney protectedPartyAttoney = isParty1Protected ? courtCase.Party1.Attorney : courtCase.Party2.Attorney;
            bool isProtectedHasAttorney = !protectedParty.IsProPer && (protectedParty.Attorney != null);

            //Restrained party
            CourtParty restrainedParty = isParty1Protected ? courtCase.Party2 : courtCase.Party1;
            Attorney restrainedPartyAttoney = isParty1Protected ? courtCase.Party2.Attorney : courtCase.Party1.Attorney;
            bool isRestrainedHasAttorney = !restrainedParty.IsProPer && (restrainedParty.Attorney != null);

            Utils.SetPdfField(form, mapper, "caseNumber", courtCase.CaseNumber);
            Utils.SetPdfField(form, mapper, "courtName", "TODO"); 

            //protected
            Utils.SetPdfField(form, mapper, "protectedName", protectedParty.FullName);

            Utils.SetPdfField(form, mapper, "protectedAttorneyName", isProtectedHasAttorney ? protectedParty.Attorney.FullName : null);
            Utils.SetPdfField(form, mapper, "protectedAttorneyFirm", isProtectedHasAttorney ? protectedParty.Attorney.FirmName : null);
            Utils.SetPdfField(form, mapper, "protectedAttorneyBarID",isProtectedHasAttorney ? protectedParty.Attorney.StateBarId : null);

            Utils.SetPdfField(form, mapper, "protectedAddressStreet", isProtectedHasAttorney ? protectedParty.Attorney.AddressInfo.StreetAddress : protectedParty.AddressInfo.StreetAddress);
            Utils.SetPdfField(form, mapper, "protectedAddressCity", isProtectedHasAttorney ? protectedParty.Attorney.AddressInfo.City : protectedParty.AddressInfo.City);
            Utils.SetPdfField(form, mapper, "protectedAddressState", isProtectedHasAttorney ? protectedParty.Attorney.AddressInfo.USAState.ToString() : protectedParty.AddressInfo.USAState.ToString());
            Utils.SetPdfField(form, mapper, "protectedAddressPostal", isProtectedHasAttorney ? protectedParty.Attorney.AddressInfo.ZipCode : protectedParty.AddressInfo.ZipCode);
            Utils.SetPdfField(form, mapper, "protectedPhone", isProtectedHasAttorney ? protectedParty.Attorney.AddressInfo.Phone : protectedParty.AddressInfo.Phone);
            Utils.SetPdfField(form, mapper, "protectedFax", isProtectedHasAttorney ? protectedParty.Attorney.AddressInfo.Fax : protectedParty.AddressInfo.Fax);
            Utils.SetPdfField(form, mapper, "protectedEmail", isProtectedHasAttorney ? protectedParty.Attorney.Email : protectedParty.Email);

            //restrained person
            Utils.SetPdfField(form, mapper, "restrainedName", restrainedParty.FullName);
            Utils.SetPdfField(form, mapper, "restrainedAddressStreet", restrainedParty.AddressInfo.StreetAddress);
            Utils.SetPdfField(form, mapper, "restrainedAddressCity", restrainedParty.AddressInfo.City);
            Utils.SetPdfField(form, mapper, "restrainedAddressState", restrainedParty.State.ToString());
            Utils.SetPdfField(form, mapper, "restrainedAddressPostal", restrainedParty.AddressInfo.ZipCode);
            Utils.SetPdfField(form, mapper, "restrainedEyeColor", restrainedParty.EyesColor.Color);
            Utils.SetPdfField(form, mapper, "restrainedHairColor", restrainedParty.HairColor.Color);
            Utils.SetPdfField(form, mapper, "restrainedRace", restrainedParty.Race.RaceName);
            Utils.SetPdfField(form, mapper, "restrainedHeight", (restrainedParty.HeightFt*12 + restrainedParty.HeightIns).ToString());
            Utils.SetPdfField(form, mapper, "restrainedWeight", restrainedParty.Weight.ToString());
            Utils.SetPdfField(form, mapper, "restrainedDOB", restrainedParty.DateOfBirth.ToOrderDate());
            Utils.SetPdfField(form, mapper, "restrainedAge", restrainedParty.Age.ToString());
            Utils.SetPdfField(form, mapper, "restrainedRelationship", restrainedParty.RelationToOtherParty);
            Utils.SetPdfField(form, mapper, "restrainedSexM", restrainedParty.Sex == Gender.M);
            Utils.SetPdfField(form, mapper, "restrainedSexF", restrainedParty.Sex == Gender.F);
           
            //other protected
            if (courtCase.OtherProtected.Count > 0)
            {
                //First protected
                var firstProtected = courtCase.OtherProtected.First();
                Utils.SetPdfField(form, mapper,"protectedAddYes"); //CheckBox
                Utils.SetPdfField(form, mapper, "protectedAdd[0]Name", firstProtected.FullName);
                Utils.SetPdfField(form, mapper, "protectedAdd[0]Sex", firstProtected.Sex.ToString());
                Utils.SetPdfField(form, mapper, "protectedAdd[0]Age", firstProtected.Age.ToString());
                Utils.SetPdfField(form, mapper, "protectedAdd[0]Relation", firstProtected.RelationshipToPlaintiff.GetDisplayName());
                Utils.SetPdfField(form, mapper, "protectedAdd[0]HouseholdYes", firstProtected.IsHouseHold);
                Utils.SetPdfField(form, mapper, "protectedAdd[0]HouseholdNo", !firstProtected.IsHouseHold);

                if (courtCase.OtherProtected.Count > 1)
                {
                    var secondProtected = courtCase.OtherProtected.ElementAt(1);
                    Utils.SetPdfField(form, mapper, "protectedAdd[1]Name", secondProtected.FullName);
                    Utils.SetPdfField(form, mapper, "protectedAdd[1]Sex", secondProtected.Sex.ToString());
                    Utils.SetPdfField(form, mapper, "protectedAdd[1]Age", secondProtected.Age.ToString());
                    Utils.SetPdfField(form, mapper, "protectedAdd[1]Relation", secondProtected.RelationshipToPlaintiff.GetDisplayName());
                    Utils.SetPdfField(form, mapper, "protectedAdd[1]HouseholdYes", secondProtected.IsHouseHold);
                    Utils.SetPdfField(form, mapper, "protectedAdd[1]HouseholdNo", !secondProtected.IsHouseHold);

                    if (courtCase.OtherProtected.Count > 2)
                    {
                        Utils.SetPdfField(form, mapper, "protectedAddAttachYes"); //CheckBox
                    }
                }

            }

            //Expiration Date
            if (reportData.IsExpire && reportData.OrdersEndDate.HasValue)
            {
                Utils.SetPdfField(form, mapper, "expireDate", reportData.OrdersEndDate.Value.ToOrderDate());

                if (reportData.OrdersEndTime.HasValue && !reportData.OrdersEndTime.Value.IsMidnight())
                {
                    Utils.SetPdfField(form, mapper, "expireTime", reportData.OrdersEndTime.Value.ToOrderTime());
                    Utils.SetPdfField(form, mapper, "expireTimePM", reportData.OrdersEndTime.Value.IsPM());
                    Utils.SetPdfField(form, mapper, "expireTimeAM", reportData.OrdersEndTime.Value.IsAM());
                }
                else
                {
                    Utils.SetPdfField(form, mapper, "expireTimeMidnight");
                }
            }

            //Hearing
            //bool isProtectedAppear = isParty1Protected ? caseHearing.Appearance.Party1Appear : caseHearing.Appearance.Party2Appear;
            //bool isRestrainedAppear = isParty1Protected ? caseHearing.Appearance.Party2Appear : caseHearing.Appearance.Party1Appear;
            //bool isProtectedAttotneyAppear = isParty1Protected ? caseHearing.Appearance.Party1AttorneyPresent : caseHearing.Appearance.Party2Appear;
            //bool isRestrainedAttotneyAppear = isParty1Protected ? caseHearing.Appearance.Party2AttorneyPresent : caseHearing.Appearance.Party1AttorneyPresent;
            bool isProtectedAppear = false;
            bool isRestrainedAppear = false;
            bool isProtectedAttotneyAppear = false;
            bool isRestrainedAttotneyAppear = false;

            Utils.SetPdfField(form, mapper, "p1AttendYes", isProtectedAppear);
            Utils.SetPdfField(form, mapper, "p1AttorneyAttendYes", isProtectedAttotneyAppear);
            Utils.SetPdfField(form, mapper, "p1AttorneyName", 
                isProtectedHasAttorney && isProtectedAttotneyAppear ? protectedParty.Attorney.FullName : null);

            Utils.SetPdfField(form, mapper, "p2AttendYes", isRestrainedAppear);
            Utils.SetPdfField(form, mapper, "p2AttorneyAttendYes", isRestrainedAttotneyAppear);
            Utils.SetPdfField(form, mapper, "p2AttorneyName", 
                isRestrainedHasAttorney && isRestrainedAttotneyAppear ? restrainedParty.Attorney.FullName : null);

            Utils.SetPdfField(form, mapper, "addPartiesAttend", "TODO");

            Utils.SetPdfField(form, mapper, "hearingDate", caseHearing.HearingDate.ToOrderDate());
            Utils.SetPdfField(form, mapper, "hearingDepartment", caseHearing.Department != null ? caseHearing.Department.Name : null);
            Utils.SetPdfField(form, mapper, "hearingCourtroom", caseHearing.Courtroom != null ? caseHearing.Courtroom.RoomName : null);
            Utils.SetPdfField(form, mapper, "hearingJudicialOfficer", caseHearing.Judge);

            //Service proof

            Utils.SetPdfField(form, mapper, "p1Attendp2Attend", isProtectedAppear && isRestrainedAppear);
            Utils.SetPdfField(form, mapper, "p1Attendp2No", isProtectedAppear && !isRestrainedAppear);
            Utils.SetPdfField(form, mapper, "posGeneral", reportData.IsPOSGeneral);
            Utils.SetPdfField(form, mapper, "proofServiceRestrainPersonal", !reportData.IsPOSGeneral);

            //Conduct
            if (reportData.ConductSection != null && reportData.ConductSection.IsEnabled)
            {
                Utils.SetPdfField(form, mapper, "conductOrders", true);
                Utils.SetPdfField(form, mapper, "addProtectedConductYes", reportData.ConductSection.IsInvolveOtherProtected);
                Utils.SetPdfField(form, mapper, "conductHarrassYes", reportData.ConductSection.IsNoAbuse);
                Utils.SetPdfField(form, mapper, "conductContactYes", reportData.ConductSection.IsNoContact);
                Utils.SetPdfField(form, mapper, "conductLocationYes", reportData.ConductSection.IsDontTryToLocate);
                if (reportData.ConductSection.IsInvolveOther)
                {
                    Utils.SetPdfField(form, mapper, "conductOtherYes", true);
                    Utils.SetPdfField(form, mapper, "conductOtherAttach", reportData.ConductSection.IsOtherAttached);
                    Utils.SetPdfField(form, mapper, "conductOtherDetail", reportData.ConductSection.OtherDescription);
                }
            }

            //Stay Away
            if (reportData.StayAwayOrdersSection != null && reportData.StayAwayOrdersSection.IsEnabled)
            {
                Utils.SetPdfField(form, mapper, "stayawayOrdersYes");
                Utils.SetPdfField(form, mapper, "stayawayOrdersYards", reportData.StayAwayOrdersSection.StayAwayDistance.ToString());
                Utils.SetPdfField(form, mapper, "stayawayPerson", reportData.StayAwayOrdersSection.IsStayAwayFromPerson);
                Utils.SetPdfField(form, mapper, "stayawayHome", reportData.StayAwayOrdersSection.IsStayAwayFromHome);
                Utils.SetPdfField(form, mapper, "stayawayWork", reportData.StayAwayOrdersSection.IsStayAwayFromWork);
                Utils.SetPdfField(form, mapper, "stayawayVehicle", reportData.StayAwayOrdersSection.IsStayAwayFromVehicle);
                Utils.SetPdfField(form, mapper, "stayawayChildcare", reportData.StayAwayOrdersSection.IsStayAwayFromChildCare);
                Utils.SetPdfField(form, mapper, "stayawayOtherProtected", reportData.StayAwayOrdersSection.IsStayAwayFromOtherProtected);
                Utils.SetPdfField(form, mapper, "stayawaySchool", reportData.StayAwayOrdersSection.IsStayAwayFromChildSchool);

                if (reportData.StayAwayOrdersSection.IsStayAwayFromOther)
                {
                    Utils.SetPdfField(form, mapper, "stayawayOther");
                    Utils.SetPdfField(form, mapper, "stayawayOtherDetail", reportData.StayAwayOrdersSection.OtherDescription);
                }
            }
            //Firearm
            Utils.SetPdfField(form, mapper, "firearmYes", reportData.IsNoGuns);

            //CARPOS
            if (reportData.CAPROSEntrySection != null)
            {
                if (reportData.CAPROSEntrySection.CARPOSEntryType == CARPOSEntryType.ByProtected)
                {
                    Utils.SetPdfField(form, mapper, "carposByProtected");
                    if (reportData.CAPROSEntrySection.LawEnforcementAgencies.Count > 0)
                    {
                        Utils.SetPdfField(form, mapper, "carposLawEnforcement[0]Agency", reportData.CAPROSEntrySection.LawEnforcementAgencies.ElementAt(0).Name);
                        Utils.SetPdfField(form, mapper, "carposLawEnforcement[0]Address", reportData.CAPROSEntrySection.LawEnforcementAgencies.ElementAt(0).Description);
                    }
                    if (reportData.CAPROSEntrySection.LawEnforcementAgencies.Count > 1)
                    {
                        Utils.SetPdfField(form, mapper, "carposLawEnforcement[1]Agency", reportData.CAPROSEntrySection.LawEnforcementAgencies.ElementAt(1).Name);
                        Utils.SetPdfField(form, mapper, "carposLawEnforcement[1]Address", reportData.CAPROSEntrySection.LawEnforcementAgencies.ElementAt(1).Description);
                    }
                    if (reportData.CAPROSEntrySection.LawEnforcementAgencies.Count > 2)
                    {
                        Utils.SetPdfField(form, mapper, "carposAdditionalYes");
                    }
                }
                else
                {
                    Utils.SetPdfField(form, mapper, "carposByClerk", reportData.CAPROSEntrySection.CARPOSEntryType == CARPOSEntryType.ByClerk);
                    Utils.SetPdfField(form, mapper, "carposByLawEnforcement", reportData.CAPROSEntrySection.CARPOSEntryType == CARPOSEntryType.ByClerkToLawEnforcement);
                }
            }

            //No Fee to Serve
            if (reportData.NoServiceFeeSection != null && reportData.NoServiceFeeSection.IsOrdered)
            {
                Utils.SetPdfField(form, mapper, "serviceNoFee");
                Utils.SetPdfField(form, mapper, "feeWaiverViolence", reportData.NoServiceFeeSection.IsBasedOnViolence);
                Utils.SetPdfField(form, mapper, "feeWaiverEntitled", reportData.NoServiceFeeSection.IsFeeWaiver);
            }
            //lawyersFees
            if (reportData.LawersFeeAndCourtCostsSection != null && reportData.LawersFeeAndCourtCostsSection.IsEnabled)
            {
                Utils.SetPdfField(form, mapper, "orderPayAttorneyCosts");
                Utils.SetPdfField(form, mapper, "courtCosts", reportData.LawersFeeAndCourtCostsSection.IsCourtCosts);
                bool IsProtectedPayer = (reportData.LawersFeeAndCourtCostsSection.Payer == ParticipantRole.PPSC && courtCase.Party1.ParticipantRole == ParticipantRole.PPSC) ||
                    (!(reportData.LawersFeeAndCourtCostsSection.Payer == ParticipantRole.PPSC) && courtCase.Party2.ParticipantRole == ParticipantRole.PPSC);
                Utils.SetPdfField(form, mapper, "feePaidBy", IsProtectedPayer ? "1" : "2");
                Utils.SetPdfField(form, mapper, "feePaidTo", IsProtectedPayer ? "2" : "1");
                if (reportData.LawersFeeAndCourtCostsSection.IsLawyerFee)
                {
                    string[][] feeItems = new string[][]{
                        new string[]{"lawyersFee[0]Item", "lawyersFee[0]Amount"},
                        new string[]{"lawyersFee[1]Item", "lawyersFee[1]Amount"},
                        new string[]{"lawyersFee[2]Item", "lawyersFee[2]Amount"},
                        new string[]{"lawyersFee[3]Item", "lawyersFee[3]Amount"}
                    };
                    Utils.SetPdfField(form, mapper, "lawyersFees");
                    var feeItemsCount  = reportData.LawersFeeAndCourtCostsSection.LawyersFees.Count;
                    for (int i = 0; i < feeItems.Length; i++)
                    {
                        if (i < feeItemsCount)
                        {
                            Utils.SetPdfField(form, mapper, feeItems[i][0], reportData.LawersFeeAndCourtCostsSection.LawyersFees.ElementAt(i).Name);
                            Utils.SetPdfField(form, mapper, feeItems[i][1], reportData.LawersFeeAndCourtCostsSection.LawyersFees.ElementAt(i).Description);
                        }
                    }
                    Utils.SetPdfField(form, mapper, "lawyersFeesAdditionalYes", feeItemsCount > feeItems.Length ? "2" : "1");
                }
            }
            //Other orders
            Utils.SetPdfField(form, mapper, "otherOrdersAttach", reportData.IsOtherOrdersAttached);
            Utils.SetPdfField(form, mapper, "otherOrdersDetail", reportData.OtherOrderDetail);
            Utils.SetPdfField(form, mapper, "otherOrdersYes", !string.IsNullOrEmpty(reportData.OtherOrderDetail) || reportData.IsOtherOrdersAttached);
        }
    }
}
