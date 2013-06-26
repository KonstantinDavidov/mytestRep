

using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    
			
	public partial class NewCourtCaseDialogViewModel
	{
		private string _caseNumber;
		public string CaseNumber
		{
			get{return _caseNumber;}
			set{
				if(_caseNumber!=value){
					this.RaiseAndSetIfChanged(ref _caseNumber, value);
				}
			}
		}
		
		private bool _isEditing;
		public bool IsEditing
		{
			get{return _isEditing;}
			set{
				if(_isEditing!=value){
					this.RaiseAndSetIfChanged(ref _isEditing, value);
				}
			}
		}
				
	}
	
			
	public partial class AddToCourtDocketDialogViewModel
	{
		private string _caseNumber;
		public string CaseNumber
		{
			get{return _caseNumber;}
			set{
				if(_caseNumber!=value){
					this.RaiseAndSetIfChanged(ref _caseNumber, value);
				}
			}
		}
		
		private DateTime _time;
		public DateTime Time
		{
			get{return _time;}
			set{
				if(_time!=value){
					this.RaiseAndSetIfChanged(ref _time, value);
				}
			}
		}
		
		private Faccts.Model.Entities.Courtrooms _courtroom;
		public Faccts.Model.Entities.Courtrooms Courtroom
		{
			get{return _courtroom;}
			set{
				if(_courtroom!=value){
					this.RaiseAndSetIfChanged(ref _courtroom, value);
				}
			}
		}
		
		private Faccts.Model.Entities.CourtDepartmenets _department;
		public Faccts.Model.Entities.CourtDepartmenets Department
		{
			get{return _department;}
			set{
				if(_department!=value){
					this.RaiseAndSetIfChanged(ref _department, value);
				}
			}
		}
		
		private bool _isPermanentRO;
		public bool IsPermanentRO
		{
			get{return _isPermanentRO;}
			set{
				if(_isPermanentRO!=value){
					this.RaiseAndSetIfChanged(ref _isPermanentRO, value);
				}
			}
		}
		
		private bool _isCCorCV;
		public bool IsCCorCV
		{
			get{return _isCCorCV;}
			set{
				if(_isCCorCV!=value){
					this.RaiseAndSetIfChanged(ref _isCCorCV, value);
				}
			}
		}
		
		private bool _isSS;
		public bool IsSS
		{
			get{return _isSS;}
			set{
				if(_isSS!=value){
					this.RaiseAndSetIfChanged(ref _isSS, value);
				}
			}
		}
		
		private bool _isCS;
		public bool IsCS
		{
			get{return _isCS;}
			set{
				if(_isCS!=value){
					this.RaiseAndSetIfChanged(ref _isCS, value);
				}
			}
		}
		
		private bool _isOtherHearingIssue;
		public bool IsOtherHearingIssue
		{
			get{return _isOtherHearingIssue;}
			set{
				if(_isOtherHearingIssue!=value){
					this.RaiseAndSetIfChanged(ref _isOtherHearingIssue, value);
				}
			}
		}
		
		private string _otherHearingIssueText;
		public string OtherHearingIssueText
		{
			get{return _otherHearingIssueText;}
			set{
				if(_otherHearingIssueText!=value){
					this.RaiseAndSetIfChanged(ref _otherHearingIssueText, value);
				}
			}
		}
		
		private ObservableCollection<Faccts.Model.Entities.Courtrooms> _courtrooms;
		public ObservableCollection<Faccts.Model.Entities.Courtrooms> Courtrooms
		{
			get{return _courtrooms;}
			set{
				if(_courtrooms!=value){
					this.RaiseAndSetIfChanged(ref _courtrooms, value);
				}
			}
		}
		
		private ObservableCollection<Faccts.Model.Entities.CourtDepartmenets> _departments;
		public ObservableCollection<Faccts.Model.Entities.CourtDepartmenets> Departments
		{
			get{return _departments;}
			set{
				if(_departments!=value){
					this.RaiseAndSetIfChanged(ref _departments, value);
				}
			}
		}
				
	}
	
			
	public partial class RelatedCasesViewModel
	{
		private bool _canConsolidate;
		public bool CanConsolidate
		{
			get{return _canConsolidate;}
			set{
				if(_canConsolidate!=value){
					this.RaiseAndSetIfChanged(ref _canConsolidate, value);
				}
			}
		}
		
		private bool _canSeparate;
		public bool CanSeparate
		{
			get{return _canSeparate;}
			set{
				if(_canSeparate!=value){
					this.RaiseAndSetIfChanged(ref _canSeparate, value);
				}
			}
		}
				
	}
	
			
	public partial class SeparateCaseDialogViewModel
	{
		private string _caseNumber;
		public string CaseNumber
		{
			get{return _caseNumber;}
			set{
				if(_caseNumber!=value){
					this.RaiseAndSetIfChanged(ref _caseNumber, value);
				}
			}
		}
		
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
				
	}
	
			
	public partial class DropDismissDialogViewModel
	{
		private string _caseNumber;
		public string CaseNumber
		{
			get{return _caseNumber;}
			set{
				if(_caseNumber!=value){
					this.RaiseAndSetIfChanged(ref _caseNumber, value);
				}
			}
		}
		
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
		
		private bool _dismiss;
		public bool Dismiss
		{
			get{return _dismiss;}
			set{
				if(_dismiss!=value){
					this.RaiseAndSetIfChanged(ref _dismiss, value);
				}
			}
		}
				
	}
	
			
	public partial class CourtDocketViewModel
	{
		private bool _canDropDismiss;
		public bool CanDropDismiss
		{
			get{return _canDropDismiss;}
			set{
				if(_canDropDismiss!=value){
					this.RaiseAndSetIfChanged(ref _canDropDismiss, value);
				}
			}
		}
		
		private bool _canReissue;
		public bool CanReissue
		{
			get{return _canReissue;}
			set{
				if(_canReissue!=value){
					this.RaiseAndSetIfChanged(ref _canReissue, value);
				}
			}
		}
		
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
		
		private DateTime? _calendarDate;
		public DateTime? CalendarDate
		{
			get{return _calendarDate;}
			set{
				if(_calendarDate!=value){
					this.RaiseAndSetIfChanged(ref _calendarDate, value);
				}
			}
		}
				
	}
	
			
	public partial class ReissueCaseDialogViewModel
	{
		private string _caseNumber;
		public string CaseNumber
		{
			get{return _caseNumber;}
			set{
				if(_caseNumber!=value){
					this.RaiseAndSetIfChanged(ref _caseNumber, value);
				}
			}
		}
		
		private DateTime? _newCourtDate;
		public DateTime? NewCourtDate
		{
			get{return _newCourtDate;}
			set{
				if(_newCourtDate!=value){
					this.RaiseAndSetIfChanged(ref _newCourtDate, value);
				}
			}
		}
		
		private DateTime _time;
		public DateTime Time
		{
			get{return _time;}
			set{
				if(_time!=value){
					this.RaiseAndSetIfChanged(ref _time, value);
				}
			}
		}
		
		private Faccts.Model.Entities.Courtrooms _courtroom;
		public Faccts.Model.Entities.Courtrooms Courtroom
		{
			get{return _courtroom;}
			set{
				if(_courtroom!=value){
					this.RaiseAndSetIfChanged(ref _courtroom, value);
				}
			}
		}
		
		private Faccts.Model.Entities.CourtDepartmenets _department;
		public Faccts.Model.Entities.CourtDepartmenets Department
		{
			get{return _department;}
			set{
				if(_department!=value){
					this.RaiseAndSetIfChanged(ref _department, value);
				}
			}
		}
		
		private bool _noPOS;
		public bool NoPOS
		{
			get{return _noPOS;}
			set{
				if(_noPOS!=value){
					this.RaiseAndSetIfChanged(ref _noPOS, value);
				}
			}
		}
		
		private bool _fCSReferral;
		public bool FCSReferral
		{
			get{return _fCSReferral;}
			set{
				if(_fCSReferral!=value){
					this.RaiseAndSetIfChanged(ref _fCSReferral, value);
				}
			}
		}
		
		private bool _getAttyToPrepare;
		public bool GetAttyToPrepare
		{
			get{return _getAttyToPrepare;}
			set{
				if(_getAttyToPrepare!=value){
					this.RaiseAndSetIfChanged(ref _getAttyToPrepare, value);
				}
			}
		}
		
		private bool _isOtherReason;
		public bool IsOtherReason
		{
			get{return _isOtherReason;}
			set{
				if(_isOtherReason!=value){
					this.RaiseAndSetIfChanged(ref _isOtherReason, value);
				}
			}
		}
		
		private string _otherReason;
		public string OtherReason
		{
			get{return _otherReason;}
			set{
				if(_otherReason!=value){
					this.RaiseAndSetIfChanged(ref _otherReason, value);
				}
			}
		}
		
		private int _reissuanceAfterDays;
		public int ReissuanceAfterDays
		{
			get{return _reissuanceAfterDays;}
			set{
				if(_reissuanceAfterDays!=value){
					this.RaiseAndSetIfChanged(ref _reissuanceAfterDays, value);
				}
			}
		}
		
		private int _paperworkOnDays;
		public int PaperworkOnDays
		{
			get{return _paperworkOnDays;}
			set{
				if(_paperworkOnDays!=value){
					this.RaiseAndSetIfChanged(ref _paperworkOnDays, value);
				}
			}
		}
		
		private bool _noServiceRequired;
		public bool NoServiceRequired
		{
			get{return _noServiceRequired;}
			set{
				if(_noServiceRequired!=value){
					this.RaiseAndSetIfChanged(ref _noServiceRequired, value);
				}
			}
		}
		
		private bool _reissuanceOnSomeDaysBeforeHearing;
		public bool ReissuanceOnSomeDaysBeforeHearing
		{
			get{return _reissuanceOnSomeDaysBeforeHearing;}
			set{
				if(_reissuanceOnSomeDaysBeforeHearing!=value){
					this.RaiseAndSetIfChanged(ref _reissuanceOnSomeDaysBeforeHearing, value);
				}
			}
		}
		
		private bool _allPaperworksOnSomeDaysBeforeHearing;
		public bool AllPaperworksOnSomeDaysBeforeHearing
		{
			get{return _allPaperworksOnSomeDaysBeforeHearing;}
			set{
				if(_allPaperworksOnSomeDaysBeforeHearing!=value){
					this.RaiseAndSetIfChanged(ref _allPaperworksOnSomeDaysBeforeHearing, value);
				}
			}
		}
		
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
		
		private ObservableCollection<Faccts.Model.Entities.Courtrooms> _courtrooms;
		public ObservableCollection<Faccts.Model.Entities.Courtrooms> Courtrooms
		{
			get{return _courtrooms;}
			set{
				if(_courtrooms!=value){
					this.RaiseAndSetIfChanged(ref _courtrooms, value);
				}
			}
		}
		
		private ObservableCollection<Faccts.Model.Entities.CourtDepartmenets> _departments;
		public ObservableCollection<Faccts.Model.Entities.CourtDepartmenets> Departments
		{
			get{return _departments;}
			set{
				if(_departments!=value){
					this.RaiseAndSetIfChanged(ref _departments, value);
				}
			}
		}
				
	}
	
			
	public partial class PersonalInformationViewModel
	{
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
				
	}
	
			
	public partial class AttorneysViewModel
	{
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
		
		private bool _attorneyForChildrenIsTheSameThenParty1;
		public bool AttorneyForChildrenIsTheSameThenParty1
		{
			get{return _attorneyForChildrenIsTheSameThenParty1;}
			set{
				if(_attorneyForChildrenIsTheSameThenParty1!=value){
					this.RaiseAndSetIfChanged(ref _attorneyForChildrenIsTheSameThenParty1, value);
				}
			}
		}
		
		private bool _attorneyForChildrenIsTheSameThenParty2;
		public bool AttorneyForChildrenIsTheSameThenParty2
		{
			get{return _attorneyForChildrenIsTheSameThenParty2;}
			set{
				if(_attorneyForChildrenIsTheSameThenParty2!=value){
					this.RaiseAndSetIfChanged(ref _attorneyForChildrenIsTheSameThenParty2, value);
				}
			}
		}
				
	}
	
			
	public partial class ChildrenOtherProtectedViewModel
	{
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
				
	}
	
			
	public partial class WitnessInterpereterViewModel
	{
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
				
	}
	
			
	public partial class CaseNotesViewModel
	{
		private Faccts.Model.Entities.CourtCase _currentCourtCase;
		public Faccts.Model.Entities.CourtCase CurrentCourtCase
		{
			get{return _currentCourtCase;}
			set{
				if(_currentCourtCase!=value){
					this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
				}
			}
		}
				
	}
	
}

