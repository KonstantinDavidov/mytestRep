

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
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private bool _isNoAbuse;
		public bool IsNoAbuse
		{
			get{return _isNoAbuse;}
			set
			{
				_isNoAbuse = value;

			}
		}
		
		private bool _isNoContact;
		public bool IsNoContact
		{
			get{return _isNoContact;}
			set
			{
				_isNoContact = value;

			}
		}
		
		private bool _isDontTryToLocate;
		public bool IsDontTryToLocate
		{
			get{return _isDontTryToLocate;}
			set
			{
				_isDontTryToLocate = value;

			}
		}
		
		private bool _isInvolveOtherProtected;
		public bool IsInvolveOtherProtected
		{
			get{return _isInvolveOtherProtected;}
			set
			{
				_isInvolveOtherProtected = value;

			}
		}
		
		private bool _isInvolveOther;
		public bool IsInvolveOther
		{
			get{return _isInvolveOther;}
			set
			{
				_isInvolveOther = value;

			}
		}
		
		private string _otherDescription;
		public string OtherDescription
		{
			get{return _otherDescription;}
			set
			{
				_otherDescription = value;

			}
		}
		
		private bool _isOtherAttached;
		public bool IsOtherAttached
		{
			get{return _isOtherAttached;}
			set
			{
				_isOtherAttached = value;

			}
		}
				
	}
	
			
	public partial class CH130StayAwayOrders
	{
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private bool _isStayAwayFromPerson;
		public bool IsStayAwayFromPerson
		{
			get{return _isStayAwayFromPerson;}
			set
			{
				_isStayAwayFromPerson = value;

			}
		}
		
		private bool _isStayAwayFromHome;
		public bool IsStayAwayFromHome
		{
			get{return _isStayAwayFromHome;}
			set
			{
				_isStayAwayFromHome = value;

			}
		}
		
		private bool _isStayAwayFromVehicle;
		public bool IsStayAwayFromVehicle
		{
			get{return _isStayAwayFromVehicle;}
			set
			{
				_isStayAwayFromVehicle = value;

			}
		}
		
		private bool _isStayAwayFromChildCare;
		public bool IsStayAwayFromChildCare
		{
			get{return _isStayAwayFromChildCare;}
			set
			{
				_isStayAwayFromChildCare = value;

			}
		}
		
		private bool _isStayAwayFromChildSchool;
		public bool IsStayAwayFromChildSchool
		{
			get{return _isStayAwayFromChildSchool;}
			set
			{
				_isStayAwayFromChildSchool = value;

			}
		}
		
		private bool _isStayAwayFromWork;
		public bool IsStayAwayFromWork
		{
			get{return _isStayAwayFromWork;}
			set
			{
				_isStayAwayFromWork = value;

			}
		}
		
		private bool _isStayAwayFromOtherProtected;
		public bool IsStayAwayFromOtherProtected
		{
			get{return _isStayAwayFromOtherProtected;}
			set
			{
				_isStayAwayFromOtherProtected = value;

			}
		}
		
		private bool _isStayAwayFromOther;
		public bool IsStayAwayFromOther
		{
			get{return _isStayAwayFromOther;}
			set
			{
				_isStayAwayFromOther = value;

			}
		}
		
		private bool _isAttachOther;
		public bool IsAttachOther
		{
			get{return _isAttachOther;}
			set
			{
				_isAttachOther = value;

			}
		}
		
		private string _otherDescription;
		public string OtherDescription
		{
			get{return _otherDescription;}
			set
			{
				_otherDescription = value;

			}
		}
		
		private int _stayAwayDistance;
		public int StayAwayDistance
		{
			get{return _stayAwayDistance;}
			set
			{
				_stayAwayDistance = value;

			}
		}
				
	}
	
			
	public partial class CH130
	{
		private long _caseHistoryId;
		public long CaseHistoryId
		{
			get{return _caseHistoryId;}
			set
			{
				_caseHistoryId = value;

			}
		}
		
		private CH130ConductChoice _conductSection;
		public CH130ConductChoice ConductSection
		{
			get{return _conductSection;}
			set
			{
				_conductSection = value;

			}
		}
		
		private CH130StayAwayOrders _stayAwayOrdersSection;
		public CH130StayAwayOrders StayAwayOrdersSection
		{
			get{return _stayAwayOrdersSection;}
			set
			{
				_stayAwayOrdersSection = value;

			}
		}
		
		private bool _isNoGuns;
		public bool IsNoGuns
		{
			get{return _isNoGuns;}
			set
			{
				_isNoGuns = value;

			}
		}
		
		private CAPROSEntry _cAPROSEntrySection;
		public CAPROSEntry CAPROSEntrySection
		{
			get{return _cAPROSEntrySection;}
			set
			{
				_cAPROSEntrySection = value;

			}
		}
		
		private NoServiceFee _noServiceFeeSection;
		public NoServiceFee NoServiceFeeSection
		{
			get{return _noServiceFeeSection;}
			set
			{
				_noServiceFeeSection = value;

			}
		}
		
		private bool _isExpire;
		public bool IsExpire
		{
			get{return _isExpire;}
			set
			{
				_isExpire = value;

			}
		}
		
		private DateTime? _ordersEndDate;
		public DateTime? OrdersEndDate
		{
			get{return _ordersEndDate;}
			set
			{
				_ordersEndDate = value;

			}
		}
		
		private DateTime? _ordersEndTime;
		public DateTime? OrdersEndTime
		{
			get{return _ordersEndTime;}
			set
			{
				_ordersEndTime = value;

			}
		}
		
		private bool? _isPOSGeneral;
		public bool? IsPOSGeneral
		{
			get{return _isPOSGeneral;}
			set
			{
				_isPOSGeneral = value;

			}
		}
		
		private LawersFeeAndCourtCosts _lawersFeeAndCourtCostsSection;
		public LawersFeeAndCourtCosts LawersFeeAndCourtCostsSection
		{
			get{return _lawersFeeAndCourtCostsSection;}
			set
			{
				_lawersFeeAndCourtCostsSection = value;

			}
		}
		
		private bool _isOtherOrdersAttached;
		public bool IsOtherOrdersAttached
		{
			get{return _isOtherOrdersAttached;}
			set
			{
				_isOtherOrdersAttached = value;

			}
		}
		
		private string _otherOrderDetail;
		public string OtherOrderDetail
		{
			get{return _otherOrderDetail;}
			set
			{
				_otherOrderDetail = value;

			}
		}
				
	}
	
			
	public partial class CH110ConductChoice
	{
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private bool _isNoAbuse;
		public bool IsNoAbuse
		{
			get{return _isNoAbuse;}
			set
			{
				_isNoAbuse = value;

			}
		}
		
		private bool _isNoContact;
		public bool IsNoContact
		{
			get{return _isNoContact;}
			set
			{
				_isNoContact = value;

			}
		}
		
		private bool _isDontTryToLocate;
		public bool IsDontTryToLocate
		{
			get{return _isDontTryToLocate;}
			set
			{
				_isDontTryToLocate = value;

			}
		}
		
		private bool _isInvolveOtherProtected;
		public bool IsInvolveOtherProtected
		{
			get{return _isInvolveOtherProtected;}
			set
			{
				_isInvolveOtherProtected = value;

			}
		}
		
		private bool _isInvolveOther;
		public bool IsInvolveOther
		{
			get{return _isInvolveOther;}
			set
			{
				_isInvolveOther = value;

			}
		}
		
		private string _otherDescription;
		public string OtherDescription
		{
			get{return _otherDescription;}
			set
			{
				_otherDescription = value;

			}
		}
		
		private OrderRestrictionState _conductState;
		public OrderRestrictionState ConductState
		{
			get{return _conductState;}
			set
			{
				_conductState = value;

			}
		}
				
	}
	
			
	public partial class CH110RestrainedPersonPayment
	{
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private bool _isAttonrneyFees;
		public bool IsAttonrneyFees
		{
			get{return _isAttonrneyFees;}
			set
			{
				_isAttonrneyFees = value;

			}
		}
		
		private string _otherDescription;
		public string OtherDescription
		{
			get{return _otherDescription;}
			set
			{
				_otherDescription = value;

			}
		}
		
		private List<OtherProtected> _otherProtectedPersons;
		public List<OtherProtected> OtherProtectedPersons
		{
			get{return _otherProtectedPersons;}
			set
			{
				_otherProtectedPersons = value;

			}
		}
				
	}
	
			
	public partial class CH110StayAwayOrders
	{
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private bool _isStayAwayFromPerson;
		public bool IsStayAwayFromPerson
		{
			get{return _isStayAwayFromPerson;}
			set
			{
				_isStayAwayFromPerson = value;

			}
		}
		
		private bool _isStayAwayFromHome;
		public bool IsStayAwayFromHome
		{
			get{return _isStayAwayFromHome;}
			set
			{
				_isStayAwayFromHome = value;

			}
		}
		
		private bool _isStayAwayFromVehicle;
		public bool IsStayAwayFromVehicle
		{
			get{return _isStayAwayFromVehicle;}
			set
			{
				_isStayAwayFromVehicle = value;

			}
		}
		
		private bool _isStayAwayFromChildCare;
		public bool IsStayAwayFromChildCare
		{
			get{return _isStayAwayFromChildCare;}
			set
			{
				_isStayAwayFromChildCare = value;

			}
		}
		
		private bool _isStayAwayFromChildSchool;
		public bool IsStayAwayFromChildSchool
		{
			get{return _isStayAwayFromChildSchool;}
			set
			{
				_isStayAwayFromChildSchool = value;

			}
		}
		
		private bool _isStayAwayFromWork;
		public bool IsStayAwayFromWork
		{
			get{return _isStayAwayFromWork;}
			set
			{
				_isStayAwayFromWork = value;

			}
		}
		
		private bool _isStayAwayFromOtherProtected;
		public bool IsStayAwayFromOtherProtected
		{
			get{return _isStayAwayFromOtherProtected;}
			set
			{
				_isStayAwayFromOtherProtected = value;

			}
		}
		
		private bool _isStayAwayFromOther;
		public bool IsStayAwayFromOther
		{
			get{return _isStayAwayFromOther;}
			set
			{
				_isStayAwayFromOther = value;

			}
		}
		
		private bool _isAttachOther;
		public bool IsAttachOther
		{
			get{return _isAttachOther;}
			set
			{
				_isAttachOther = value;

			}
		}
		
		private string _otherDescription;
		public string OtherDescription
		{
			get{return _otherDescription;}
			set
			{
				_otherDescription = value;

			}
		}
		
		private int _stayAwayDistance;
		public int StayAwayDistance
		{
			get{return _stayAwayDistance;}
			set
			{
				_stayAwayDistance = value;

			}
		}
		
		private OrderRestrictionState _stayAwayState;
		public OrderRestrictionState StayAwayState
		{
			get{return _stayAwayState;}
			set
			{
				_stayAwayState = value;

			}
		}
				
	}
	
			
	public partial class CH110
	{
		private long _caseHistoryId;
		public long CaseHistoryId
		{
			get{return _caseHistoryId;}
			set
			{
				_caseHistoryId = value;

			}
		}
		
		private CH110ConductChoice _conductSection;
		public CH110ConductChoice ConductSection
		{
			get{return _conductSection;}
			set
			{
				_conductSection = value;

			}
		}
		
		private CH110StayAwayOrders _stayAwayOrdersSection;
		public CH110StayAwayOrders StayAwayOrdersSection
		{
			get{return _stayAwayOrdersSection;}
			set
			{
				_stayAwayOrdersSection = value;

			}
		}
		
		private bool _isNoGuns;
		public bool IsNoGuns
		{
			get{return _isNoGuns;}
			set
			{
				_isNoGuns = value;

			}
		}
		
		private CAPROSEntry _cAPROSEntrySection;
		public CAPROSEntry CAPROSEntrySection
		{
			get{return _cAPROSEntrySection;}
			set
			{
				_cAPROSEntrySection = value;

			}
		}
		
		private NoServiceFee _noServiceFeeSection;
		public NoServiceFee NoServiceFeeSection
		{
			get{return _noServiceFeeSection;}
			set
			{
				_noServiceFeeSection = value;

			}
		}
		
		private DateTime _ordersEndDate;
		public DateTime OrdersEndDate
		{
			get{return _ordersEndDate;}
			set
			{
				_ordersEndDate = value;

			}
		}
		
		private DateTime? _ordersEndTime;
		public DateTime? OrdersEndTime
		{
			get{return _ordersEndTime;}
			set
			{
				_ordersEndTime = value;

			}
		}
		
		private bool _isOtherOrdersAttached;
		public bool IsOtherOrdersAttached
		{
			get{return _isOtherOrdersAttached;}
			set
			{
				_isOtherOrdersAttached = value;

			}
		}
		
		private string _otherOrderDetail;
		public string OtherOrderDetail
		{
			get{return _otherOrderDetail;}
			set
			{
				_otherOrderDetail = value;

			}
		}
				
	}
	
			
	public partial class DV130ConductChoice
	{
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private bool _isNoAbuse;
		public bool IsNoAbuse
		{
			get{return _isNoAbuse;}
			set
			{
				_isNoAbuse = value;

			}
		}
		
		private bool _isNoContact;
		public bool IsNoContact
		{
			get{return _isNoContact;}
			set
			{
				_isNoContact = value;

			}
		}
		
		private bool _isDontTryToLocate;
		public bool IsDontTryToLocate
		{
			get{return _isDontTryToLocate;}
			set
			{
				_isDontTryToLocate = value;

			}
		}
		
		private bool _isExceptionsExist;
		public bool IsExceptionsExist
		{
			get{return _isExceptionsExist;}
			set
			{
				_isExceptionsExist = value;

			}
		}
				
	}
	
			
	public partial class DV130StayAwayOrders
	{
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private bool _isStayAwayFromPerson;
		public bool IsStayAwayFromPerson
		{
			get{return _isStayAwayFromPerson;}
			set
			{
				_isStayAwayFromPerson = value;

			}
		}
		
		private bool _isStayAwayFromHome;
		public bool IsStayAwayFromHome
		{
			get{return _isStayAwayFromHome;}
			set
			{
				_isStayAwayFromHome = value;

			}
		}
		
		private bool _isStayAwayFromVehicle;
		public bool IsStayAwayFromVehicle
		{
			get{return _isStayAwayFromVehicle;}
			set
			{
				_isStayAwayFromVehicle = value;

			}
		}
		
		private bool _isStayAwayFromChildCareOrSchool;
		public bool IsStayAwayFromChildCareOrSchool
		{
			get{return _isStayAwayFromChildCareOrSchool;}
			set
			{
				_isStayAwayFromChildCareOrSchool = value;

			}
		}
		
		private bool _isStayAwayFromPersonSchool;
		public bool IsStayAwayFromPersonSchool
		{
			get{return _isStayAwayFromPersonSchool;}
			set
			{
				_isStayAwayFromPersonSchool = value;

			}
		}
		
		private bool _isStayAwayFromWork;
		public bool IsStayAwayFromWork
		{
			get{return _isStayAwayFromWork;}
			set
			{
				_isStayAwayFromWork = value;

			}
		}
		
		private bool _isStayAwayFromOtherProtected;
		public bool IsStayAwayFromOtherProtected
		{
			get{return _isStayAwayFromOtherProtected;}
			set
			{
				_isStayAwayFromOtherProtected = value;

			}
		}
		
		private bool _isStayAwayFromOther;
		public bool IsStayAwayFromOther
		{
			get{return _isStayAwayFromOther;}
			set
			{
				_isStayAwayFromOther = value;

			}
		}
		
		private bool _isAttachOther;
		public bool IsAttachOther
		{
			get{return _isAttachOther;}
			set
			{
				_isAttachOther = value;

			}
		}
		
		private string _otherDescription;
		public string OtherDescription
		{
			get{return _otherDescription;}
			set
			{
				_otherDescription = value;

			}
		}
		
		private int _stayAwayDistance;
		public int StayAwayDistance
		{
			get{return _stayAwayDistance;}
			set
			{
				_stayAwayDistance = value;

			}
		}
				
	}
	
			
	public partial class DV130Moveout
	{
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private string _moveoutAddress;
		public string MoveoutAddress
		{
			get{return _moveoutAddress;}
			set
			{
				_moveoutAddress = value;

			}
		}
				
	}
	
			
	public partial class DV130Animals
	{
		private bool _isEnabled;
		public bool IsEnabled
		{
			get{return _isEnabled;}
			set
			{
				_isEnabled = value;

			}
		}
		
		private int _stayAwayAnimalsDistance;
		public int StayAwayAnimalsDistance
		{
			get{return _stayAwayAnimalsDistance;}
			set
			{
				_stayAwayAnimalsDistance = value;

			}
		}
		
		private string _animalsDescription;
		public string AnimalsDescription
		{
			get{return _animalsDescription;}
			set
			{
				_animalsDescription = value;

			}
		}
				
	}
	
			
	public partial class DV130
	{
		private DV130ConductChoice _dV130ConductChoiceSection;
		public DV130ConductChoice DV130ConductChoiceSection
		{
			get{return _dV130ConductChoiceSection;}
			set
			{
				_dV130ConductChoiceSection = value;

			}
		}
		
		private DV130StayAwayOrders _dV130StayAwayOrdersSection;
		public DV130StayAwayOrders DV130StayAwayOrdersSection
		{
			get{return _dV130StayAwayOrdersSection;}
			set
			{
				_dV130StayAwayOrdersSection = value;

			}
		}
		
		private DV130Moveout _dV130MoveoutSection;
		public DV130Moveout DV130MoveoutSection
		{
			get{return _dV130MoveoutSection;}
			set
			{
				_dV130MoveoutSection = value;

			}
		}
		
		private bool _isRecordUnlawfulCommunicationsAllowed;
		public bool IsRecordUnlawfulCommunicationsAllowed
		{
			get{return _isRecordUnlawfulCommunicationsAllowed;}
			set
			{
				_isRecordUnlawfulCommunicationsAllowed = value;

			}
		}
		
		private DV130Animals _dV130AnimalsSection;
		public DV130Animals DV130AnimalsSection
		{
			get{return _dV130AnimalsSection;}
			set
			{
				_dV130AnimalsSection = value;

			}
		}
		
		private bool _isBattererIntervention;
		public bool IsBattererIntervention
		{
			get{return _isBattererIntervention;}
			set
			{
				_isBattererIntervention = value;

			}
		}
		
		private bool _isNoGuns;
		public bool IsNoGuns
		{
			get{return _isNoGuns;}
			set
			{
				_isNoGuns = value;

			}
		}
				
	}
	
}

