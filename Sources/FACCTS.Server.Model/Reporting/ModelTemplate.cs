using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using FACCTS.Server.Model.Reporting.Entities;
using FACCTS.Server.Model.DataModel;
using System.Collections.Generic;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.Reporting;

namespace FACCTS.Server.Model.OrderModels
{
			
	public partial class OtherOrders
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public string OtherOrdersDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class CH130ConductChoice
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsNoAbuse
		{
			get; set;
		}
		
		public bool IsNoContact
		{
			get; set;
		}
		
		public bool IsDontTryToLocate
		{
			get; set;
		}
		
		public bool IsInvolveOtherProtected
		{
			get; set;
		}
		
		public bool IsInvolveOther
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public bool IsOtherAttached
		{
			get; set;
		}
				
	}
	
			
	public partial class CH130StayAwayOrders
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsStayAwayFromPerson
		{
			get; set;
		}
		
		public bool IsStayAwayFromHome
		{
			get; set;
		}
		
		public bool IsStayAwayFromVehicle
		{
			get; set;
		}
		
		public bool IsStayAwayFromChildCare
		{
			get; set;
		}
		
		public bool IsStayAwayFromChildSchool
		{
			get; set;
		}
		
		public bool IsStayAwayFromWork
		{
			get; set;
		}
		
		public bool IsStayAwayFromOtherProtected
		{
			get; set;
		}
		
		public bool IsStayAwayFromOther
		{
			get; set;
		}
		
		public bool IsAttachOther
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public int StayAwayDistance
		{
			get; set;
		}
				
	}
	
			
	public partial class CH130
	{
		public CH130ConductChoice ConductSection
		{
			get; set;
		}
		
		public CH130StayAwayOrders StayAwayOrdersSection
		{
			get; set;
		}
		
		public bool IsNoGuns
		{
			get; set;
		}
		
		public CAPROSEntry CAPROSEntrySection
		{
			get; set;
		}
		
		public NoServiceFee NoServiceFeeSection
		{
			get; set;
		}
		
		public bool? IsPOSGeneral
		{
			get; set;
		}
		
		public LawersFeeAndCourtCosts LawersFeeAndCourtCostsSection
		{
			get; set;
		}
		
		public bool IsOtherOrdersAttached
		{
			get; set;
		}
		
		public string OtherOrderDetail
		{
			get; set;
		}
				
	}
	
			
	public partial class CH110ConductChoice
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsNoAbuse
		{
			get; set;
		}
		
		public bool IsNoContact
		{
			get; set;
		}
		
		public bool IsDontTryToLocate
		{
			get; set;
		}
		
		public bool IsInvolveOtherProtected
		{
			get; set;
		}
		
		public bool IsInvolveOther
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public OrderRestrictionState ConductState
		{
			get; set;
		}
				
	}
	
			
	public partial class CH110RestrainedPersonPayment
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsAttonrneyFees
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public List<OtherProtected> OtherProtectedPersons
		{
			get; set;
		}
				
	}
	
			
	public partial class CH110StayAwayOrders
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsStayAwayFromPerson
		{
			get; set;
		}
		
		public bool IsStayAwayFromHome
		{
			get; set;
		}
		
		public bool IsStayAwayFromVehicle
		{
			get; set;
		}
		
		public bool IsStayAwayFromChildCare
		{
			get; set;
		}
		
		public bool IsStayAwayFromChildSchool
		{
			get; set;
		}
		
		public bool IsStayAwayFromWork
		{
			get; set;
		}
		
		public bool IsStayAwayFromOtherProtected
		{
			get; set;
		}
		
		public bool IsStayAwayFromOther
		{
			get; set;
		}
		
		public bool IsAttachOther
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public int StayAwayDistance
		{
			get; set;
		}
		
		public OrderRestrictionState StayAwayState
		{
			get; set;
		}
				
	}
	
			
	public partial class CH110
	{
		public CH110ConductChoice ConductSection
		{
			get; set;
		}
		
		public CH110StayAwayOrders StayAwayOrdersSection
		{
			get; set;
		}
		
		public bool IsNoGuns
		{
			get; set;
		}
		
		public CAPROSEntry CAPROSEntrySection
		{
			get; set;
		}
		
		public NoServiceFee NoServiceFeeSection
		{
			get; set;
		}
		
		public bool IsOtherOrdersAttached
		{
			get; set;
		}
		
		public string OtherOrderDetail
		{
			get; set;
		}
				
	}
	
			
	public partial class DVConductChoice
	{
		public bool IsNoAbuse
		{
			get; set;
		}
		
		public bool IsNoContact
		{
			get; set;
		}
		
		public bool IsDontTryToLocate
		{
			get; set;
		}
		
		public bool IsExceptionsExist
		{
			get; set;
		}
				
	}
	
			
	public partial class DVStayAwayOrders
	{
		public bool IsStayAwayFromPerson
		{
			get; set;
		}
		
		public bool IsStayAwayFromHome
		{
			get; set;
		}
		
		public bool IsStayAwayFromVehicle
		{
			get; set;
		}
		
		public bool IsStayAwayFromChildCareOrSchool
		{
			get; set;
		}
		
		public bool IsStayAwayFromPersonSchool
		{
			get; set;
		}
		
		public bool IsStayAwayFromWork
		{
			get; set;
		}
		
		public bool IsStayAwayFromOtherProtected
		{
			get; set;
		}
		
		public bool IsStayAwayFromOther
		{
			get; set;
		}
		
		public bool IsAttachOther
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public int StayAwayDistance
		{
			get; set;
		}
				
	}
	
			
	public partial class DVAnimals
	{
		public int StayAwayAnimalsDistance
		{
			get; set;
		}
		
		public string AnimalsDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class DVPropertyRestraint
	{
		public bool IsProtectedHasPropertyRestraint
		{
			get; set;
		}
		
		public bool IsRestrainedHasPropertyRestraint
		{
			get; set;
		}
				
	}
	
			
	public partial class DV110
	{
		public OrderRestrictionState ConductChoiceState
		{
			get; set;
		}
		
		public DVConductChoice ConductChoice
		{
			get; set;
		}
		
		public OrderRestrictionState StayAwayOrdersState
		{
			get; set;
		}
		
		public DVStayAwayOrders StayAwayOrders
		{
			get; set;
		}
		
		public OrderRestrictionState MoveoutState
		{
			get; set;
		}
		
		public string MoveoutAddress
		{
			get; set;
		}
		
		public OrderRestrictionState RecordUnlawfulCommunicationsAllowedState
		{
			get; set;
		}
		
		public OrderRestrictionState AnimalsSectionState
		{
			get; set;
		}
		
		public DVAnimals AnimalsSection
		{
			get; set;
		}
		
		public bool IsNoGuns
		{
			get; set;
		}
		
		public OrderRestrictionState OtherOrdersState
		{
			get; set;
		}
		
		public string OtherOrdersDescription
		{
			get; set;
		}
		
		public bool IsOterordersAttached
		{
			get; set;
		}
		
		public OrderRestrictionState PropertyControlState
		{
			get; set;
		}
		
		public List<DataItem> PropertyControlItems
		{
			get; set;
		}
		
		public OrderRestrictionState DebtPaymentState
		{
			get; set;
		}
		
		public List<DebtPaymentItem> DebtPaymentItems
		{
			get; set;
		}
		
		public OrderRestrictionState DVPropertyRestraintState
		{
			get; set;
		}
		
		public DVPropertyRestraint PropertyRestraint
		{
			get; set;
		}
		
		public OrderRestrictionState ChildCustodyAndVisitationState
		{
			get; set;
		}
				
	}
	
			
	public partial class DV130
	{
		public bool IsConductChoiceEnabled
		{
			get; set;
		}
		
		public DVConductChoice ConductChoice
		{
			get; set;
		}
		
		public bool IsStayAwayOrdersEnabled
		{
			get; set;
		}
		
		public DVStayAwayOrders StayAwayOrders
		{
			get; set;
		}
		
		public bool IsPOSProvidedToCourt
		{
			get; set;
		}
		
		public bool IsMoveoutEnabled
		{
			get; set;
		}
		
		public string MoveoutAddress
		{
			get; set;
		}
		
		public bool IsRecordUnlawfulCommunicationsAllowed
		{
			get; set;
		}
		
		public bool IsAnimalsEnabled
		{
			get; set;
		}
		
		public DVAnimals Animals
		{
			get; set;
		}
		
		public OtherOrders OtherOrders
		{
			get; set;
		}
		
		public bool IsBattererIntervention
		{
			get; set;
		}
		
		public bool IsNoGuns
		{
			get; set;
		}
		
		public bool IsPropertyControlEnabled
		{
			get; set;
		}
		
		public List<DataItem> PropertyControlItems
		{
			get; set;
		}
		
		public bool IsDebtPaymentEnabled
		{
			get; set;
		}
		
		public List<DebtPaymentItem> DebtPaymentItems
		{
			get; set;
		}
		
		public bool IsPropertyRestraintEnabled
		{
			get; set;
		}
		
		public DVPropertyRestraint PropertyRestraint
		{
			get; set;
		}
		
		public List<PaymentItem> Costs
		{
			get; set;
		}
		
		public bool IsChildCustodyAndVisitationEnabled
		{
			get; set;
		}
				
	}
	
			
	public partial class IsNoVisitationForParents
	{
		public string IsEnabled
		{
			get; set;
		}
		
		public CustodyParent IsNoVisitationParent
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class VisitationSchedule
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsWeekendsAvailableForVisitation
		{
			get; set;
		}
		
		public DateTime WeekendsStartingDate
		{
			get; set;
		}
		
		public bool IsFirstWeekendAvailableForVisitation
		{
			get; set;
		}
		
		public bool IsSecondWeekendAvailableForVisitation
		{
			get; set;
		}
		
		public bool IsThirdWeekendAvailableForVisitation
		{
			get; set;
		}
		
		public bool IsFourthWeekendAvailableForVisitation
		{
			get; set;
		}
		
		public bool IsFifthWeekendAvailableForVisitation
		{
			get; set;
		}
		
		public DayOfWeek FirstAvailableWeekendDay
		{
			get; set;
		}
		
		public DateTime FirstAvailableWeekendTime
		{
			get; set;
		}
		
		public DayOfWeek LastAvailableWeekendDay
		{
			get; set;
		}
		
		public DateTime LastAvailableWeekendTime
		{
			get; set;
		}
		
		public bool IsWeekdaysAvailableForVisitation
		{
			get; set;
		}
		
		public DateTime WeekdaysStartingDate
		{
			get; set;
		}
		
		public DayOfWeek FirstAvailableWeekdayDay
		{
			get; set;
		}
		
		public DateTime FirstAvailableWeekdayTime
		{
			get; set;
		}
		
		public DayOfWeek LastAvailableWeekdayDay
		{
			get; set;
		}
		
		public DateTime LastAvailableWeekdayTime
		{
			get; set;
		}
		
		public bool IsOtherVisitationAvilable
		{
			get; set;
		}
				
	}
	
			
	public partial class ChildVisitation
	{
		public string IsEnabled
		{
			get; set;
		}
		
		public string IsNoVisitationForParents
		{
			get; set;
		}
		
		public bool IsAttachedDocumentAvilable
		{
			get; set;
		}
		
		public int AttachedDocumentPagesCount
		{
			get; set;
		}
		
		public DateTime AttachedDocumentDate
		{
			get; set;
		}
		
		public bool IsPartiesMustGoToMediation
		{
			get; set;
		}
		
		public string MediationDescription
		{
			get; set;
		}
		
		public CustodyParent VisitationGrantedParent
		{
			get; set;
		}
		
		public string VisitationGrantedOtherParentDescription
		{
			get; set;
		}
		
		public VisitationSchedule VisitationScheduleSection
		{
			get; set;
		}
				
	}
	
			
	public partial class Transportation
	{
		public string IsEnabled
		{
			get; set;
		}
		
		public CustodyParent TransportationPickUpPerson
		{
			get; set;
		}
		
		public string TransportationPickUpPersonOtherDescription
		{
			get; set;
		}
		
		public string TransportationPickUpLocation
		{
			get; set;
		}
		
		public CustodyParent TransportationDropOffPerson
		{
			get; set;
		}
		
		public string TransportationDropOffPersonOtherDescription
		{
			get; set;
		}
		
		public string TransportationDropOffLocation
		{
			get; set;
		}
				
	}
	
			
	public partial class TravelRestrict
	{
		public string IsEnabled
		{
			get; set;
		}
		
		public bool IsMomRestrained
		{
			get; set;
		}
		
		public bool IsDadRestrained
		{
			get; set;
		}
		
		public bool IsOtherRestrained
		{
			get; set;
		}
		
		public string OtherRestrainedDescription
		{
			get; set;
		}
		
		public bool IsUSEscapeDenied
		{
			get; set;
		}
		
		public bool IsCAEscapeDenied
		{
			get; set;
		}
		
		public bool IsOtherLocationsEscapeDenied
		{
			get; set;
		}
		
		public string OtherLocationsDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class ExchangeAndRemoval
	{
		public string IsEnabled
		{
			get; set;
		}
		
		public Transportation TransportationSection
		{
			get; set;
		}
		
		public TravelRestrict TravelRestrictSection
		{
			get; set;
		}
		
		public bool IsChildAbductionRiskExist
		{
			get; set;
		}
		
		public bool IsDV145Attached
		{
			get; set;
		}
		
		public bool IsUSCountryOfHabitualResidence
		{
			get; set;
		}
		
		public bool IsOtherCountryOfHabitualResidence
		{
			get; set;
		}
		
		public string OtherCountryAsHabitualResidenceDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class DV140
	{
		public List<ChildCustodyItem> ChildCustodyItems
		{
			get; set;
		}
		
		public ChildVisitation ChildVisitationSection
		{
			get; set;
		}
		
		public ExchangeAndRemoval ExchangeAndRemovalSection
		{
			get; set;
		}
		
		public OtherOrders DV140OtherOrders
		{
			get; set;
		}
				
	}
	
			
	public partial class DV150
	{
		public bool IsPartiesMustGoToMediation
		{
			get; set;
		}
		
		public string MediationPlaceDescription
		{
			get; set;
		}
		
		public bool IsVisitsSupervised
		{
			get; set;
		}
		
		public CustodyParent SupervisedPerson
		{
			get; set;
		}
		
		public string OtherVisitationPersonDescription
		{
			get; set;
		}
		
		public bool IsExchangesOfChildrenAreSupervised
		{
			get; set;
		}
		
		public bool IsAllDV140VisitSupervised
		{
			get; set;
		}
		
		public byte SupervisedVisitsPerWeek
		{
			get; set;
		}
		
		public byte SupervisedVisitsHours
		{
			get; set;
		}
		
		public string SupervisedScheduleDescription
		{
			get; set;
		}
		
		public bool OtherScheduleAttached
		{
			get; set;
		}
		
		public string ProviderName
		{
			get; set;
		}
		
		public string ProviderAddress
		{
			get; set;
		}
		
		public string ProviderPhone
		{
			get; set;
		}
		
		public SupervisionProviderType ProviderType
		{
			get; set;
		}
		
		public bool IsMomPay
		{
			get; set;
		}
		
		public decimal MomPayment
		{
			get; set;
		}
		
		public bool IsDadPay
		{
			get; set;
		}
		
		public decimal DadPayment
		{
			get; set;
		}
		
		public bool IsOtherPay
		{
			get; set;
		}
		
		public decimal OtherPayment
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public DateTime? MomContactProviderDate
		{
			get; set;
		}
		
		public DateTime? DadContactProviderDate
		{
			get; set;
		}
		
		public string OtherContactProviderDescription
		{
			get; set;
		}
		
		public string OtherOrdersDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class SuspiciousDoneThings
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsJobQuited
		{
			get; set;
		}
		
		public bool IsBankAccountClosed
		{
			get; set;
		}
		
		public bool IsAssetsLost
		{
			get; set;
		}
		
		public bool IsHomeSold
		{
			get; set;
		}
		
		public bool IsLeaseEnded
		{
			get; set;
		}
		
		public bool IsDocumentsLost
		{
			get; set;
		}
		
		public bool IsAppliedForDocuments
		{
			get; set;
		}
				
	}
	
			
	public partial class NegativeHistory
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsDomesticViolence
		{
			get; set;
		}
		
		public bool IsChildAbuse
		{
			get; set;
		}
		
		public bool IsParentingMissing
		{
			get; set;
		}
		
		public bool IsDeniedTalking
		{
			get; set;
		}
				
	}
	
			
	public partial class NecessaryTravelDocuments
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public bool IsTravelItineraryRequired
		{
			get; set;
		}
		
		public bool IsCopiesOfAirlineTicketsRequired
		{
			get; set;
		}
		
		public bool IsAddressesAndPhonesRequired
		{
			get; set;
		}
		
		public bool IsOtherParentAirlineTicketRequired
		{
			get; set;
		}
		
		public bool IsOtherExist
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class NotifyEmbancyInfo
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public string CountryName
		{
			get; set;
		}
		
		public int ProvideProofDays
		{
			get; set;
		}
				
	}
	
			
	public partial class DV145
	{
		public bool IsPastROViolations
		{
			get; set;
		}
		
		public bool IsNoTiesWithCalifornia
		{
			get; set;
		}
		
		public SuspiciousDoneThings SuspiciousDoneThingsSection
		{
			get; set;
		}
		
		public NegativeHistory NegativeHistorySection
		{
			get; set;
		}
		
		public bool HasCriminalRecord
		{
			get; set;
		}
		
		public bool HasOtherLocationsTies
		{
			get; set;
		}
		
		public bool IsPostBondRequered
		{
			get; set;
		}
		
		public decimal BondAmount
		{
			get; set;
		}
		
		public bool IsMoveWithoutPermissionDenied
		{
			get; set;
		}
		
		public RestrainedLocations MoveDenaiedLocations
		{
			get; set;
		}
		
		public string OtherMoveDenaiedLocationsDescription
		{
			get; set;
		}
		
		public bool IsTravelWithoutPermissionDenied
		{
			get; set;
		}
		
		public RestrainedLocations TravelDenaiedLocations
		{
			get; set;
		}
		
		public string OtherTravelDenaiedLocationsDescription
		{
			get; set;
		}
		
		public string OtherParentToGivePermission
		{
			get; set;
		}
		
		public bool IsNotifyOtherStateRequired
		{
			get; set;
		}
		
		public USAState OtherState
		{
			get; set;
		}
		
		public bool TravelDocumentsApplyDenied
		{
			get; set;
		}
		
		public string TurnedInDocuments
		{
			get; set;
		}
		
		public NecessaryTravelDocuments NecessaryTravelDocumentsSection
		{
			get; set;
		}
		
		public bool IsNotifyForeignEmbassyRequired
		{
			get; set;
		}
		
		public bool IsForeignCustodyCourtOrderRequired
		{
			get; set;
		}
		
		public bool IsEnforcingCourtOrderRequired
		{
			get; set;
		}
		
		public string EnforcingAgencyName
		{
			get; set;
		}
		
		public OtherOrders OtherPermissionsOrder
		{
			get; set;
		}
		
		public NotifyEmbancyInfo NotifyEmbancyInfo
		{
			get; set;
		}
				
	}
	
			
	public partial class IncomeAndDeductions
	{
		public Designation Designation
		{
			get; set;
		}
		
		public decimal TotalGrossMonthlyIncome
		{
			get; set;
		}
		
		public decimal TotalMonthlyDeductions
		{
			get; set;
		}
		
		public decimal TotalHardshipDeductions
		{
			get; set;
		}
		
		public decimal NetMonthlyDisposableIncome
		{
			get; set;
		}
				
	}
	
			
	public partial class JudgmentForSpousalSupport
	{
		public bool IsModifiesJudgmentOrder
		{
			get; set;
		}
		
		public DateTime ModifingJudgmentOrderDate
		{
			get; set;
		}
		
		public bool WerePartiesMarried
		{
			get; set;
		}
		
		public int MarriedLifeYears
		{
			get; set;
		}
		
		public int MarriedLifeMonths
		{
			get; set;
		}
		
		public bool WerePartiesPartners
		{
			get; set;
		}
		
		public int PartnershipLifeYears
		{
			get; set;
		}
		
		public int PartnershipLifeMonths
		{
			get; set;
		}
		
		public bool ArePartiesBothSelfSupported
		{
			get; set;
		}
		
		public bool IsMaritalStandardOfLivingEnabled
		{
			get; set;
		}
		
		public string MaritalStandardOfLivingDescription
		{
			get; set;
		}
		
		public bool IsStandartOfLivingAttached
		{
			get; set;
		}
		
		public bool IsSupportReserved
		{
			get; set;
		}
		
		public bool IsSupportReservedForPetitioner
		{
			get; set;
		}
		
		public bool IsSupportReservedForRespondent
		{
			get; set;
		}
		
		public bool IsSupportTerminated
		{
			get; set;
		}
		
		public bool IsSupportTerminatedForPetitioner
		{
			get; set;
		}
		
		public bool IsSupportTerminatedForRespondent
		{
			get; set;
		}
				
	}
	
			
	public partial class CourtOrders
	{
		public Designation SupportToBePaidFrom
		{
			get; set;
		}
		
		public Designation SupportToBePaidTo
		{
			get; set;
		}
		
		public decimal SupportAmount
		{
			get; set;
		}
		
		public DateTime SupportFromDate
		{
			get; set;
		}
		
		public bool IsPayOnTheDayOfMonth
		{
			get; set;
		}
		
		public byte DayOfMonth
		{
			get; set;
		}
		
		public bool IsOtherPaymentScheme
		{
			get; set;
		}
		
		public string OtherPaymentSchemeDescription
		{
			get; set;
		}
		
		public DateTime SupportUntilDate
		{
			get; set;
		}
		
		public bool IsTemporarySupportEnabled
		{
			get; set;
		}
		
		public bool IsSpousalSupportEnabled
		{
			get; set;
		}
		
		public bool IsFamilySupportEnabled
		{
			get; set;
		}
		
		public bool IsPartnerSupportEnabled
		{
			get; set;
		}
		
		public bool IsSupportConditionsEnabled
		{
			get; set;
		}
		
		public bool IsMustInformAboutEmploymentChanges
		{
			get; set;
		}
		
		public string IsOrderForFamilySupport
		{
			get; set;
		}
		
		public string IsSelfSupportEffortsEnabled
		{
			get; set;
		}
		
		public Designation SelfSupportEffortedPerson
		{
			get; set;
		}
		
		public bool IsEarningAssignmentStatementEnabled
		{
			get; set;
		}
		
		public bool IsServiceStayedPeriodProvided
		{
			get; set;
		}
		
		public int ServiceStayedPeriod
		{
			get; set;
		}
		
		public bool IsNoticeAboutDurationEnabled
		{
			get; set;
		}
		
		public bool IsOtherOrdersEnabled
		{
			get; set;
		}
		
		public string OtherOrdersDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class FL343
	{
		public bool IsAttachedToFOAH
		{
			get; set;
		}
		
		public bool IsAttachedToDVRO
		{
			get; set;
		}
		
		public bool IsAttachedToJudgment
		{
			get; set;
		}
		
		public bool IsAttachedToStipulation
		{
			get; set;
		}
		
		public bool IsAttachedToOther
		{
			get; set;
		}
		
		public string OtherAttachedToDescription
		{
			get; set;
		}
		
		public string IncomeAndDeductions
		{
			get; set;
		}
		
		public string IsComputerPrintOutAttach
		{
			get; set;
		}
		
		public JudgmentForSpousalSupport JudgmentForSpousalSupport
		{
			get; set;
		}
		
		public CourtOrders CourtOrders
		{
			get; set;
		}
				
	}
	
			
	public partial class EAConductChoice
	{
		public bool IsNoAbuse
		{
			get; set;
		}
		
		public bool IsNoContact
		{
			get; set;
		}
		
		public bool IsDontTryToLocate
		{
			get; set;
		}
		
		public bool IsInvolveOtherProtected
		{
			get; set;
		}
		
		public bool IsInvolveOther
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public bool IsOtherAttached
		{
			get; set;
		}
				
	}
	
			
	public partial class EAStayAwayOrders
	{
		public bool IsStayAwayFromPerson
		{
			get; set;
		}
		
		public bool IsStayAwayFromHome
		{
			get; set;
		}
		
		public bool IsStayAwayFromVehicle
		{
			get; set;
		}
		
		public bool IsStayAwayFromWork
		{
			get; set;
		}
		
		public bool IsStayAwayFromOtherProtected
		{
			get; set;
		}
		
		public bool IsStayAwayFromOther
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public int StayAwayDistance
		{
			get; set;
		}
				
	}
	
			
	public partial class Firearms
	{
		public bool IsNoGuns
		{
			get; set;
		}
		
		public bool IsCourtHasFirearmsInformation
		{
			get; set;
		}
				
	}
	
			
	public partial class EA110
	{
		public OrderRestrictionState EAConductChoiceState
		{
			get; set;
		}
		
		public EAConductChoice EAConductChoice
		{
			get; set;
		}
		
		public OrderRestrictionState EAStayAwayOrdersState
		{
			get; set;
		}
		
		public EAStayAwayOrders EAStayAwayOrders
		{
			get; set;
		}
		
		public OrderRestrictionState MoveoutState
		{
			get; set;
		}
		
		public string MoveoutAddress
		{
			get; set;
		}
		
		public CAPROSEntry CAPROSEntrySection
		{
			get; set;
		}
		
		public NoServiceFee NoServiceFeeSection
		{
			get; set;
		}
		
		public bool IsOtherOrdersAttached
		{
			get; set;
		}
		
		public string OtherOrderDetail
		{
			get; set;
		}
		
		public bool IsFirearmsGranted
		{
			get; set;
		}
		
		public Firearms Firearms
		{
			get; set;
		}
		
		public bool IsFinancialAbuseInvolved
		{
			get; set;
		}
				
	}
	
			
	public partial class EA130
	{
		public bool IsEAConductChoiceEnabled
		{
			get; set;
		}
		
		public EAConductChoice EAConductChoice
		{
			get; set;
		}
		
		public bool EAStayAwayOrdersEnabled
		{
			get; set;
		}
		
		public EAStayAwayOrders EAStayAwayOrders
		{
			get; set;
		}
		
		public bool IsMoveoutEnabled
		{
			get; set;
		}
		
		public string MoveoutAddress
		{
			get; set;
		}
		
		public CAPROSEntry CAPROSEntrySection
		{
			get; set;
		}
		
		public NoServiceFee NoServiceFeeSection
		{
			get; set;
		}
		
		public bool IsOtherOrdersAttached
		{
			get; set;
		}
		
		public string OtherOrderDetail
		{
			get; set;
		}
		
		public bool IsNoGuns
		{
			get; set;
		}
		
		public Firearms Firearms
		{
			get; set;
		}
		
		public bool IsFinancialAbuseInvolved
		{
			get; set;
		}
				
	}
	
			
	public partial class FL344
	{
		public bool IsRestrainedOrdersEnabled
		{
			get; set;
		}
		
		public Designation RestrainedPerson
		{
			get; set;
		}
		
		public bool IsNoDisposing
		{
			get; set;
		}
		
		public bool IsMustNotify
		{
			get; set;
		}
		
		public bool IsNoChangeCoverages
		{
			get; set;
		}
		
		public bool IsNoDebt
		{
			get; set;
		}
		
		public bool IsPropertyAndPossesionEnabled
		{
			get; set;
		}
		
		public List<DataItem> PropertyAndPossetion
		{
			get; set;
		}
		
		public bool IsDebtOrdersEnabled
		{
			get; set;
		}
		
		public List<DebtItem> Debts
		{
			get; set;
		}
		
		public bool IsOtherPropertyAttached
		{
			get; set;
		}
		
		public bool AreThisTemporaryOrders
		{
			get; set;
		}
		
		public OtherOrders OtherOrders
		{
			get; set;
		}
				
	}
	
			
	public partial class TimeShare
	{
		public byte ChildrenNumber
		{
			get; set;
		}
		
		public byte TimeSpentWithPetitioner
		{
			get; set;
		}
		
		public byte TimeSpentWithRespondent
		{
			get; set;
		}
		
		public byte TimeSpentWithOther
		{
			get; set;
		}
				
	}
	
			
	public partial class LowIncomeAdjustment
	{
		public bool IsLowIncomeAdjustmentApplies
		{
			get; set;
		}
		
		public string DoesNotApplyReasonDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class AdditionalPayment
	{
		public bool IsPetitionerMustPay
		{
			get; set;
		}
		
		public AdditionalChildSupportItem PetitionerMustPay
		{
			get; set;
		}
		
		public bool IsRespondentMustPay
		{
			get; set;
		}
		
		public AdditionalChildSupportItem RespondentMustPay
		{
			get; set;
		}
		
		public bool IsOtherMustPay
		{
			get; set;
		}
		
		public AdditionalChildSupportItem OtherMustPay
		{
			get; set;
		}
		
		public string IsCostsToBePaidEnabled
		{
			get; set;
		}
		
		public string CostsToBePaid
		{
			get; set;
		}
				
	}
	
			
	public partial class ChildSupport
	{
		public List<ChildSupportItem> ChildSupportItems
		{
			get; set;
		}
		
		public PayableSchedule PayableSchedule
		{
			get; set;
		}
		
		public string OtherPayableScheduleDescription
		{
			get; set;
		}
		
		public DateTime CommencingDate
		{
			get; set;
		}
		
		public Designation PaidByPerson
		{
			get; set;
		}
		
		public Designation PaidToPerson
		{
			get; set;
		}
		
		public string IsMandatoryAdditionalChildSupportEnabled
		{
			get; set;
		}
		
		public bool IsChildCareRelatedToEmploymentEnabled
		{
			get; set;
		}
		
		public AdditionalPayment ChildCareRelatedToEmployment
		{
			get; set;
		}
		
		public bool IsReasonableUninsuredHealthCareEnabled
		{
			get; set;
		}
		
		public AdditionalPayment ReasonableUninsuredHealthCare
		{
			get; set;
		}
		
		public bool IsAdditionalChildSupportEnabled
		{
			get; set;
		}
		
		public bool IsEducationalCostsEnabled
		{
			get; set;
		}
		
		public AdditionalPayment EducationalCosts
		{
			get; set;
		}
		
		public bool IsTravelExpensesEnabled
		{
			get; set;
		}
		
		public AdditionalPayment TravelExpenses
		{
			get; set;
		}
		
		public bool IsNonGuidlineOrder
		{
			get; set;
		}
		
		public decimal TotalChildSupportPerMonth
		{
			get; set;
		}
		
		public decimal TotalBaseChildPerMonth
		{
			get; set;
		}
		
		public decimal AdditionalChildPerMonth
		{
			get; set;
		}
				
	}
	
			
	public partial class MultyChoice
	{
		public bool IsPetitonerSelected
		{
			get; set;
		}
		
		public bool IsRespondentSelected
		{
			get; set;
		}
		
		public bool IsOtherSelected
		{
			get; set;
		}
				
	}
	
			
	public partial class HealthCare
	{
		public MultyChoice HealthInsuranceMaintained
		{
			get; set;
		}
		
		public bool IsHealthInsuranceIsNotAvailableEnabled
		{
			get; set;
		}
		
		public MultyChoice HealthInsuranceIsNotAvailable
		{
			get; set;
		}
		
		public bool IsReimbursementCanBeAssigned
		{
			get; set;
		}
				
	}
	
			
	public partial class FL342
	{
		public bool IsAttachedToFOAH
		{
			get; set;
		}
		
		public bool IsAttachedToDVRO
		{
			get; set;
		}
		
		public bool IsAttachedToJudjement
		{
			get; set;
		}
		
		public bool IsAttachedToOther
		{
			get; set;
		}
		
		public string OtherDescription
		{
			get; set;
		}
		
		public bool IsPrintoutAttached
		{
			get; set;
		}
		
		public bool IsIncomeEnabled
		{
			get; set;
		}
		
		public List<IncomeItem> Incomes
		{
			get; set;
		}
		
		public bool IsTimeShareEnabled
		{
			get; set;
		}
		
		public TimeShare TimeShare
		{
			get; set;
		}
		
		public bool IsHardshipsEnabled
		{
			get; set;
		}
		
		public List<HardshipItem> HardshipItems
		{
			get; set;
		}
		
		public bool IsLowIncomeAdjustmentEnabled
		{
			get; set;
		}
		
		public LowIncomeAdjustment LowIncomeAdjustment
		{
			get; set;
		}
		
		public bool IsChildSupportEnabled
		{
			get; set;
		}
		
		public ChildSupport ChildSupport
		{
			get; set;
		}
		
		public bool IsEmploymentSearchEnabled
		{
			get; set;
		}
		
		public MultyChoice EmploymentSearch
		{
			get; set;
		}
		
		public HealthCare HealthCare
		{
			get; set;
		}
		
		public string OthersDescription
		{
			get; set;
		}
				
	}
	
}

