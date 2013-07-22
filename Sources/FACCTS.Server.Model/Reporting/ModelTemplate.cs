using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using FACCTS.Server.Model.Reporting.Entities;
using FACCTS.Server.Model.DataModel;
using System.Collections.Generic;

namespace FACCTS.Server.Model.OrderModels
{
			
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
	
			
	public partial class DV130ConductChoice
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
		
		public bool IsExceptionsExist
		{
			get; set;
		}
				
	}
	
			
	public partial class DV130StayAwayOrders
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
	
			
	public partial class DV130Moveout
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public string MoveoutAddress
		{
			get; set;
		}
				
	}
	
			
	public partial class DV130Animals
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public int StayAwayAnimalsDistance
		{
			get; set;
		}
		
		public string AnimalsDescription
		{
			get; set;
		}
				
	}
	
			
	public partial class DV130OtherOrders
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
	
			
	public partial class DV130DebtPayment
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public List<DebtPaymentItem> DebtPaymentItems
		{
			get; set;
		}
				
	}
	
			
	public partial class DV130PropertyControl
	{
		public bool IsEnabled
		{
			get; set;
		}
		
		public List<DataItem> PropertyControl
		{
			get; set;
		}
				
	}
	
			
	public partial class DV130PropertyRestraint
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
	
			
	public partial class DV130
	{
		public DV130ConductChoice DV130ConductChoiceSection
		{
			get; set;
		}
		
		public DV130StayAwayOrders DV130StayAwayOrdersSection
		{
			get; set;
		}
		
		public bool IsPOSProvidedToCourt
		{
			get; set;
		}
		
		public DV130Moveout DV130MoveoutSection
		{
			get; set;
		}
		
		public bool IsRecordUnlawfulCommunicationsAllowed
		{
			get; set;
		}
		
		public DV130Animals DV130AnimalsSection
		{
			get; set;
		}
		
		public DV130OtherOrders DV130OtherOrdersSection
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
		
		public DV130PropertyControl DV130PropertyControlSection
		{
			get; set;
		}
		
		public DV130DebtPayment DV130DebtPaymentSection
		{
			get; set;
		}
		
		public DV130PropertyRestraint DV130PropertyRestraintSection
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
		
		public bool IsNoVisitationForMom
		{
			get; set;
		}
		
		public bool IsNoVisitationForDad
		{
			get; set;
		}
		
		public bool IsNoVisitationForOther
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
		
		public string MedeationDescription
		{
			get; set;
		}
		
		public VisitationSchedule VisitationScheduleSection
		{
			get; set;
		}
				
	}
	
			
	public partial class DV140
	{
		public ChildVisitation ChildVisitationSection
		{
			get; set;
		}
				
	}
	
}

