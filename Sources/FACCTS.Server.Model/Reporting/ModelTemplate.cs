using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using FACCTS.Server.Model.DataModel;
using System.Collections.Generic;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Server.Model.OrderModels
{
			
	public partial interface IOtherOrders
	{
		
		bool IsEnabled
		{
			get; set;
		}
		
		string OtherOrdersDescription
		{
			get; set;
		}
			}
	public partial class OtherOrders : IOtherOrders
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
	
			
	public partial interface ICAPROSEntry
	{
		
		CARPOSEntryType CARPOSEntryType
		{
			get; set;
		}
		
		ICollection<IDataItem> LawEnforcementAgencies
		{
			get; set;
		}
			}
	public partial class CAPROSEntry : ICAPROSEntry
	{
		public CARPOSEntryType CARPOSEntryType
		{
			get; set;
		}
		
		public ICollection<IDataItem> LawEnforcementAgencies
		{
			get; set;
		}
			}
	
			
	public partial interface INoServiceFee
	{
		
		bool IsOrdered
		{
			get; set;
		}
		
		bool IsFeeWaiver
		{
			get; set;
		}
		
		bool IsBasedOnViolence
		{
			get; set;
		}
			}
	public partial class NoServiceFee : INoServiceFee
	{
		public bool IsOrdered
		{
			get; set;
		}
		
		public bool IsFeeWaiver
		{
			get; set;
		}
		
		public bool IsBasedOnViolence
		{
			get; set;
		}
			}
	
			
	public partial interface ILawersFeeAndCourtCosts
	{
		
		bool IsLawyerFee
		{
			get; set;
		}
		
		bool IsCourtCosts
		{
			get; set;
		}
		
		ParticipantRole Payer
		{
			get; set;
		}
		
		ICollection<IDataItem> LawyersFees
		{
			get; set;
		}
			}
	public partial class LawersFeeAndCourtCosts : ILawersFeeAndCourtCosts
	{
		public bool IsLawyerFee
		{
			get; set;
		}
		
		public bool IsCourtCosts
		{
			get; set;
		}
		
		public ParticipantRole Payer
		{
			get; set;
		}
		
		public ICollection<IDataItem> LawyersFees
		{
			get; set;
		}
			}
	
			
	public partial interface IDebtPaymentItem
	{
		
		string Name
		{
			get; set;
		}
		
		ParticipantRole PaymentFor
		{
			get; set;
		}
		
		DateTime PaymentDate
		{
			get; set;
		}
			}
	public partial class DebtPaymentItem : IDebtPaymentItem
	{
		public string Name
		{
			get; set;
		}
		
		public ParticipantRole PaymentFor
		{
			get; set;
		}
		
		public DateTime PaymentDate
		{
			get; set;
		}
			}
	
			
	public partial interface IPaymentItem
	{
		
		string PaymentDescription
		{
			get; set;
		}
		
		bool IsAttorneyFee
		{
			get; set;
		}
		
		string PaymentFor
		{
			get; set;
		}
		
		decimal Amount
		{
			get; set;
		}
		
		DateTime PaymentDueDate
		{
			get; set;
		}
			}
	public partial class PaymentItem : IPaymentItem
	{
		public string PaymentDescription
		{
			get; set;
		}
		
		public bool IsAttorneyFee
		{
			get; set;
		}
		
		public string PaymentFor
		{
			get; set;
		}
		
		public decimal Amount
		{
			get; set;
		}
		
		public DateTime PaymentDueDate
		{
			get; set;
		}
			}
	
			
	public partial interface ICHConductChoice
	{
		
		bool IsNoAbuse
		{
			get; set;
		}
		
		bool IsNoContact
		{
			get; set;
		}
		
		bool IsDontTryToLocate
		{
			get; set;
		}
		
		bool IsInvolveOtherProtected
		{
			get; set;
		}
		
		bool IsInvolveOther
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
		
		bool IsOtherAttached
		{
			get; set;
		}
			}
	public partial class CHConductChoice : ICHConductChoice
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
	
			
	public partial interface ICHStayAwayOrders
	{
		
		bool IsStayAwayFromPerson
		{
			get; set;
		}
		
		bool IsStayAwayFromHome
		{
			get; set;
		}
		
		bool IsStayAwayFromVehicle
		{
			get; set;
		}
		
		bool IsStayAwayFromChildCare
		{
			get; set;
		}
		
		bool IsStayAwayFromChildSchool
		{
			get; set;
		}
		
		bool IsStayAwayFromWork
		{
			get; set;
		}
		
		bool IsStayAwayFromOtherProtected
		{
			get; set;
		}
		
		bool IsStayAwayFromOther
		{
			get; set;
		}
		
		bool IsAttachOther
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
		
		int StayAwayDistance
		{
			get; set;
		}
			}
	public partial class CHStayAwayOrders : ICHStayAwayOrders
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
	
			
	public partial interface ICH130
	{
		
		bool IsConductChoiceEnabled
		{
			get; set;
		}
		
		ICHConductChoice ConductChoice
		{
			get; set;
		}
		
		bool IsStayAwayOrdersEnabled
		{
			get; set;
		}
		
		ICHStayAwayOrders StayAwayOrders
		{
			get; set;
		}
		
		bool IsNoGuns
		{
			get; set;
		}
		
		ICAPROSEntry CAPROSEntry
		{
			get; set;
		}
		
		INoServiceFee NoServiceFee
		{
			get; set;
		}
		
		bool? IsPOSGeneral
		{
			get; set;
		}
		
		ILawersFeeAndCourtCosts LawersFeeAndCourtCosts
		{
			get; set;
		}
		
		bool IsOtherOrdersAttached
		{
			get; set;
		}
		
		string OtherOrderDetail
		{
			get; set;
		}
			}
	public partial class CH130 : ICH130
	{
		public bool IsConductChoiceEnabled
		{
			get; set;
		}
		
		public ICHConductChoice ConductChoice
		{
			get; set;
		}
		
		public bool IsStayAwayOrdersEnabled
		{
			get; set;
		}
		
		public ICHStayAwayOrders StayAwayOrders
		{
			get; set;
		}
		
		public bool IsNoGuns
		{
			get; set;
		}
		
		public ICAPROSEntry CAPROSEntry
		{
			get; set;
		}
		
		public INoServiceFee NoServiceFee
		{
			get; set;
		}
		
		public bool? IsPOSGeneral
		{
			get; set;
		}
		
		public ILawersFeeAndCourtCosts LawersFeeAndCourtCosts
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
	
			
	public partial interface ICH110
	{
		
		OrderRestrictionState ConductSectionState
		{
			get; set;
		}
		
		ICHConductChoice ConductSection
		{
			get; set;
		}
		
		OrderRestrictionState StayAwayOrdersState
		{
			get; set;
		}
		
		ICHStayAwayOrders StayAwayOrders
		{
			get; set;
		}
		
		bool IsNoGuns
		{
			get; set;
		}
		
		ICAPROSEntry CAPROSEntrySection
		{
			get; set;
		}
		
		INoServiceFee NoServiceFeeSection
		{
			get; set;
		}
		
		bool IsOtherOrdersAttached
		{
			get; set;
		}
		
		string OtherOrderDetail
		{
			get; set;
		}
			}
	public partial class CH110 : ICH110
	{
		public OrderRestrictionState ConductSectionState
		{
			get; set;
		}
		
		public ICHConductChoice ConductSection
		{
			get; set;
		}
		
		public OrderRestrictionState StayAwayOrdersState
		{
			get; set;
		}
		
		public ICHStayAwayOrders StayAwayOrders
		{
			get; set;
		}
		
		public bool IsNoGuns
		{
			get; set;
		}
		
		public ICAPROSEntry CAPROSEntrySection
		{
			get; set;
		}
		
		public INoServiceFee NoServiceFeeSection
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
	
			
	public partial interface IDVConductChoice
	{
		
		bool IsNoAbuse
		{
			get; set;
		}
		
		bool IsNoContact
		{
			get; set;
		}
		
		bool IsDontTryToLocate
		{
			get; set;
		}
		
		bool IsExceptionsExist
		{
			get; set;
		}
			}
	public partial class DVConductChoice : IDVConductChoice
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
	
			
	public partial interface IDVStayAwayOrders
	{
		
		bool IsStayAwayFromPerson
		{
			get; set;
		}
		
		bool IsStayAwayFromHome
		{
			get; set;
		}
		
		bool IsStayAwayFromVehicle
		{
			get; set;
		}
		
		bool IsStayAwayFromChildCareOrSchool
		{
			get; set;
		}
		
		bool IsStayAwayFromPersonSchool
		{
			get; set;
		}
		
		bool IsStayAwayFromWork
		{
			get; set;
		}
		
		bool IsStayAwayFromOtherProtected
		{
			get; set;
		}
		
		bool IsStayAwayFromOther
		{
			get; set;
		}
		
		bool IsAttachOther
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
		
		int StayAwayDistance
		{
			get; set;
		}
			}
	public partial class DVStayAwayOrders : IDVStayAwayOrders
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
	
			
	public partial interface IDVAnimals
	{
		
		int StayAwayAnimalsDistance
		{
			get; set;
		}
		
		string AnimalsDescription
		{
			get; set;
		}
			}
	public partial class DVAnimals : IDVAnimals
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
	
			
	public partial interface IDVPropertyRestraint
	{
		
		bool IsProtectedHasPropertyRestraint
		{
			get; set;
		}
		
		bool IsRestrainedHasPropertyRestraint
		{
			get; set;
		}
			}
	public partial class DVPropertyRestraint : IDVPropertyRestraint
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
	
			
	public partial interface IDV110
	{
		
		OrderRestrictionState ConductChoiceState
		{
			get; set;
		}
		
		IDVConductChoice ConductChoice
		{
			get; set;
		}
		
		OrderRestrictionState StayAwayOrdersState
		{
			get; set;
		}
		
		IDVStayAwayOrders StayAwayOrders
		{
			get; set;
		}
		
		OrderRestrictionState MoveoutState
		{
			get; set;
		}
		
		string MoveoutAddress
		{
			get; set;
		}
		
		OrderRestrictionState RecordUnlawfulCommunicationsAllowedState
		{
			get; set;
		}
		
		OrderRestrictionState AnimalsSectionState
		{
			get; set;
		}
		
		IDVAnimals AnimalsSection
		{
			get; set;
		}
		
		bool IsNoGuns
		{
			get; set;
		}
		
		OrderRestrictionState OtherOrdersState
		{
			get; set;
		}
		
		string OtherOrdersDescription
		{
			get; set;
		}
		
		bool IsOterordersAttached
		{
			get; set;
		}
		
		OrderRestrictionState PropertyControlState
		{
			get; set;
		}
		
		ICollection<IDataItem> PropertyControlItems
		{
			get; set;
		}
		
		OrderRestrictionState DebtPaymentState
		{
			get; set;
		}
		
		ICollection<IDebtPaymentItem> DebtPaymentItems
		{
			get; set;
		}
		
		OrderRestrictionState DVPropertyRestraintState
		{
			get; set;
		}
		
		IDVPropertyRestraint PropertyRestraint
		{
			get; set;
		}
		
		OrderRestrictionState ChildCustodyAndVisitationState
		{
			get; set;
		}
			}
	public partial class DV110 : IDV110
	{
		public OrderRestrictionState ConductChoiceState
		{
			get; set;
		}
		
		public IDVConductChoice ConductChoice
		{
			get; set;
		}
		
		public OrderRestrictionState StayAwayOrdersState
		{
			get; set;
		}
		
		public IDVStayAwayOrders StayAwayOrders
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
		
		public IDVAnimals AnimalsSection
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
		
		public ICollection<IDataItem> PropertyControlItems
		{
			get; set;
		}
		
		public OrderRestrictionState DebtPaymentState
		{
			get; set;
		}
		
		public ICollection<IDebtPaymentItem> DebtPaymentItems
		{
			get; set;
		}
		
		public OrderRestrictionState DVPropertyRestraintState
		{
			get; set;
		}
		
		public IDVPropertyRestraint PropertyRestraint
		{
			get; set;
		}
		
		public OrderRestrictionState ChildCustodyAndVisitationState
		{
			get; set;
		}
			}
	
			
	public partial interface IDV130
	{
		
		bool IsConductChoiceEnabled
		{
			get; set;
		}
		
		IDVConductChoice ConductChoice
		{
			get; set;
		}
		
		bool IsStayAwayOrdersEnabled
		{
			get; set;
		}
		
		IDVStayAwayOrders StayAwayOrders
		{
			get; set;
		}
		
		bool IsPOSProvidedToCourt
		{
			get; set;
		}
		
		bool IsMoveoutEnabled
		{
			get; set;
		}
		
		string MoveoutAddress
		{
			get; set;
		}
		
		bool IsRecordUnlawfulCommunicationsAllowed
		{
			get; set;
		}
		
		bool IsAnimalsEnabled
		{
			get; set;
		}
		
		IDVAnimals Animals
		{
			get; set;
		}
		
		IOtherOrders OtherOrders
		{
			get; set;
		}
		
		bool IsBattererIntervention
		{
			get; set;
		}
		
		bool IsNoGuns
		{
			get; set;
		}
		
		bool IsPropertyControlEnabled
		{
			get; set;
		}
		
		ICollection<IDataItem> PropertyControlItems
		{
			get; set;
		}
		
		bool IsDebtPaymentEnabled
		{
			get; set;
		}
		
		ICollection<IDebtPaymentItem> DebtPaymentItems
		{
			get; set;
		}
		
		bool IsPropertyRestraintEnabled
		{
			get; set;
		}
		
		IDVPropertyRestraint PropertyRestraint
		{
			get; set;
		}
		
		ICollection<IPaymentItem> Costs
		{
			get; set;
		}
		
		bool IsChildCustodyAndVisitationEnabled
		{
			get; set;
		}
			}
	public partial class DV130 : IDV130
	{
		public bool IsConductChoiceEnabled
		{
			get; set;
		}
		
		public IDVConductChoice ConductChoice
		{
			get; set;
		}
		
		public bool IsStayAwayOrdersEnabled
		{
			get; set;
		}
		
		public IDVStayAwayOrders StayAwayOrders
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
		
		public IDVAnimals Animals
		{
			get; set;
		}
		
		public IOtherOrders OtherOrders
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
		
		public ICollection<IDataItem> PropertyControlItems
		{
			get; set;
		}
		
		public bool IsDebtPaymentEnabled
		{
			get; set;
		}
		
		public ICollection<IDebtPaymentItem> DebtPaymentItems
		{
			get; set;
		}
		
		public bool IsPropertyRestraintEnabled
		{
			get; set;
		}
		
		public IDVPropertyRestraint PropertyRestraint
		{
			get; set;
		}
		
		public ICollection<IPaymentItem> Costs
		{
			get; set;
		}
		
		public bool IsChildCustodyAndVisitationEnabled
		{
			get; set;
		}
			}
	
			
	public partial interface IIsNoVisitationForParents
	{
		
		bool IsEnabled
		{
			get; set;
		}
		
		CustodyParent IsNoVisitationParent
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
			}
	public partial class IsNoVisitationForParents : IIsNoVisitationForParents
	{
		public bool IsEnabled
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
	
			
	public partial interface IVisitationSchedule
	{
		
		bool IsEnabled
		{
			get; set;
		}
		
		bool IsWeekendsAvailableForVisitation
		{
			get; set;
		}
		
		DateTime WeekendsStartingDate
		{
			get; set;
		}
		
		bool IsFirstWeekendAvailableForVisitation
		{
			get; set;
		}
		
		bool IsSecondWeekendAvailableForVisitation
		{
			get; set;
		}
		
		bool IsThirdWeekendAvailableForVisitation
		{
			get; set;
		}
		
		bool IsFourthWeekendAvailableForVisitation
		{
			get; set;
		}
		
		bool IsFifthWeekendAvailableForVisitation
		{
			get; set;
		}
		
		DayOfWeek FirstAvailableWeekendDay
		{
			get; set;
		}
		
		DateTime FirstAvailableWeekendTime
		{
			get; set;
		}
		
		DayOfWeek LastAvailableWeekendDay
		{
			get; set;
		}
		
		DateTime LastAvailableWeekendTime
		{
			get; set;
		}
		
		bool IsWeekdaysAvailableForVisitation
		{
			get; set;
		}
		
		DateTime WeekdaysStartingDate
		{
			get; set;
		}
		
		DayOfWeek FirstAvailableWeekdayDay
		{
			get; set;
		}
		
		DateTime FirstAvailableWeekdayTime
		{
			get; set;
		}
		
		DayOfWeek LastAvailableWeekdayDay
		{
			get; set;
		}
		
		DateTime LastAvailableWeekdayTime
		{
			get; set;
		}
		
		bool IsOtherVisitationAvilable
		{
			get; set;
		}
			}
	public partial class VisitationSchedule : IVisitationSchedule
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
	
			
	public partial interface IChildVisitation
	{
		
		string IsEnabled
		{
			get; set;
		}
		
		string IsNoVisitationForParents
		{
			get; set;
		}
		
		bool IsAttachedDocumentAvilable
		{
			get; set;
		}
		
		int AttachedDocumentPagesCount
		{
			get; set;
		}
		
		DateTime AttachedDocumentDate
		{
			get; set;
		}
		
		bool IsPartiesMustGoToMediation
		{
			get; set;
		}
		
		string MediationDescription
		{
			get; set;
		}
		
		CustodyParent VisitationGrantedParent
		{
			get; set;
		}
		
		string VisitationGrantedOtherParentDescription
		{
			get; set;
		}
		
		IVisitationSchedule VisitationSchedule
		{
			get; set;
		}
			}
	public partial class ChildVisitation : IChildVisitation
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
		
		public IVisitationSchedule VisitationSchedule
		{
			get; set;
		}
			}
	
			
	public partial interface ITransportation
	{
		
		string IsEnabled
		{
			get; set;
		}
		
		CustodyParent TransportationPickUpPerson
		{
			get; set;
		}
		
		string TransportationPickUpPersonOtherDescription
		{
			get; set;
		}
		
		string TransportationPickUpLocation
		{
			get; set;
		}
		
		CustodyParent TransportationDropOffPerson
		{
			get; set;
		}
		
		string TransportationDropOffPersonOtherDescription
		{
			get; set;
		}
		
		string TransportationDropOffLocation
		{
			get; set;
		}
			}
	public partial class Transportation : ITransportation
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
	
			
	public partial interface ITravelRestrict
	{
		
		string IsEnabled
		{
			get; set;
		}
		
		bool IsMomRestrained
		{
			get; set;
		}
		
		bool IsDadRestrained
		{
			get; set;
		}
		
		bool IsOtherRestrained
		{
			get; set;
		}
		
		string OtherRestrainedDescription
		{
			get; set;
		}
		
		bool IsUSEscapeDenied
		{
			get; set;
		}
		
		bool IsCAEscapeDenied
		{
			get; set;
		}
		
		bool IsOtherLocationsEscapeDenied
		{
			get; set;
		}
		
		string OtherLocationsDescription
		{
			get; set;
		}
			}
	public partial class TravelRestrict : ITravelRestrict
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
	
			
	public partial interface IExchangeAndRemoval
	{
		
		string IsEnabled
		{
			get; set;
		}
		
		ITransportation Transportation
		{
			get; set;
		}
		
		ITravelRestrict TravelRestrict
		{
			get; set;
		}
		
		bool IsChildAbductionRiskExist
		{
			get; set;
		}
		
		bool IsDV145Attached
		{
			get; set;
		}
		
		bool IsUSCountryOfHabitualResidence
		{
			get; set;
		}
		
		bool IsOtherCountryOfHabitualResidence
		{
			get; set;
		}
		
		string OtherCountryAsHabitualResidenceDescription
		{
			get; set;
		}
			}
	public partial class ExchangeAndRemoval : IExchangeAndRemoval
	{
		public string IsEnabled
		{
			get; set;
		}
		
		public ITransportation Transportation
		{
			get; set;
		}
		
		public ITravelRestrict TravelRestrict
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
	
			
	public partial interface IChildCustodyItem
	{
		
		long ChildId
		{
			get; set;
		}
		
		CustodyParent LegalCustodyParent
		{
			get; set;
		}
		
		CustodyParent PhysicalCustodyParent
		{
			get; set;
		}
			}
	public partial class ChildCustodyItem : IChildCustodyItem
	{
		public long ChildId
		{
			get; set;
		}
		
		public CustodyParent LegalCustodyParent
		{
			get; set;
		}
		
		public CustodyParent PhysicalCustodyParent
		{
			get; set;
		}
			}
	
			
	public partial interface IDV140
	{
		
		ICollection<IChildCustodyItem> ChildCustodyItems
		{
			get; set;
		}
		
		IChildVisitation ChildVisitation
		{
			get; set;
		}
		
		IExchangeAndRemoval ExchangeAndRemoval
		{
			get; set;
		}
		
		IOtherOrders OtherOrders
		{
			get; set;
		}
			}
	public partial class DV140 : IDV140
	{
		public ICollection<IChildCustodyItem> ChildCustodyItems
		{
			get; set;
		}
		
		public IChildVisitation ChildVisitation
		{
			get; set;
		}
		
		public IExchangeAndRemoval ExchangeAndRemoval
		{
			get; set;
		}
		
		public IOtherOrders OtherOrders
		{
			get; set;
		}
			}
	
			
	public partial interface IDV150
	{
		
		bool IsPartiesMustGoToMediation
		{
			get; set;
		}
		
		string MediationPlaceDescription
		{
			get; set;
		}
		
		bool IsVisitsSupervised
		{
			get; set;
		}
		
		CustodyParent SupervisedPerson
		{
			get; set;
		}
		
		string OtherVisitationPersonDescription
		{
			get; set;
		}
		
		bool IsExchangesOfChildrenAreSupervised
		{
			get; set;
		}
		
		bool IsAllDV140VisitSupervised
		{
			get; set;
		}
		
		byte SupervisedVisitsPerWeek
		{
			get; set;
		}
		
		byte SupervisedVisitsHours
		{
			get; set;
		}
		
		string SupervisedScheduleDescription
		{
			get; set;
		}
		
		bool OtherScheduleAttached
		{
			get; set;
		}
		
		string ProviderName
		{
			get; set;
		}
		
		string ProviderAddress
		{
			get; set;
		}
		
		string ProviderPhone
		{
			get; set;
		}
		
		SupervisionProviderType ProviderType
		{
			get; set;
		}
		
		bool IsMomPay
		{
			get; set;
		}
		
		decimal MomPayment
		{
			get; set;
		}
		
		bool IsDadPay
		{
			get; set;
		}
		
		decimal DadPayment
		{
			get; set;
		}
		
		bool IsOtherPay
		{
			get; set;
		}
		
		decimal OtherPayment
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
		
		DateTime? MomContactProviderDate
		{
			get; set;
		}
		
		DateTime? DadContactProviderDate
		{
			get; set;
		}
		
		string OtherContactProviderDescription
		{
			get; set;
		}
		
		string OtherOrdersDescription
		{
			get; set;
		}
			}
	public partial class DV150 : IDV150
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
	
			
	public partial interface ISuspiciousDoneThings
	{
		
		bool IsEnabled
		{
			get; set;
		}
		
		bool IsJobQuited
		{
			get; set;
		}
		
		bool IsBankAccountClosed
		{
			get; set;
		}
		
		bool IsAssetsLost
		{
			get; set;
		}
		
		bool IsHomeSold
		{
			get; set;
		}
		
		bool IsLeaseEnded
		{
			get; set;
		}
		
		bool IsDocumentsLost
		{
			get; set;
		}
		
		bool IsAppliedForDocuments
		{
			get; set;
		}
			}
	public partial class SuspiciousDoneThings : ISuspiciousDoneThings
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
	
			
	public partial interface INegativeHistory
	{
		
		bool IsEnabled
		{
			get; set;
		}
		
		bool IsDomesticViolence
		{
			get; set;
		}
		
		bool IsChildAbuse
		{
			get; set;
		}
		
		bool IsParentingMissing
		{
			get; set;
		}
		
		bool IsDeniedTalking
		{
			get; set;
		}
			}
	public partial class NegativeHistory : INegativeHistory
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
	
			
	public partial interface INecessaryTravelDocuments
	{
		
		bool IsEnabled
		{
			get; set;
		}
		
		bool IsTravelItineraryRequired
		{
			get; set;
		}
		
		bool IsCopiesOfAirlineTicketsRequired
		{
			get; set;
		}
		
		bool IsAddressesAndPhonesRequired
		{
			get; set;
		}
		
		bool IsOtherParentAirlineTicketRequired
		{
			get; set;
		}
		
		bool IsOtherExist
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
			}
	public partial class NecessaryTravelDocuments : INecessaryTravelDocuments
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
	
			
	public partial interface INotifyEmbassyInfo
	{
		
		bool IsEnabled
		{
			get; set;
		}
		
		string CountryName
		{
			get; set;
		}
		
		int ProvideProofDays
		{
			get; set;
		}
			}
	public partial class NotifyEmbassyInfo : INotifyEmbassyInfo
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
	
			
	public partial interface IDV145
	{
		
		bool IsPastROViolations
		{
			get; set;
		}
		
		bool IsNoTiesWithCalifornia
		{
			get; set;
		}
		
		ISuspiciousDoneThings SuspiciousDoneThings
		{
			get; set;
		}
		
		INegativeHistory NegativeHistory
		{
			get; set;
		}
		
		bool HasCriminalRecord
		{
			get; set;
		}
		
		bool HasOtherLocationsTies
		{
			get; set;
		}
		
		bool IsPostBondRequered
		{
			get; set;
		}
		
		decimal BondAmount
		{
			get; set;
		}
		
		bool IsMoveWithoutPermissionDenied
		{
			get; set;
		}
		
		RestrainedLocations MoveDenaiedLocations
		{
			get; set;
		}
		
		string OtherMoveDenaiedLocationsDescription
		{
			get; set;
		}
		
		bool IsTravelWithoutPermissionDenied
		{
			get; set;
		}
		
		RestrainedLocations TravelDenaiedLocations
		{
			get; set;
		}
		
		string OtherTravelDenaiedLocationsDescription
		{
			get; set;
		}
		
		string OtherParentToGivePermission
		{
			get; set;
		}
		
		bool IsNotifyOtherStateRequired
		{
			get; set;
		}
		
		USAState OtherState
		{
			get; set;
		}
		
		bool TravelDocumentsApplyDenied
		{
			get; set;
		}
		
		string TurnedInDocuments
		{
			get; set;
		}
		
		INecessaryTravelDocuments NecessaryTravelDocuments
		{
			get; set;
		}
		
		bool IsNotifyForeignEmbassyRequired
		{
			get; set;
		}
		
		bool IsForeignCustodyCourtOrderRequired
		{
			get; set;
		}
		
		bool IsEnforcingCourtOrderRequired
		{
			get; set;
		}
		
		string EnforcingAgencyName
		{
			get; set;
		}
		
		IOtherOrders OtherPermissionsOrder
		{
			get; set;
		}
		
		INotifyEmbassyInfo NotifyEmbassyInfo
		{
			get; set;
		}
			}
	public partial class DV145 : IDV145
	{
		public bool IsPastROViolations
		{
			get; set;
		}
		
		public bool IsNoTiesWithCalifornia
		{
			get; set;
		}
		
		public ISuspiciousDoneThings SuspiciousDoneThings
		{
			get; set;
		}
		
		public INegativeHistory NegativeHistory
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
		
		public INecessaryTravelDocuments NecessaryTravelDocuments
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
		
		public IOtherOrders OtherPermissionsOrder
		{
			get; set;
		}
		
		public INotifyEmbassyInfo NotifyEmbassyInfo
		{
			get; set;
		}
			}
	
			
	public partial interface IIncomeAndDeductions
	{
		
		Designation Designation
		{
			get; set;
		}
		
		decimal TotalGrossMonthlyIncome
		{
			get; set;
		}
		
		decimal TotalMonthlyDeductions
		{
			get; set;
		}
		
		decimal TotalHardshipDeductions
		{
			get; set;
		}
		
		decimal NetMonthlyDisposableIncome
		{
			get; set;
		}
			}
	public partial class IncomeAndDeductions : IIncomeAndDeductions
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
	
			
	public partial interface IJudgmentForSpousalSupport
	{
		
		bool IsModifiesJudgmentOrder
		{
			get; set;
		}
		
		DateTime ModifingJudgmentOrderDate
		{
			get; set;
		}
		
		bool WerePartiesMarried
		{
			get; set;
		}
		
		int MarriedLifeYears
		{
			get; set;
		}
		
		int MarriedLifeMonths
		{
			get; set;
		}
		
		bool WerePartiesPartners
		{
			get; set;
		}
		
		int PartnershipLifeYears
		{
			get; set;
		}
		
		int PartnershipLifeMonths
		{
			get; set;
		}
		
		bool ArePartiesBothSelfSupported
		{
			get; set;
		}
		
		bool IsMaritalStandardOfLivingEnabled
		{
			get; set;
		}
		
		string MaritalStandardOfLivingDescription
		{
			get; set;
		}
		
		bool IsStandartOfLivingAttached
		{
			get; set;
		}
		
		bool IsSupportReserved
		{
			get; set;
		}
		
		bool IsSupportReservedForPetitioner
		{
			get; set;
		}
		
		bool IsSupportReservedForRespondent
		{
			get; set;
		}
		
		bool IsSupportTerminated
		{
			get; set;
		}
		
		bool IsSupportTerminatedForPetitioner
		{
			get; set;
		}
		
		bool IsSupportTerminatedForRespondent
		{
			get; set;
		}
			}
	public partial class JudgmentForSpousalSupport : IJudgmentForSpousalSupport
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
	
			
	public partial interface ICourtOrders
	{
		
		Designation SupportToBePaidFrom
		{
			get; set;
		}
		
		Designation SupportToBePaidTo
		{
			get; set;
		}
		
		decimal SupportAmount
		{
			get; set;
		}
		
		DateTime SupportFromDate
		{
			get; set;
		}
		
		bool IsPayOnTheDayOfMonth
		{
			get; set;
		}
		
		byte DayOfMonth
		{
			get; set;
		}
		
		bool IsOtherPaymentScheme
		{
			get; set;
		}
		
		string OtherPaymentSchemeDescription
		{
			get; set;
		}
		
		DateTime SupportUntilDate
		{
			get; set;
		}
		
		bool IsTemporarySupportEnabled
		{
			get; set;
		}
		
		bool IsSpousalSupportEnabled
		{
			get; set;
		}
		
		bool IsFamilySupportEnabled
		{
			get; set;
		}
		
		bool IsPartnerSupportEnabled
		{
			get; set;
		}
		
		bool IsSupportConditionsEnabled
		{
			get; set;
		}
		
		bool IsMustInformAboutEmploymentChanges
		{
			get; set;
		}
		
		bool IsOrderForFamilySupport
		{
			get; set;
		}
		
		string IsSelfSupportEffortsEnabled
		{
			get; set;
		}
		
		Designation SelfSupportEffortedPerson
		{
			get; set;
		}
		
		bool IsEarningAssignmentStatementEnabled
		{
			get; set;
		}
		
		bool IsServiceStayedPeriodProvided
		{
			get; set;
		}
		
		int ServiceStayedPeriod
		{
			get; set;
		}
		
		bool IsNoticeAboutDurationEnabled
		{
			get; set;
		}
		
		bool IsOtherOrdersEnabled
		{
			get; set;
		}
		
		string OtherOrdersDescription
		{
			get; set;
		}
			}
	public partial class CourtOrders : ICourtOrders
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
		
		public bool IsOrderForFamilySupport
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
	
			
	public partial interface IFL343
	{
		
		bool IsAttachedToFOAH
		{
			get; set;
		}
		
		bool IsAttachedToDVRO
		{
			get; set;
		}
		
		bool IsAttachedToJudgment
		{
			get; set;
		}
		
		bool IsAttachedToStipulation
		{
			get; set;
		}
		
		bool IsAttachedToOther
		{
			get; set;
		}
		
		string OtherAttachedToDescription
		{
			get; set;
		}
		
		ICollection<IIncomeAndDeductions> IncomeAndDeductions
		{
			get; set;
		}
		
		bool IsComputerPrintOutAttach
		{
			get; set;
		}
		
		IJudgmentForSpousalSupport JudgmentForSpousalSupport
		{
			get; set;
		}
		
		ICourtOrders CourtOrders
		{
			get; set;
		}
			}
	public partial class FL343 : IFL343
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
		
		public ICollection<IIncomeAndDeductions> IncomeAndDeductions
		{
			get; set;
		}
		
		public bool IsComputerPrintOutAttach
		{
			get; set;
		}
		
		public IJudgmentForSpousalSupport JudgmentForSpousalSupport
		{
			get; set;
		}
		
		public ICourtOrders CourtOrders
		{
			get; set;
		}
			}
	
			
	public partial interface IEAConductChoice
	{
		
		bool IsNoAbuse
		{
			get; set;
		}
		
		bool IsNoContact
		{
			get; set;
		}
		
		bool IsDontTryToLocate
		{
			get; set;
		}
		
		bool IsInvolveOtherProtected
		{
			get; set;
		}
		
		bool IsInvolveOther
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
		
		bool IsOtherAttached
		{
			get; set;
		}
			}
	public partial class EAConductChoice : IEAConductChoice
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
	
			
	public partial interface IEAStayAwayOrders
	{
		
		bool IsStayAwayFromPerson
		{
			get; set;
		}
		
		bool IsStayAwayFromHome
		{
			get; set;
		}
		
		bool IsStayAwayFromVehicle
		{
			get; set;
		}
		
		bool IsStayAwayFromWork
		{
			get; set;
		}
		
		bool IsStayAwayFromOtherProtected
		{
			get; set;
		}
		
		bool IsStayAwayFromOther
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
		
		int StayAwayDistance
		{
			get; set;
		}
			}
	public partial class EAStayAwayOrders : IEAStayAwayOrders
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
	
			
	public partial interface IFirearms
	{
		
		bool IsNoGuns
		{
			get; set;
		}
		
		bool IsCourtHasFirearmsInformation
		{
			get; set;
		}
			}
	public partial class Firearms : IFirearms
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
	
			
	public partial interface IEA110
	{
		
		OrderRestrictionState EAConductChoiceState
		{
			get; set;
		}
		
		IEAConductChoice EAConductChoice
		{
			get; set;
		}
		
		OrderRestrictionState EAStayAwayOrdersState
		{
			get; set;
		}
		
		IEAStayAwayOrders EAStayAwayOrders
		{
			get; set;
		}
		
		OrderRestrictionState MoveoutState
		{
			get; set;
		}
		
		string MoveoutAddress
		{
			get; set;
		}
		
		ICAPROSEntry CAPROSEntry
		{
			get; set;
		}
		
		INoServiceFee NoServiceFee
		{
			get; set;
		}
		
		bool IsOtherOrdersAttached
		{
			get; set;
		}
		
		string OtherOrderDetail
		{
			get; set;
		}
		
		bool IsFirearmsGranted
		{
			get; set;
		}
		
		IFirearms Firearms
		{
			get; set;
		}
		
		bool IsFinancialAbuseInvolved
		{
			get; set;
		}
			}
	public partial class EA110 : IEA110
	{
		public OrderRestrictionState EAConductChoiceState
		{
			get; set;
		}
		
		public IEAConductChoice EAConductChoice
		{
			get; set;
		}
		
		public OrderRestrictionState EAStayAwayOrdersState
		{
			get; set;
		}
		
		public IEAStayAwayOrders EAStayAwayOrders
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
		
		public ICAPROSEntry CAPROSEntry
		{
			get; set;
		}
		
		public INoServiceFee NoServiceFee
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
		
		public IFirearms Firearms
		{
			get; set;
		}
		
		public bool IsFinancialAbuseInvolved
		{
			get; set;
		}
			}
	
			
	public partial interface IEA130
	{
		
		bool IsEAConductChoiceEnabled
		{
			get; set;
		}
		
		IEAConductChoice EAConductChoice
		{
			get; set;
		}
		
		bool EAStayAwayOrdersEnabled
		{
			get; set;
		}
		
		IEAStayAwayOrders EAStayAwayOrders
		{
			get; set;
		}
		
		bool IsMoveoutEnabled
		{
			get; set;
		}
		
		string MoveoutAddress
		{
			get; set;
		}
		
		ICAPROSEntry CAPROSEntrySection
		{
			get; set;
		}
		
		INoServiceFee NoServiceFeeSection
		{
			get; set;
		}
		
		bool IsOtherOrdersAttached
		{
			get; set;
		}
		
		string OtherOrderDetail
		{
			get; set;
		}
		
		bool IsNoGuns
		{
			get; set;
		}
		
		IFirearms Firearms
		{
			get; set;
		}
		
		bool IsFinancialAbuseInvolved
		{
			get; set;
		}
			}
	public partial class EA130 : IEA130
	{
		public bool IsEAConductChoiceEnabled
		{
			get; set;
		}
		
		public IEAConductChoice EAConductChoice
		{
			get; set;
		}
		
		public bool EAStayAwayOrdersEnabled
		{
			get; set;
		}
		
		public IEAStayAwayOrders EAStayAwayOrders
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
		
		public ICAPROSEntry CAPROSEntrySection
		{
			get; set;
		}
		
		public INoServiceFee NoServiceFeeSection
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
		
		public IFirearms Firearms
		{
			get; set;
		}
		
		public bool IsFinancialAbuseInvolved
		{
			get; set;
		}
			}
	
			
	public partial interface IDebtItem
	{
		
		decimal TotalDebt
		{
			get; set;
		}
		
		decimal AmountOfPayments
		{
			get; set;
		}
		
		Designation PayTo
		{
			get; set;
		}
		
		Designation PaidBy
		{
			get; set;
		}
			}
	public partial class DebtItem : IDebtItem
	{
		public decimal TotalDebt
		{
			get; set;
		}
		
		public decimal AmountOfPayments
		{
			get; set;
		}
		
		public Designation PayTo
		{
			get; set;
		}
		
		public Designation PaidBy
		{
			get; set;
		}
			}
	
			
	public partial interface IFL344
	{
		
		bool IsRestrainedOrdersEnabled
		{
			get; set;
		}
		
		Designation RestrainedPerson
		{
			get; set;
		}
		
		bool IsNoDisposing
		{
			get; set;
		}
		
		bool IsMustNotify
		{
			get; set;
		}
		
		bool IsNoChangeCoverages
		{
			get; set;
		}
		
		bool IsNoDebt
		{
			get; set;
		}
		
		bool IsPropertyAndPossesionEnabled
		{
			get; set;
		}
		
		ICollection<IDataItem> PropertyAndPossetion
		{
			get; set;
		}
		
		bool IsDebtOrdersEnabled
		{
			get; set;
		}
		
		ICollection<IDebtItem> Debts
		{
			get; set;
		}
		
		bool IsOtherPropertyAttached
		{
			get; set;
		}
		
		bool AreThisTemporaryOrders
		{
			get; set;
		}
		
		IOtherOrders OtherOrders
		{
			get; set;
		}
			}
	public partial class FL344 : IFL344
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
		
		public ICollection<IDataItem> PropertyAndPossetion
		{
			get; set;
		}
		
		public bool IsDebtOrdersEnabled
		{
			get; set;
		}
		
		public ICollection<IDebtItem> Debts
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
		
		public IOtherOrders OtherOrders
		{
			get; set;
		}
			}
	
			
	public partial interface ITimeShare
	{
		
		byte ChildrenNumber
		{
			get; set;
		}
		
		byte TimeSpentWithPetitioner
		{
			get; set;
		}
		
		byte TimeSpentWithRespondent
		{
			get; set;
		}
		
		byte TimeSpentWithOther
		{
			get; set;
		}
			}
	public partial class TimeShare : ITimeShare
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
	
			
	public partial interface ILowIncomeAdjustment
	{
		
		bool IsLowIncomeAdjustmentApplies
		{
			get; set;
		}
		
		string DoesNotApplyReasonDescription
		{
			get; set;
		}
			}
	public partial class LowIncomeAdjustment : ILowIncomeAdjustment
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
	
			
	public partial interface IAdditionalChildSupportItem
	{
		
		int Percents
		{
			get; set;
		}
		
		decimal Amount
		{
			get; set;
		}
			}
	public partial class AdditionalChildSupportItem : IAdditionalChildSupportItem
	{
		public int Percents
		{
			get; set;
		}
		
		public decimal Amount
		{
			get; set;
		}
			}
	
			
	public partial interface IAdditionalPayment
	{
		
		bool IsPetitionerMustPay
		{
			get; set;
		}
		
		IAdditionalChildSupportItem PetitionerMustPay
		{
			get; set;
		}
		
		bool IsRespondentMustPay
		{
			get; set;
		}
		
		IAdditionalChildSupportItem RespondentMustPay
		{
			get; set;
		}
		
		bool IsOtherMustPay
		{
			get; set;
		}
		
		IAdditionalChildSupportItem OtherMustPay
		{
			get; set;
		}
		
		string IsCostsToBePaidEnabled
		{
			get; set;
		}
		
		string CostsToBePaid
		{
			get; set;
		}
			}
	public partial class AdditionalPayment : IAdditionalPayment
	{
		public bool IsPetitionerMustPay
		{
			get; set;
		}
		
		public IAdditionalChildSupportItem PetitionerMustPay
		{
			get; set;
		}
		
		public bool IsRespondentMustPay
		{
			get; set;
		}
		
		public IAdditionalChildSupportItem RespondentMustPay
		{
			get; set;
		}
		
		public bool IsOtherMustPay
		{
			get; set;
		}
		
		public IAdditionalChildSupportItem OtherMustPay
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
	
			
	public partial interface IChildSupportItem
	{
		
		long ChildId
		{
			get; set;
		}
		
		string PaidToPersonName
		{
			get; set;
		}
		
		decimal MonthlyAmount
		{
			get; set;
		}
			}
	public partial class ChildSupportItem : IChildSupportItem
	{
		public long ChildId
		{
			get; set;
		}
		
		public string PaidToPersonName
		{
			get; set;
		}
		
		public decimal MonthlyAmount
		{
			get; set;
		}
			}
	
			
	public partial interface IChildSupport
	{
		
		ICollection<IChildSupportItem> ChildSupportItems
		{
			get; set;
		}
		
		PayableSchedule PayableSchedule
		{
			get; set;
		}
		
		string OtherPayableScheduleDescription
		{
			get; set;
		}
		
		DateTime CommencingDate
		{
			get; set;
		}
		
		Designation PaidByPerson
		{
			get; set;
		}
		
		Designation PaidToPerson
		{
			get; set;
		}
		
		bool IsMandatoryAdditionalChildSupportEnabled
		{
			get; set;
		}
		
		bool IsChildCareRelatedToEmploymentEnabled
		{
			get; set;
		}
		
		IAdditionalPayment ChildCareRelatedToEmployment
		{
			get; set;
		}
		
		bool IsReasonableUninsuredHealthCareEnabled
		{
			get; set;
		}
		
		IAdditionalPayment ReasonableUninsuredHealthCare
		{
			get; set;
		}
		
		bool IsAdditionalChildSupportEnabled
		{
			get; set;
		}
		
		bool IsEducationalCostsEnabled
		{
			get; set;
		}
		
		IAdditionalPayment EducationalCosts
		{
			get; set;
		}
		
		bool IsTravelExpensesEnabled
		{
			get; set;
		}
		
		IAdditionalPayment TravelExpenses
		{
			get; set;
		}
		
		bool IsNonGuidlineOrder
		{
			get; set;
		}
		
		decimal TotalChildSupportPerMonth
		{
			get; set;
		}
		
		decimal TotalBaseChildPerMonth
		{
			get; set;
		}
		
		decimal AdditionalChildPerMonth
		{
			get; set;
		}
			}
	public partial class ChildSupport : IChildSupport
	{
		public ICollection<IChildSupportItem> ChildSupportItems
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
		
		public bool IsMandatoryAdditionalChildSupportEnabled
		{
			get; set;
		}
		
		public bool IsChildCareRelatedToEmploymentEnabled
		{
			get; set;
		}
		
		public IAdditionalPayment ChildCareRelatedToEmployment
		{
			get; set;
		}
		
		public bool IsReasonableUninsuredHealthCareEnabled
		{
			get; set;
		}
		
		public IAdditionalPayment ReasonableUninsuredHealthCare
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
		
		public IAdditionalPayment EducationalCosts
		{
			get; set;
		}
		
		public bool IsTravelExpensesEnabled
		{
			get; set;
		}
		
		public IAdditionalPayment TravelExpenses
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
	
			
	public partial interface IMultyChoice
	{
		
		bool IsPetitonerSelected
		{
			get; set;
		}
		
		bool IsRespondentSelected
		{
			get; set;
		}
		
		bool IsOtherSelected
		{
			get; set;
		}
			}
	public partial class MultyChoice : IMultyChoice
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
	
			
	public partial interface IHealthCare
	{
		
		IMultyChoice HealthInsuranceMaintained
		{
			get; set;
		}
		
		bool IsHealthInsuranceIsNotAvailableEnabled
		{
			get; set;
		}
		
		IMultyChoice HealthInsuranceIsNotAvailable
		{
			get; set;
		}
		
		bool IsReimbursementCanBeAssigned
		{
			get; set;
		}
			}
	public partial class HealthCare : IHealthCare
	{
		public IMultyChoice HealthInsuranceMaintained
		{
			get; set;
		}
		
		public bool IsHealthInsuranceIsNotAvailableEnabled
		{
			get; set;
		}
		
		public IMultyChoice HealthInsuranceIsNotAvailable
		{
			get; set;
		}
		
		public bool IsReimbursementCanBeAssigned
		{
			get; set;
		}
			}
	
			
	public partial interface IHardshipItem
	{
		
		Hardship Hardship
		{
			get; set;
		}
		
		decimal PlantiffPaymentAmount
		{
			get; set;
		}
		
		decimal RespondentPaymentAmount
		{
			get; set;
		}
		
		decimal OtherPaymentAmount
		{
			get; set;
		}
		
		DateTime PaymentEndDate
		{
			get; set;
		}
			}
	public partial class HardshipItem : IHardshipItem
	{
		public Hardship Hardship
		{
			get; set;
		}
		
		public decimal PlantiffPaymentAmount
		{
			get; set;
		}
		
		public decimal RespondentPaymentAmount
		{
			get; set;
		}
		
		public decimal OtherPaymentAmount
		{
			get; set;
		}
		
		public DateTime PaymentEndDate
		{
			get; set;
		}
			}
	
			
	public partial interface IIncomeItem
	{
		
		Designation ParentRole
		{
			get; set;
		}
		
		decimal GrossMonthlyIncome
		{
			get; set;
		}
		
		decimal NetMonthlyIncome
		{
			get; set;
		}
		
		decimal ImputedMonthlyIncome
		{
			get; set;
		}
		
		decimal ImputedYearIncome
		{
			get; set;
		}
		
		bool IsRecievedByTANF
		{
			get; set;
		}
			}
	public partial class IncomeItem : IIncomeItem
	{
		public Designation ParentRole
		{
			get; set;
		}
		
		public decimal GrossMonthlyIncome
		{
			get; set;
		}
		
		public decimal NetMonthlyIncome
		{
			get; set;
		}
		
		public decimal ImputedMonthlyIncome
		{
			get; set;
		}
		
		public decimal ImputedYearIncome
		{
			get; set;
		}
		
		public bool IsRecievedByTANF
		{
			get; set;
		}
			}
	
			
	public partial interface IFL342
	{
		
		bool IsAttachedToFOAH
		{
			get; set;
		}
		
		bool IsAttachedToDVRO
		{
			get; set;
		}
		
		bool IsAttachedToJudjement
		{
			get; set;
		}
		
		bool IsAttachedToOther
		{
			get; set;
		}
		
		string OtherDescription
		{
			get; set;
		}
		
		bool IsPrintoutAttached
		{
			get; set;
		}
		
		bool IsIncomeEnabled
		{
			get; set;
		}
		
		ICollection<IIncomeItem> Incomes
		{
			get; set;
		}
		
		bool IsTimeShareEnabled
		{
			get; set;
		}
		
		TimeShare TimeShare
		{
			get; set;
		}
		
		bool IsHardshipsEnabled
		{
			get; set;
		}
		
		ICollection<IHardshipItem> HardshipItems
		{
			get; set;
		}
		
		bool IsLowIncomeAdjustmentEnabled
		{
			get; set;
		}
		
		ILowIncomeAdjustment LowIncomeAdjustment
		{
			get; set;
		}
		
		bool IsChildSupportEnabled
		{
			get; set;
		}
		
		IChildSupport ChildSupport
		{
			get; set;
		}
		
		bool IsEmploymentSearchEnabled
		{
			get; set;
		}
		
		IMultyChoice EmploymentSearch
		{
			get; set;
		}
		
		IHealthCare HealthCare
		{
			get; set;
		}
		
		string OthersDescription
		{
			get; set;
		}
			}
	public partial class FL342 : IFL342
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
		
		public ICollection<IIncomeItem> Incomes
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
		
		public ICollection<IHardshipItem> HardshipItems
		{
			get; set;
		}
		
		public bool IsLowIncomeAdjustmentEnabled
		{
			get; set;
		}
		
		public ILowIncomeAdjustment LowIncomeAdjustment
		{
			get; set;
		}
		
		public bool IsChildSupportEnabled
		{
			get; set;
		}
		
		public IChildSupport ChildSupport
		{
			get; set;
		}
		
		public bool IsEmploymentSearchEnabled
		{
			get; set;
		}
		
		public IMultyChoice EmploymentSearch
		{
			get; set;
		}
		
		public IHealthCare HealthCare
		{
			get; set;
		}
		
		public string OthersDescription
		{
			get; set;
		}
			}
	
			
	public partial interface IFL341
	{
		
		Designation RestrictedPerson
		{
			get; set;
		}
		
		bool IsAbductionEnabled
		{
			get; set;
		}
		
		bool IsSexualAbuseEnabled
		{
			get; set;
		}
		
		bool IsPhysicalAbuseEnabled
		{
			get; set;
		}
		
		bool IsDomesticViolenceEnabled
		{
			get; set;
		}
		
		bool IsDrugAbuseEnabled
		{
			get; set;
		}
		
		bool IsAlcoholAbuseEnabled
		{
			get; set;
		}
		
		bool IsNeglectEnebled
		{
			get; set;
		}
		
		bool IsOtherEnabled
		{
			get; set;
		}
		
		string OtherDescription1
		{
			get; set;
		}
		
		string OtherDescription2
		{
			get; set;
		}
		
		bool IsPetitionerSupervised
		{
			get; set;
		}
		
		bool IsRespondentSupervised
		{
			get; set;
		}
			}
	public partial class FL341 : IFL341
	{
		public Designation RestrictedPerson
		{
			get; set;
		}
		
		public bool IsAbductionEnabled
		{
			get; set;
		}
		
		public bool IsSexualAbuseEnabled
		{
			get; set;
		}
		
		public bool IsPhysicalAbuseEnabled
		{
			get; set;
		}
		
		public bool IsDomesticViolenceEnabled
		{
			get; set;
		}
		
		public bool IsDrugAbuseEnabled
		{
			get; set;
		}
		
		public bool IsAlcoholAbuseEnabled
		{
			get; set;
		}
		
		public bool IsNeglectEnebled
		{
			get; set;
		}
		
		public bool IsOtherEnabled
		{
			get; set;
		}
		
		public string OtherDescription1
		{
			get; set;
		}
		
		public string OtherDescription2
		{
			get; set;
		}
		
		public bool IsPetitionerSupervised
		{
			get; set;
		}
		
		public bool IsRespondentSupervised
		{
			get; set;
		}
			}
	
			
	public partial interface IFL340
	{
			}
	public partial class FL340 : IFL340
	{	}
	
}

