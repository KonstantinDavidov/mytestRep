

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
	
			
	public partial class CH130LawyerFeesAndCostsSection
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
		
		private bool _noAbuse;
		public bool NoAbuse
		{
			get{return _noAbuse;}
			set
			{
				_noAbuse = value;

			}
		}
		
		private bool _noContact;
		public bool NoContact
		{
			get{return _noContact;}
			set
			{
				_noContact = value;

			}
		}
		
		private bool _dontTryToLocate;
		public bool DontTryToLocate
		{
			get{return _dontTryToLocate;}
			set
			{
				_dontTryToLocate = value;

			}
		}
		
		private bool _coversOtherProtectedPerson;
		public bool CoversOtherProtectedPerson
		{
			get{return _coversOtherProtectedPerson;}
			set
			{
				_coversOtherProtectedPerson = value;

			}
		}
		
		private bool _other;
		public bool Other
		{
			get{return _other;}
			set
			{
				_other = value;

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
		
		private ServiceReqState _service;
		public ServiceReqState Service
		{
			get{return _service;}
			set
			{
				_service = value;

			}
		}
		
		private OrderItemState _conductState;
		public OrderItemState ConductState
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
		
		private OrderItemState _stayAwayState;
		public OrderItemState StayAwayState
		{
			get{return _stayAwayState;}
			set
			{
				_stayAwayState = value;

			}
		}
		
		private bool _person;
		public bool Person
		{
			get{return _person;}
			set
			{
				_person = value;

			}
		}
		
		private bool _home;
		public bool Home
		{
			get{return _home;}
			set
			{
				_home = value;

			}
		}
		
		private bool _vehicle;
		public bool Vehicle
		{
			get{return _vehicle;}
			set
			{
				_vehicle = value;

			}
		}
		
		private bool _childCare;
		public bool ChildCare
		{
			get{return _childCare;}
			set
			{
				_childCare = value;

			}
		}
		
		private bool _work;
		public bool Work
		{
			get{return _work;}
			set
			{
				_work = value;

			}
		}
		
		private bool _otherProtected;
		public bool OtherProtected
		{
			get{return _otherProtected;}
			set
			{
				_otherProtected = value;

			}
		}
		
		private bool _other;
		public bool Other
		{
			get{return _other;}
			set
			{
				_other = value;

			}
		}
		
		private bool _isAttach;
		public bool IsAttach
		{
			get{return _isAttach;}
			set
			{
				_isAttach = value;

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
	
}

