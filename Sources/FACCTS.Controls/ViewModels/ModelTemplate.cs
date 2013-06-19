﻿

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
	
}

